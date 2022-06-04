import React, { Component } from "react";
import { Button, Col, Container, Dropdown, Form, Row, Table } from "react-bootstrap";
import Badge from "react-bootstrap/Badge";

export default class TeamRequests extends Component {

    constructor(props) {
        super(props);

        this.state = {
            requests: [
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
                {id: 1234, title: "Exemplo de titulo de requisicao para squads", },
            ]
        }
    }

    render() {
        return (
            <Container>
                <Row>
                    <Col>
                        <h4 className="medium">
                            Demandas da Squad
                            <small className="text-muted">  </small>
                        </h4>
                    </Col>
                </Row>
                <Row className="mt-2">
                    <Col className="p-0">
                        <Form.Group>
                            <Form.Control type="text" placeholder="Pesquisar Demanda" />
                        </Form.Group>
                    </Col>
                    <Col sm={4} className="d-flex flex-row-reverse p-0">
                        <Button variant="success">Nova Demanda</Button>
                        <Dropdown className="mr-2">
                            <Dropdown.Toggle variant="dark" id="dropdown-basic">
                                Tipo
                            </Dropdown.Toggle>

                            <Dropdown.Menu>
                                <Dropdown.Item href="#/action-1">Adicionar card</Dropdown.Item>
                                <Dropdown.Item href="#/action-2">Another action</Dropdown.Item>
                                <Dropdown.Item href="#/action-3">Something else</Dropdown.Item>
                            </Dropdown.Menu>
                        </Dropdown>
                        <Dropdown className="mr-2">
                            <Dropdown.Toggle variant="dark" id="dropdown-basic">
                                Ordenar
                            </Dropdown.Toggle>

                            <Dropdown.Menu>
                                <Dropdown.Item href="#/action-1">Adicionar card</Dropdown.Item>
                                <Dropdown.Item href="#/action-2">Another action</Dropdown.Item>
                                <Dropdown.Item href="#/action-3">Something else</Dropdown.Item>
                            </Dropdown.Menu>
                        </Dropdown>
                    </Col>
                </Row>
                <Row className="mt-3">
                    <Table striped bordered hover>
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Titulo</th>
                                <th>Projeto</th>
                                <th>Status</th>
                                <th>Tipo</th>
                                <th>Autor</th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.requests.map((req, index) => {
                                return (
                                    <tr key={index}>
                                        <td>#{req.id}</td>
                                        <td>{req.title}</td>
                                        <td>Tudo do Diario Oficial</td>
                                        <td><Badge variant="primary">Aberto</Badge></td>
                                        <td><Badge variant="danger">Muito Alta</Badge></td>
                                        <td>Wanderley Alisson</td>
                                    </tr>
                                )
                            })}

                        </tbody>
                    </Table>
                </Row>
            </Container>
        )
    }
}