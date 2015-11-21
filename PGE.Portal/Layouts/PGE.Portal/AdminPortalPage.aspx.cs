using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using PGEPortal.Service.Entity;
using PGEPortal.Service.BusinessLogic;



namespace PGE.Portal.Layouts.PGE.Portal
{
    public partial class AdminPortalPage : BaseLayoutPages
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strMasterType = Request.QueryString["MasterType"];
            if (string.IsNullOrEmpty(strMasterType))
            {
                ShowStatusBar(this, "Information", "Query string MasterType is not found");
                return;
            }

            string controlTemplate = MasterInputControl(strMasterType);
            if (string.IsNullOrEmpty(controlTemplate))
            {
                ShowStatusBar(this, "Information", string.Format("Master Data {0} is not found", strMasterType));
                return;
            }

            SetPageTitle(this.Page, MasterInputTitle(strMasterType));

            Control control = Page.LoadControl(Constant.CONTROL_TEMPLATES_PATH + controlTemplate);
            ControlContainer.Controls.Add(control);
        }

        #region Master Main Menu
            [System.Web.Services.WebMethod]
            public static List<MainMenuEntity> LoadMasterMainMenu()
                {
                    List<MainMenuEntity> menuList = null;
                    try
                    {
                        BaseLogic logic = new BaseLogic();
                        menuList = logic.SPRead<MainMenuEntity>(new MainMenuEntity() { MenuName = "" });
                    }
                    catch (Exception ex)
                    {
                        return menuList;
                    }
                    return menuList;
                }

            [System.Web.Services.WebMethod]
            public static string SaveMasterMenu(string masterMenuString, bool isEdit)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    MainMenuEntity mainMenu = (MainMenuEntity)serializer.Deserialize(masterMenuString, typeof(MainMenuEntity));
                    try
                    {
                        BaseLogic logic = new BaseLogic();
                        if (isEdit) logic.SPUpdate<MainMenuEntity>(mainMenu);
                        else logic.SPSave<MainMenuEntity>(mainMenu);
                    }
                    catch (SqlException sqlEx)
                    {
                        if (sqlEx.Message.Contains("duplicate")) return string.Format("Menu {0} yang anda masukkan telah tersedia", mainMenu.MenuName);
                        else return string.Format("Telah terjadi error. ({0})", sqlEx.Message);
                    }
                    catch (Exception ex)
                    {
                        return string.Format("Telah terjadi error. ({0})", ex.Message);
                    }
                    return "Success. Master Menu telah disimpan.";
                }

            [System.Web.Services.WebMethod]
            public static string DeleteMasterMenu(string menuName)
            {
                try
                {
                    BaseLogic logic = new BaseLogic();
                    logic.SPDelete<MainMenuEntity>(new MainMenuEntity() { MenuName = menuName });
                }
                catch (Exception ex)
                {
                    return "Telah terjadi error";
                }
                return "Success";
            }
        #endregion

        #region Master Main Link App
            
            [System.Web.Services.WebMethod]
            public static List<MainKategoryAppEntity> LoadMasterKategoriApp()
            {
                List<MainKategoryAppEntity> kategoryAppList = null;
                try
                {
                    BaseLogic logic = new BaseLogic();
                    kategoryAppList = logic.SPRead<MainKategoryAppEntity>(new MainKategoryAppEntity() { LinkAppKategoryName = "" });
                }
                catch (Exception ex)
                {
                    return kategoryAppList;
                }
                return kategoryAppList;
            }

            [System.Web.Services.WebMethod]
            public static string SaveKategoryApp(string LinkAppKategoryName, bool isEdit)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                MainKategoryAppEntity mainKategoryApp = (MainKategoryAppEntity)serializer.Deserialize(LinkAppKategoryName, typeof(MainKategoryAppEntity));
                try
                {
                    BaseLogic logic = new BaseLogic();
                    if (isEdit) logic.SPUpdate<MainKategoryAppEntity>(mainKategoryApp);
                    else logic.SPSave<MainKategoryAppEntity>(mainKategoryApp);
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Message.Contains("duplicate")) return string.Format("Kategori {0} yang anda masukkan telah tersedia", mainKategoryApp.LinkAppKategoryName);
                    else return string.Format("Telah terjadi error. ({0})", sqlEx.Message);
                }
                catch (Exception ex)
                {
                    return string.Format("Telah terjadi error. ({0})", ex.Message);
                }
                return "Success. Master Kategori Aplikasi telah disimpan.";
            }

            [System.Web.Services.WebMethod]
            public static string DeleteKategoryApp(string masterkategoryAppString)
            {
                try
                {
                    BaseLogic logic = new BaseLogic();
                    logic.SPDelete<MainKategoryAppEntity>(new MainKategoryAppEntity() { LinkAppKategoryName = masterkategoryAppString });
                }
                catch (Exception ex)
                {
                    return "Telah terjadi error";
                }
                return "Success";
            }

        #endregion
    }
}
