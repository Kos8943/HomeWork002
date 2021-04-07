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

            string Page = Request.QueryString["Page"];

            //判定是否登入
            //bool Logined = LoginHelper.HasLogined();
            //if (!Logined)
            //{
            //    Response.Redirect("LoginPage.aspx");
            //}

            if (!IsPostBack)
            {
                DataTable dt = ConnectDB.ReadDroneBattery();

                if (Page == null)
                {
                    Page = "1";
                }

                ChangePage.TotalSize = dt.Rows.Count;
                int fistData = (Convert.ToInt32(Page) - 1) * 10 + 1;
                int LastData = Convert.ToInt32(Page) * 10;

                DataTable dt1 = ConnectDB.ReadTenDataDroneBattery(fistData, LastData);

                
                this.DroneBatteryReater.DataSource = dt1;
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
            string Page = Request.QueryString["Page"];

            if ("DeleteItem" == cmdName)
            {
                ConnectDB.DeleteBattery(Convert.ToInt32(cmdArgu));
            }

            if ("UpDateItem" == cmdName)
            {
                string targetUrl = "~/Drone_Battery_Create.aspx?Sid=" + cmdArgu;

                Response.Redirect(targetUrl);
            }

            DataTable dt = ConnectDB.ReadDroneBattery();

            if (Page == null)
            {
                Page = "1";
            }

            ChangePage.TotalSize = dt.Rows.Count;
            int fistData = (Convert.ToInt32(Page) - 1) * 10 + 1;
            int LastData = Convert.ToInt32(Page) * 10;

            DataTable dt1 = ConnectDB.ReadTenDataDroneBattery(fistData, LastData);


            this.DroneBatteryReater.DataSource = dt1;
            this.DroneBatteryReater.DataBind();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Drone_Battery_Create.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string WantSearch = this.DropDownListSearch.SelectedValue;
            string KeyWord = this.textKeyWord.Text;

            DataTable dt = ConnectDB.KeyWordSearchDroneBattery(WantSearch, KeyWord);
            this.DroneBatteryReater.DataSource = dt;
            this.DroneBatteryReater.DataBind();
        }

    }
}