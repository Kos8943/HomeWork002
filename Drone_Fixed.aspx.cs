using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWork002
{
    public partial class Drone_Fixed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Headder1.TableName = "無人機維修紀錄";
            //判定是否登入
            //bool Logined = LoginHelper.HasLogined();
            //if (!Logined)
            //{
            //    Response.Redirect("LoginPage.aspx");
            //}

            if (!IsPostBack)
            {
                DataTable dt = ConnectDB.ReadDroneFixed();
                this.DroneFixReater.DataSource = dt;
                this.DroneFixReater.DataBind();
            }
        }


        protected void DroneFixReater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void DroneFixReater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string cmdName = e.CommandName;
            string cmdArgu = e.CommandArgument.ToString();

            if ("DeleteItem" == cmdName)
            {
                ConnectDB.DelectDroneFix(cmdArgu);
            }

            if ("UpDateItem" == cmdName)
            {
                string targetUrl = "~/Drone_Fix_CreateData.aspx?ID=" + cmdArgu;

                Response.Redirect(targetUrl);
            }


            DataTable dt = ConnectDB.ReadDroneFixed();
            this.DroneFixReater.DataSource = dt;
            this.DroneFixReater.DataBind();
        }

        protected void CreateDate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Drone_Fix_CreateData.aspx");
        }
    }
}