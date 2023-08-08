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
    

    const roomBookData = {
      hotelId: bookingDTO.hotelId,
      hotelName: bookingDTO.hotelName,
      roomId: bookingDTO.roomId,
      userId: 9,
      price: bookingDTO.price,
      userName: roomBook.userName,
      bookingAt: roomBook.bookingAt,
      checkIn: roomBook.checkIn,
      checkOut: roomBook.checkOut,
      guests: guests,
    };

    fetch("https://localhost:7290/api/HotelBooking/Book Hotel", {
      method: "POST",
      headers: {
      Accept: "application/json",
      "Content-Type": "application/json"
      },
      body: JSON.stringify(roomBookData)
      })
      .then(async (data)=>{
        if(data.status == 200)
        {
            var myData = await data.json();
            alert("susee");
            closeModal()
        }     
    })
    .catch(error => console.log(error));
    e.preventDefault();
  };

  useEffect(() => {

    const currentDate = new Date();
    const formattedDate = currentDate.toISOString().split('T')[0];
    const formattedTime = currentDate.toTimeString().split(' ')[0];
    setRoomBook((prevRoomBook) => ({
      ...prevRoomBook,
      bookingAt: `${formattedDate}T${formattedTime}`,
    }));
    setGuests((prevGuests) => {
      const newGuests = Array.from({ length: guestCount }, (_, index) =>
        index < prevGuests.length ? prevGuests[index] : { ...initialGuest }
      );
      return newGuests;
    });
  }, [guestCount]);

  const addGuest = () => {
    setGuests([...guests, { name: '', age: '', gender: '' }]);
  };



  return (
    <div className='book'>
    <div className="container mt-5">
    <div className="row justify-content-center">
      <div className="col-lg-8">
        <div className="book">
          <div className="popup">
            <div className="popup-inner p-4">
              <h2 className="mb-4">Room Booking</h2>
              <br></br>
              <div className="row">
                <div className="col-lg-6">
                  <form onSubmit={handleSubmit}>
                    {/* Username */}
                    <div className="mb-3">
                      <label htmlFor="userName" className="form-label">
                        Username:
                      </label>
                      <input
                        type="text"
                        id="userName"
                        className="form-control"
                        value={roomBook.userName}
                        onChange={(e) =>
                          setRoomBook({ ...roomBook, userName: e.target.value })
                        }
                      />
                    </div>

                    {/* Check-in */}
                    <div className="mb-3">
                      <label htmlFor="checkIn" className="form-label">
                        Check-in:
                      </label>
                      <input
                        type="date"
                        id="checkIn"
                        className="form-control"
                        value={roomBook.checkIn}
                        onChange={(e) =>
                          setRoomBook({ ...roomBook, checkIn: e.target.value })
                        }
                      />
                    </div>

                    {/* Checkout */}
                    <div className="mb-3">
                      <label htmlFor="checkOut" className="form-label">
                        Checkout:
                      </label>
                      <input
                        type="date"
                        id="checkOut"
                        className="form-control"
                        value={roomBook.checkOut}
                        onChange={(e) =>
                          setRoomBook({ ...roomBook, checkOut: e.target.value })
                        }
                      />
                    </div>


                    <div className="d-flex justify-content-center">
                      <button type="submit" className="btn btn-primary me-2">
                        Book
                      </button>
                      <button
                        type="button"
                        className="btn btn-secondary"
                        onClick={closeModal}>
                        Close
                      </button>
                    </div>
                  </form>
                </div>

                <div className="col-lg-6">
                  {guests.map((guest, index) => (
                    <div key={index} className="mb-4">
                      <h3 className="mb-3">Guest {index + 1}</h3>
                      <div className="mb-2">
                        <label htmlFor={`name${index}`} className="form-label">
                          Name:
                        </label>
                        <input
                          type="text"
                          id={`name${index}`}
                          className="form-control"
                          value={guest.name}
                          onChange={(e) => {
                            const updatedGuests = [...guests];
                            updatedGuests[index].name = e.target.value;
                            setGuests(updatedGuests);
                          }}
                        />
                      </div>

                      <div className="mb-2">
                        <label htmlFor={`age${index}`} className="form-label">
                          Age:
                        </label>
                        <input
                          type="number"
                          id={`age${index}`}
                          className="form-control"
                          value={guest.age}
                          onChange={(e) => {
                            const updatedGuests = [...guests];
                            updatedGuests[index].age = parseInt(e.target.value);
                            setGuests(updatedGuests);
                          }}
                        />
                      </div>

                      <div className="mb-2">
                        <label htmlFor={`gender${index}`} className="form-label">
                          Gender:
                        </label>
                        <input
                          type="text"
                          id={`gender${index}`}
                          className="form-control"
                          value={guest.gender}
                          onChange={(e) => {
                            const updatedGuests = [...guests];
                            updatedGuests[index].gender = e.target.value;
                            setGuests(updatedGuests);
                          }}
                        />
                      </div>
                    </div>
                  ))}
                  <div className="d-flex justify-content-center">
                    <button type="button" className="btn btn-primary" onClick={addGuest}>
                      Add Guest
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  </div>
  );
}

export default BookingModal;


