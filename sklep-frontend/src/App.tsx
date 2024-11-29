import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import routes from "./utils/router";  
import TopNavbar from "./components/topnav";

export default function App() {
  return (
    <Router>
      <TopNavbar />
      <Routes>
        {routes.map((route, index) => (
          <Route key={index} path={route.path} element={route.element} />
        ))}
      </Routes>
    </Router>
  );
}
