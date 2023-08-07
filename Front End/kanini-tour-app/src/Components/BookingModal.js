import React, { useState ,useEffect } from 'react';
import './BookingModal.css';

function BookingModal({closeModal,bookingDTO }) {


  const [roomBook, setRoomBook] = useState({
    "hotelId": bookingDTO.hotelId,
    "hotelName": bookingDTO.hotelName,
    "roomId": bookingDTO.roomId,
    "userId": 0,
    "price": 0,
    "userName": "",
    "bookingAt": "",
    "checkIn": "",
    "checkOut": "",
    "guests": [
      {
        "name": "",
        "age": 0,
        "gender": ""
      }
    ]
  });

  const initialGuest = { name: '', age: 0, gender: '' };
  // const initialGuestCount = parseInt(localStorage.getItem('guestCount')) || 1;
  const initialGuestCount=1

  const [guestCount, setGuestCount] = useState(initialGuestCount);
  const [guests, setGuests] = useState(Array.from({ length: initialGuestCount }, () => ({ ...initialGuest })));



  
  const handleSubmit = (e) => {
    
    e.preventDefault();
    const roomBookData = {
      hotelId: bookingDTO.hotelId,
      hotelName: bookingDTO.hotelName,
      roomId: bookingDTO.roomId,
      userId: 0,
      price: 0,
      userName: roomBook.userName,
      bookingAt: roomBook.bookingAt,
      checkIn: roomBook.checkIn,
      checkOut: roomBook.checkOut,
      guests: guests,
    };
    console.log(roomBookData);
  };

  useEffect(() => {
    // Update localStorage when guestCount changes
    // localStorage.setItem('guestCount', guestCount);
    setGuests((prevGuests) => {
      const newGuests = Array.from({ length: guestCount }, (_, index) =>
        index < prevGuests.length ? prevGuests[index] : { ...initialGuest }
      );
      return newGuests;
    });
  }, [guestCount]);



  return (
    <div className='User'>

      <div className="popup">
        <div className="popup-inner">

        <p>Hotel Name: {bookingDTO.Id}</p>
          <h2>Room Booking</h2>
          <form onSubmit={handleSubmit}>

             {/* Username */}
             <label>
              Username:
              <input
                type="text"
                value={roomBook.userName}
                onChange={(e) => setRoomBook({ ...roomBook, userName: e.target.value })}
              />
            </label>

            {/* Check-in */}
            <label>
              checkIn:
              <input
                type="date"
                value={roomBook.checkIn}
                onChange={(e) => setRoomBook({ ...roomBook, checkIn: e.target.value })}
              />
            </label>

            {/* Checkout */}
            <label>
              Checkout:
              <input
                type="date"
                value={roomBook.checkOut}
                onChange={(e) => setRoomBook({ ...roomBook, checkOut: e.target.value })}
              />
            </label>

            {/* BookingAt */}
            <label>
              BookingAt:
              <input
                type="date"
                value={roomBook.bookingAt}
                onChange={(e) => setRoomBook({ ...roomBook, bookingAt: e.target.value })}
              />
            </label>

               {guests.map((guest, index) => (
              <div key={index}>
                <h3>Guest {index + 1}</h3>
                <label>
                  Name:
                  <input
                    type="text"
                    value={guest.name}
                    onChange={(e) => {
                      const updatedGuests = [...guests];
                      updatedGuests[index].name = e.target.value;
                      setGuests(updatedGuests);
                    }}
                  />
                </label>

                <label>
                  Age:
                  <input
                    type="number"
                    value={guest.age}
                    onChange={(e) => {
                      const updatedGuests = [...guests];
                      updatedGuests[index].age = parseInt(e.target.value);
                      setGuests(updatedGuests);
                    }}
                  />
                </label>

                <label>
                  Gender:
                  <input
                    type="text"
                    value={guest.gender}
                    onChange={(e) => {
                      const updatedGuests = [...guests];
                      updatedGuests[index].gender = e.target.value;
                      setGuests(updatedGuests);
                    }}
                  />
                </label>
              </div>
            ))}
           

            <button type="submit">Book</button>
            <button onClick={() => closeModal()}>Close</button>
          </form>
        </div>
      </div>
    </div>
  );
}

export default BookingModal;


