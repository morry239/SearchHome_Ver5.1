import {getDataHorsensHistorical} from './fetcher.js';
async function showHorsensHistoricalData() {
    try {
        const horsensLast24Hours = await getDataHorsensHistorical(); // Fetch data here

        // Create a new HTML page dynamically
        const newPage = window.open('newPage.html', '_blank');
        newPage.document.open();
        newPage.document.write('<html><head><title>New Page</title></head><body>');

        // Display fetched data on the new page
        const horsensTable = document.createElement('table');
        horsensLast24Hours.forEach((value, key) => {
            const newRow = document.createElement('tr');
            const cell1 = document.createElement('td');
            cell1.textContent = value;
            newRow.appendChild(cell1);
            horsensTable.appendChild(newRow);
        });
        newPage.document.write('<h1>Data Loaded:</h1>');
        newPage.document.body.appendChild(horsensTable);

        newPage.document.write('</body></html>');
        newPage.document.close();
    } catch (error) {
        console.error('Error:', error);
    }
}