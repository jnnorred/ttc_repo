function populateDashboard(){
    getCustomers(); 
    getUpcoming(); 
}

function getCustomers(){
    const allCustomersApiUrl = "https://titletowncateringapi.herokuapp.com/api/customer";
    fetch(allCustomersApiUrl).then(function(response){
        console.log(response); 
        return response.json(); 
    }).then(function (json) {
        console.log(json);
        customers = json; 
    })
};


  const searchInput = document.getElementById('search');
  const searchWrapper = document.querySelector('.search-bar');
  const resultsWrapper = document.querySelector('.results');
  
  searchInput.addEventListener('keyup', () => {
    let results = [];
    let input = searchInput.value;
    if (input.length) {
      results = customers.filter((item) => {
        var fullName = item.fName;
        return fullName.toLowerCase().includes(input.toLowerCase());
      });
    }
    renderResults(results);
  });
  
  function renderResults(results) {
    if (!results.length) {
      return searchWrapper.classList.remove('show');
    }
  
    const content = results
      .map((item) => {
        return `<li><a href= "#" role="button" onclick="openNewEvent(${item.custID});">${item.fName} ${item.lName}</a></li>`;
      })
      .join('');
  
    searchWrapper.classList.add('show');
    resultsWrapper.innerHTML = `<ul>${content}</ul>`;
  }
//searchbar end 
//add cust expand start
document.querySelector('#expander').addEventListener('click', function() {
    document.querySelector('.Add-Event').classList.toggle('expand');
    document.getElementById('event-form').style.display = 'none'; 

});

function openNewEvent(id) {
    document.getElementById('event-form').style.display = 'block'; 
    document.querySelector('.Add-Event').classList.add('expand');
    customers.forEach(customer => {
        if (customer.custID == id) {
            document.getElementById('pre-filled').style.display = 'block';
            document.getElementById('search').value = `${customer.fName} ${customer.lName}`; 
            searchWrapper.classList.remove('show'); 
            let html = `<span><h5>Customer Name:&emsp;${customer.fName} ${customer.lName}</h5></span>`; 
            html += `<span><h5>Comapany:&emsp;${customer.company}</h5></span>`;
            html += `<span><h5>Phone #:&emsp;${customer.phone}</h5></span>`;
            html += `<span><h5>Email:&emsp;${customer.email}</h5></span>`;
            document.querySelector('.auto-filled').innerHTML = html;
            document.getElementById('sub_btn').setAttribute('onClick', `postEvent(${customer.custID})`); 
        }
    });
}
function postEvent(id) {
    const createEventApiUrl = "https://titletowncateringapi.herokuapp.com/api/event";
    const eventName = document.getElementById("eventName").value;
    const day = document.getElementById('eventDay').value;
    const month = document.getElementById('eventMonth').value;
    const year = document.getElementById("eventYear").value;
    const date = `${year}-${month}-${day}`; 
    const cost = document.getElementById("eventCost").value;
    const timeVal = document.getElementById("eventTime").value;
    const tod = document.getElementById("tod").value;
    const eventTime = timeVal +' '+tod;
    const CustID = id; 
    
    
    fetch(createEventApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            eventName: eventName, 
            eventDate: date,
            eventTime: eventTime,
            cost: cost,
            customer:{
                custID: id
            }

        })
    })
    .then((response) =>{
        console.log(response); 
        document.forms['new-event'].reset();
        document.getElementById('event-form').style.display = 'none'; 
        document.querySelector('.Add-Event').classList.remove('expand');
        document.getElementById('search').value = ``; 
        document.getElementById('pre-filled').style.display = 'none';
        1
    })
}

function getUpcoming(){
  const getUpcomingEventsUrl = "https://titletowncateringapi.herokuapp.com/api/event/getupcoming";
  fetch(getUpcomingEventsUrl).then(function(response){
      console.log(response); 
      return response.json(); 
  }).then(function (json) {
      console.log(json);
      eventUpcoming = json; 
      populateEventUpcoming();
  })
}


function populateEventUpcoming(){
  let html = '<div class = upcomingEvents>';0 
    eventUpcoming.forEach(upcoming => {
        html += '<div class = float-container>';
        html += '<div class = "float-child name">';
        html += '<h3>Event Name:  '+ upcoming.eventName +'</h3>'; 
        html += `<h5> Estimated Charge: ${upcoming.cost}</h5>`;
        html += '</div>';
        html += '<div class = "float-child Amount">';
        var date = upcoming.eventDate; 
        html += `<h3>${date.toLocaleString("en-US")}</h3>`;
        html += '</div>';1
        html += '</div>';
    });
    html += '</div>';
    document.querySelector('.Upcoming-Events').innerHTML = html;
}
