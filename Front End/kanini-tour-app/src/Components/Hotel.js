import { useEffect, useState } from "react";
import { useNavigate } from 'react-router';
import tour from './Assets/tour.jpg';
import AddHotelModal from "./AddHotelModal";

function Hotel() {

  const [hotels, setHotels] = useState([]);
  const [filteredHotel,setFilteredhotel]=useState([]);
  const navigate = useNavigate();
  const [requestBody, setSequestBody] = useState({
    "id": 0
  });

  const city = localStorage.getItem("city");
  //const city ="string";
  
  const changeId = (id) => {
    navigate(`/room/${id}`);
  };

  const fetchHotels = () => {
    fetch('https://localhost:7001/api/Hotel/GetAllHotel')
      .then(response => response.json())
      .then(data => {
        setHotels(data);
        if (city && city !== "null") {
          const filteredHotels = data.filter(hotel => hotel.city.toLowerCase() === city.toLowerCase());
          setFilteredhotel(filteredHotels);
          console.log(filteredHotels);
        } else {
          setFilteredhotel(data);
        }
      })
      .catch(error => console.log(error));
  };


//Add HotelPopup
const [addPopUp, setAddPopup] = useState(false);
const handleAddOpen = () => {
  setAddPopup(true);
};
const handleAddClose = () => {
  setAddPopup(false);
};

  //Add Hotel 
  const handleAddHotel = (hotelData) => {
    fetch("https://localhost:7001/api/Hotel/AddHotel", {
      method: "POST",
      headers: {
      Accept: "application/json",
      "Content-Type": "application/json"
      },
      body: JSON.stringify(hotelData)
      })
      .then(async (data)=>{
        if(data.status == 200)
        {
            var myData = await data.json();
            console.log(myData);
            alert(" gvhijo");
        }     
    })
      .catch(error => console.log(error));
     };
  

  useEffect(() => {
    fetchHotels();
  }, [requestBody,addPopUp]);

  return (
    <div>
      <section className="my-background-radial-gradient overflow-hidden">
        <div className="my-doctors-container container">
          <div className="my-page-heading">
            <h2> Hotel Details</h2>
          </div>
          <hr></hr>
          <div className="row row-cols-1 row-cols-md-4 g-4" >
            {filteredHotel.map(hotel => (
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

      <button onClick={() => handleAddOpen(true)}>Open Add Hotel Modal</button>
      {addPopUp && <AddHotelModal closeModal={() => handleAddClose()} onAddHotel={handleAddHotel} />}
    
    </div>
  );
}

export default Hotel;
