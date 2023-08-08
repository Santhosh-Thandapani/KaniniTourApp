import React, { useState, useEffect } from 'react';
import './Bookingpackge.css'

function BookingPackage({ closeModal, bookingDTO }) {

  const [roomPackage, setRoomPackage] = useState({
    packageId: bookingDTO.Id,
    packageName: bookingDTO.packageName,
    roomId: bookingDTO.roomId,
    userId: 0,
    price: bookingDTO.roomId,
    userName: '',
    bookingAt: '',
    checkIn: '',
    checkOut: '',
    guests: [
      {
        name: '',
        age: 0,
        gender: '',
      },
    ],
  });

  const initialGuest = { name: '', age: 0, gender: '' };
  const initialGuestCount = 1;

  const [guestCount, setGuestCount] = useState(initialGuestCount);
  const [guests, setGuests] = useState(Array.from({ length: initialGuestCount }, () => ({ ...initialGuest })));

  

  useEffect(() => {

    const currentDate = new Date();
    const formattedDate = currentDate.toISOString().split('T')[0];
    const formattedTime = currentDate.toTimeString().split(' ')[0];
    setRoomPackage((prevRoomBook) => ({
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



  const handleSubmit = (e) => {
    

    const packageBookData = {
      packageId: bookingDTO.hotelId,
      packageName: bookingDTO.hotelName,
      packageId: bookingDTO.roomId,
      userId: 9,
      price: bookingDTO.price,
      userName: roomPackage.userName,
      bookingAt: roomPackage.bookingAt,
      checkIn: roomPackage.checkIn,
      checkOut: roomPackage.checkOut,
      guests: guests,
    };
    console.log(packageBookData);

    fetch("https://localhost:7290/api/HotelBooking/Book Hotel", {
      method: "POST",
      headers: {
      Accept: "application/json",
      "Content-Type": "application/json"
      },
      body: JSON.stringify(packageBookData)
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


  return (
    <div className='package'>
      <div className='container mt-5'>
        <div className='row justify-content-center'>
          <div className='col-lg-8'>
            <div className='package-popup'>
              <div className='popup-inner p-4'>
                <h2 className='mb-4'>Package Booking</h2>
                <br />
                <div className='row'>
                  <div className='col-lg-6'>
                    <form onSubmit={handleSubmit}>
                      {/* Username */}
                      <div className='mb-3'>
                        <label htmlFor='userName' className='form-label'>
                          Username:
                        </label>
                        <input
                          type='text'
                          id='userName'
                          className='form-control'
                          value={roomPackage.userName}
                          onChange={(e) => setRoomPackage({ ...roomPackage, userName: e.target.value })}
                        />
                      </div>

                      {/* Check-in */}
                      <div className='mb-3'>
                        <label htmlFor='checkIn' className='form-label'>
                          Check-in:
                        </label>
                        <input
                          type='date'
                          id='checkIn'
                          className='form-control'
                          value={roomPackage.checkIn}
                          onChange={(e) => setRoomPackage({ ...roomPackage, checkIn: e.target.value })}
                        />
                      </div>

                      {/* Checkout */}
                      <div className='mb-3'>
                        <label htmlFor='checkOut' className='form-label'>
                          Checkout:
                        </label>
                        <input
                          type='date'
                          id='checkOut'
                          className='form-control'
                          value={roomPackage.checkOut}
                          onChange={(e) => setRoomPackage({ ...roomPackage, checkOut: e.target.value })}
                        />
                      </div>
                    </form>
                  </div>

                  <div className='col-lg-6'>
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
                    <div className='d-flex justify-content-center'>
                      <button type='button' className='btn btn-primary' onClick={addGuest}>
                        Add Guest
                      </button>
                    </div>
                  </div>
                </div>
                <div className='kk'></div>
                <div className='d-flex justify-content-center mt-4'>
                  {/* Center the Book and Cancel buttons */}
                  <button type='submit' className='btn btn-primary me-2'>
                    Book
                  </button>
                  <button type='button' className='btn btn-secondary' onClick={closeModal}>
                    Cancel
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default BookingPackage;
