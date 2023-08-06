import 'bootstrap/dist/css/bootstrap.min.css';
import '@fortawesome/fontawesome-free/css/all.min.css';
import Hotel from "./Components/Hotel";
import Room from "./Components/Room";
import { BrowserRouter, Route, Routes} from 'react-router-dom';
import LandingPage from './Components/LandingPage';
import SearchForm from './Components/Mainbar';
import Packages from './Components/Packages';

function App() {
  return (
    <div>

      
      <BrowserRouter>
         <Routes>
         <Route path='/' element={<LandingPage/>}/>
           <Route path='/room/:id' element={<Room/>}/> 
           <Route path='/search' element={<SearchForm/>}/> 
           <Route path='/hotels' element={<Hotel/>}/>
           <Route path='/packages' element={<Packages/>}/>
         </Routes>
      </BrowserRouter> 
      
    </div>
  );
}

export default App;
