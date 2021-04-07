using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWork002
{
    public partial class Drone_UserList_Create : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string id = Request.QueryString["Sid"];

            DataTable dt = ConnectDB.ReadSingleDroneUser(id);

            if (id == null)
            {
                return;
            }

            this.TextAccount.Text = dt.Rows[0]["Account"].ToString();
            this.TextPwd.Text = dt.Rows[0]["Pwd"].ToString();
            this.TextName.Text = dt.Rows[0]["Name"].ToString();

            this.title.InnerHtml = "編輯電池資料";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Headder1.TableName = "";
            this.Master.FindControl("ChangePage").Visible = false;

            //判定是否登入
            //bool Logined = LoginHelper.HasLogined();
            //if (!Logined)
            //{
            //    Response.Redirect("LoginPage.aspx");
            //}
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            int Sid = Convert.ToInt32(Request.QueryString["Sid"]);
            string account = this.TextAccount.Text;
            string Pwd = this.TextPwd.Text;
            string Name = this.TextName.Text;
            bool canSubmit = false;

            if (account == "")
            {
                this.ErrorMsgAccount.Visible = true;
            }

            if (Pwd == "")
            {
                this.ErrorMsgPwd.Visible = true;
            }

            if (Name == "")
            {
                this.ErrorMsgName.Visible = true;
            }

            if (account != "" && Pwd != "" && Name != "")
            {
                canSubmit = true;
            }


            if (canSubmit)
            {
                if (Sid == 0)
                {
                    ConnectDB.InsertIntoDroneUser(account, Pwd, Name);
                    Response.Redirect("Drone_UserList.aspx");
                }

                if (Sid != 0)
                {

                    ConnectDB.UpDateUserAccount(Sid, account, Pwd, Name);
                    Response.Redirect("Drone_UserList.aspx");
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
            Response.Redirect("Drone_UserList.aspx");
        }
    }
}