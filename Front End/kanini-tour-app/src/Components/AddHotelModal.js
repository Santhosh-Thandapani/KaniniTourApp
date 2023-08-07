import { faColonSign } from "@fortawesome/free-solid-svg-icons";
import { useState } from "react";

function AddHotelModal({ closeModal, onAddHotel }) {

  const [hotelData, setHotelData] = useState({
    id: 0,
    name: "",
    picture: "",
    houseNo: 0,
    street: "",
    landmark: "",
    city: "",
    rooms: [],
    hotelAmenities: [],
  });

  const [newRoom, setNewRoom] = useState({
    roomName: "",
    roomPicture: "",
    totalRooms: 0,
    size: 0,
    bedType: "",
    type: "",
    price: 0,
    roomAmenity: [],
  });

  const [amenity, setAmenity] = useState({
    name: "",
  });

  const [newHotelAmenity, setNewHotelAmenity] = useState({
    amenity: "",
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setHotelData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleRoomInputChange = (e, index) => {
    const { name, value } = e.target;
    setHotelData((prevData) => {
      const updatedRooms = [...prevData.rooms];
      updatedRooms[index] = {
        ...updatedRooms[index],
        [name]: value,
      };
      return {
        ...prevData,
        rooms: updatedRooms,
      };
    });
  };


  const handleAmenityInputChange = (e, roomIndex, amenityIndex) => {
    const { name, value } = e.target;
    setHotelData((prevData) => {
      const updatedRooms = [...prevData.rooms];
      const updatedRoom = {
        ...updatedRooms[roomIndex],
        roomAmenity: updatedRooms[roomIndex].roomAmenity.map((item, index) =>
          index === amenityIndex ? { ...item, [name]: value } : item
        ),
      };
      updatedRooms[roomIndex] = updatedRoom;
      return {
        ...prevData,
        rooms: updatedRooms,
      };
    });
  };
  


  const handleAddAmenity = (roomIndex) => {
    setHotelData((prevData) => {
      const updatedRooms = [...prevData.rooms];
      const updatedRoom = {
        ...updatedRooms[roomIndex],
        roomAmenity: [...updatedRooms[roomIndex].roomAmenity, amenity],
      };
      updatedRooms[roomIndex] = updatedRoom;
      return {
        ...prevData,
        rooms: updatedRooms,
      };
    });
    setAmenity({
      name: "",
    });
  };

  const handleHotelAmenityInputChange = (e, index) => {
    const { name, value } = e.target;
    setHotelData((prevData) => {
      const updatedAmenities = [...prevData.hotelAmenities];
      updatedAmenities[index] = {
        ...updatedAmenities[index],
        [name]: value,
      };
      return {
        ...prevData,
        hotelAmenities: updatedAmenities,
      };
    });
  };

  const handleAddHotelAmenity = () => {
    setHotelData((prevData) => ({
      ...prevData,
      hotelAmenities: [...prevData.hotelAmenities, newHotelAmenity],
    }));
    setNewHotelAmenity({
      amenity: "",
    });
  };


  const handleAddRoom = () => {
    setHotelData((prevData) => ({
      ...prevData,
      rooms: [...prevData.rooms, newRoom],
    }));
    setNewRoom({
      roomName: "",
      roomPicture: "",
      totalRooms: 0,
      size: 0,
      bedType: "",
      type: "",
      price: 0,
      roomAmenity: [],
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    
    console.log(hotelData)
    onAddHotel(hotelData);
    
    setHotelData({
      id: 0,
      name: "",
      picture: "",
      houseNo: 0,
      street: "",
      landmark: "",
      city: "",
      rooms: [],
      hotelAmenities: [],
    });

    // Close the modal after form submission
    closeModal();
  };

  return (
    <div className="popup">
      <div className="popup-inner">
        <h2>Add Hotel</h2>
        <form onSubmit={handleSubmit}>
          <label>
            Name:
            <input
              type="text"
              name="name"
              value={hotelData.name}
              onChange={handleInputChange}
            />
          </label>

          <label>
            Picture:
            <input
              type="text"
              name="picture"
              value={hotelData.picture}
              onChange={handleInputChange}
            />
          </label>

          <label>
            House No:
            <input
              type="number"
              name="houseNo"
              value={hotelData.houseNo}
              onChange={handleInputChange}
            />
          </label>

          <label>
            Street:
            <input
              type="text"
              name="street"
              value={hotelData.street}
              onChange={handleInputChange}
            />
          </label>

          <label>
            Landmark:
            <input
              type="text"
              name="landmark"
              value={hotelData.landmark}
              onChange={handleInputChange}
            />
          </label>

          <label>
            City:
            <input
              type="text"
              name="city"
              value={hotelData.city}
              onChange={handleInputChange}
            />
          </label>

          <button type="button" onClick={handleAddHotelAmenity}>
            Add Hotel Amenity
          </button>

          {/* Display added hotel amenities */}
          {hotelData.hotelAmenities.map((amenity, index) => (
            <div key={index}>
              <h4>Hotel Amenity {index + 1}</h4>
              <label>
                Amenity:
                <input
                  type="text"
                  name="amenity"
                  value={amenity.amenity}
                  onChange={(e) => handleHotelAmenityInputChange(e, index)}
                />
              </label>
            </div>
          ))}

          {/* Add Room Button */}
          <button type="button" onClick={handleAddRoom}>
            Add Room
          </button>

          {/* Display added rooms */}
          {hotelData.rooms.map((room, index) => (
            <div key={index}>
              <h3>Room {index + 1}</h3>
              <label>
                Room Name:
                <input
                  type="text"
                  name="roomName"
                  value={room.roomName}
                  onChange={(e) => handleRoomInputChange(e, index)}
                />
              </label>
              
                <label>
                  Room Picture:
                  <input
                    type="text"
                    name="roomPicture"
                    value={room.roomPicture}
                    onChange={(e) => handleRoomInputChange(e, index)}
                  />
                </label>

                <label>
                  Total Rooms:
                  <input
                    type="number"
                    name="totalRooms"
                    value={room.totalRooms}
                    onChange={(e) => handleRoomInputChange(e, index)}
                  />
                </label>

                <label>
                  Size Of Room:
                  <input
                    type="number"
                    name="size"
                    value={room.size}
                    onChange={(e) => handleRoomInputChange(e, index)}
                  />
                </label>

                <label>
                  Bed Type :
                  <input
                    type="text"
                    name="bedType"
                    value={room.bedType}
                    onChange={(e) => handleRoomInputChange(e, index)}
                  />
                </label>

                <label>
                  Type 'AC/Non-AC':
                  <input
                    type="text"
                    name="type"
                    value={room.type}
                    onChange={(e) => handleRoomInputChange(e, index)}
                  />
                </label>


                <label>
                  Price :
                  <input
                    type="number"
                    name="type"
                    value={room.price}
                    onChange={(e) => handleRoomInputChange(e, index)}
                  />
                </label>

           <div>
              <h4>Room Amenities</h4>
              {room.roomAmenity.map((item, amenityIndex) => (
              <div key={amenityIndex}>
                <h5>Amenity: {amenityIndex + 1}</h5>
                <label>
                  Amenity Name:
                  <input
                    type="text"
                    name="name"
                    value={item.name}
                    onChange={(e) => handleAmenityInputChange(e, index, amenityIndex)}
                  />
                </label>
              </div>
            ))}
              <button type="button" onClick={() => handleAddAmenity(index)}>Add Room Amenity</button>
          </div>
            </div>
          ))}

          <button type="submit">Add Hotel</button>
          <button type="button" onClick={closeModal}>
            Close
          </button>
        </form>
      </div>
    </div>
  );
}

export default AddHotelModal;
