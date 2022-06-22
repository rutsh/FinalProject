import './App.css';
import React, { Suspense } from 'react';
import { Routes, Route, Link } from 'react-router-dom';
import { RecoilRoot } from "recoil";
import { SignIn } from "./Screens/ScreenA/SignIn";
import SignUp from './Screens/ScreenB/SignUp';
import { FormDialog } from './Screens/ScreenC/FixedExpense';


function App() {
  
  return (
    <div>
      <RecoilRoot>
        <Suspense fallback={<h4>Loading...</h4>} >
         <Routes>
            <Route path="" element={SignIn()} />
            <Route path="/SignUp" element={SignUp()}/>
            <Route path="/FixedExpense" element={FormDialog()}/>
          
         </Routes>
        </Suspense>
      
        </RecoilRoot>
    </div>
  );
}

export default App;
