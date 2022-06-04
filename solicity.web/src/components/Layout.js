import React from "react";
import { Button, Container, Form, FormControl, Nav, Navbar } from "react-bootstrap";
import { Link, Navigate, Outlet, useNavigate } from "react-router-dom";
import { useAuth } from "./AuthProvider";

export const Layout = () => {
    const { user } = useAuth();
    const navigate = useNavigate();

    if (user) {
        navigate("/")
    }

    return (
        <Container fluid className="m-0 p-0">
            <Navbar bg="dark" variant="dark">
                <Navbar.Brand href="#home">Solicity</Navbar.Brand>
                <Nav className="mr-auto">
                    <Nav.Link href="#home">Home</Nav.Link>
                    <Nav.Link href="#features">Teams</Nav.Link>
                    <Nav.Link href="#pricing">Cards</Nav.Link>
                    <Link to="/">Home</Link>
                    <Link to="/login">Login</Link>
                </Nav>
            </Navbar>
            <Outlet />
        </Container>
    )
};