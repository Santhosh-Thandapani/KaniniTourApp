import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import "./Room.css";
import goa from "./Assets/goa.jpg";
import "./PackageDetail.css";
import { Modal,Form ,Button} from "react-bootstrap";

function PackageDetail() {

  const { id } = useParams();

  const [pack, setPackage] = useState();
  const [requestBody, setRequestBody] = useState({
    id: id,
  });
   //const peopleCount = parseInt(localStorage.getItem("peopleCount"));
   const peopleCount=2;
   // Initialize an array to store inputs for each person
   const [peopleInputs, setPeopleInputs] = useState([]);

  // New state for booking details
  const [bookingDetails, setBookingDetails] = useState({
    packgeId: id,
    userId: 4,
    packageName:"",
    userName: "",
    bookingAt: "",
    checkIn: "",
    checkOut: "",
    guests: [...Array(peopleCount)].map(() => ({
      name: "",
      age: 0,
      gender: "",
    })),
  });
  
  useEffect(() => {
    if (pack) {
      setBookingDetails((prevState) => ({
        ...prevState,
        packageName: pack.packageName,
      }));
    }
  }, [pack]);

// Update booking details when inputs change
const handleUserNameChange = (e) => {
    const { value } = e.target;
    setBookingDetails((prevState) => ({
      ...prevState,
      userName: value,
    }));
  };

  const handleBookingAtChange = (e) => {
    const { value } = e.target;
    setBookingDetails((prevState) => ({
      ...prevState,
      bookingAt: value,
    }));
  };

  const handleCheckInChange = (e) => {
    const { value } = e.target;
    setBookingDetails((prevState) => ({
      ...prevState,
      checkIn: value,
    }));
  };

  const handleCheckOutChange = (e) => {
    const { value } = e.target;
    setBookingDetails((prevState) => ({
      ...prevState,
      checkOut: value,
    }));
  };

  const handleGuestChange = (index, field, value) => {
    setBookingDetails((prevState) => {
      const updatedGuests = [...prevState.guests];
      updatedGuests[index][field] = value;
      return { ...prevState, guests: updatedGuests };
    });
  };



  // Booking Popup
  const [bookingPopup, setBookingPopup] = useState(false);
  const handleOpen = () => {
    setBookingPopup(true);
  };
  const handleClose = () => {
    setBookingPopup(false);
  };

  const bookPackage=()=>{
    handlePaymentOpen()
    makeBooking();
  }

 
  // Payment Popup
  const [paymentPopup, setPaymentPopup] = useState(false);
  const handlePaymentOpen = () => {
    setPaymentPopup(true);
  };
  const handlePaymentClose = () => {
    setPaymentPopup(false);
  };

  const makePayment=()=>{
    
  }
  

  const makeBooking = () => {
    fetch("https://localhost:7290/api/PackageBooking/Book Package", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(bookingDetails),
    })
    
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
      })
      .catch((error) => console.log(error));
  };

  const fetchPackageById = () => {
    fetch("https://localhost:7118/api/Package/GetPackage", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(requestBody),
    })
      .then((response) => response.json())
      .then((data) => {
        setPackage(data);
        console.log(data);
      })
      .catch((error) => console.log(error));
  };

  useEffect(() => {
    fetchPackageById();
  }, [requestBody]);


 

  useEffect(() => {
    // Initialize the peopleInputs array with empty objects based on the people count
    setPeopleInputs([...Array(peopleCount)].map(() => ({})));
  }, [peopleCount]);


  return (

    <div className="pack-body">
      {pack && (
        <>
          <div className="pack-img">
            <img src={goa} className="packImg" alt="Avatar woman" />
          </div>
          <div className="pack-details">
            <h1>{pack.packageName}</h1>
            <p>Duration: {pack.daysCount} days and {pack.nightsCount} nights</p>
            <p>Max Limit: {pack.maxLimit}</p>
            <p>Picture: {pack.picture}</p>
            <p>Hotel Stay Status: {pack.hotelStayStatus}</p>
            <p>Editable: {pack.editable}</p>

            <h2>Itineraries:</h2>
            {pack.itineraries.map((itinerary) => (
              <div key={itinerary.id} className="itinerary-item">
                <h3>Itinerary {itinerary.id}</h3>
                <p>Transport: {itinerary.transport}</p>
                <p>Transport Fare: {itinerary.transportFair}</p>
                <p>Food: {itinerary.food}</p>
                <p>Food Fare: {itinerary.foodFair}</p>

                <h4>Activities:</h4>
                {itinerary.activities.map((activity) => (
                  <div key={activity.itineraryId} className="activity-item">
                    <p>Activity Name: {activity.activityName}</p>
                    <p>Spot: {activity.spot}</p>
                    <p>City ID: {activity.cityId}</p>
                  </div>
                ))}

                <h4>Stay:</h4>
                <p>Hotel ID: {itinerary.stay.hotelId}</p>
                <p>Room ID: {itinerary.stay.roomId}</p>
              </div>
            ))}
          </div>
        </>
      )}

      <button onClick={()=>{handleOpen()}}>Book</button>


      {bookingPopup && (
            <div className="bookingPop">
              <h2>{pack.packageName}</h2>
              <p>Duration: {pack.daysCount} days and {pack.nightsCount} nights</p>

              {/* Display name, age, and gender input boxes based on people count */}
              <input
                    type="text"
                    placeholder="Your Name"
                    value={bookingDetails.userName}
                    onChange={handleUserNameChange}
                />

              <div>
                <input
                  type="date"
                  placeholder="Booking Date"
                  value={bookingDetails.bookingAt}
                  onChange={handleBookingAtChange}
                />
              </div>

              <div>
                <input
                  type="date"
                  placeholder="Check-in Date"
                  value={bookingDetails.checkIn}
                  onChange={handleCheckInChange}
                />
              </div>

              <div>
                <input
                  type="date"
                  placeholder="Check-out Date"
                  value={bookingDetails.checkOut}
                  onChange={handleCheckOutChange}
                />
              </div>

              {bookingDetails.guests.map((guest, index) => (
                <div key={index}>
                  <input
                    type="text"
                    placeholder={`Name of Person ${index + 1}`}
                    value={guest.name}
                    onChange={(e) =>
                      handleGuestChange(index, "name", e.target.value)
                    }
                  />
                  <input
                    type="number"
                    placeholder={`Age of Person ${index + 1}`}
                    value={guest.age}
                    onChange={(e) =>
                      handleGuestChange(index, "age", parseInt(e.target.value))
                    }
                  />
                  <input
                    type="text"
                    placeholder={`Gender of Person ${index + 1}`}
                    value={guest.gender}
                    onChange={(e) =>
                      handleGuestChange(index, "gender", e.target.value)
                    }
                  />
                </div>
              ))}
              <button onClick={bookPackage}>Proceed to Pay</button>

              <button onClick={() => handleClose()}>Cancel</button>
            </div>
          )}


        <Modal show={paymentPopup} onHide={handlePaymentClose}>
            <Modal.Header closeButton>
                <Modal.Title>Login / Sign Up</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                <Form.Group className="mb-3" controlId="formUsername">
                    <Form.Label>Username</Form.Label>
                    <Form.Control
                    type="text"
                    name="travelerName"
                    placeholder="Enter username"
                    />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formPassword">
                    <Form.Label>Password</Form.Label>
                    <Form.Control
                    type="password"
                    name="password"
                    placeholder="Password"
                    />
                </Form.Group>
                <Button variant="primary" onClick={makePayment} className="rounded-pill"> Login </Button>
                </Form>
            </Modal.Body>
         </Modal>


    </div>
  );
}

export default PackageDetail;
