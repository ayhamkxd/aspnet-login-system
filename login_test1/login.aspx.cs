using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace login_test1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TestDatabaseConnection();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userInput = txtUsername.Text.Trim();  
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(userInput) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter both username/email and password!";
                return;
            }

           
            if (AuthenticateUser(userInput, password, userInput))
            {
                Session["Username"] = userInput;
                lblMessage.Text = "Login successful! Welcome, Ayham!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Invalid username/email or password!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool AuthenticateUser(string username, string password, string email)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                   
                    string query = "SELECT username FROM users WHERE (username = @Username OR email = @Email) AND password = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Email", email);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        return result != null;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Database error: " + ex.Message;
                return false;
            }
        }

        private void TestDatabaseConnection()
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string testQuery = "SELECT COUNT(*) FROM users";
                    using (SqlCommand cmd = new SqlCommand(testQuery, conn))
                    {
                        int userCount = (int)cmd.ExecuteScalar();
                        lblMessage.Text = $"Database connected! Found {userCount} users.";
                        lblMessage.ForeColor = System.Drawing.Color.Blue;
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Connection failed: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}