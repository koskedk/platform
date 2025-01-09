import { useEffect, useState } from "react";
import { Forecast } from "./Forecast";

function Weather(){
    const apiUrl = process.env.REACT_APP_API_URL;
    const [reports,setReports]=useState<Forecast[]>([])

     // Fetch data when the component mounts
  useEffect(() => {
    const fetchData = async () => {
        const response = await fetch(`${process.env.REACT_APP_API_URL}/WeatherForecast`); // Replace with your API URL
        const result:Forecast[] = await response.json();
        setReports(result); // Set the fetched data to state      
    }

    fetchData(); // Call the function to fetch data
  }, []);

    return (
        <div>
            <h1>Weather Forecast</h1>
            <hr/>
            {apiUrl}
            <ul>
            {reports.map((r)=>(
                <li>{r.date}, {r.temperatureC} C [{r.summary}]</li>
            ))}
            </ul>
        </div>
    )
}

export default Weather