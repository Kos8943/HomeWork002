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

            string Page = Request.QueryString["Page"];
            //判定是否登入
            //bool Logined = LoginHelper.HasLogined();
            //if (!Logined)
            //{
            //    Response.Redirect("LoginPage.aspx");
            //}

            if (!IsPostBack)
            {
                DataTable dt = ConnectDB.ReadDroneFixed();

                if (Page == null)
                {
                    Page = "1";
                }

                ChangePage.TotalSize = dt.Rows.Count;
                int fistData = (Convert.ToInt32(Page) - 1) * 10 + 1;
                int LastData = Convert.ToInt32(Page) * 10;

                DataTable dt1 = ConnectDB.ReadTenDataDroneFix(fistData, LastData);

                this.DroneFixReater.DataSource = dt1;
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string WantSearch = this.DropDownListSearch.SelectedValue;
            string KeyWord = this.textKeyWord.Text;

            DataTable dt = ConnectDB.KeyWordSearchDroneFixed(WantSearch, KeyWord);
            this.DroneFixReater.DataSource = dt;
            this.DroneFixReater.DataBind();
        }
    }
}