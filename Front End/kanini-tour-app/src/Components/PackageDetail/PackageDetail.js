import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import goa from '../Assets/goa.jpg';
import "./PackageDetail.css";
import { Modal,Form ,Button} from "react-bootstrap";
import NavbarHome from "../NavbarHome/NavbarHome";
import BookingPackage from "../BookingPackage/BookingPackage";

function PackageDetail() {

  const { id } = useParams();

  const [pack, setPackage] = useState();
  
  const [requestBody, setRequestBody] = useState({
    id: id,
  });
   

  //Booking DTO
  const[bookingDTO,setBookingDTO]=useState({
    packageId:id,
    packageName:pack,
    price:0,
  })

  useEffect(() => {
    // Update the bookingDTO when the pack state changes
    if (pack) {
      setBookingDTO((prevBookingDTO) => ({
        ...prevBookingDTO,
        packageName: pack.packageName,
        price: pack.price,
      }));
    }
  }, [pack]);


  // Booking Popup
  const [bookingPopup, setBookingPopup] = useState(false);
  
  const handleOpen = (price,name) => {
    console.log(id);
    setBookingDTO((prevBookingDTO) => ({
        ...prevBookingDTO,
        packageId: id,
        packageName: name,
        price:price
      }));
      console.log(bookingDTO);
    setBookingPopup(true);
  };
  const handleClose=()=>{
    setBookingPopup(false);
  }



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


  return (

    <div className="pack-body">
        <NavbarHome/>
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
            <p>Price :{pack.price}</p>

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

      <button onClick={()=>{handleOpen(pack.price,pack.packgeName)}}>Book</button>

      {bookingPopup && <BookingPackage  closeModal={handleClose} bookingDTO={bookingDTO} />}

     
    </div>
  );
}

export default PackageDetail;
