using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWork002
{
    public partial class Drone_Destination : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Headder1.TableName = "出勤紀錄一覽表";

            string Page = Request.QueryString["Page"];


            //判定是否登入
            bool Logined = LoginHelper.HasLogined();
            if (!Logined)
            {
                Response.Redirect("LoginPage.aspx");
            }

            if (!IsPostBack)
            {

                DataTable dt = ConnectDB.ReadDroneDestination();

                if (Page == null)
                {
                    Page = "1";
                }

                ChangePage.TotalSize = dt.Rows.Count;
                int fistData = (Convert.ToInt32(Page) - 1) * 10 + 1;
                int LastData = Convert.ToInt32(Page) * 10;

                DataTable dt1 = ConnectDB.ReadTenDataDroneDestination(fistData, LastData);

                //dt1 = ConnectDB.ReadTenDataDroneDetail(fistData, LastData);
                this.DroneDetailRepeater.DataSource = dt1;
                this.DroneDetailRepeater.DataBind();

            }


        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Drone_Destination_Create.aspx");
        }

        protected void DroneDetailRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DataRowView drv = e.Item.DataItem as DataRowView;


                }




            }
        }

        protected void DroneDetailRepeater_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            string cmdName = e.CommandName;
            string cmdArgu = e.CommandArgument.ToString();
            string Page = Request.QueryString["Page"];

            if ("DeleteItem" == cmdName)
            {
                ConnectDB.DelectDestination(cmdArgu);
            }

            if ("UpDateItem" == cmdName)
            {
                string targetUrl = "~/Drone_Destination_Create.aspx?ID=" + cmdArgu;

                Response.Redirect(targetUrl);
            }


            if (Page == null)
            {
                Page = "1";
            }

            int fistData = (Convert.ToInt32(Page) - 1) * 10 + 1;
            int LastData = Convert.ToInt32(Page) * 10;

            DataTable dt1 = ConnectDB.ReadTenDataDroneDestination(fistData, LastData);

            //dt1 = ConnectDB.ReadTenDataDroneDetail(fistData, LastData);
            this.DroneDetailRepeater.DataSource = dt1;
            this.DroneDetailRepeater.DataBind();


            //dt1 = ConnectDB.ReadTenDataDroneDetail(fistData, LastData);
            //this.DroneDetailRepeater.DataSource = dt1;
            //this.DroneDetailRepeater.DataBind();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string WantSearch = this.DropDownListSearch.SelectedValue;
            string KeyWord = this.textKeyWord.Text;

            DataTable dt = ConnectDB.KeyWordSearchDroneDestination(WantSearch, KeyWord);
            this.DroneDetailRepeater.DataSource = dt;
            this.DroneDetailRepeater.DataBind();
        }
    }
}
