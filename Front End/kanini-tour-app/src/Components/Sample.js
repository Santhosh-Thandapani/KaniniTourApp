import './Sample.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Navbar, Nav, NavDropdown } from "react-bootstrap";
import { Carousel } from 'react-bootstrap';

function Sample() {
  return (
    <div className="vendorNavbar">
      <div className="navBar">
        <Navbar className="custom-navbar" expand="lg">
          <Navbar.Brand href="#">Book Your Hotel</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="ml-auto">
              <Nav.Link href="#home">Home</Nav.Link>
              <Nav.Link href="#services">Hotels</Nav.Link>
              <Nav.Link href="#rooms">Rooms</Nav.Link> 
            </Nav>
          </Navbar.Collapse>
        </Navbar>
      </div>


{/* <header id="header" className="fied-top">
        <div className="container d-flex align-items-center">
    <a href="/" className="logo me-auto">
      <img src={logo} alt="Medico" />
    </a>
    <nav id="navbar" className="navbar order-last order-lg-0">
      <ul>
        <li>
          <a className="nav-link scrollto" href="#hero">
            Home
          </a>
        </li>
        <li>
          <a className="nav-link scrollto" href="#about">
            About
          </a>
        </li>
        <li>
          <a className="nav-link scrollto" href="#services">
            Services
          </a>
        </li>
        <li>
          <a className="nav-link scrollto" href="#contact">
            Contact
          </a>
        </li>

        &nbsp;&nbsp;&nbsp;&nbsp;
        {!isLoggedIn && (
          <li>
            <span onClick={handleLoginOpen}>Login</span>
          </li>
        )}
        {loginPopUp && <Login closeLoginModal={handleLoginClose} />}


        &nbsp;&nbsp;&nbsp;&nbsp;
        {!isLoggedIn && (
          <li>
            <span onClick={handleUserPopupOpen}>Register</span>
          </li>
        )}
        {userPopUp && <UserRegister closeLoginModal={handleUserPopupClose} />}


         &nbsp;&nbsp;&nbsp;&nbsp;
        {!isLoggedIn && (
          <li>
            <span onClick={handleAgentPopupOpen}>Joinwithus</span>
          </li>
        )}
        {agentPopup && <AgentRegister closeLoginModal={handleAgentPopupClose}/> }  


            

      </ul>
      <i className="bi bi-list mobile-nav-toggle"></i>
    </nav>
  </div>
</header> */}


        <div className='container-fluid' >
        <div className="row">
            <div className="col-12">
                <Carousel>

                    <Carousel.Item>
                        <img
                            className="d-block w-100"
                            src="https://picsum.photos/500/300?img=1"
                            alt="First slide"
                        />
                        <Carousel.Caption>
                            <h3>First slide label</h3>
                            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                        </Carousel.Caption>
                    </Carousel.Item>

                    <Carousel.Item>
                        <img
                            className="d-block w-100"
                            src="https://picsum.photos/500/300?img=2"
                            alt="Second slide"
                        />

                        <Carousel.Caption>
                            <h3>Second slide label</h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                        </Carousel.Caption>
                    </Carousel.Item>

                    <Carousel.Item>
                        <img
                            className="d-block w-100"
                            src="https://picsum.photos/500/300?img=3"
                            alt="Third slide"
                        />
                        <Carousel.Caption>
                            <h3>Third slide label</h3>
                            <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                </Carousel>
            </div>
        </div>
        </div>

    </div>
  );
}

export default Sample;













