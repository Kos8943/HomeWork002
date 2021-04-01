using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HomeWork002
{
    public class LoginHelper
    {
        private const string _sessionKey = "IsLogined";
        private const string _sessionKey_Account = "Account";
        //檢查是否登入
        public static bool HasLogined()
        {
            bool? val = HttpContext.Current.Session[_sessionKey] as bool?;
            if (val.HasValue && val.Value)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static bool TryLogin(string account, string password)
        {
            if (HasLogined())
            {
                return true;
            }

            DataTable dt = DBAccountManager.GetUserAccount(account);

            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }



            //bool isAccountRight = string.Compare("Kos", account, true) == 0;
            string dbPwd = dt.Rows[0].Field<string>("Pwd");
            string dbName = dt.Rows[0].Field<string>("Name");
            bool isPasswordRight = string.Compare(dbPwd, password) == 0;

            if (isPasswordRight)
            {
                HttpContext.Current.Session[_sessionKey] = true;
                HttpContext.Current.Session[_sessionKey_Account] = dbName;

                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 登出目前的使用者,如果沒登入就不執行
        /// </summary>
        public static void Logout()
        {
            if (!HasLogined())
            {
                return;
            }

            HttpContext.Current.Session.Remove(_sessionKey);
            HttpContext.Current.Session.Remove(_sessionKey_Account);
        }

        /// <summary>
        /// 取得已登入者的資訊,如果沒有回傳空字串
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentUserInfo()
        {
            if (!HasLogined())
            {
                return string.Empty;
            }

            return HttpContext.Current.Session[_sessionKey_Account] as string;


        }
    }
}