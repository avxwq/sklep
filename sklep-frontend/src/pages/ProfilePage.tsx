import OrderHistory from "../components/OrderHistory";
import Profile from "../components/ProfileForm";
import "../styles/ProfilePage.css"; // Import stylów

export default function ProfilePage() {
    return (
        <div className="profile-page">
            <div className="profile-page-container">
                <Profile />
                <OrderHistory />
            </div>
        </div>
    );
}