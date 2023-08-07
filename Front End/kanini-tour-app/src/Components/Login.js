import React, { useState } from 'react';
import './Login.css';
import ForgetPassword from './ForgetPassword';

function Login({ closeLoginModal }) {
  const [login, setLogin] = useState({
    phoneNumber: "",
    password: "",
  });

  const handleSubmit = (e) => {
    
    fetch("https://localhost:7077/api/EndUser/Login", {
      method: "POST",
      headers: {
      Accept: "application/json",
      "Content-Type": "application/json"
      },
      body: JSON.stringify(login)
      })
      .then(async (data)=>{
        if(data.status == 200)
        {
            var myData = await data.json();
            localStorage.setItem("userId",myData.userId);
            localStorage.setItem("role",myData.role);
            localStorage.setItem("status",myData.status);
            localStorage.setItem("token",myData.token);
            closeLoginModal()
        }     
    })
    .catch(error => console.log(error));

    e.preventDefault();
  };

  //open Forget Password popup:
  const [forgetPopUp, setForgetPopUp] = useState(false);
  const handleForgetOpen = () => {
    setForgetPopUp(true);
  };
  const handleForgetClose = () => {
    setForgetPopUp(false);
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setLogin((prevLogin) => ({
      ...prevLogin,
      [name]: value,
    }));
  };
  

  return (
    <div className="popup">
      <div className="popup-inner">
        <h2>Login</h2>
        <form onSubmit={handleSubmit}>
         
          <label>
            Phone Number:
            <input type="text" name="phoneNumber" value={login.phoneNumber} onChange={handleInputChange} />
          </label>
          
          <label>
            Password:
            <input type="password"  name="password"  value={login.password} onChange={handleInputChange} />
          </label>
          
          <button type="submit">Login</button>
          <button onClick={() => closeLoginModal()}>Close</button>
          <br/>
          <a onClick={handleForgetOpen}>Forget Password</a>
        </form>

        {forgetPopUp && <ForgetPassword closeModal={handleForgetClose} />}
      </div>
    </div>
  );
}

export default Login;
