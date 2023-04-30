using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Attenda
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string enteredUsername = username.Text;
            string enteredPassword = password.Text;

            // Check if the entered username and password are valid
            bool isValidLogin = ValidateLogin(enteredUsername, enteredPassword);

            if (isValidLogin)
            {
                // Redirect to the main page of the application
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                // Display an error message if the login is invalid
                errorLabel.Visible = true;
                errorLabel.Text = "Invalid username or password.";
            }
        }

        private bool ValidateLogin(string username, string password)
        {
            // TODO: Implement validation logic here, e.g. check the entered username and password against a database of users
            // For now, we'll just assume that any username and password is valid
            return true;
        }

    }
}