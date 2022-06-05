import React, { Component, useState } from "react";
import { Alert, Button, Card, Col, Container, Form, Row, Spinner } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../../components/AuthProvider";

export default function CreateTeamPage() {

    let [teamName, setTeamName] = useState("");
    let [teamDescription, setTeamDescription] = useState("");
    let [isPublic, setIsPublic] = useState(true);
    let [dataUri, setDataUri] = useState('')


    let [alert, setAlert] = useState(null);
    let [loading, setLoading] = useState(false);
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
                public: isPublic,
                image: dataUri
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


    const fileToDataUri = (file) => new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.onload = (event) => {
            resolve(event.target.result)
        };
        reader.readAsDataURL(file);
    })

    const onChange = (file) => {

        if (!file) {
            setDataUri('');
            return;
        }

        fileToDataUri(file)
            .then(dataUri => {
                setDataUri(dataUri)
            })

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
                            <Form.Control as="textarea" rows={5} value={teamDescription} onChange={(e) => setTeamDescription(e.target.value)} isInvalid={teamDescription.length > 256} />
                            <Form.Text className="text-muted">
                                Os nomes de times são únicos mas podem ser alterados posteriormente. ({teamDescription.length}/256)
                            </Form.Text>
                        </Form.Group>
                        <Form.Group className="mt-3">
                            <Form.Label>Foto do time</Form.Label>
                            <input class="form-control p-1" type="file" accept="image/x-png,image/jpeg" onChange={(event) => onChange(event.target.files[0] || null)} />
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
                        <Button variant="success" className="mt-3" size="md" onClick={handlerSubmit} disabled={loading}>
                            {
                                loading && <Spinner
                                    as="span"
                                    animation="border"
                                    size="sm"
                                    role="status"
                                    aria-hidden="true"
                                    className="mr-2"
                                />
                            }
                            Criar time
                        </Button>
                    </Form>
                </Col>
                <Col className="d-flex justify-content-center align-items-center">
                    <Card style={{ width: '18rem' }} className="m-3">
                        <Card.Img variant="top" src={dataUri ? dataUri : "https://picsum.photos/300/200"} />
                        <Card.Body>
                            <Card.Title>{teamName ? teamName : "Nome do Time"}</Card.Title>
                            <Card.Text>
                                {teamDescription ? teamDescription : "Example team description"}
                            </Card.Text>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </Container>
    );
}