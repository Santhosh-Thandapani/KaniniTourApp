import { useEffect, useState } from "react";
import { useNavigate } from 'react-router';
import PackageAddModal from "./PackageAddModal";
import './Packages.css';
  


function Packages() {
  const [packages, setPackages] = useState([]);

  const[openAddModal,setOpenAddModal]=useState(false);

  const navigate = useNavigate();
  const [requestBody, setSequestBody] = useState({
    "id": 0
  });

  const changeId = (id) => {
    setSequestBody({ ...requestBody, id: id });
    navigate(`/package/${id}`);
  };

  const fetchPackages = () => {
    fetch('https://localhost:7118/api/Package/GetAllPackage')
      .then(response => response.json())
      .then(data => {
        console.log(data)
        setPackages(data);
      })
      .catch(error => console.log(error));
  };

  useEffect(() => {
    fetchPackages();
  },[requestBody,openAddModal]);


  return (
    <div>
      
      <section className="my-background-radial-gradient overflow-hidden">
        <div className="my-doctors-container container">
          <div className="my-page-heading">
            <h2> Package Details</h2>
          </div>
          <hr></hr>
          <div className="row row-cols-1 row-cols-md-4 g-4" >
            {packages.map(getPackage => (
              <div key={getPackage.id} className="col">
                <div className="card shadow">
                  <div className="card-body" onClick={() =>{changeId(getPackage.id)}}>
                    <br />
                    <h3 className="card-title"><strong>{getPackage.packageName}</strong></h3>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
      </section>

      <br/>

      <button className="addButton" 
        onClick={()=>{
          setOpenAddModal(true)}}>
      Add</button>
  
      {openAddModal && <PackageAddModal closeModal={setOpenAddModal}/>} 


       {/* ----------------------------------------------------
        --------------------StartFlip -------------------------*/}

        <div className="flip-card-container">
          <div className="flip-card">

            <div className="card-front">
              <figure>
                <div className="img-bg"></div>
                <img src="https://images.unsplash.com/photo-1486162928267-e6274cb3106f?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60" alt="Brohm Lake"/>
                <figcaption>Brohm Lake</figcaption>
              </figure>

              <ul>
                <li>Detail 1</li>
                <li>Detail 2</li>
                <li>Detail 3</li>
                <li>Detail 4</li>
                <li>Detail 5</li>
              </ul>
            </div>

            <div className="card-back">
              <figure>
                <div className="img-bg"></div>
                <img src="https://images.unsplash.com/photo-1486162928267-e6274cb3106f?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60" alt="Brohm Lake"/>
              </figure>

              <button>Book</button>

              <div className="design-container">
                <span className="design design--1"></span>
                <span className="design design--2"></span>
                <span className="design design--3"></span>
                <span className="design design--4"></span>
                <span className="design design--5"></span>
                <span className="design design--6"></span>
                <span className="design design--7"></span>
                <span className="design design--8"></span>
              </div>
            </div>

          </div>
        </div>
        {/* ----------------------------------------------------
        --------------------end Flip -------------------------*/}
 
    </div>
  );
}

export default Packages;
