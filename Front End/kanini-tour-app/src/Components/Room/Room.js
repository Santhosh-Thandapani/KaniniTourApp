import { useParams} from "react-router-dom";
import { useEffect, useState } from "react";
import './Room.css';
import tour from '../Assets/pack.jpg';
import BookingModal from "../BookingModal/BookingModal";
import ViewHotelReview from "../ViewHotelReview/ViewHotelReview";
import NavbarHome from "../NavbarHome/NavbarHome";

function Room() {
  const { id } = useParams(); 
  const[hotel,setHotel]=useState({});
  const [rooms, setRooms] = useState([])
  const [requestBody, setRequestBody] = useState({
    "id": id,
    "roomId":0
  });

  //bookingDTO
  const[bookingDTO,setBookingDTO]=useState({
    hotelId:id,
    hotelName:"",
    price:0,
    roomId:0
  })

  const isAdmin = () => {
    const role = localStorage.getItem("role");
    return role === "admin";
  };


  //Booking Popup:
  const [bookingPopup, setBookingPopup] = useState(false);

   const handleOpen = (getRoomId,getPrice) => {
    
    setRequestBody((prevRequestBody) => ({
      ...prevRequestBody,
      roomId: getRoomId
    }));

    const hotelName = hotel.name;
    setBookingDTO((prevBookingDTO) => ({
      ...prevBookingDTO,
      hotelId: id,
      hotelName: hotelName,
      price:getPrice,
      roomId: getRoomId,
    }));
    // Show the booking popup
     setBookingPopup(true);
  };

  const handleClose = () => {
    setBookingPopup(false);
  };


  const fetchHoteById = () => {
    fetch("https://localhost:7001/api/Hotel/GetHotel", {
        method: "POST",
        headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
        },
        body: JSON.stringify(requestBody)
    })
        .then(response => response.json())
        .then(data => {
          setHotel(data);
          setBookingDTO(prevBookingDTO => ({
            ...prevBookingDTO,
            hotelName: data.name
          }));
        })
        .catch(error => console.log(error));
     }

 const fetchRooms = () => {
        fetch("https://localhost:7001/api/Room/GetRooms", {
            method: "POST",
            headers: {
            Accept: "application/json",
            "Content-Type": "application/json"
            },
            body: JSON.stringify(requestBody)
        })
            .then(response => response.json())
            .then(data => {
                console.log(data);
              setRooms(data);
            })
            .catch(error => console.log(error));
    }
      
    useEffect(()=>{
      fetchRooms();
      fetchHoteById();
    },[requestBody])

  return (
    <>
   <NavbarHome/>
  <div className="container mt-5 mb-5">
  {rooms.length > 0 ? (
    rooms.map((room) => (
    <div  key={room.id} className="d-flex justify-content-center row">
        <div className="col-md-10">
            <div className="row p-2 bg-white border rounded">
                <div className="col-md-3 mt-1"><img class="img-fluid img-responsive rounded product-image" src="https://i.imgur.com/QpjAiHq.jpg"/></div>
                <div className="col-md-6 mt-1">
                    <h5>{room.roomName}</h5>
                    <div className="d-flex flex-row">
                        <div className="ratings mr-2"><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i></div><span>310</span>
                    </div>
                    <div className="mt-1 mb-1 spec-1">
                        <span>
                        <i class="fa-solid fa-bed"></i> <b>Bed Type:</b> {room.bedType}
                        </span> &nbsp;&nbsp;
                        <span>
                        <i class="fas fa-fan"></i> <b>Type:</b> {room.type}
                        </span>&nbsp;&nbsp;
                        <span>
                            <i class="fa-solid fa-hotel"></i><b> Room Size:</b> {room.size}.Sqft
                        </span>&nbsp;&nbsp;
                    </div>

                    {/* <div className="mt-1 mb-1 spec-1">
                        <span>
                            <i class="fa-solid fa-hotel"></i>Room Size: {room.size}
                        </span>
                    </div> */}

                    <b>Amenity</b>
                    {Array.isArray(room.roomAmenity) ? (
                      <ul>
                    
                        {room.roomAmenity.map((amt) => (
                          <div key={amt.id}>
                            <i class="fa-solid fa-arrow-right">&nbsp;&nbsp;</i>{amt.amenity}
                          </div>
                        ))}
                      </ul>
                    ) : (
                      <p>Loading amenities...</p>
                    )}
                </div>
                <div className="align-items-center align-content-center col-md-3 border-left mt-1">
                    <div className="d-flex flex-row align-items-center">
                        <h4 classNme="mr-1">Price: <i class="fa-solid fa-indian-rupee-sign"></i> {room.price}</h4>
                    </div>

                    {!isAdmin() && (
                       <div classNAme="d-flex flex-column mt-4">
                       <button class="btn btn-primary btn-lg" onClick={() => handleOpen(room.id,room.price)}>Book</button>
                     </div>
                    )}
                </div>
            </div>
        </div>
    </div>
) )): (
  <p>Loading rooms...</p>
)}
</div>
       {bookingPopup && <BookingModal closeModal={handleClose} bookingDTO={bookingDTO} />}
  </>
  );
}

export default Room;
  