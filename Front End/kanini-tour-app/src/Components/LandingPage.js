import React from 'react';
import './LandingPage.css';
import logo from './Assets/logo.png';
import tour from './Assets/tour.jpg';
import { Button, Carousel } from 'react-bootstrap';
import slide1 from './Assets/slide/slide-1.jpg';
import slide2 from './Assets/slide/slide-2.jpg'
import slide3 from './Assets/slide/slide-3.jpg';
import { Link } from 'react-router-dom';
import { useState ,useEffect} from 'react';
import { useNavigate } from "react-router";


function LandingPage() {

    const [hotelData, setHotelData] = useState({
        "destination":"",
        "checkIn":new Date(0),   
        "checkOut":new Date(0),
        "adults":0,
        "rooms":0,
        "children":0
    });
    const [packageData, setPackageData] = useState({ 
        "destination":"",
        "checkIn":new Date(0),   
        "checkOut":new Date(0),
        "adults":0,
        "rooms":0,
        "children":0});

    const [showPackageButton, setShowPackageButton] = useState(true);
    const isLoggedIn = sessionStorage.getItem('UserId') && localStorage.getItem('token');
    const navigate = useNavigate();
    const handleHotelButtonClick = () => {
      setShowPackageButton(false);
    };
  
    const handlePackageButtonClick = () => {
      setShowPackageButton(true);
    };
  
    const handleSubmit = () => {
      if (showPackageButton) {
        console.log('Package data:', packageData);
        localStorage.setItem("Destination",packageData.destination);
        localStorage.setItem("CheckIn",packageData.checkIn)
        localStorage.setItem("CheckOut",packageData.checkOut)
        localStorage.setItem("Adults",packageData.adults)
        localStorage.setItem("Children",packageData.children)
        localStorage.setItem("Rooms",packageData.rooms)
        navigate('/packages');
      } 
      else {
        console.log('Hotel data:', hotelData);
        localStorage.setItem("Destination",hotelData.destination);
        localStorage.setItem("CheckIn",hotelData.checkIn)
        localStorage.setItem("CheckOut",hotelData.checkOut)
        localStorage.setItem("Adults",hotelData.adults)
        localStorage.setItem("Children",hotelData.children)
        localStorage.setItem("Rooms",hotelData.rooms)
        navigate('/hotels');
      }
    };
   

    return (
      <div>
           <header id="header" className="fixed-top">
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
        
            {!isLoggedIn && (
            <li>
            <Link className="nav-link scrollto" to={"/doctor"}>
                Join with us!
            </Link>
            </li>
            
        )}
        {!isLoggedIn && (
            <li>
            <Link className="nav-link scrollto" to={"/doctor"}>
                Login
            </Link>
            </li>
            
        )}
        {!isLoggedIn && (
            <li>
            <Link className="nav-link scrollto" to={"/doctor"}>
                Register
            </Link>
            </li>
            
        )}

      </ul>
      <i className="bi bi-list mobile-nav-toggle"></i>
    </nav>
  </div>
</header>


<section id="hero">
      <Carousel className="custom-carousel">
        {/* Slide 1 */}
        <Carousel.Item>
          <img
            className="d-block w-100"
            src={slide1}
            alt="First slide"
          />
        </Carousel.Item>

        {/* Slide 2 */}
        <Carousel.Item>
          <img
            className="d-block w-100"
            src={slide2}
            alt="Second slide"
          />
        </Carousel.Item>

        {/* Slide 3 */}
        <Carousel.Item>
          <img
            className="d-block w-100"
            src={slide3}
            alt="Third slide"
          />
        </Carousel.Item>
      </Carousel>
    </section>

    <div className='searchBox'>
    <div className="row" style={{ background: 'white', padding: '20px' }}>
      <div className="col-md-12" style={{ width: '80%', margin: '0 auto' }}>
        <button
          className={`btn-get-started scrollto ${!showPackageButton ? 'active' : ''}`}
          onClick={handleHotelButtonClick}
        >
          Hotel
        </button>
        <button
          className={`btn-get-started scrollto ${showPackageButton ? 'active' : ''}`}
          onClick={handlePackageButtonClick}
        >
          Packages
        </button>
        <br />
        <div className="info-box">
          <i className="bx bx-map"></i>
          <h3>Make Search Here</h3>

          <div className="container">
            <div className="col-lg-12">
              <div className="row">
                <div className="col-md-4 form-group">
                  <input
                    type="text"
                    name="name"
                    className="form-control"
                    id="name"
                    placeholder="Destination"
                    required
                    onChange={(e) =>
                      showPackageButton
                        ? setPackageData({ ...packageData, destination: e.target.value })
                        : setHotelData({ ...hotelData, destination: e.target.value })
                    }
                  />
                </div>
                <div className="col-md-4 form-group mt-3 mt-md-0">
                  <input
                    type="date"
                    className="form-control"
                    name="email"
                    id="email"
                    placeholder="Check In"
                    required
                    onChange={(e) =>
                      showPackageButton
                        ? setPackageData({ ...packageData, checkIn: e.target.value })
                        : setHotelData({ ...hotelData, checkIn: e.target.value })
                    }
                  />
                </div>
                <div className="col-md-4 form-group">
                  <input
                    type="date"
                    name="name"
                    className="form-control"
                    id="name"
                    placeholder="Check Out"
                    required
                    onChange={(e) =>
                      showPackageButton
                        ? setPackageData({ ...packageData, checkOut: e.target.value })
                        : setHotelData({ ...hotelData, checkOut: e.target.value })
                    }
                  />
                </div>
              </div>

              <div className="row">
                <div className="col-md-4 form-group form-group mt-3">
                  <input
                    type="number"
                    name="name"
                    className="form-control"
                    id="name"
                    placeholder="Adult"
                    required
                    onChange={(e) =>
                      showPackageButton
                        ? setPackageData({ ...packageData, adults: e.target.value })
                        : setHotelData({ ...hotelData, adults: e.target.value })
                    }
                  />
                </div>
                <div className="col-md-4 form-group form-group mt-3">
                  <input
                    type="number"
                    className="form-control"
                    name="email"
                    id="email"
                    placeholder="Children"
                    required
                    onChange={(e) =>
                      showPackageButton
                        ? setPackageData({ ...packageData, children: e.target.value })
                        : setHotelData({ ...hotelData, children: e.target.value })
                    }
                  />
                </div>
                <div className="col-md-4 form-group form-group mt-3">
                  <input
                    type="number"
                    name="name"
                    className="form-control"
                    id="name"
                    placeholder="Room"
                    required
                    onChange={(e) =>
                      showPackageButton
                        ? setPackageData({ ...packageData, rooms: e.target.value })
                        : setHotelData({ ...hotelData, rooms: e.target.value })
                    }
                  />
                </div>
              </div>
            </div>
          </div>

          <button className="btn-get-started scrollto" onClick={handleSubmit}>
            Search
          </button>
        </div>
      </div>
    </div>
    </div>
    

    <div className="section-title">
        <h2>Places</h2>
    </div>
    <section id="featured-services" className="featured-services">
      <div className="container" data-aos="fade-up">
        <div className="row">
          <div className="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0">
            <div className="icon-box" data-aos="fade-up" data-aos-delay="100">
              <div className="icon">
                {/* <i className="fas fa-heartbeat"></i> */}
                <img className="d-block w-100" src={tour} alt="Second slide" />
                </div>
              <h4 className="title"><a href=""> Chennai </a></h4>
              <p className="description"> Improve operational efficiency and patient satisfaction</p>
            </div>
          </div>

          <div className="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0">
            <div className="icon-box" data-aos="fade-up" data-aos-delay="200">
              <div className="icon">
              <img className="d-block w-100" src={tour} alt="Second slide" />
              </div>
              <h4 className="title"><a href=""> Chennai </a></h4>
              <p className="description"> Improve operational efficiency and patient satisfaction</p>
            </div>
          </div>

          <div className="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0">
            <div className="icon-box" data-aos="fade-up" data-aos-delay="300">
              <div className="icon">
                <img className="d-block w-100" src={tour} alt="Second slide" />
                </div>
                <h4 className="title"><a href=""> Chennai </a></h4>
              <p className="description"> Improve operational efficiency and patient satisfaction</p>
            </div>
          </div>

          <div className="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0">
            <div className="icon-box" data-aos="fade-up" data-aos-delay="400">
              <div className="icon">
              <img className="d-block w-100" src={tour} alt="Second slide" />
              </div>
              <h4 className="title"><a href=""> Chennai </a></h4>
              <p className="description"> Improve operational efficiency and patient satisfaction</p>
            </div>
          </div>
          <br/>   <br/>   <br/>   <br/> 
          <div className='more'>
          <a href="#about" className="btn-get-started scrollto">
              Read More
            </a>
            </div>
        </div>
      </div>
    </section>

    
    <div className="section-title">
        <h2>Top PAckages</h2>
    </div>
    <div className='kkk'>
    <section id="featured-services" className="featured-services">
      <div className="container" data-aos="fade-up">
        <div className="row">
          <div className="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0">
            <div className="icon-box" data-aos="fade-up" data-aos-delay="100">
              <div className="icon">
                {/* <i className="fas fa-heartbeat"></i> */}
                <img className="d-block w-100" src={tour} alt="Second slide" />
                </div>
              <h4 className="title"><a href=""> Chennai </a></h4>
              <p className="description"> Improve operational efficiency and patient satisfaction</p>
            </div>
          </div>

          <div className="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0">
            <div className="icon-box" data-aos="fade-up" data-aos-delay="200">
              <div className="icon">
              <img className="d-block w-100" src={tour} alt="Second slide" />
              </div>
              <h4 className="title"><a href=""> Chennai </a></h4>
              <p className="description"> Improve operational efficiency and patient satisfaction</p>
            </div>
          </div>

          <div className="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0">
            <div className="icon-box" data-aos="fade-up" data-aos-delay="300">
              <div className="icon">
                <img className="d-block w-100" src={tour} alt="Second slide" />
                </div>
                <h4 className="title"><a href=""> Chennai </a></h4>
              <p className="description"> Improve operational efficiency and patient satisfaction</p>
            </div>
          </div>

          <div className="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0">
            <div className="icon-box" data-aos="fade-up" data-aos-delay="400">
              <div className="icon">
              <img className="d-block w-100" src={tour} alt="Second slide" />
              </div>
              <h4 className="title"><a href=""> Chennai </a></h4>
              <p className="description"> Improve operational efficiency and patient satisfaction</p>
            </div>
          </div>
          <br/>   
          <div className='more'>
          <a href="#about" className="btn-get-started scrollto">
              Read More
            </a>
            </div>
        </div>
      </div>
    </section>
    </div>


    
    {/* service */}
    <section id="services" className="services">
      <div className="container" data-aos="fade-up">

        <div className="section-title">
          <h2>Services</h2>
          <p>With a vast network of hospitals and clinics, Apollo Hospital offers a comprehensive range of medical 
            services across various specialties. It is equipped with state-of-the-art infrastructure, cutting-edge medical equipment, 
            and a team of highly skilled doctors, nurses, and healthcare professionals</p>
        </div>

        <div className="row">
          <div className="col-lg-4 col-md-6 icon-box" data-aos="zoom-in" data-aos-delay="100">
            <div className="icon"><i className="fas fa-heartbeat"></i></div>
            <h4 className="title"><a href="">Orthopedic</a></h4>
            <p className="description">Improve operational efficiency and patient satisfaction 
            through coordination and communication integrated hospital management system.</p>
          </div>
          <div className="col-lg-4 col-md-6 icon-box" data-aos="zoom-in" data-aos-delay="200">
            <div className="icon"><i className="fas fa-pills"></i></div>
            <h4 className="title"><a href="">Blood pressure levels</a></h4>
            <p className="description">Our goal is to promote healthy blood pressure levels, reduce cardiovascular risks, 
              and improve overall patient well-being</p>
          </div>
          <div className="col-lg-4 col-md-6 icon-box" data-aos="zoom-in" data-aos-delay="300">
            <div className="icon"><i className="fas fa-hospital-user"></i></div>
            <h4 className="title"><a href="">Emergency</a></h4>
            <p className="description">Emergency department is a critical unit in hospitals, providing immediate medical care to patients with life-threatening 
            conditions and urgent medical needs.</p>
          </div>
          <div className="col-lg-4 col-md-6 icon-box" data-aos="zoom-in" data-aos-delay="100">
            <div className="icon"><i className="fas fa-dna"></i></div>
            <h4 className="title"><a href="">DNA</a></h4>
            <p className="description">At our hospital, we utilize cutting-edge DNA testing and analysis to provide personalized healthcare solutions.</p>
          </div>
          <div className="col-lg-4 col-md-6 icon-box" data-aos="zoom-in" data-aos-delay="200">
            <div className="icon"><i className="fas fa-wheelchair"></i></div>
            <h4 className="title"><a href="">Give our Hands</a></h4>
            <p className="description">Treating physically challenged individuals requires a holistic approach, focusing on their specific needs and abilities to 
            enhance their quality of life.</p>
          </div>
          <div className="col-lg-4 col-md-6 icon-box" data-aos="zoom-in" data-aos-delay="300">
            <div className="icon"><i className="fas fa-notes-medical"></i></div>
            <h4 className="title"><a href="">Medical supplies</a></h4>
            <p className="description">Medical supplies encompass a wide range of products, including disposable items, equipment, instruments</p>
          </div>
        </div>

      </div>
    </section>


    <section id="contact" className="contact">
      <div className="container">

        <div className="section-title">
          <h2>Contact</h2>
          <p>Medico Hospitals Enterprise Limited brings to your attention that certain persons are circulating/posting 
            fake advertisements inviting applications from candidates for
             employment in the Company through e-mails, WhatsApp messages and on leading job portals.</p>
        </div>

      </div>

      <div className="container">

        <div className="row mt-5">

          <div className="col-lg-6">

            <div className="row">
              <div className="col-md-12">
                <div className="info-box">
                  <i className="bx bx-map"></i>
                  <h3>Our Address</h3>
                  <p>64, New Cross Road, Pheonix mall Oppo, Chennai </p>
                </div>
              </div>
              <div className="col-md-6">
                <div className="info-box mt-4">
                  <i className="bx bx-envelope"></i>
                  <h3>Email Us</h3>
                  <p>madico@hospital.com<br />santhosh@madico.com</p>
                </div>
              </div>
              <div className="col-md-6">
                <div className="info-box mt-4">
                  <i className="bx bx-phone-call"></i>
                  <h3>Call Us</h3>
                  <p>+91 97877 56230<br />+91 9360538710 254445 41</p>
                </div>
              </div>
            </div>

          </div>

          <div className="col-lg-6">
            <form  method="post" role="form" className="php-email-form">
              <div className="row">
                <div className="col-md-6 form-group">
                  <input type="text" name="name" className="form-control" id="name" placeholder="Your Name" required />
                </div>
                <div className="col-md-6 form-group mt-3 mt-md-0">
                  <input type="email" className="form-control" name="email" id="email" placeholder="Your Email" required />
                </div>
              </div>
              <div className="form-group mt-3">
                <input type="text" className="form-control" name="subject" id="subject" placeholder="Subject" required />
              </div>
              <div className="form-group mt-3">
                <textarea className="form-control" name="message" rows="7" placeholder="Message" required></textarea>
              </div>
              <div className="my-3">
                <div className="loading">Loading</div>
                <div className="error-message"></div>
                <div className="sent-message">Your message has been sent. Thank you!</div>
              </div>
              <div className="text-center"><button type="submit">Send Message</button></div>
            </form>
          </div>

        </div>

      </div>
    </section>

      </div>
    );
  }
  
  export default LandingPage;