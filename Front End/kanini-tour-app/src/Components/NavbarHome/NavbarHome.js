import './NavbarHome.css';
import { Navbar, Nav, NavDropdown } from "react-bootstrap";
import { useState,useEffect } from 'react';
import Login from '../Login/Login';
import UserRegister from '../UserRegister/UserRegister';
import AgentRegister from '../AgentRegister/AgentRegister';
import { useNavigate } from "react-router";

function NavbarHome() {
      const navigate = useNavigate();
       const isLoggedIn = localStorage.getItem('userId') && localStorage.getItem('token');

        // Login Popup 
        const [loginPopUp, setLoginPopUp] = useState(false);
        const handleLoginOpen = () => {
          setLoginPopUp(true);
        };
        const handleLoginClose = () => {
          setLoginPopUp(false);
        };

        //User register popup
        const [userPopUp, setUserPopUp] = useState(false);
        const handleUserPopupOpen = () => {
          setUserPopUp(true);
        };
        const handleUserPopupClose = () => {
          setUserPopUp(false);
        };

        //Tour Agent Register Popup
        const [agentPopup, setAgentPopup] = useState(false);
        const handleAgentPopupOpen = () => {
          setAgentPopup(true);
        };
        const handleAgentPopupClose = () => {
          setAgentPopup(false);
        };

        const logout=()=>{
          localStorage.clear();
          navigate('/');
        }



  return (
    <div className="vendorNavbar">
      <div className="navBar">
        <Navbar className="custom-navbar" expand="lg">
          <Navbar.Brand href="#">Book Your Hotel</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="ml-auto">

              <Nav.Link href="/#home">Home</Nav.Link>
              <Nav.Link href="/#places">Top Places</Nav.Link>
              <Nav.Link href="/#services">Services</Nav.Link>
              <Nav.Link href="/#contact">Contact</Nav.Link> 

              {isLoggedIn && (
                <Nav.Link onClick={logout}>Logout</Nav.Link> 
              )}

              {!isLoggedIn && (
                <Nav.Link onClick={handleLoginOpen}>Login</Nav.Link> 
              )}
              {loginPopUp && <Login closeLoginModal={handleLoginClose} />}


              {!isLoggedIn && (
                <Nav.Link onClick={handleUserPopupOpen}>Register</Nav.Link> 
              )}
              {userPopUp && <UserRegister closeUserModal={handleUserPopupClose} />}

              {!isLoggedIn && (
                <Nav.Link onClick={handleAgentPopupOpen}>Join with us !</Nav.Link> 
              )}
              {agentPopup && <AgentRegister closeAgentModal={handleAgentPopupClose}/> }  

            </Nav>
          </Navbar.Collapse>
        </Navbar>
      </div>
    </div>

  );
}

export default NavbarHome;
