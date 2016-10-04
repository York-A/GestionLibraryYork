using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace webFormExample
{
    public partial class index : System.Web.UI.Page
    {
        DataTable dT;
        protected void Page_Load(object sender, EventArgs e)
        {
            dataLoad();

        }

        private void dataLoad()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[""].ConnectionString;
                string SQL = "SELECT * FROM  users";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                DataSet dS = new DataSet();
                SqlDataAdapter dAdapter = new SqlDataAdapter(SQL, conn);
                dAdapter.Fill(dS);
                //grdUser
                dT = dS.Tables[0];
                grdUser.DataSource = dT;
                grdUser.DataBind();
                conn.Close();
                
            }
            catch (SqlException ex)
            {

                Console.Error.Write(ex.Message);
            }
           


        }
    }
}