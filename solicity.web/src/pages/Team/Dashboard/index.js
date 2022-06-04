import React, { Component } from "react";
import { Card, Col, Container, Row } from "react-bootstrap";

export default class TeamDashboard extends Component {
    render() {
        return (
            <Container>
                <Row>
                    <Col className="d-flex">
                        <Card
                            bg={"dark"}
                            text={"light"}
                            style={{ width: '18rem' }}
                            className="mb-3"
                        >
                            <Card.Body>
                                <Card.Title>52304 </Card.Title>
                                <Card.Text>
                                    Demandas em aberto.
                                </Card.Text>
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>
                <Row>
                    <Col sm={4}>
                        <Card className="p-3">
                            <h4>Ultimas Demandas</h4>
                        </Card>
                    </Col>
                    <Col>
                        <Card>
                            aaa
                        </Card>
                    </Col>
                </Row>
            </Container>
        )
    }
}