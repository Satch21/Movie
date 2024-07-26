import './App.css';
import Films from './pages/films/Films.tsx';
import Home from './pages/home/Home';
import {
    BrowserRouter ,
    Route,
    Link,
    Routes,
    
} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';
import { Navbar, Nav, NavDropdown } from "react-bootstrap";

const App: React.FC = () => {
    return (
        <BrowserRouter>
            <Navbar bg="light" expand="lg">
                <Navbar.Brand>
                    <h1 style={{ color: "green" }}>Movies</h1>
                </Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ml-auto">
                        <Nav.Link as={Link} to="/">
                            Home
                        </Nav.Link>
                        <Nav.Link as={Link} to="/film/*">
                            Liste des films
                        </Nav.Link>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path='/film/*' element={<Films />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;