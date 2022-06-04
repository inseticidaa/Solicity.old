import React, { Component } from "react";
import { Col, Container, Nav, Row } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../components/AuthProvider";
import Layout from "../../components/Layout";
import TeamDashboard from "./Dashboard";
import TeamRequests from "./Requests";

export default function TeamPage(props) {

    return (
        <Container>
            <Row>
                <Col className="mt-5">
                    <h2 className="medium">
                        Squad das Galaxias e dos Planetas
                        <small className="text-muted"> #213</small>
                    </h2>
                </Col>
            </Row>
            <Row >
                <Col className="mt-3">
                    <Nav variant="tabs" defaultActiveKey="/home">
                        <Nav.Item>
                            <Nav.Link>Dashboard</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link>Demandas</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link>Projetos</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link>Minhas Demandas</Nav.Link>
                        </Nav.Item>
                    </Nav>
                </Col>
            </Row>
            <Row className="mt-3">
                <TeamDashboard />
            </Row>
        </Container>
    );
}