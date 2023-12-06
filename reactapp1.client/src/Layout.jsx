import { Outlet } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import "./Layout.css"

export const Layout = () => {
    let navigate = useNavigate();

    return (
        <>
            <header>
                <img src="/src/assets/RomanPlumbing.png" />
                <nav>
                    <ul>
                        <li onClick={() => navigate("/")}><a>Home</a></li>
                        <li onClick={() => navigate("catalogue") }><a>Bathrooms</a></li>
                        <li><a href="/">My Order</a></li>
                        <li><a href="/">About Us</a></li>
                        <li><a href="/">Contact</a></li>
                    </ul>
                </nav>
            </header>

            <main>
                <Outlet />
            </main>
        </>
    )
};