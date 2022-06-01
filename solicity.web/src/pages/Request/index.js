import React, { Component } from "react";
import {
  Breadcrumb,
  Button,
  Card,
  Col,
  Container,
  Dropdown,
  FormControl,
  InputGroup,
  Row,
  Table,
  Toast,
} from "react-bootstrap";
import Badge from "react-bootstrap/Badge";

export default class Request extends Component {

  constructor(props) {
    super(props);

    this.state = {
      request: {
        id: 3141,
        title: "Exemplo de titulo de requisicao para squads"
      },
      
      comment_input: ""
    }
  }

  render() {
    return (
      <Container className="mt-3">
        <Row>
          <Col sm>
            <Breadcrumb>
              <Breadcrumb.Item href="#">Times</Breadcrumb.Item>
              <Breadcrumb.Item href="https://getbootstrap.com/docs/4.0/components/breadcrumb/">
                Velozes & Curiosos
              </Breadcrumb.Item>
              <Breadcrumb.Item>Demandas</Breadcrumb.Item>
              <Breadcrumb.Item active>#{this.state.request.id}</Breadcrumb.Item>
            </Breadcrumb>
          </Col>
        </Row>
        <Row>
          <Col sm={9}>
            <h2 className="medium">
              {this.state.request.title}
              <small className="text-muted"> #{this.state.request.id}</small>
            </h2>
          </Col>
          <Col sm className="d-flex flex-row-reverse ">
            <Dropdown className="align-self-center">
              <Dropdown.Toggle variant="success" id="dropdown-basic">
                Actions
              </Dropdown.Toggle>

              <Dropdown.Menu>
                <Dropdown.Item href="#/action-1">Adicionar card</Dropdown.Item>
                <Dropdown.Item href="#/action-2">Another action</Dropdown.Item>
                <Dropdown.Item href="#/action-3">Something else</Dropdown.Item>
              </Dropdown.Menu>
            </Dropdown>
          </Col>
        </Row>
        <Row>
          <Col sm={10}>
            <span className="lead fw-normal">
              <span className="badge badge-success large">Aberto</span>{" "}
              Wanderley Alisson abriu essa Solicitacao a 3 horas atrás
            </span>
          </Col>
        </Row>
        <Row>
          <Col sm>
            <hr className="mt-3 mb-4" />
          </Col>
        </Row>
        <Row>
          <Col sm={8}>
            <Card>
              <Card.Header>
                <a href="#">Wanderley</a>{" "}
                <span className="text-muted"> enviou a 3 horas atrás</span>
              </Card.Header>
              <Card.Body className="p-4">
                <div>
                  Lorem Ipsum is simply dummy text of the printing and
                  typesetting industry. Lorem Ipsum has been the industry's
                  standard dummy text ever since the 1500s, when an unknown
                  printer took a galley of type and scrambled it to make a type
                  specimen book. It has survived not only five centuries, but
                  also the leap into electronic typesetting, remaining
                  essentially unchanged. It was popularised in the 1960s with
                  the release of Letraset sheets containing Lorem Ipsum
                  passages, and more recently with desktop publishing software
                  like Aldus PageMaker including versions of Lorem Ipsum.
                </div>
              </Card.Body>
            </Card>

            <Card className="w-100 mt-3">
              <Card.Body className="p-2">
                <FormControl
                  className="mt-1"
                  as="textarea"
                  aria-label="With textarea"
                  placeholder="Escreva um comentario..."
                  value={this.state.comment_input}
                  onChange={(e) => this.setState({comment_input: e.target.value})}
                />
                <div className="d-flex flex-row-reverse mt-3">
                  <Button variant="success" size="sm" disabled={!this.state.comment_input != ""}>
                    Commentar
                  </Button>
                </div>
              </Card.Body>
            </Card>
          </Col>
          <Col className="pl-0">
            <Row>
              <Col sm>
                <Card className="w-100">
                  <Card.Body className="p-4">
                    <h5 className="card-title">Informacoes</h5>
                    <Row>
                      <Table hover size="sm">
                        <tbody>
                          <tr>
                            <td><strong>Projeto</strong></td>
                            <td>Tudo do Diario Oficial</td>
                          </tr>
                          <tr>
                            <td><strong>Prioridade</strong></td>
                            <td><Badge variant="warning">Muito Alta</Badge></td>
                          </tr>
                          <tr>
                            <td><strong>Solicitante</strong></td>
                            <td>Wanderley Alisson</td>
                          </tr>
                        </tbody>
                      </Table>
                    </Row>
                  </Card.Body>
                </Card>
              </Col>
            </Row>
            <Row className="mt-3">
              <Col sm>
                <Card className="w-100">
                  <Card.Body className="p-3">
                    <h5 className="card-title">Cartões Associados</h5>
                    <Toast>
                      <Toast.Header closeButton={false}>
                        <strong className="mr-auto">
                          <a href="#">#1241 </a>
                        </strong>
                        <small>11 mins ago</small>
                      </Toast.Header>
                      <Toast.Body>
                        Migracao de carteiras do ambiente de desenvolvimento
                        para o ambiente de producao
                      </Toast.Body>
                    </Toast>
                    <Toast>
                      <Toast.Header closeButton={false}>
                        <strong className="mr-auto">
                          <a href="#">#1241</a>
                        </strong>
                        <small>11 mins ago</small>
                      </Toast.Header>
                      <Toast.Body>
                        Migracao de carteiras do ambiente de desenvolvimento
                        para o ambiente de producao
                      </Toast.Body>
                    </Toast>
                  </Card.Body>
                </Card>
              </Col>
            </Row>
            <Row className="mt-3">
              <Col sm>
                <Card className="w-100">
                  <Card.Body className="p-4">
                    <h5 className="card-title">Projeto</h5>
                    <div>aaa</div>
                  </Card.Body>
                </Card>
              </Col>
            </Row>
            <Row className="mt-3">
              <Col sm>
                <Card className="w-100">
                  <Card.Body className="p-4">
                    <h5 className="card-title">Projeto</h5>
                    <div>aaa</div>
                  </Card.Body>
                </Card>
              </Col>
            </Row>
          </Col>
        </Row>
      </Container>
    );
  }
}
