import React, { useState } from 'react';
import './AgentRegister.css';

function AgentRegister({ closeAgentModal }) {
  const [register, setRegister] = useState({
    "user": {
      "phoneNo": ""
    },
    "name": "",
    "dateOfBirth": "",
    "age": 0,
    "gender": "",
    "email": "",
    "picture": "",
    "address": "",
    "passwordClear": ""
  });

  const handleSubmit = (e) => {
    fetch("https://localhost:7077/api/EndUser/TourAgent Register", {
        method: "POST",
        headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
        },
        body: JSON.stringify(register)
        })
        .then(async (data)=>{
            console.log(register)
          if(data.status == 200)
          {
              var myData = await data.json();
              localStorage.setItem("userId",myData.userId);
              localStorage.setItem("role",myData.role);
              localStorage.setItem("status",myData.status);
              localStorage.setItem("token",myData.token);
              closeAgentModal()
          }     
      })
      .catch(error => console.log(error));
      e.preventDefault();
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;

    // Check if the field is "user.phoneNo"
    if (name.includes('.')) {
      const [nestedObj, nestedField] = name.split('.');

      setRegister((prevRegister) => ({
        ...prevRegister,
        [nestedObj]: {
          ...prevRegister[nestedObj],
          [nestedField]: value,
        },
      }));
    } else {
      setRegister((prevRegister) => ({
        ...prevRegister,
        [name]: value,
      }));
    }
  };

  return (
    <div className='agent'>
    <div className="popup">
      <div className="popup-inner">
        <h2>Agent Register</h2>
        <form onSubmit={handleSubmit}>
          <div className="form-row">
            <div className="form-column">
              <div className="form-column-inner">
                <label>
                  Username:
                  <input type="text" name="name" value={register.name} onChange={handleInputChange} />
                </label>

                <label>
                  Date of Birth:
                  <input type="date" name="dateOfBirth" value={register.dateOfBirth} onChange={handleInputChange} />
                </label>

                <label>
                  Gender:
                  <input type="text" name="gender" value={register.gender} onChange={handleInputChange} />
                </label>

                <label>
                  Phone Number:
                  <input type="text" name="user.phoneNo" value={register.user.phoneNo} onChange={handleInputChange} />
                </label>
              </div>
            </div>

            <div className="form-column">
              <div className="form-column-inner">
                <label>
                  Profile Picture:
                  <input type="text" name="picture" value={register.picture} onChange={handleInputChange} />
                </label>

                <label>
                  Email:
                  <input type="email" name="email" value={register.email} onChange={handleInputChange} />
                </label>

                <label>
                  Address:
                  <input type="text" name="address" value={register.address} onChange={handleInputChange} />
                </label>

                <label>
                  Password:
                  <input type="password" name="password" value={register.password} onChange={handleInputChange} />
                </label>
              </div>
            </div>
          </div>

          <div className="form-buttons">
            <button type="submit">Register</button>
            <button type="button" onClick={closeAgentModal}>Close</button>
          </div>
        </form>
      </div>
    </div>
  </div>
  );
}

export default AgentRegister;
