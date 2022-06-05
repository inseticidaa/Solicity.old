import React, { Component, useState } from "react";
import { Alert, Button, Col, Container, Form, Row } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../components/AuthProvider";

export default function CreateTeamPage() {

    let [teamName, setTeamName] = useState("");
    let [teamDescription, setTeamDescription] = useState("");
    let [isPublic, setIsPublic] = useState(true);
    let [alert, setAlert] = useState(null);
    const navigate = useNavigate();

    let { user } = useAuth();

    let handlerSubmit = () => {

        if (teamName === "") {
            setAlert({ message: "Voce precisa inserir um e-mail valido!", type: "warning" })
        }

        fetch('https://localhost:7264/api/Teams', {
            method: 'POST',
            headers: new Headers({
                'Authorization': 'Bearer ' + user.token,
                "Content-Type": "application/json"
            }),
            body: JSON.stringify({
                description: teamDescription,
                name: teamName,
                public: isPublic
            })
        })
            .then((res, err) => {
                if (err) return setAlert({ message: "Internal Server Error", type: "danger" });
                console.log(err);

                res.json()
                    .then((body, err) => {
                        if (err) return setAlert({ message: "Internal Server Error: Error on try parse json from request response", type: "danger" });
                        
                        switch (res.status) {
                            case 400:
                            case 401:
                              console.log(body)
                              setAlert({ message: body.message, type: "danger" })
                              break;
                            case 201:
                            case 200:
                              setAlert({ message: "Time criado", type: "success" })
                              navigate(`/teams/${body.teamId}`)
                              break;
                          };                        
                    })
            });
    }

    return (
        <Container>
            <Row className="justify-content-md-center mt-5">
                <Col md={7}>
                    {
                        alert &&
                        <Alert variant={alert.type}>
                            <Alert.Heading>{alert.title}</Alert.Heading>
                            {alert.message}
                        </Alert>
                    }
                </Col>
            </Row>
            <Row className="justify-content-md-center mt-2">
                <Col md={7}>
                    <h2>Criar novo time</h2>
                    <hr className="mt-4 mb-4" />
                    <Form>
                        <Form.Group>
                            <Form.Label>Nome do time (Campo Obrigatorio)</Form.Label>
                            <Form.Control type="text" as="input" value={teamName} onChange={(e) => setTeamName(e.target.value)} />
                            <Form.Text className="text-muted">
                                Os nomes de times são únicos mas podem ser alterados posteriormente.
                            </Form.Text>
                        </Form.Group>
                        <Form.Group className="mt-2">
                            <Form.Label>Descricao</Form.Label>
                            <Form.Control as="textarea" rows={5} value={teamDescription} onChange={(e) => setTeamDescription(e.target.value)} />
                            <Form.Text className="text-muted">
                                Os nomes de times são únicos mas podem ser alterados posteriormente.
                            </Form.Text>
                        </Form.Group>
                        <Form.Group className="mt-3">
                            <Form.Check
                                type="switch"
                                id="custom-switch"
                                label="Visibilidade Publica"
                                checked={isPublic}
                                onChange={() => setIsPublic(!isPublic)}
                            />
                            <Form.Text className="text-muted">
                                Times públicos são visíveis a todos os usuários da plataforma.
                            </Form.Text>
                        </Form.Group>
                        <Button variant="success" className="mt-3" size="md" onClick={handlerSubmit}>
                            Criar time
                        </Button>
                    </Form>
                </Col>
            </Row>
        </Container>
    );
}