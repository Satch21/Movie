import React from 'react';
import { Card, Row, Col } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const Home: React.FC = () => {
    return (
        <>
            <div className='mt-3'>
                <Row>
                    <Col>
                        <Card border='success'>
                            <Card.Header>Films</Card.Header>
                            <Card.Body>
                                <Card.Title>
                                    <Link to="/films/*">Liste des films</Link>
                                </Card.Title>
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>
            </div>
        </>
    );
}

export default Home;