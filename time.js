import "./styles.css";
import { React, useState, useEffect } from "react";

export default function App() {
  var [sec, setSec] = useState(0);
  var [min, setMin] = useState(0);

  useEffect(() => {
    const interval = setInterval(() => {
      if (sec === 59) setMin((min) => min + 1);
      setSec((sec) => (sec + 1) % 60);
    }, 1000);
    return () => clearInterval(interval);
  }, [sec]);
  return (
    <div className="App">
      00:{String(min).padStart(2, "0")}:{String(sec).padStart(2, "0")}
    </div>
  );
}