using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWork002
{
    public partial class Drone_Battery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Headder1.TableName = "電池管理表";

            //判定是否登入
            //bool Logined = LoginHelper.HasLogined();
            //if (!Logined)
            //{
            //    Response.Redirect("LoginPage.aspx");
            //}

            if (!IsPostBack)
            {
                DataTable dt = ConnectDB.ReadDroneBattery();
                this.DroneBatteryReater.DataSource = dt;
                this.DroneBatteryReater.DataBind();
            }
            
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }


        protected void DroneBatteryReater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string cmdName = e.CommandName;
            string cmdArgu = e.CommandArgument.ToString();

            if ("DeleteItem" == cmdName)
            {
                ConnectDB.DeleteBattery(cmdArgu);
            }

            if ("UpDateItem" == cmdName)
            {
                string targetUrl = "~/Drone_Battery_Create.aspx?ID=" + cmdArgu;

                Response.Redirect(targetUrl);
            }

            DataTable dt = ConnectDB.ReadDroneBattery();
            this.DroneBatteryReater.DataSource = dt;
            this.DroneBatteryReater.DataBind();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Drone_Battery_Create.aspx");
        }

    }
}