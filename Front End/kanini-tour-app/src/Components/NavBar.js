import React, { Fragment } from "react";
import { Link } from "react-router-dom";
import { Button } from "react-bootstrap";
import '../Components/NavBar.css';


const NavbarPage = () => {
  const guestLinks = (
    <ul>
      <li>
        <Link to="/">
          <Button className="btn btn-primary createNew">Create New</Button>
        </Link>
      </li>
      <li>
        <Link to="/about">
          <Button className="btn btn-danger signOut">Sign out</Button>
        </Link>
      </li>
    </ul>
  );

  return (
    <nav className="navbar bg-white">
      <h3 className="titleName">
        <Link to="/">
          <i className="fas fa-pen" /> demo
        </Link>
      </h3>
      {guestLinks}
    </nav>
  );
};

export default NavbarPage;