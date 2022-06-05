import React, { useEffect, useState } from "react";
import { Form, Button, Card, Row, Col, Container, Spinner, Alert } from 'react-bootstrap';
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../components/AuthProvider";

export default function LoginPage() {

    let [email, setEmail] = useState("");
    let [emailIsValid, setemailIsValid] = useState(true);
    let [password, setPassword] = useState("");
    let [passwordIsValid, setPasswordIsValid] = useState(true);

    let [loading, setLoading] = useState(false);
    let [alert, setAlert] = useState(null)
    let { user, signin } = useAuth();
    const navigate = useNavigate();

    let handleSubmit = () => {

        let isEmail = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/.test(email);
        if (!isEmail) {
            setAlert({ message: "Voce precisa inserir um e-mail valido!", type: "warning" })
            setemailIsValid(false);
            setPasswordIsValid(true);
            return;
        }
        else {
            setemailIsValid(true);
        }

        let isPassword = password !== ""
        if (!isPassword) {
            setAlert({ message: "Voce precisa preencher sua senha!", type: "warning" })
            setPasswordIsValid(false);
            return;
        }
        else {
            setPasswordIsValid(true);
        }

        setAlert(null);
        setLoading(true);

        signin(email, password, (err) => {
            if (err) {
                setAlert(err);
                setLoading(false);
                return;
            }

            setAlert({ message: `Autorizado!`, type: "success" });
            navigate('/');
        });
    };

    const handleKeyDown = (event) => {
        if (event.key === 'Enter') {
            handleSubmit();
        }
    }

    useEffect(() => {
        if (user) {
            navigate('/');
        }
    })


    return (
        <Container className="vh-100 d-flex align-items-sm-center">
            <Row className="w-100 justify-content-sm-center">
                <Col md="5">
                    {
                        alert &&
                        <Alert variant={alert.type}>
                            <Alert.Heading>{alert.title}</Alert.Heading>
                            {alert.message}
                        </Alert>
                    }
                    <Card>
                        <Card.Body className="p-4">
                            <Card.Title>
                                <h1>Login</h1>
                            </Card.Title>
                            <Form>
                                <Form.Group controlId="formBasicEmail">
                                    <Form.Label>E-Mail</Form.Label>
                                    <Form.Control type="email"
                                        placeholder="Insira seu e-mail"
                                        isInvalid={!emailIsValid}
                                        value={email}
                                        onChange={(e) => setEmail(e.target.value)}
                                        onKeyDown={handleKeyDown} />
                                    <Form.Text className="text-muted">
                                        Insira um e-mail de uma conta cadastrada.
                                    </Form.Text>
                                </Form.Group>

                                <Form.Group className="mt-3">
                                    <Form.Label>Senha</Form.Label>
                                    <Form.Control type="password"
                                        placeholder="Insira sua senha"
                                        isInvalid={!passwordIsValid}
                                        value={password}
                                        onChange={(e) => setPassword(e.target.value)}
                                        onKeyDown={handleKeyDown} />
                                </Form.Group>
                                <Form.Group className="mt-3">
                                    <Form.Check type="checkbox" label="Continuar logado (nao esta funcionando)" />
                                </Form.Group>
                                <Button variant="success" className="mt-3" onClick={handleSubmit} disabled={loading}>
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
                                    Entrar
                                </Button>
                            </Form>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </Container>
    )
}