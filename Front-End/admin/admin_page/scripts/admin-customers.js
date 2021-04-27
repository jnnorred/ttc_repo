function populateDashboard(){
    getBalance(); 
    // getInvoices(); 
}

function getInvoices(id){
    const allPostsApiUrl = "https://localhost:5001/api/customer/getinvoices/"+id;
    fetch(allPostsApiUrl).then(function(response){
        console.log(response); 
        return response.json(); 
    }).then(function (json) {
        console.log(json);
        customerInvoices = json; 
        showInvoices(); 
    })
};

function showInvoices(){
    var modal = document.getElementById("editModal"); 
    let html = '<h2> Account Number:  ' +customerInvoices.accountNo+'</h2>'
    html += '<h2> Customer Name:  ' +customerInvoices.fName+' '+customerInvoices.lName+'</h2>';
    html += '<h2> Invoices With Balance:</h2>'
    customerInvoices.invoiceList.forEach(invoice => {
        html += '<div class = float-container>'; 
        html += '<div class = "float-child Descrip">';
        html += '<h3><b> Event: '+invoice.eventName + '</b></h3>'; 
        html += '<h4>Invoice No.:'+invoice.invoiceNo +'</h4>';
        html += '</div>'; 
        html += '<div class = "float-child Amount">';
        html +='<h4> Amount Due: ' + formatter.format(invoice.amountDue) + '</h4> <ion-icon name="mail-outline"></ion-icon>';
        html += '</div>'; 
        html += '</div>';

    });
    html += "<button class =\"close\" onclick= \"closeModal()\"><ion-icon name=\"close-circle-outline\"></ion-icon></button>"
    html += '</div>'
    document.querySelector('.modal-content').innerHTML = html;
    modal.style.display = "block"; 

    var button = document.getElementsByClassName("close")[0]; 
}
function closeModal(){
    var modal = document.getElementById("editModal");
    modal.style.display = "none";
}
window.onclick = function(event){
    var modal = document.getElementById("editModal"); 
    if(event.target == modal){
        modal.style.display = "none"; 
    }
}
var formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
});

function amountDue(){

    let html = '<div class = BalanceDue>' 
    customersBalance.forEach(customer => {
        html += '<div class = float-container>';
        html += '<div class = "float-child name">';
        html += '<h3>'+ customer.fName +'</h3>'; 
        html += '<h5> Amount Due </h5>';
        html += '</div>';
        html += '<div class = "float-child Amount">';''
        html += "<button title= \"Click To See "+customer.fName+"\ Invoices\" onclick= \"getInvoices("+customer.custID+")\">"+customer.invoiceSummary.numberOfEvents+" Unpaid Event(s)</button>"; 
        html += '<h5>'+ formatter.format(customer.invoiceSummary.amountDue) +'</h5>'; 
        html += '</div>'
        html += '</div>'



    });
    html += '</div>'
    document.querySelector('.Customers-Balance').innerHTML = html;
    
}

function getBalance(){
    const allPostsApiUrl = "https://localhost:5001/api/customer/getbalance";
    fetch(allPostsApiUrl).then(function(response){
        console.log(response); 
        return response.json(); 
    }).then(function (json) {
        console.log(json);
        customersBalance = json; 
        amountDue(); 
    })
}