using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWork002
{
    public partial class Drone_Fix_CreatData : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];

            DataTable dt = ConnectDB.ReadSingleDroneFix(id);

            DataTable dr = ConnectDB.ReadDroneDetail();

            this.DropDownListDroneID.DataSource = dr;

            
            this.DropDownListDroneID.DataTextField = "Drone_ID";
            this.DropDownListDroneID.DataValueField = "Drone_ID";
            this.DropDownListDroneID.DataBind();

            if (id == null)
            {
                return;
            }

            this.DropDownListDroneID.SelectedValue = dt.Rows[0]["Drone_ID"].ToString();
            this.TextStopDate.Text = dt.Rows[0]["StopDate"].ToString();
            this.TextSendDate.Text = dt.Rows[0]["SendDate"].ToString();
            this.TextFixVendor.Text = dt.Rows[0]["FixVendor"].ToString();
            this.TextStopReason.Text = dt.Rows[0]["StopReason"].ToString();
            this.TextChange.Text = dt.Rows[0]["FixChange"].ToString();
            this.TextRemarks.Text = dt.Rows[0]["Remarks"].ToString();

            this.title.InnerText = "編輯維修紀錄";

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Headder1.TableName = "";
            this.Master.FindControl("ChangePage").Visible = false;

            this.FixChangeMsg.Visible = false;
            this.FixStopDateMsg.Visible = false;
            this.FixSendDateMsg.Visible = false;
            this.FixVendorMsg.Visible = false;
            this.FixStopReason.Visible = false;
            //判定是否登入
            //bool Logined = LoginHelper.HasLogined();
            //if (!Logined)
            //{
            //    Response.Redirect("LoginPage.aspx");
            //}

        }

        protected void Create_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];
            string DroneID = this.DropDownListDroneID.SelectedValue;
            string change = this.TextChange.Text;
            string stop = this.TextStopDate.Text;
            string send = this.TextSendDate.Text;
            string fix = this.TextFixVendor.Text;
            string reason = this.TextStopReason.Text;         
            string remarks = this.TextRemarks.Text;
            bool canSubmit = false;

            if(change == "")
            {
                this.FixChangeMsg.Visible = true;
            }

            if (stop == "")
            {
                this.FixStopDateMsg.Visible = true;
            }

            if (send == "")
            {
                this.FixSendDateMsg.Visible = true;
            }

            if (fix == "")
            {
                this.FixVendorMsg.Visible = true;
            }

            if (reason == "")
            {
                this.FixStopReason.Visible = true;
            }

            if(change != "" && stop != "" && send != "" && fix != "" && reason != "")
            {
                canSubmit = true;
            }

            if (canSubmit)
            {
                if (id == null)
                {
                    ConnectDB.InsertIntoDroneFix(DroneID, change, stop, send, fix, reason, remarks);
                }

                if (id != null)
                {
                    ConnectDB.UpDateDroneFix(id, DroneID, change, stop, send, fix, reason, remarks);
                }
                Response.Redirect("Drone_Fixed.aspx");
            }
           
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Drone_Fixed.aspx");
        }
    }
}