using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWork002
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static string HeaderTableName { get; set; }
        protected void Page_Init(object sender, EventArgs e)
        {
            //Headder1 headder1 = new Headder1();
            //headder1.SetLtHeader = "無人機管理表";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Master.FindControl("Headder1").FindControl("txtTableName");
            if (!IsPostBack)
            {
                
                DataTable dt = ConnectDB.ReadDroneDetail();
                this.DroneDetailRepeater.DataSource = dt;
                this.DroneDetailRepeater.DataBind();
            }


        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Drone_Detail_CreateData.aspx");
        }

        protected void DroneDetailRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.ItemType == ListItemType.AlternatingItem)
                {

                }

                DataRowView drv = e.Item.DataItem as DataRowView;


            }
        }

        protected void DroneDetailRepeater_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            string cmdName = e.CommandName;
            string cmdArgu = e.CommandArgument.ToString();


            if("DeleteItem" == cmdName)
            {
                ConnectDB.DelectDroneDetail(cmdArgu);
            }

            if("UpDateItem" == cmdName)
            {
                string targetUrl = "~/Drone_Detail_CreateData.aspx?ID=" + cmdArgu;

                Response.Redirect(targetUrl);
            }
            

            DataTable dt = ConnectDB.ReadDroneDetail();
            this.DroneDetailRepeater.DataSource = dt;
            this.DroneDetailRepeater.DataBind();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string WantSearch = this.DropDownListSearch.SelectedValue;
            string KeyWord = this.textKeyWord.Text;           

            DataTable dt = ConnectDB.KeyWordSearchDroneDetail(WantSearch, KeyWord);
            this.DroneDetailRepeater.DataSource = dt;
            this.DroneDetailRepeater.DataBind();
        }
    }
}