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
                string connectionString = ConfigurationManager.ConnectionStrings["GESTLIBRARYConnectionString"].ConnectionString;
                string SQL = "select * from dbo.[user] where deleted=0";
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

        protected void grdv_Users_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string comand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            string code = grdUser.DataKeys[index].Value.ToString();
            switch (comand)
            {
                case "editUser":
                    {
                        lblIdUser.Text = code;
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script>");
                        sb.Append("$('#editModal').modal('show')");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "editarUsuario", sb.ToString(), false);


                    }
                    break;
                case "deleteUser":
                    {

                        txtIdUser.Text = code;
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script>");
                        sb.Append("$('#deleteConfirm').modal('show')");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ConfirmarBorrado", sb.ToString(), false);
                    }
                    break;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            string connectionString = ConfigurationManager.ConnectionStrings["GESTLIBRARYConnectionString"].ConnectionString;

            string code = txtIdUser.Text;
            //string SQL = "DELETE FROM user WHERE idUser=" + code;
           
            string SQL = "update dbo.[user] set deleted=1 where idUser=" + code;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand sqlcmm = new SqlCommand();
                sqlcmm.Connection = conn;
                sqlcmm.CommandText = SQL;
                sqlcmm.CommandType = CommandType.Text;
                sqlcmm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            dataLoad();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script>");
            sb.Append("$('#deleteConfirm').modal('hide')");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OcultarCreate", sb.ToString(), false);
        }

        protected void btnSaveUser_Click(object sender, EventArgs e)
        {
            string code = lblIdUser.Text;
            string name = txtNameUser.Text;
            string connectionString = ConfigurationManager.ConnectionStrings["GESTLIBRARYConnectionString"].ConnectionString;
            int cod;

            string SQL = "INSERT INTO user(name) VALUES(" + name + ")";
            if (Int32.TryParse(code, out cod) && cod > -1)
            {
                SQL = "UPDATE dbo.[user] SET name='" + name + "' where idUser=" + code;
                //SQL = "UPDATE user SET name = '" + name + "' WHERE idUser =" + code;
            }

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand sqlcmm = new SqlCommand();
                sqlcmm.Connection = conn;
                sqlcmm.CommandText = SQL;
                sqlcmm.CommandType = CommandType.Text;
                sqlcmm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            dataLoad();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script>");
            sb.Append("$('#editModal').modal('hide')");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OcultarCreate", sb.ToString(), false);
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            lblIdUser.Text = "-1";
            txtNameUser.Text = "";
            sb.Append(@"<script>");
            sb.Append("$('#editModal').modal('show')");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarCreate", sb.ToString(), false);
        }
    }
}