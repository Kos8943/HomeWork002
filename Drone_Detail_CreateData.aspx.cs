﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HomeWork002
{
    public partial class Drone_Detail_CreateData : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];

            DataTable dt = ConnectDB.ReadSingleDroneDetail(id);

            if (id == null)
            {
                return;
            }

            this.TextDroneName.Text = dt.Rows[0]["Drone_ID"].ToString();
            this.TextManufacturer.Text = dt.Rows[0]["Manufacturer"].ToString();
            this.TextWeightLoad.Text = dt.Rows[0]["WeightLoad"].ToString();
            this.TextStatus.Text = dt.Rows[0]["Status"].ToString();
            this.TextStopReason.Text = dt.Rows[0]["StopReason"].ToString();
            this.TextOperator.Text = dt.Rows[0]["operator"].ToString();

            this.title.InnerText = "編輯植保機";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DroneIDmsg.Visible = false;
            this.errorManufacturerMsg.Visible = false;
            this.errorWeightLoadMsg.Visible = false;
            this.errorStatusMsg.Visible = false;
            this.errorOperatorMsg.Visible = false;

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
            string name = this.TextDroneName.Text;
            string Manufacturer = this.TextManufacturer.Text;
            string WeightLoad = this.TextWeightLoad.Text;
            string Status = this.TextStatus.Text;
            string StopReason = this.TextStopReason.Text;
            string Operator = this.TextOperator.Text;
            string Method = this.Create.Text;
            bool canSubmit = false;


            if (name == "")
            {
                this.DroneIDmsg.Visible = true;
            }
            if (Manufacturer == "")
            {
                this.errorManufacturerMsg.Visible = true;
            }
            if (WeightLoad == "")
            {
                this.errorWeightLoadMsg.Visible = true;
            }
            if (Status == "")
            {
                this.errorStatusMsg.Visible = true;
            }
            if (Operator == "")
            {
                this.errorOperatorMsg.Visible = true;
            }

            if(name != "" && Manufacturer != "" && WeightLoad != "" && Status != "" && Operator != "")
            {
                canSubmit = true;
            }
            //將變數傳進Method
            if (canSubmit)
            {
                if (id == null)
                {
                    ConnectDB.InsertIntoDroneDetail(name, Manufacturer, WeightLoad, Status, StopReason, Operator);
                    Response.Redirect("Drone_Detail.aspx");
                }

                if (id != null)
                {
                    ConnectDB.UpDateDroneDetail(name, Manufacturer, WeightLoad, Status, StopReason, Operator);
                    Response.Redirect("Drone_Detail.aspx");
                }
            }


        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Drone_Detail.aspx");
        }
    }
}