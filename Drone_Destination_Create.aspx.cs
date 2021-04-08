using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWork002
{
    public partial class Drone_Destination_Create : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];

            DataTable dt = ConnectDB.ReadSingleDestination(id);

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
            this.TextDate.Text = dt.Rows[0]["Date"].ToString();
            this.TextStaff.Text = dt.Rows[0]["Staff"].ToString();
            this.TextBattery.Text = dt.Rows[0]["Battery_Count"].ToString();
            this.TextCustomerName.Text = dt.Rows[0]["Cumstomer_Name"].ToString();
            this.TextCustomerTel.Text = dt.Rows[0]["Tel"].ToString();
            this.TextCustomerAddres.Text = dt.Rows[0]["Address"].ToString();
            this.TextRemarks.Text = dt.Rows[0]["Remarks"].ToString();

            this.title.InnerText = "編輯出勤紀錄";

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
            string id = Request.QueryString["ID"];
            string DroneID = this.DropDownListDroneID.SelectedValue;
            string date = this.TextDate.Text;
            string staff = this.TextStaff.Text;
            string battery = this.TextBattery.Text;
            string customer = this.TextCustomerName.Text;
            string tel = this.TextCustomerTel.Text;
            string address = this.TextCustomerAddres.Text;
            string remarks = this.TextRemarks.Text;
            bool canSubmit = false;

            if (date == "")
            {
                this.errorMsgDate.Visible = true;
            }

            if (staff == "")
            {
                this.errorMsgStaff.Visible = true;
            }

            if (battery == "")
            {
                this.errorMsgBattery.Visible = true;
            }

            if (customer == "")
            {
                this.errorMsgCustomerName.Visible = true;
            }

            if (tel == "")
            {
                this.errorMsgCustomerTel.Visible = true;
            }

            if (address == "")
            {
                this.errorMsgCustomerAddress.Visible = true;
            }



            if (date != "" && staff != "" && battery != "" && customer != "" && tel != "" && address != "")
            {
                canSubmit = true;
            }

            if (canSubmit)
            {
                if (id == null)
                {
                    ConnectDB.InsertIntoDroneDestination(date, staff, DroneID, battery, customer, tel, address, remarks);
                }

                if (id != null)
                {
                    ConnectDB.UpDateDroneDestination(id, date, staff, DroneID, battery, customer, tel, address, remarks);
                }
                Response.Redirect("Drone_Destination.aspx");
            }

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Drone_Destination.aspx");
        }
    }
}