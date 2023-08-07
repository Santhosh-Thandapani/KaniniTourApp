import { useState ,useEffect } from "react";
import './Profile.css';
function Profile(){

    const [input, setInput] = useState({ id: 3 });
    const [user,setUser]=useState();
          
    useEffect(()=>{
        fetchUser();
      },[input])

      const myInlineStyle = {
        visibility: 'visible',
        animationDelay: '0.2s',
        animationName: 'fadeInUp',
      };

    const fetchUser = () => {
        fetch("https://localhost:7077/api/EndUser/Passenger Profile", {
            method: "POST",
            headers: {
            Accept: "application/json",
            "Content-Type": "application/json"
            },
            body: JSON.stringify(input)
        })
            .then(response => response.json())
            .then(data => {
                setUser(data);
                console.log(data);
            })
            .catch(error => console.log(error));
         }


    return (
        <div>
    <section className="my-background-radial-gradient overflow-hidden">
      <div className="my-doctors-container container">
        <div className="my-page-heading">
          <h2> User Details</h2>
        </div>
        <hr />
        {user ? (
          <div className="row row-cols-1 row-cols-md-4 g-4">
            <div className="col">
              <div className="card shadow">
                <div className="card-body">
                  <br />
                  <h3 className="card-title"><strong>{user.name}</strong></h3>
                  <p className="card-text">Age: {user.age}</p>
                  <p className="card-text">Gender: {user.gender}</p>
                  <p className="card-text">Address: {user.address}</p>
                  <p className="card-text">Email: {user.email}</p>
                </div>
              </div>
            </div>
          </div>
        ) : (
          <p>Loading...</p>
        )}
      </div>
    </section>





    <div class="container">
        <div class="row justify-content-center">
          <div class="col-12 col-sm-8 col-lg-6">
            <div class="section_heading text-center wow fadeInUp" data-wow-delay="0.2s" style={myInlineStyle}>
              <h3>Our Creative <span> Team</span></h3>
              <p>Appland is completely creative, lightweight, clean &amp; super responsive app landing page.</p>
              <div class="line"></div>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-12 col-sm-6 col-lg-3">
            <div class="single_advisor_profile wow fadeInUp" data-wow-delay="0.2s" style={myInlineStyle}>
              <div class="advisor_thumb"><img src="https://bootdey.com/img/Content/avatar/avatar1.png" alt=""/>
                <div class="social-info"><a href="#"><i class="fa fa-facebook"></i></a><a href="#"><i class="fa fa-twitter"></i></a><a href="#"><i class="fa fa-linkedin"></i></a></div>
              </div>
              <div class="single_advisor_details_info">
                <h6>Samantha Sarah</h6>
                <p class="designation">Founder &amp; CEO</p>
              </div>
            </div>
          </div>
          <div class="col-12 col-sm-6 col-lg-3">
            <div class="single_advisor_profile wow fadeInUp" data-wow-delay="0.3s" style={myInlineStyle}>
              <div class="advisor_thumb"><img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt=""/>
                <div class="social-info"><a href="#"><i class="fa fa-facebook"></i></a><a href="#"><i class="fa fa-twitter"></i></a><a href="#"><i class="fa fa-linkedin"></i></a></div>
              </div>
              <div class="single_advisor_details_info">
                <h6>Nazrul Islam</h6>
                <p class="designation">UI Designer</p>
              </div>
            </div>
          </div>
          <div class="col-12 col-sm-6 col-lg-3">
            <div class="single_advisor_profile wow fadeInUp" data-wow-delay="0.4s" style={myInlineStyle}>
              <div class="advisor_thumb"><img src="https://bootdey.com/img/Content/avatar/avatar6.png" alt=""/>
                <div class="social-info"><a href="#"><i class="fa fa-facebook"></i></a><a href="#"><i class="fa fa-twitter"></i></a><a href="#"><i class="fa fa-linkedin"></i></a></div>
              </div>
              <div class="single_advisor_details_info">
                <h6>Riyadh Khan</h6>
                <p class="designation">Developer</p>
              </div>
            </div>
          </div>
          <div class="col-12 col-sm-6 col-lg-3">
            <div class="single_advisor_profile wow fadeInUp" data-wow-delay="0.5s" style={myInlineStyle}>
              <div class="advisor_thumb"><img src="https://bootdey.com/img/Content/avatar/avatar2.png" alt=""/>
                <div class="social-info"><a href="#"><i class="fa fa-facebook"></i></a><a href="#"><i class="fa fa-twitter"></i></a><a href="#"><i class="fa fa-linkedin"></i></a></div>
              </div>
              <div class="single_advisor_details_info">
                <h6>Niloy Islam</h6>
                <p class="designation">Marketing Manager</p>
              </div>
            </div>
          </div>
        </div>
      </div>








  </div>
    )
}
export default Profile;



    