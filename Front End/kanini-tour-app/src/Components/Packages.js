import { useEffect, useState } from "react";
import { useNavigate } from 'react-router';
  


function Packages() {
  const [packages, setPackages] = useState([]);
  const navigate = useNavigate();
  const [requestBody, setSequestBody] = useState({
    "id": 0
  });

  const changeId = (id) => {
    setSequestBody({ ...requestBody, id: id });
    navigate(`/room/${id}`);
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
  },[requestBody]);


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
    </div>
  );
}

export default Packages;
