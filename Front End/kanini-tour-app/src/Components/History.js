import React, { useState, useEffect } from "react";

function History() {
  const [input, setInput] = useState({ id: 3 });
  const [hotelBooking, setHotelBooking] = useState([]);
  const [packageBooking,setPackageBooking] =useState([]);

  useEffect(() => {
    fetchhotelBooking();
    fetchPackageBooking();
  }, [input]);

  const fetchhotelBooking = () => {
    fetch("https://localhost:7290/api/HotelBooking/GetAll Booking", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(input),
    })
      .then((response) => response.json())
      .then((data) => {
        setHotelBooking(data);
      })
      .catch((error) => console.log(error));
  };


  const fetchPackageBooking = () => {
    fetch("https://localhost:7290/api/PackageBooking/GetAll Booking", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(input),
    })
      .then((response) => response.json())
      .then((data) => {
        setPackageBooking(data);
      })
      .catch((error) => console.log(error));
  };

  return (
    <div>
        <h2>Hotel Booking History</h2>
      {hotelBooking.map((booking) => {
        return (
          <div key={booking.hotelId}>
            <div>
              <h3>Hotel Name: {booking.hotelName}</h3>
              <p>Room ID: {booking.roomId}</p>
              <p>User ID: {booking.userId}</p>
              <p>User Name: {booking.userName}</p>
              <p>Booking At: {booking.bookingAt}</p>
              <p>Check-In: {booking.checkIn}</p>
              <p>Check-Out: {booking.checkOut}</p>
              <p>Guests:</p>
              <ul>
                {booking.guests.map((guest, index) => (
                  <li key={index}>
                    Name: {guest.name}, Age: {guest.age}, Gender: {guest.gender}
                  </li>
                ))}
              </ul>
            </div>
            <hr />
          </div>
        );
      })}

      <h2>Package Bookings:</h2>
      {packageBooking.map((booking) => (
        <div key={booking.packgeId} className="card">
          <div>
            <h3>Package Name: {booking.packageName}</h3>
            <p>User ID: {booking.userId}</p>
            <p>User Name: {booking.userName}</p>
            <p>Booking At: {booking.bookingAt}</p>
            <p>Check-In: {booking.checkIn}</p>
            <p>Check-Out: {booking.checkOut}</p>
            <p>Guests:</p>
            <ul>
              {booking.guests.map((guest, index) => (
                <li key={index}>
                  Name: {guest.name}, Age: {guest.age}, Gender: {guest.gender}
                </li>
              ))}
            </ul>
          </div>
        </div>
      ))}



    </div>
  );
}

export default History;
