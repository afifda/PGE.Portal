using Microsoft.SharePoint.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace PGE.Portal.Layouts.PGE.Portal
{
    public class BaseLayoutPages : LayoutsPageBase
    {
        //protected static MasterUserByUserNameEntity User
        //{
        //    get
        //    {
        //        return new MasterDataLogic().SPRead<MasterUserByUserNameEntity>(new MasterUserByUserNameEntity() { UserName = SPContext.Current.Web.CurrentUser.LoginName }).FirstOrDefault();
        //    }
        //}

        //protected static bool IsValidUser
        //{
        //    get
        //    {
        //        return User != null;
        //    }
        //}

        protected string MasterInputControl(string masterType)
        {
            switch (masterType)
            {
                case Constant.INPUT_MENU_TYPE:
                    return Constant.INPUT_MENU_CONTROL;
                case Constant.INPUT_MENU_CHILD_TYPE:
                    return Constant.INPUT_MENU_CHILD_CONTROL;
                case Constant.INPUT_KATEGORY_APP_TYPE:
                    return Constant.INPUT_KATEGORY_APP_CONTROL;
                case Constant.INPUT_KATEGORY_APP_CHILD_TYPE:
                    return Constant.INPUT_KATEGORY_APP_CHILD_CONTROL;
                case Constant.INPUT_MAIN_PICTURE_TYPE:
                    return Constant.INPUT_MAIN_PICTURE_CONTROL;
                case Constant.INPUT_BOTTOM_PICTURE_TYPE;
                     return Constant.INPUT_BOTTOM_PICTURE_CONTROL;
                default: return string.Empty;
            }
        }

        //protected string ReportInputControl(string reportType)
        //{
        //    switch (reportType)
        //    {
        //        case Constant.REPORT_BAR_CHART_TYPE:
        //            return Constant.REPORT_BAR_PARAM_CONTROL;
        //        case Constant.REPORT_PIE_CHART_TYPE:
        //            return Constant.REPORT_PIE_PARAM_CONTROL;
        //        case Constant.REPORT_DETAIL_REPORT_TYPE:
        //            return Constant.REPORT_EXCEL_PARAM_CONTROL;
        //        default: return string.Empty;
        //    }
        //}

        protected string MasterInputTitle(string masterType)
        {
            switch (masterType)
            {
                case Constant.INPUT_MENU_TYPE:
                    return Constant.INPUT_MENU_TITLE;
                case Constant.INPUT_MENU_CHILD_TYPE:
                    return Constant.INPUT_MENU_CHILD_TITLE;
                case Constant.INPUT_KATEGORY_APP_TYPE:
                    return Constant.INPUT_KATEGORY_APP_TITLE;
                case Constant.INPUT_KATEGORY_APP_CHILD_TYPE:
                    return Constant.INPUT_KATEGORY_APP_CHILD_TITLE;
                case Constant.INPUT_MAIN_PICTURE_TYPE:
                    return Constant.INPUT_MAIN_PICTURE_TITLE;
                case Constant.INPUT_BOTTOM_PICTURE_TYPE;
                    return Constant.INPUT_BOTTOM_PICTURE_TITLE;
                default: return string.Empty;
            }
        }

        protected void ShowStatusBar(Page page, string title, string message)
        {
            message = message.Trim(';');
            message = message.Replace(";", "<br/>");
            SPPageStatusSetter pageStatusSetter = new SPPageStatusSetter();
            pageStatusSetter.AddStatus(title, message, SPPageStatusColor.Yellow);
            page.Controls.Add(pageStatusSetter);
        }

        protected void ShowStatusBar(UserControl userControl, string title, string message)
        {
            message = message.Trim(';');
            message = message.Replace(";", "<br/>");
            SPPageStatusSetter pageStatusSetter = new SPPageStatusSetter();
            pageStatusSetter.AddStatus(title, message, SPPageStatusColor.Yellow);
            userControl.Controls.Add(pageStatusSetter);
        }

        protected void SetPageTitle(Page page, string title)
        {
            LiteralControl titleControl = (LiteralControl)page.Master.FindControl("PlaceHolderPageTitle").Controls[0];
            titleControl.Text = title;
        }

        private const string JS_VERSION_FORMAT = "?v={0}";
        private const string JS_DATE_VERSION_FORMAT = "yyyyMMddhhmmss";
        protected static string JSVersion
        {
            get
            {
                return string.Format(JS_VERSION_FORMAT, DateTime.Now.ToString(JS_DATE_VERSION_FORMAT));
            }
        }
    }
}
