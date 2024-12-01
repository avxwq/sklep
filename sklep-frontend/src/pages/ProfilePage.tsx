import OrderHistory from "../components/OrderHistory";
<<<<<<< HEAD
import ProfileC from "../components/ProfileC";
=======
import Profile from "../components/ProfileForm";
import "../styles/ProfilePage.css"; // Import stylów
>>>>>>> c909233fe49b97b3bd22dd415995ecce0cbc788b

export default function ProfilePage() {
    return (
<<<<<<< HEAD
        <>
        <ProfileC />
        <OrderHistory />
        </>
=======
        <div className="profile-page">
            <div className="profile-page-container">
                <Profile />
                <OrderHistory />
            </div>
        </div>
>>>>>>> c909233fe49b97b3bd22dd415995ecce0cbc788b
    );
}