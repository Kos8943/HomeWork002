using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWork002
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string id = Request.QueryString["Sid"];

            DataTable dt = ConnectDB.ReadSingleBattery(id);

            if (id == null)
            {
                return;
            }

            this.TextBatteryName.Text = dt.Rows[0]["Battery_ID"].ToString();
            this.TextBatteryStatus.Text = dt.Rows[0]["status"].ToString();
            this.TextStop.Text = dt.Rows[0]["stopReason"].ToString();

            this.title.InnerHtml = "編輯電池資料";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Headder1.TableName = "";
            this.Master.FindControl("ChangePage").Visible = false;

            this.BatteryIDmsg.Visible = false;
            this.BatteryStatus.Visible = false;
            //判定是否登入
            //bool Logined = LoginHelper.HasLogined();
            //if (!Logined)
            //{
            //    Response.Redirect("LoginPage.aspx");
            //}
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Sid"]);
            string name = this.TextBatteryName.Text;
            string Status = this.TextBatteryStatus.Text;
            string StopReason = this.TextStop.Text;
            bool canSubmit = false;

            if(name == "")
            {
                this.BatteryIDmsg.Visible = true;
            }

            if (Status == "")
            {
                this.BatteryStatus.Visible = true;
            }

            if (name != "" && Status != "")
            {
                canSubmit = true;
            }
          

            if (canSubmit)
            {
                if (id == 0)
                {
                    ConnectDB.InsertIntoDroneBattery(name, Status, StopReason);
                    Response.Redirect("Drone_Battery.aspx");
                }

                if (id != 0)
                {

                    ConnectDB.UpDateBattery(id, name, Status, StopReason);
                    Response.Redirect("Drone_Battery.aspx");
                }
            }
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //string id = Request.QueryString["ID"];
            //string name = this.TextBatteryName.Text;
            //string Status = this.TextBatteryStatus.Text;
            //string StopReason = this.TextStop.Text;

            //ConnectDB.UpDateBattery( name, Status, StopReason);
            //Response.Redirect("Drone_Detail.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Drone_Battery.aspx");
        }
    }
}