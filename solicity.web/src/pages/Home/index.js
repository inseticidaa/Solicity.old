import React from "react";
import { Card, Col, Container, Row } from "react-bootstrap";
import { useAuth } from "../../components/AuthProvider";

export default function HomePage(props) {
    let { user } = useAuth();

    return (
        <Container>
            <Row className="mt-3">
                <Col>
                    <Card text={'white'}>
                        <Card.Body>
                            <Card.Title>Atualizacoes</Card.Title>
                            <Row>
                            </Row>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </Container >
    )
}