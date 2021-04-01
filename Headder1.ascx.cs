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
        public string Path { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             
            if(Request.RawUrl == "/Drone_Detail.aspx")
            {
                this.txtTableName.Text = "無人機資料表";
            }
            
        }
    }
}