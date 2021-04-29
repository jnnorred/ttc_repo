function populateDashboard(){
    getCustomers();
    getUpcoming(); 
    getNext(); 
    getInquries(); 
}

function countCustomers(){
    let html = '<h1><a href = "/Front-End/admin/admin_page/html/admin-customers.html">';
    html += customers.length+"</h1><h2>Total <br>Customers</h2></a>"; 
    document.querySelector('.Customers').innerHTML = html; 
}

function getCustomers(){
    const allCustomersApiUrl = "https://titletowncateringapi.herokuapp.com/api/customer";
    fetch(allCustomersApiUrl).then(function(response){
        console.log(response); 
        return response.json(); 
    }).then(function (json) {
        console.log(json);
        customers = json; 
        countCustomers();
    })
}


function getUpcoming(){
    const getUpcomingEventsUrl = "https://titletowncateringapi.herokuapp.com/api/event/getupcoming";
    fetch(getUpcomingEventsUrl).then(function(response){
        console.log(response); 
        return response.json(); 
    }).then(function (json) {
        console.log(json);
        upcomingEvents = json; 
        populateEventCount();
    })
}

function populateEventCount(){
    let html = '<h1><a href = "/Front-End/admin/admin_page/html/admin-events-upcoming.html">';
    html += upcomingEvents.length+"</h1><h2>Upcoming <br>Events</h2></a>"; 
    document.querySelector('.Upcoming-Events').innerHTML = html; 
}

function getNext(){
    const getNexEventUrl = "https://titletowncateringapi.herokuapp.com/api/event/getnext"; 
    fetch(getNexEventUrl).then(function(response){
        console.log(response); 
        return response.json(); 
    }).then(function (json) {
        console.log(json);
        nextEvent = json; 
        populateNextEvent();
    })
}
function populateNextEvent(){
    let html = '<a href = "/Front-End/admin/admin_page/html/admin-events-upcoming.html"><h1> '+nextEvent.customer.timeDifference+ '</h1>';
    html += '<h2> Days Till <br>Next Event </h2>';
    html += '</a>';
    document.querySelector('.Next-Event').innerHTML = html; 
}
function getInquries(){
    const getCustomerInquriesUrl = "https://titletowncateringapi.herokuapp.com/api/customer/getinquries"; 
    fetch(getCustomerInquriesUrl).then(function(response){
        console.log(response); 
        return response.json(); 
    }).then(function (json) {
        console.log(json);
        customerInquiry = json; 
        populateUnreadQueries();
    })
}
function populateUnreadQueries(){
    var count = 0; 
    for(var i = 0; i < customerInquiry.length; i++)
    {
        if (customerInquiry[i].message.status == 0) {
            count++; 
        }
    }
    let html = '<h1><a href = "/Front-End/admin/admin_page/html/admin-inquries.html"> '+count+ '</h1>';
    html += '<h2> Unread Customer <br> Inquiries </h2></a>';
    document.querySelector('.Inquries').innerHTML = html; 
}

