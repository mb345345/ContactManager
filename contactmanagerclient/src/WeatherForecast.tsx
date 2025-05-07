import { useEffect, useState } from 'react';
import axios from 'axios';

interface Forecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

function WeatherForecast() {
  const [forecasts, setForecasts] = useState<Forecast[]>([]);

  useEffect(() => {
    axios.get<Forecast[]>('https://localhost:7183/weatherforecast')
      .then(response => setForecasts(response.data))
      .catch(error => console.error('Error fetching weather data:', error));
  }, []);

  return (
    <div>
      <h2>Weather Forecast</h2>
      <ul>
        {forecasts.map((forecast, index) => (
          <li key={index}>
            {forecast.date} - {forecast.summary} - {forecast.temperatureC}°C
          </li>
        ))}
      </ul>
    </div>
  );
}

export default WeatherForecast;
