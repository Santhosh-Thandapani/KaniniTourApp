import { useEffect, useState } from "react";
import { useNavigate } from 'react-router';
import PackageAddModal from "../AddPackageModal/PackageAddModal";
import './Packages.css';
import NavbarHome from "../NavbarHome/NavbarHome";
  


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

  const isAgent = () => {
    const role = localStorage.getItem("role");
   // return role === "agent";
   return true;
  };


  useEffect(() => {
    fetchPackages();
  },[requestBody,openAddModal]);


  return (
    <div>
    <NavbarHome/>


         <div className="add-icon-container">
            {isAgent    () && (
              <i class="fa-solid fa-plus fa-beat fa-2xl" onClick={() => setOpenAddModal(true)}></i>
            )}
          </div>
  
      {openAddModal && <PackageAddModal closeModal={setOpenAddModal}/>} 

    <div className="row row-cols-1 row-cols-md-4 g-4" >
      {packages.map(getPackage => (
        <div className="flip-card-container"key={getPackage.id}>
        
          <div className="flip-card" onClick={() =>{changeId(getPackage.id)}}>
            <div className="card-front">
              <figure>
                <div className="img-bg"></div>
                <img src="https://images.unsplash.com/photo-1486162928267-e6274cb3106f?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60" alt="Brohm Lake"/>
                <figcaption><h2>{getPackage.packageName}</h2></figcaption>
              </figure>

              <ul>
                <li><strong>{getPackage.daysCount}Days / {getPackage.nightsCount}Nights</strong></li>
                <li>{getPackage.city}</li>
                <li>{getPackage.state}</li>
                <li>{getPackage.country}</li>
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
         ))}
     </div> 
    </div>
  );
}

export default Packages;
