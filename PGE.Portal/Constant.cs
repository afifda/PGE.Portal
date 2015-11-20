using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE.Portal
{
    static class Constant
    {
        #region Control Template
        public const string CONTROL_TEMPLATES_PATH = @"~/_CONTROLTEMPLATES/15/PGEPortal/";
        public const string INPUT_MENU_CONTROL = "InputMenuControl.ascx";

        public const string INPUT_MENU_TYPE = "InputMenu";

        public const string INPUT_MENU_TITLE = "Master Data Menu";

        #endregion

        #region Message
        public static string ERROR_NOT_AUTHORIZED = string.Format("Anda tidak mempunyai hak akses pada laman ini.{0}Hubungi Administrator untuk mendapatkan hak akses.", Environment.NewLine);
        public static string ERROR_DEFAULT = string.Format("Halaman ini mengalami error.{0}Hubungi Administrator.", Environment.NewLine);
        #endregion

        #region Value
        #endregion


    }
}
