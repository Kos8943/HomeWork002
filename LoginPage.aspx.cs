using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWork002
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string Account = this.txtAccount.Text;
            string Password = this.txtPassword.Text;

            if (Account == "" || Password == "")
            {
                this.ltErrorMsg.Text = "請輸入帳號密碼";
                this.ltErrorMsg.Visible = true;
                return;
            }


            bool CanLogin = LoginHelper.TryLogin(Account, Password);

            if (CanLogin)
            {
                Response.Redirect("Drone_Detail.aspx");
            }
            else
            {                
                this.ltErrorMsg.Text = "帳號或密碼錯誤";
                this.ltErrorMsg.Visible = true;
                //Response.Redirect("LoginPage.aspx");
            }

            
        }
    }
}