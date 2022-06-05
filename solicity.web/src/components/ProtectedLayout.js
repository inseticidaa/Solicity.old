import { useEffect } from "react";
import { Container, Nav, Navbar } from "react-bootstrap";
import { Link, matchRoutes, Navigate, useLocation, useNavigate, useOutlet } from "react-router-dom";
import { useAuth } from "./AuthProvider";


export const ProtectedLayout = () => {
    const { user } = useAuth();
    const outlet = useOutlet();
    const navigate = useNavigate();
    const location = useLocation();
    const path = location.pathname

    console.log(user);
    if (!user) {
        return <Navigate to="/login" />;
    }

    console.log(path)

    return (
        <Container fluid className="m-0 p-0">
            <Navbar bg="dark" variant="dark">
                <Navbar.Brand href="#home">Solicity</Navbar.Brand>
                <Nav className="mr-auto">
                    <Nav.Link onClick={() => navigate("/")}>Home</Nav.Link>
                    <Nav.Link onClick={() => navigate("/teams/")}>Teams</Nav.Link>
                    <Nav.Link href="#pricing">Cards</Nav.Link>
                    {user.isAdmin && <Nav.Link href="#pricing">Create Team</Nav.Link>}
                </Nav>
            </Navbar>
            {outlet}
        </Container>
    );
};
