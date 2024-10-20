async function fetchData() {
    try {
        const response = await fetch('/api/API/availableListings');
        if (!response.ok) {
            throw new Error(`Error fetching data: ${response.status}`);
        }
        const data = await response.json();
        displayData(data);
    } catch (error) {
        console.error('Error:', error);
        document.getElementById('listings-container').innerHTML = `<p>Error loading listings: ${error.message}</p>`;
    }
}

function displayData(data) {
    const listingsContainer = document.getElementById('listings-container');
    listingsContainer.innerHTML = ''; // Clear any existing content

    data.forEach(listing => {
        const listingElement = document.createElement('div');
        listingElement.classList.add('listing');

        const listingName = document.createElement('h3');
        listingName.textContent = listing.listingName;
        listingElement.appendChild(listingName);

        if (listing.imageUrl) {
            const imageUrl = document.createElement('img');
            imageUrl.src = listing.imageUrl;
            listingElement.appendChild(imageUrl);
        }

        const category = document.createElement('p');
        category.textContent = `Category: ${listing.category ? listing.category.propertyName + ' - ' + listing.category.propertyType : 'Not Provided'}`;
        listingElement.appendChild(category);

        const location = document.createElement('p');
        location.textContent = `Location: ${listing.location ? listing.location.City + ', ' + listing.location.State + ', ' + listing.location.PLZ : 'Not Provided'}`;
        listingElement.appendChild(location);

        listingsContainer.appendChild(listingElement);
    });
}

fetchData();