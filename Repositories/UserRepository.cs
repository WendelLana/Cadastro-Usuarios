using Microsoft.Data.SqlClient;
using wendel_d3_avaliacao.Interfaces;
using wendel_d3_avaliacao.Models;

namespace wendel_d3_avaliacao.Repositories
{
    internal class UserRepository : IUser
    {
        private readonly string stringConexao = "Data Source=DESKTOP-RJNUR4N\\SQLEXPRESS;Initial Catalog=wendel-d3-avaliacao; user id=sa; pwd=root1234;TrustServerCertificate=true;";
        //private readonly string stringConexao = "Data source=DESKTOP-RJNUR4N\\SQLEXPRESS; initial catalog=wendel-d3-avaliacao; integrated security=true;";

        public void Create(User user)
        {
            using (SqlConnection con = new(stringConexao))
            {
                string queryInsert = "INSERT INTO UserLogin (Name, Email, Password) VALUES (@Name, @Email, @Password);";

                using (SqlCommand cmd = new(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("Name", user.Name);
                    cmd.Parameters.AddWithValue("Email", user.Email);
                    cmd.Parameters.AddWithValue("Password", user.Password);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public User? Login(String email, String password)
        {
            using (SqlConnection con = new(stringConexao))
            {
                string querySelectAll = "SELECT IdUser, Name, Email, Password FROM UserLogin WHERE Email = @Email AND Password = @Password";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new(querySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("Email", email);
                    cmd.Parameters.AddWithValue("Password", password);

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        User user = new()
                        {
                            IdUser = rdr["IdUser"].ToString(),
                            Name = (string)rdr["Name"],
                            Email = (string)rdr["Email"],
                            Password = (string)rdr["Password"]
                        };

                        return user;
                    }
                }
            }

            return null;
        }
    }
}
