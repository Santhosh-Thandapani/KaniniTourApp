import React, { useEffect, useState } from "react";
import about from '../Assets/logo.png'; 
import DoctorImage from '../Assets/logo.png';
import './AdminPage.css';
import { useNavigate } from "react-router";
import NavbarHome from "../NavbarHome/NavbarHome";

function AdminHome() {
  const [activeSection, setActiveSection] = useState('content');
  const [agents, setAgents] = useState([]);
  const [users, setUsers] = useState([]);
  const [notApprovedAgents, setNotApprovedAgents] = useState([]);
  const [navbarOpen, setNavbarOpen] = useState(false);
  const [filteredAgents,setFilteredAgents]=useState([]);

  const handleSectionClick = (section) => {
    setActiveSection(section);
    setNavbarOpen(false);
  };
  const navigate = useNavigate();
    
  var [searchName,setSearchName]=useState("");

  useEffect(() => {
    fetchApprovedAgents();
    fetchNotApprovedAgents();
    fetchAllUsers();
  },[]);

  useEffect(() => {
    const filtered = agents.filter(agent =>
      agent.name.toLowerCase().includes(searchName.toLowerCase())
    );
    setFilteredAgents(filtered);
  }, [agents, searchName]);
  

  const fetchAllUsers = () => {
    fetch('https://localhost:7077/api/EndUser/GetAll Passengers')
      .then(response => response.json())
      .then(data => setUsers(data))
      .catch(error => console.log(error));
  };

  const fetchApprovedAgents = () => {
    fetch('https://localhost:7077/api/EndUser/GetAll Approved Agents')
      .then(response => response.json())
      .then(data => setAgents(data))
      .catch(error => console.log(error));
  };
  const fetchNotApprovedAgents = () => {
    fetch("https://localhost:7077/api/EndUser/GetAll NotApproved Agents")
      .then(response => response.json())
      .then(data => setNotApprovedAgents(data))
      .catch(error => console.log(error));
  };
    
  return (
    <>
    <NavbarHome/>
    <nav className="navbar navbar-expand-lg navbar-light bg-light-blue custom-navbar">
        <div className="container-fluid">
          <button className="navbar-toggler"  type="button" onClick={() => setNavbarOpen(!navbarOpen)}  >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className={`collapse navbar-collapse ${navbarOpen ? 'show' : ''}`}>
            <p className="navbar-nav me-auto mb-1 mb-lg-0">
              <li className="nav-item">
                <a className="nav-link" href="#" onClick={() => handleSectionClick('approved')}>
                  View agent
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="#" onClick={() => handleSectionClick('Notapproved')}>
                  Req agent
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="#" onClick={() => handleSectionClick('users')}>
                 All Users
                </a>
              </li>
            </p>
            <div className="top-left-search">
            <form className="d-flex">
              <input className="form-control me-2" type="search" placeholder="Search" onChange={(event)=>{
              setSearchName(event.target.value);
              }}/>
              <button className="btn btn-success" type="submit">
                Search
              </button>
            </form>
            </div>
            <div  className="top-left-logout">
            <p className="navbar-nav me-auto mb-1 mb-lg-0">
              </p>
              </div>
          </div>
        </div>
      </nav>


      {activeSection === 'content' && (
        <div className="content">
          
          <section id="about" className="about">
      <div className="container" data-aos="fade-up">

        <div className="section-title">
          <h2>About Us</h2>
          <p>Medico Hospitals was founded by Prathap C. Reddy in 1983 as the first corporate health care in India. 
            The first branch at Chennai was inaugurated by the then President of India Zail Singh.</p>
        </div>

        <div className="row">
          <div className="col-lg-6" data-aos="fade-right">
            <img src={about} className="img-fluid" alt="" />
          </div>
          <div className="col-lg-6 pt-4 pt-lg-0 content" data-aos="fade-left">
            <h3>Medico HealthCo group's Chain Pharmacy and 
            its digital healthcare business Medico 24/7.</h3>
            <p className="fst-italic">
            Medico Hospital is a renowned healthcare institution that is globally recognized for its excellence in patient care,
             medical expertise, and advanced technology.
            </p>
            <ul>
              <li><i className="bi bi-check-circle"></i> It is equipped with state-of-the-art infrastructure, cutting-edge medical equipment</li>
              <li><i className="bi bi-check-circle"></i> Globally recognized for its excellence in patient care</li>
              <li><i className="bi bi-check-circle"></i> Provide personalized, evidence-based treatment, innovative procedures</li>
            </ul>
            <p>
            Medico Hospital is a renowned healthcare institution that is globally recognized for its excellence in patient care, medical expertise,
             and advanced technology. With a vast network of hospitals and clinics, Apollo Hospital offers a comprehensive range of medical services across 
             various specialties. It is equipped with state-of-the-art infrastructure, cutting-edge medical equipment, and a team of highly skilled doctors, 
             nurses, and healthcare professionals. Committed to delivering exceptional healthcare services, Apollo Hospital strives to provide personalized, 
            evidence-based treatment, innovative procedures, and compassionate care to patients from around the world.
            </p>
          </div>
        </div>
      </div>
    </section>

        </div>
      )} 
 

{activeSection === 'Notapproved'  && (

  <section className="my-background-radial-gradient overflow-hidden">
    
    <div className="my-doctors-container container">
    <div className="my-page-heading">
  <h2><strong>Requested Agents Details</strong></h2>
</div>
<hr></hr>
      {notApprovedAgents && notApprovedAgents.length > 0 ? (
        
       <div className="row row-cols-1 row-cols-md-3 g-4 justify-content-center">
       {notApprovedAgents.map(agent => (
         <div key={agent.TourAgentId} className="col">
           <div className="card shadow">
             <div className="card-body d-flex flex-column align-items-center">
             <br/>
               <h3 className="card-title mb-3 text-center"><strong>{agent.name}</strong></h3>
               {/* <p className="card-text">Qualification: {doctor.qualifications}</p> */}
              
     <hr/>
     <div className="d-flex justify-content-center">
            <button
                onClick={() => {
                
                console.log({id:agent.tourAgentId})
                fetch("https://localhost:7077/api/EndUser/Update Agent Status", {
                    method: "PUT",
                    headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json",
                    },
                    body: JSON.stringify({id:agent.tourAgentId})
                 })
                    .then(response => response.json())
                    .then(data => {
                    console.log(data);
                    fetchApprovedAgents();
                    fetchNotApprovedAgents();
                    })
                    .catch(error => console.log(error));
                }}
                className="btn btn-primary me-2">
                Approve
            </button>

            <button
                onClick={() => {
                fetch("https://localhost:7077/api/EndUser/Decline Agent", {
                    method: "PUT",
                    headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json"
                    },
                    body: JSON.stringify({id:agent.tourAgentId})
                })
                    .then(response => response.json())
                    .then(data => {
                    console.log(data);
                    })
                    .catch(error => console.log(error));
                }}
                className="btn btn-danger me-2"
            >
                Decline
            </button>
        </div>
        </div>
        </div>
       </div> ))}
     </div>) : (
        <p>No Agents to display.</p> )}
    </div>
  </section>
)}

      

      {activeSection === 'approved' && (
      <div className="approved">
      <section className="my-background-radial-gradient overflow-hidden">
        <div className="my-doctors-container container">
          <div className="my-page-heading">
            <h2><strong>Approved Agents Details</strong></h2>
          </div>
          <hr/>
          <div className="row row-cols-1 row-cols-md-3 g-4">
      {filteredAgents.map((agent) => (
        <div key={agent.TourAgentId} className="col">
        
          <div className="card shadow">
            <div className="card-body text-center"> 
              <br/>
              <img
                src={DoctorImage} 
                alt={agent.Name}
                className="doctor-image rounded-circle mx-auto d-block"
                style={{ width: '200px', height: '200px' }}
              /><br/>
               <h3 className="card-title mb-3 text-center"><strong>{agent.name}</strong></h3>
              {/* <p className="card-text">Qualification: {doctor.qualifications}</p>
              <p className="card-text">Experience: {doctor.experience}</p>
              <p className="card-text">Specialization: {doctor.specialty}</p>
              <p className="card-text">Date of Birth: {new Date(doctor.dateOfBirth).toLocaleDateString()}</p>
              <p className="card-text">Age: {doctor.age}</p>
              <p className="card-text">Address: {doctor.address}</p>
              <p className="card-text">Contact: {doctor.contactNo}</p> */}
            </div>
          </div>
        </div>
      ))}
          </div>
        </div>
      </section>    
        </div>
      )}


     {activeSection === 'users' && (
      
      <section className="my-background-radial-gradient overflow-hidden">
      <div className="my-doctors-container container">
        <div className="my-page-heading">
          <h2> Users Details</h2>
        </div>
        <hr></hr>
        <div className="row row-cols-1 row-cols-md-4 g-4">
          {users.map(user => (
            <div key={user.userId} className="col">
              <div className="card shadow">
                <div className="card-body">
                  <br/>
                  <h3 className="card-title"><strong>{user.name}</strong></h3>
                  <p className="card-text">Date of Birth: {new Date(user.dateOfBirth).toLocaleDateString()}</p>
                  <p className="card-text">Age: {user.age}</p>
                  <p className="card-text">Address: {user.address}</p>
                  <p className="card-text">Contact: {user.contactNo}</p>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </section>
    
     )}


    </>
  );
}

export default AdminHome;
