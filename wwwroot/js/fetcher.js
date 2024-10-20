import {Temperature,Event} from './model.js';

export async function getDataHorsensHistorical() {
    const horsensDataMap = new Map(); // Create a Map to group data by time
    try {
        const response = await fetch('/api/API/availableListings', { method: 'GET' });
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status} - ${response.statusText}`);
        }
        const data = await response.json();
        const plainData = require('/Users/mamikawamura/RiderProjects/WebApplication1/SearchHome/wwwroot/availableListings.json');
        //console.log(data)
        
        let propertyNameArr = Object.entries(plainData);
        console.log(propertyNameArr);

        for (const row of propertyNameArr) {
            const clientname = row?.property_name;
            console.log(clientname);
            const time = row.time;
            const type = row.type;
            const value = row.value;
            const unit = row.unit;
            const place = row.place;
           
            const direction = row.direction;

            // console.log(row.time)

            // Create a new WeatherData object
            const weatherData = new WeatherData(value, type, unit, new Event(time, place), direction, precipitationType);

            if (!horsensDataMap.has(time)) {
                // If the time entry doesn't exist in the Map, create a new entry
                horsensDataMap.set(time, {
                    temperature: [],
                    windSpeed: [],
                    precipitation: [],
                    cloudCoverage: [],
                });
            }

            // Push the data to the respective arrays based on type
            switch (type) {
                case 'temperature':
                    let temp = new Temperature(weatherData);
                    horsensDataMap.get(time).temperature.push(temp.toString());
                    break;
                case 'precipitation':
                    let precipitation = new Precipitation(weatherData);
                    horsensDataMap.get(time).precipitation.push(precipitation.toString());
                    break;
                case 'wind speed':
                    let windSpeed = new Wind(weatherData);
                    horsensDataMap.get(time).windSpeed.push(windSpeed.toString());
                    break;
                case 'cloud coverage':
                    let cloudCoverage = new CloudCoverage(weatherData);
                    horsensDataMap.get(time).cloudCoverage.push(cloudCoverage.toString());
                    break;
            }
        }
        
        

        let horsensData = []

        horsensDataMap.forEach((value, key) => {

            const date  = new Date(key)

            const day = date.getDate();
            const month = date.getMonth() + 1; // Months are zero-based, so add 1
            const year = date.getFullYear();

            const daysOfWeek = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
            const dayOfWeek = daysOfWeek[date.getDay()];

            const formattedDate = `${day}/${month}/${year}`;

            const hours = date.getHours().toString().padStart(2, '0'); // Ensure two digits
            const minutes = date.getMinutes().toString().padStart(2, '0'); // Ensure two digits


            let tempval = dayOfWeek + ", " + formattedDate + " "+hours+":"+minutes+ "---" + value['temperature'] +" "+ value['windSpeed'] +" "+ value['precipitation'] +" "+ value['cloudCoverage'];

            horsensData.push(tempval)
        });

        return horsensData;
    } catch (error) {
        console.error('Error:', error);
    }
}
