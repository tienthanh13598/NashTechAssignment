import React, { lazy, Suspense } from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
 
} from "react-router-dom";

const Createproduct=lazy(()=>import('./components/createproduct'));
const Detailproduct=lazy(()=>import('./components/detailproduct'));
const Listproduct=lazy(()=>import('./components/listproduct'));

function App() {
  return(
    <Router>
    <ul>
      <li>
        <Link to="/">List product</Link>
      </li>
      <li>
      <Link to="/detailproduct">Detail product</Link>
      </li>
      <li>
      <Link to="/createproduct">Create product</Link>
      </li>
    </ul>
    
      <Suspense fallback={<div>Please wait for loading...</div>}>
      <Switch>
        <Route exact path="/" component={Listproduct}></Route>
        <Route  path="/detailproduct" component={Detailproduct}></Route>
        <Route  path="/createproduct" component={Createproduct}></Route>
      </Switch>
      </Suspense>
    
    
   
  </Router>
  )
  
}

export default App;
