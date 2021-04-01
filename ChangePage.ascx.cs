using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWork002
{
    public partial class ChangePage : System.Web.UI.UserControl
    {
        public static int PageSize { get; set; } = 10;

        public static int PageIndex { get; set; } = 1;

        public static int TotalSize { get; set; } = 10;

        public string Url { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int currentPageIndex = Convert.ToInt32(Request.QueryString["Page"]);

            int pages = TotalSize / PageSize + 1;

            this.aLinkFristPage.HRef = this.BuildPagingUrl(1);
            this.aLinkLastPage.HRef = this.BuildPagingUrl(pages);
            for(int i = currentPageIndex - 3; i <= currentPageIndex + 3; i++)
            {
                if(i <= 0)
                {
                    continue;
                }

                //動態增加連結
                this.PlaceHolder1.Controls.Add(
                    new HyperLink() { 
                        ID = $"btn{i}" ,
                        Text= $"{i}",
                        NavigateUrl= $"{Url}?Page={i}",
                        CssClass="LinkStyle"
                    });

                if(i == pages)
                {
                    break;
                }
            }

            //this.aLink1.HRef = this.BuildPagingUrl(currentPageIndex - 3);
            //this.aLink2.HRef = this.BuildPagingUrl(currentPageIndex - 2);
            //this.aLink3.HRef = this.BuildPagingUrl(currentPageIndex - 1);
            //this.aLink4.HRef = this.BuildPagingUrl(currentPageIndex);
            //this.aLink5.HRef = this.BuildPagingUrl(currentPageIndex + 1);
            //this.aLink6.HRef = this.BuildPagingUrl(currentPageIndex + 2);
            //this.aLink7.HRef = this.BuildPagingUrl(currentPageIndex + 3);
        }

        string BuildPagingUrl(int pageIndex)
        {
            return $"{Url}?Page={pageIndex}";
        }
    }
}