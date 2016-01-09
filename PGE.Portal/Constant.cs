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
            public const string INPUT_MENU_CHILD_CONTROL = "InputMenuChildControl.ascx";
            public const string INPUT_KATEGORY_APP_CONTROL = "InputKategoryAppControl.ascx";
            public const string INPUT_KATEGORY_APP_CHILD_CONTROL = "InputKategoryAppChildControl.ascx";
            public const string INPUT_MAIN_PICTURE_CONTROL = "InputMainPic.ascx";
            public const string INPUT_MAIN_EVENT_CONTROL = "InputMasterEvent.ascx";
            public const string INPUT_MAIN_NEWS_CONTROL = "InputMasterNews.ascx";
            public const string INPUT_BOTTOM_PICTURE_CONTROL = "InputBottomPic.ascx";
            public const string MAIN_MENU_CONTROL = "MainMenu.ascx";

            public const string INPUT_MENU_TYPE = "InputMenu";
            public const string INPUT_MENU_CHILD_TYPE = "InputMenuChild";
            public const string INPUT_KATEGORY_APP_TYPE = "InputKategoryApp";
            public const string INPUT_KATEGORY_APP_CHILD_TYPE = "InputKategoryAppChild";
            public const string INPUT_MAIN_PICTURE_TYPE = "InputMainPic";
            public const string INPUT_MAIN_EVENT = "InputMasterEvent";
            public const string INPUT_MAIN_NEWS = "InputMasterNews";
            public const string INPUT_BOTTOM_PICTURE_TYPE = "InputBottomPic";
            public const string MAIN_MENU_TYPE = "MainMenu";


            public const string INPUT_MENU_TITLE = "Master Menu";
            public const string INPUT_MENU_CHILD_TITLE = "Master Menu Child";
            public const string INPUT_KATEGORY_APP_TITLE = "Master Kategory App";
            public const string INPUT_KATEGORY_APP_CHILD_TITLE = "Master Kategory App Child";
            public const string INPUT_MAIN_PICTURE_TITLE = "Master Main Picture";
            public const string INPUT_BOTTOM_PICTURE_TITLE = "Master Bottom Picture";
            public const string INPUT_MAIN_EVENT_TITLE = "Master Main Event";
            public const string INPUT_MAIN_NEWS_TITLE = "Master Main News";
            public const string MAIN_MENU_TITTLE = "Main Menu";
        #endregion

        #region Message
            public static string ERROR_NOT_AUTHORIZED = string.Format("Anda tidak mempunyai hak akses pada laman ini.{0}Hubungi Administrator untuk mendapatkan hak akses.", Environment.NewLine);
            public static string ERROR_DEFAULT = string.Format("Halaman ini mengalami error.{0}Hubungi Administrator.", Environment.NewLine);
        #endregion

        #region Value
        #endregion


    }
}
