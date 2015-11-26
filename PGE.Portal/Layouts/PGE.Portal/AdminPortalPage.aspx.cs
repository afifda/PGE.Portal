using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using PGEPortal.Service.Entity;
using PGEPortal.Service.BusinessLogic;
using System.Web;
using System.IO;
using PGEPortal.Service.DataAccess;



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

        #region Master Main Menu Child

            [System.Web.Services.WebMethod]
            public static List<MainMenuEntity> LoadMainMenu()
            {
                List<MainMenuEntity> menuList = null;
                try
                {
                    BaseLogic logic = new BaseLogic();
                    menuList = logic.SPRead<MainMenuEntity>(new MainMenuEntity() { Id = 0 });                  
                }
                catch (Exception ex)
                {
                    return menuList;
                }
                return menuList;
            }    

            [System.Web.Services.WebMethod]
            public static List<MainMenuChildEntity> LoadMasterMainMenuChild()
            {
                List<MainMenuChildEntity> menuChildList = null;
                try
                {
                    BaseLogic logic = new BaseLogic();
                    menuChildList = logic.SPRead<MainMenuChildEntity>(new MainMenuChildEntity() { Id = 0 });
                }
                catch (Exception ex)
                {
                    return menuChildList;
                }
                return menuChildList;
            }

            [System.Web.Services.WebMethod]
            public static string SaveMasterMenuChild(string masterMenuChildString, bool isEdit)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                MainMenuChildEntity mainMenuChild = (MainMenuChildEntity)serializer.Deserialize(masterMenuChildString, typeof(MainMenuChildEntity));
                try
                {
                    BaseLogic logic = new BaseLogic();
                    if (isEdit) logic.SPUpdate<MainMenuChildEntity>(mainMenuChild);
                    else logic.SPSave<MainMenuChildEntity>(mainMenuChild);
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Message.Contains("duplicate")) return string.Format("Menu {0} yang anda masukkan telah tersedia", mainMenuChild.MenuChildName);
                    else return string.Format("Telah terjadi error. ({0})", sqlEx.Message);
                }
                catch (Exception ex)
                {
                    return string.Format("Telah terjadi error. ({0})", ex.Message);
                }
                return "Berhasil. Master Menu Child telah disimpan.";
            }

            [System.Web.Services.WebMethod]
            public static string DeleteMasterMenuChild(int IdChild)
                {
                    try
                    {
                        BaseLogic logic = new BaseLogic();
                        logic.SPDelete<MainMenuChildEntity>(new MainMenuChildEntity() { Id = IdChild });
                    }
                    catch (Exception ex)
                    {
                        return "Telah terjadi error";
                    }
                    return "Success";
                }
        
        #endregion

        #region Master Main Kategory App

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

        #region Master Main Kategory Child

            [System.Web.Services.WebMethod]
            public static List<MainKategoryAppEntity> LoadMainKategory()
            {
                List<MainKategoryAppEntity> kategoryList = null;
                try
                {
                    BaseLogic logic = new BaseLogic();
                    kategoryList = logic.SPRead<MainKategoryAppEntity>(new MainKategoryAppEntity() { Id = 0 });
                }
                catch (Exception ex)
                {
                    return kategoryList;
                }
                return kategoryList;
            }

            [System.Web.Services.WebMethod]
            public static List<MainKategoryChildAppEntity> LoadMasterMainKategoryAppChild()
            {
                List<MainKategoryChildAppEntity> kategoryChildList = null;
                try
                {
                    BaseLogic logic = new BaseLogic();
                    kategoryChildList = logic.SPRead<MainKategoryChildAppEntity>(new MainKategoryChildAppEntity() { Id = 0 });
                }
                catch (Exception ex)
                {
                    return kategoryChildList;
                }
                return kategoryChildList;
            }

            [System.Web.Services.WebMethod]
            public static string SaveMasterKategoryAppChild(string masterKategoryAppChildString, bool isEdit)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                MainKategoryChildAppEntity kategoryChild = (MainKategoryChildAppEntity)serializer.Deserialize(masterKategoryAppChildString, typeof(MainKategoryChildAppEntity));
                try
                {
                    BaseLogic logic = new BaseLogic();
                    if (isEdit) logic.SPUpdate<MainKategoryChildAppEntity>(kategoryChild);
                    else logic.SPSave<MainKategoryChildAppEntity>(kategoryChild);
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Message.Contains("duplicate")) return string.Format("Menu {0} yang anda masukkan telah tersedia", kategoryChild.LinkAppName);
                    else return string.Format("Telah terjadi error. ({0})", sqlEx.Message);
                }
                catch (Exception ex)
                {
                    return string.Format("Telah terjadi error. ({0})", ex.Message);
                }
                return "Berhasil. Master Menu Child telah disimpan.";
            }

            [System.Web.Services.WebMethod]
            public static string DeleteMasterKategoryAppChild(int IdChild)
            {
                try
                {
                    BaseLogic logic = new BaseLogic();
                    logic.SPDelete<MainKategoryChildAppEntity>(new MainKategoryChildAppEntity() { Id = IdChild });
                }
                catch (Exception ex)
                {
                    return "Telah terjadi error";
                }
                return "Success";
            }

            #endregion

        #region Master Main Pic
            [System.Web.Services.WebMethod]
            public static string SaveMasterMainPic(string fileToUpload, bool isEdit)
            {
                BaseLogic logic = new BaseLogic();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                MainPicEntity mainMenu = (MainPicEntity)serializer.Deserialize(fileToUpload, typeof(MainPicEntity));
                int success = 0;
                try
                {
                    SPSite site = new SPSite("http://affandi:100/sites/pgeportal/");

                    using (site)
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true; 
                        using (web)
                        {
                            SPFolder picLibrary = web.Lists["MainGallery"].RootFolder;
                            

                            byte[] picFile = null;

                            using (FileStream fStream = new FileStream(mainMenu.Path, FileMode.Open))
                            {
                                picFile = new byte[(int)fStream.Length];
                                fStream.Read(picFile, 0, (int)fStream.Length);
                                fStream.Close();
                            }

                            SPFile file = picLibrary.Files.Add(mainMenu.FileName, picFile);
                            picLibrary.Update();
                            string URLIMG = "";
                            string FileName = "";
                            FileName = mainMenu.FileName;
                            URLIMG = site.Url+file.Url;
                            
                            SPDocumentLibrary docLib = (SPDocumentLibrary)web.Lists["MainGallery"];
                            try
                            {
                                success = logic.SaveImgPic(URLIMG, FileName);
                               
                            }
                            catch (Exception ex)
                            {
                                
                                return string.Format("Telah terjadi error Pada saat Simpan File to DB. ({0})", ex.Message);
                            }


                        }
                    }
                }
                catch (Exception ex)
                {
                    return string.Format("Telah terjadi error. ({0})", ex.Message);
                }
                return "Berhasil. Master Menu Child telah disimpan.";
            }
        #endregion        
    }
}
