using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWork002
{
    public partial class Headder1 : System.Web.UI.UserControl
    {
        public static string TableName { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtTableName.Text = TableName;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginHelper.Logout();
            Response.Redirect("LoginPage.aspx");
        }
    }
}