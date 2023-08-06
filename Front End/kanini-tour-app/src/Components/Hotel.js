import { useEffect, useState } from "react";
import { useNavigate } from 'react-router';
import tour from './Assets/tour.jpg';

function Hotel() {

  const [hotels, setHotels] = useState([]);
  const [location, setLocation] = useState({});
  const navigate = useNavigate();
  const [requestBody, setSequestBody] = useState({
    "id": 0
  });
  
  const changeId = (id) => {
    navigate(`/room/${id}`);
  };

  const fetchHotels = () => {
    fetch('https://localhost:7001/api/Hotel/GetAllHotel')
      .then(response => response.json())
      .then(data => {
        setHotels(data);
        console.log(data)
      })
      .catch(error => console.log(error));
  };

  // const fetchLocation = (id) => { 
  //   fetch("https://localhost:7137/api/Location/GetOne", {
  //     method: "POST",
  //     headers: {
  //       Accept: "application/json",
  //       "Content-Type": "application/json"
  //     },
  //     body: JSON.stringify({ id: id }) 
  //   })
  //   .then(response => response.json())
  //   .then(data => {
  //     setLocation(data); 
  //     console.log(data);
  //   })
  //   .catch(error => console.log(error));
  // };

  useEffect(() => {
    fetchHotels();
  }, [requestBody]);

  return (
    <div>
      <section className="my-background-radial-gradient overflow-hidden">
        <div className="my-doctors-container container">
          <div className="my-page-heading">
            <h2> Hotel Details</h2>
          </div>
          <hr></hr>
          <div className="row row-cols-1 row-cols-md-4 g-4" >
            {hotels.map(hotel => (
              <div key={hotel.id} className="col">
                <div className="card shadow">
                  <img className="card-img" src={tour} alt="Suresh Dasari Card" />
                  <div className="card-body" onClick={() => { changeId(hotel.id) }}>
                    <br />
                    <h3 className="card-title"><strong>{hotel.name}</strong></h3>
                    <div>
                      5<i className='fa fa-star' style={{ color: "#ffde05" }}></i>
                    </div>
                    <p className="card-text"><strong>Address</strong> {hotel.houseNo}, {hotel.landmark}, Chennai, Tamil Nadu, India</p>
                    <div className="Location">
                    </div>
                    <h6><strong>Hotel Amenities:</strong></h6>
                    {hotel.hotelAmenities.map(amt => (
                      <ul key={amt.id}>
                        <li>{amt.amenity}</li>
                      </ul>
                    ))}
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
      </section>
    </div>
  );
}

export default Hotel;
