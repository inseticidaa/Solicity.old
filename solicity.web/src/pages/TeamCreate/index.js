import React, { Component } from "react";
import { Button, Col, Container, Form, Row } from "react-bootstrap";
import Layout from "../../components/Layout";

export default class CreateTeam extends Component {

    constructor(props) {
        super(props);

        this.state = {
            teamName: "",
            teamDescription: "",
            isPublic: true
        }
    }

    render() {
        return (
            <Layout>
                <Row className="justify-content-md-center mt-5">
                    <Col md={5}></Col>
                </Row>
                <Row className="justify-content-md-center mt-2">
                    <Col md={5}>
                        <h2>Criar novo time</h2>
                        <hr className="mt-4 mb-4" />
                        <Form>
                            <Form.Group>
                                <Form.Label>Nome do time (Campo Obrigatorio)</Form.Label>
                                <Form.Control type="text" as="input" value={this.state.teamName} onChange={(e) => this.setState({teamName: e.target.value})}/>
                                <Form.Text className="text-muted">
                                    Os nomes de times são únicos mas podem ser alterados posteriormente.
                                </Form.Text>
                            </Form.Group>
                            <Form.Group className="mt-2">
                                <Form.Label>Descricao</Form.Label>
                                <Form.Control as="textarea" rows={5} value={this.state.teamDescription} onChange={(e) => this.setState({teamDescription: e.target.value})}/>
                                <Form.Text className="text-muted">
                                    Os nomes de times são únicos mas podem ser alterados posteriormente.
                                </Form.Text>
                            </Form.Group>
                            <Form.Group className="mt-3">
                                <Form.Check
                                    type="switch"
                                    id="custom-switch"
                                    label="Visibilidade Publica"
                                    checked={this.state.isPublic}
                                    onChange={() => this.setState({isPublic: !this.state.isPublic})}
                                />
                                <Form.Text className="text-muted">
                                    Times públicos são visíveis a todos os usuários da plataforma.
                                </Form.Text>
                            </Form.Group>
                            <Button variant="success" type="submit" className="mt-3" size="md">
                                Criar time
                            </Button>
                        </Form>
                    </Col>
                </Row>
            </Layout>
        );
    }
}