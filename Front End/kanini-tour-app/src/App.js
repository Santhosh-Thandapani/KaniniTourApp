import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import '@fortawesome/fontawesome-free/css/all.min.css';
import Hotel from "./Components/Hotel";
import Room from "./Components/Room";
import { BrowserRouter, Route, Routes} from 'react-router-dom';
import LandingPage from './Components/LandingPage';
import Packages from './Components/Packages';
import AdminHome from './Components/AdminPage';
import PackageDetail from './Components/PackageDetail';
import Profile from './Components/Profile';
import History from './Components/History';
import AddHotelModal from './Components/AddHotelModal';
import ViewHotelReview from './Components/ViewHotelReview';
import Sample from './Components/Sample';

function App() {
  return (
    <div>

      
      <BrowserRouter>
         <Routes>
           <Route path='/' element={<LandingPage/>}/>
           <Route path='adminHome' element={<AdminHome/>}/>
           <Route path='/room/:id' element={<Room/>}/> 
           <Route path='/package/:id' element={<PackageDetail/>}/>
           <Route path='/hotels' element={<Hotel/>}/>
           <Route path='/packages' element={<Packages/>}/>
           <Route path='/profile' element={<Profile/>}/>
           <Route path='/history' element={<History/>}/>
           <Route path='/addhotel' element={<AddHotelModal/>}/>
           <Route path='/review' element={<ViewHotelReview/>}/>
           <Route path='/sample' element={<Sample/>}/>
         </Routes>
      </BrowserRouter> 
      
    </div>
  );
}

export default App;
