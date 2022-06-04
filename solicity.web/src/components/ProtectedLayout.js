import { Container, Nav, Navbar } from "react-bootstrap";
import { Link, Navigate, useNavigate, useOutlet } from "react-router-dom";
import { useAuth } from "./AuthProvider";

export const ProtectedLayout = () => {
    const { user } = useAuth();
    const outlet = useOutlet();
    const navigate = useNavigate();

    if (!user) {
        navigate("/login")
    }

    return (
        <Container fluid className="m-0 p-0">
            <Navbar bg="dark" variant="dark">
                <Navbar.Brand href="#home">Solicity</Navbar.Brand>
                <Nav className="mr-auto">
                    <Nav.Link href="#home">Home</Nav.Link>
                    <Nav.Link href="#features">Teams</Nav.Link>
                    <Nav.Link href="#pricing">Cards</Nav.Link>
                    
                </Nav>
            </Navbar>
            {outlet}
        </Container>
    );
};
