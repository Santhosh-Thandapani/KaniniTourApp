import React, { useState } from 'react';
import './UserRegister.css';

function UserRegister({ closeLoginModal }) {
  const [register, setRegister] = useState({
    "user": {
      "phoneNo": ""
    },
    "name": "",
    "age": 0,
    "gender": "",
    "email": "",
    "address": "",
    "passwordClear": ""
  });

  const handleSubmit = (e) => {
    e.preventDefault();
    // Add your logic here for handling form submission
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
    <div className='User'>
      <div className="popup">
        <div className="popup-inner">
          <h2>Login</h2>
          <form onSubmit={handleSubmit}>
            <label>
              Username:
              <input type="text" name="name" value={register.name} onChange={handleInputChange} />
            </label>

            <label>
              Age:
              {/* <input type="number" name="age" value={register.age} onChange={handleInputChange} /> */}
              <input type="number"  
                onChange={(event) => {
                    setRegister({ ...register, age:Number(event.target.value) });
                      }}/>
            </label>

            <label>
              Gender:
              <input type="text" name="gender" value={register.gender} onChange={handleInputChange} />
            </label>

            <label>
              Email:
              <input type="email" name="email" value={register.email} onChange={handleInputChange} />
            </label>

            <label>
              Phone Number:
              {/* <input type="text" name="user.phoneNo" value={register.user.phoneNo} onChange={handleInputChange} /> */}
              <input
                    type="text"
                    value={register.user.phoneNo}
                    onChange={(event) => {
                        setRegister((prevRegister) => ({
                        ...prevRegister,
                        user: {
                            ...prevRegister.user,
                            phoneNo: event.target.value
                        }
                        }));
                    }}
                    />
            </label>

            <label>
              Address:
              <input type="text" name="address" value={register.address} onChange={handleInputChange} />
            </label>

            <label>
              Password:
              <input type="password" name="password" value={register.password} onChange={handleInputChange} />
            </label>

            <button type="submit" onClick={() => { console.log(register) }}>Register</button>
            <button onClick={() => closeLoginModal()}>Close</button>
          </form>
        </div>
      </div>
    </div>
  );
}

export default UserRegister;
