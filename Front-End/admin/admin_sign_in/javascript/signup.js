
function checkPassword(){
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    if (username.ToUpperCase() === 'ADMIN' && password.ToUpperCase() === 'PASSWORD') {
        var url = "Front-End/admin/admin_page/html/";
        window.location = url; 
      }
      else
      {
        setFormMessage(loginForm, "error", "Invalid username/password combination");
      }
}


