using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using sklep.Models;
using sklep.Models.DTOs;
using sklep.Services;

namespace sklep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SklepContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly TokenService _tokenService;

        public UsersController(SklepContext context, TokenService tokenService, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            if (_context.Users.Any(u => u.Email == model.Email))
                return BadRequest("User already exists.");

            var user = new User
            {
                Username = model.Username,
                Email = model.Email
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Registration successful" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
                return Unauthorized("Invalid credentials.");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Invalid credentials.");

            var token = _tokenService.GenerateToken(user);

            return Ok(new { Token = token, UserId = user.Id });
        }

        [HttpPost("{userId}/addToCart")]
        public async Task<IActionResult> AddToCart(int userId, [FromBody] ProductDto productDto)
        {
            if (productDto == null || productDto.ProductId <= 0 || productDto.Quantity <= 0)
                return BadRequest("Invalid product or quantity.");

            var user = await _context.Users
                .Include(u => u.Cart)
                .ThenInclude(c => c.CartItems)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return NotFound("User not found.");

            if (user.Cart == null)
            {
                user.Cart = new Cart { UserId = userId };
                _context.Carts.Add(user.Cart);
            }

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productDto.ProductId);
            if (product == null)
                return NotFound("Product not found.");

            if (product.StockQuantity < productDto.Quantity)
                return BadRequest("Insufficient stock.");

            var cartItem = user.Cart.CartItems.FirstOrDefault(ci => ci.ProductId == productDto.ProductId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = user.Cart.Id,
                    ProductId = product.Id,
                    Quantity = productDto.Quantity
                };
                user.Cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += productDto.Quantity;
            }

            product.StockQuantity -= productDto.Quantity;

            await _context.SaveChangesAsync();

            return Ok("Item added to cart.");
        }

        [HttpGet("{userId}/cart")]
        public async Task<IActionResult> GetCart(int userId)
        {
            // Retrieve the user and include their cart with cart items and products
            var user = await _context.Users
                .Include(u => u.Cart)
                .ThenInclude(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return NotFound("User not found.");

            if (user.Cart == null || !user.Cart.CartItems.Any())
                return Ok(new { Message = "Cart is empty", CartItems = new List<object>() });

            // Map cart items to a DTO for the frontend
            var cartItems = user.Cart.CartItems.Select(ci => new
            {
                ProductId = ci.Product.Id,
                Name = ci.Product.Name,
                ImageUrl = ci.Product.ImageUrl,
                Price = ci.Product.Price,
                Quantity = ci.Quantity,
                TotalPrice = ci.Quantity * ci.Product.Price
            }).ToList();

            // Calculate total cart value
            var totalValue = cartItems.Sum(ci => ci.TotalPrice);

            return Ok(new
            {
                CartItems = cartItems,
                TotalValue = totalValue
            });
        }



        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
