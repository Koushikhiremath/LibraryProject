using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace LibraryProject.DataAccees
{
    public class Data
    {
        public static string connectionstring = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;

        public void signup(UserDetails userDetails)
        {

            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand cmd = new SqlCommand("signup", connection);
            cmd.Parameters.AddWithValue("@username", userDetails.username);
            cmd.Parameters.AddWithValue("@email", userDetails.email);
            cmd.Parameters.AddWithValue("@password", userDetails.password);
            cmd.Parameters.AddWithValue("@role", userDetails.role);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            

        }

        public Validate loginvalidate(Login login)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            Validate validate = new Validate();
            List<Login> logins = new List<Login>();

            SqlCommand command = new SqlCommand("select email,password,role from user_login", connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet data = new DataSet();

            adapter.Fill(data);

            foreach (DataRow item in data.Tables[0].Rows)
            {
                if(item["email"].ToString()==login.email && item["password"].ToString()==login.password && item["role"].ToString()=="admin")
                {
                    

                    validate.login = true;
                    validate.role = true;

                    break;


                }
                else if(item["email"].ToString() == login.email && item["password"].ToString() == login.password)
                {
                    validate.login = true;
                    validate.role = false;

                    break;
                }
                else
                {
                    validate.login = false;
                    validate.login = false;
                }
            }

            return validate;





        }
    }
}