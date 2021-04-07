using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWork002
{
    public partial class Drone_Customer_Create : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];

            DataTable dt = ConnectDB.ReadSingleDroneDetail(id);

            if (id == null)
            {
                return;
            }

            this.TextName.Text = dt.Rows[0]["Name"].ToString();
            this.TextTel.Text = dt.Rows[0]["Tel"].ToString();
            this.TextAddress.Text = dt.Rows[0]["Address"].ToString();
            this.TextCrop.Text = dt.Rows[0]["Crop"].ToString();
            this.TextArea.Text = dt.Rows[0]["Area"].ToString();
            this.TextPesticide.Text = dt.Rows[0]["Pesticide"].ToString();
            this.TextPesticideDate.Text = dt.Rows[0]["Pesticide_Date"].ToString();
            this.TextFarmAddress.Text = dt.Rows[0]["Farm_Address"].ToString();

            this.title.InnerText = "編輯植保機";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.errorMsgName.Visible = false;
            this.errorMsgTel.Visible = false;
            this.errorMsgAddress.Visible = false;
            this.errorMsgCrop.Visible = false;
            this.errorMsgArea.Visible = false;
            this.errorMsgPesticide.Visible = false;
            this.errorMsgPesticideDate.Visible = false;

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
            string name = this.TextName.Text;
            string Tel = this.TextTel.Text;
            string Address = this.TextAddress.Text;
            string Crop = this.TextCrop.Text;
            string Area = this.TextArea.Text;
            string Pesticide = this.TextPesticide.Text;
            string PesticideDate = this.TextPesticideDate.Text;
            string Farm_Address = this.TextFarmAddress.Text;
            bool canSubmit = false;


            if (name == "")
            {
                this.errorMsgName.Visible = true;
            }

            if (Tel == "")
            {
                this.errorMsgTel.Visible = true;
            }

            if (Address == "")
            {
                this.errorMsgAddress.Visible = true;
            }

            if (Crop == "")
            {
                this.errorMsgCrop.Visible = true;
            }

            if (Area == "")
            {
                this.errorMsgArea.Visible = true;
            }

            if (Pesticide == "")
            {
                this.errorMsgPesticide.Visible = true;
            }

            if (PesticideDate == "")
            {
                this.errorMsgPesticideDate.Visible = true;
            }

            if(name != "" && Tel != "" && Address != "" && Crop != "" && Area != "" && Pesticide != "" && PesticideDate != "")
            {
                canSubmit = true;
            }



            //將變數傳進Method
            if (canSubmit)
            {
                if (id == null)
                {
                    //ConnectDB.InsertIntoDroneDetail(name, Manufacturer, WeightLoad, Status, StopReason, Operator);
                    Response.Redirect("Drone_Customer.aspx");
                }

                if (id != null)
                {
                    //ConnectDB.UpDateDroneDetail(name, Manufacturer, WeightLoad, Status, StopReason, Operator);
                    Response.Redirect("Drone_Customer.aspx");
                }
            }


        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Drone_Customer.aspx");
        }
    }
}