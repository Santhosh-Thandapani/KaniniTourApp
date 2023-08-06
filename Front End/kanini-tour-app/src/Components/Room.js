import { useParams} from "react-router-dom";
import { useEffect, useState } from "react";
import './Room.css';
import tour from './Assets/tour.jpg';

function Room() {
  const { id } = useParams(); 
  const[hotel,setHotel]=useState({});
  const [requestBody, setSequestBody] = useState({
    "id": id
  });
  const [rooms, setRooms] = useState([])

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
            console.log(data);
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
              setRooms(data);
                console.log(data);
            })
            .catch(error => console.log(error));
    }
      
    useEffect(()=>{
      fetchRooms();
      fetchHoteById();
    },[requestBody])

  return (
    <div className="page-container">
      <div class="split left">
        <div class="centered-left">
          <img src={tour} alt="Avatar woman"/>
          <h3 className="card-title"><strong>{hotel.name}</strong></h3>
          <div>
              5<i className='fa fa-star' style={{ color: "#ffde05" }}></i>
          </div>
          <p className="card-text"><strong>Address</strong> {hotel.houseNo}, {hotel.landmark}, Chennai, Tamil Nadu, India</p>
            <div className="Location">
            </div>
            <h6><strong>Hotel Amenities:</strong></h6>
            {Array.isArray(hotel.hotelAmenities) ? (
                <ul>
                  {hotel.hotelAmenities.map((amt) => (
                    <li key={amt.id}>{amt.amenity}</li>
                  ))}
                </ul>
              ) : (
                <p>Loading amenities...</p>
              )}

        </div>
      </div>

      <div class="split right">
        <div class="centered-right">
          <div>
          {rooms.length > 0 ? (
              rooms.map((room) => (
                <div key={room.id} class="row">
                 <div class="col-md-4">
                  <div class="bg-image hover-overlay ripple" data-mdb-ripple-color="light">
                    <img src={tour} class="img-fluid" alt="Room"/>
                    <a href="#!">
                      <div class="mask"></div>
                    </a>
                  </div>
                </div>

                <div class="col-md-4">
                  <div class="card-body">
                    <h5 class="card-title">{room.roomName}</h5>
                    <p>Bed Type: {room.bedType}</p>
                    <p>Room Size: {room.size}</p>
                    {Array.isArray(room.roomAmenity) ? (
                      <ul>
                        {room.roomAmenity.map((amt) => (
                          <li key={amt.id}>{amt.amenity}</li>
                        ))}
                      </ul>
                    ) : (
                      <p>Loading amenities...</p>
                    )}

                    

                  </div>
                </div>

                <div class="col-md-4">
                  <div class="card-body">
                    <p>Type: {room.type}</p>
                    <h6>Price: {room.price}</h6>
                    <a href="#!" class="btn btn-primary">Button</a>
                  </div>
                </div>

              </div>
            ) )): (
              <p>Loading rooms...</p>
            )}
          </div>
            
        </div>
      </div>
  </div>
   
  );
}

export default Room;
  