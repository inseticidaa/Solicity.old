import React, { useEffect, useState } from "react";
import { Badge, Button, Card, Col, Container, Dropdown, Form, Row } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../components/AuthProvider";

export default function TeamsPage(props) {

    const navigate = useNavigate();
    let { user } = useAuth();

    const [page, setPage] = useState(0);
    const [teams, setTeams] = useState([]);

    useEffect(() => {
        getTeams()
    }, []);

    let getTeams = () => {

        let targetPage = page + 1;

        console.log("to aqui")
        fetch(`https://localhost:7264/api/Teams?page=${targetPage}&pageSize=10`, {
            method: 'GET',
            headers: new Headers({
                'Authorization': 'Bearer ' + user.token,
                "Content-Type": "application/json"
            })
        })
            .then(res => res.json())
            .then(list => {
                setPage(targetPage);
                let temp_teams = teams;
                temp_teams.push(...list);
                setTeams(temp_teams);
                console.log(teams);
            })
    }

    return (
        <Container>
            <Row>
                <Col className="p-0 mt-4">
                    <h3 className="medium">
                        Todos os Times
                        <small className="text-muted"> Publicos E Privados </small>
                    </h3>
                </Col>
            </Row>
            <Row>
                <Col>
                    <Row className="mt-2">
                        <Col className="p-0">
                            <Form.Group>
                                <Form.Control type="text" placeholder="Buscar Time" />
                            </Form.Group>
                        </Col>
                        <Col sm={4} className="d-flex flex-row-reverse p-0">
                            <Button variant="success" onClick={() => navigate("/teams/create")}>Novo Time</Button>
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
                </Col>
            </Row>

            <Row className="mt-3 mb-5 d-flex justify-content-md-center">

                {
                    teams.map((data, index) => {
                        return (<Card style={{ width: '18rem' }} className="m-3" key={index} onClick={() => navigate(`/teams/${data.id}`)}>
                            <Card.Img variant="top" src={`https://picsum.photos/${300 + index}/${200 + index}`} />
                            <Card.Header>
                                <span className="badge badge-info">Release 3</span>
                                <span className="badge badge-success ml-2">Sprint 21</span>
                            </Card.Header>
                            <Card.Body>
                                <Card.Title>{data.name}</Card.Title>
                                <Card.Text>
                                    {data.description}
                                </Card.Text>
                            </Card.Body>
                        </Card>)
                    })
                }
            </Row>
        </Container>
    )
}