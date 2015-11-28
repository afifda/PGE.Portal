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
            public static List<MainPicEntity> LoadMasterMainPic()
            {
                List<MainPicEntity> picList = null;
                try
                {
                    BaseLogic logic = new BaseLogic();
                    picList = logic.SPRead<MainPicEntity>(new MainPicEntity() { Path = "" });
                }
                catch (Exception ex)
                {
                    return picList;
                }
                return picList;
            }

            [System.Web.Services.WebMethod]
            public static string SaveMasterMainPic(string fileToUpload, bool isEdit)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                MainPicEntity MainMenu = (MainPicEntity)serializer.Deserialize(fileToUpload, typeof(MainPicEntity));
                string sites = "http://server-local12:8282/sites/PGEPortal/";
                
                try
                {                                                            
                    SPSite site = new SPSite(sites);

                    using (site)
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true; 
                        using (web)
                        {
                            SPFolder picLibrary = web.Lists["MainGallery"].RootFolder;


                            byte[] picFile = null;

                            using (FileStream fStream = new FileStream(MainMenu.Path, FileMode.Open))
                            {
                                picFile = new byte[(int)fStream.Length];
                                fStream.Read(picFile, 0, (int)fStream.Length);
                                fStream.Close();
                            }

                            SPFile file = picLibrary.Files.Add(MainMenu.FileName, picFile);
                            picLibrary.Update();
                            
                            SPDocumentLibrary docLib = (SPDocumentLibrary)web.Lists["MainGallery"];
                            #region febri
                            //where docu is my  document library
                            SPListItemCollection items = docLib.Items;
                            string  urlPicLib ="";                            
                            string url = "";
                            foreach (SPListItem item in items)
                            {

                                if (item.Name == mainMenu.FileName) {
                                    urlPicLib = item.Url;
                                    mainMenu.Path = sites+urlPicLib;
                                }
                            }           

                             //Here to save url db
                            if (isEdit) logic.SPUpdate<MainPicEntity>(mainMenu);
                            else logic.SPSave<MainPicEntity>(mainMenu);
                            #endregion

                            #region fandi
                            //string URLIMG = "";
                            //string FileName = "";
                            //FileName = mainMenu.FileName;
                            //URLIMG = site.Url + file.Url;
                            //try
                            //{
                            //    success = logic.SaveImgPic(URLIMG, FileName);

                            //}
                            //catch (Exception ex)
                            //{
                            SPListItemCollection items = docLib.Items;
                            string urlPicLib = "";

                            foreach (SPListItem item in items)
                            {
                            //    return string.Format("Telah terjadi error Pada saat Simpan File to DB. ({0})", ex.Message);
                            //}
                            #endregion


                                if (item.Name == MainMenu.FileName)
                                {
                                    urlPicLib = item.Url;
                                    MainMenu.Path = sites + urlPicLib;
                                }
                            }           

                            // Here to save url db//
                        }
                    }
                }
                catch (Exception ex)
                {
                    return string.Format("Telah terjadi error. ({0})", ex.Message);
                }
                return "Berhasil. Master Main Picture telah disimpan.";
            }

                            BaseLogic logic = new BaseLogic();
                            if (isEdit) logic.SPUpdate<MainPicEntity>(MainMenu);
                            else logic.SPSave<MainPicEntity>(MainMenu);

                            #endregion

                          
                        }
                    }
                }
                catch (Exception ex)
                {
                    return string.Format("Telah terjadi error. ({0})", ex.Message);
                }
                return "Berhasil. Master Main Picture telah disimpan.";
            }

            [System.Web.Services.WebMethod]
            public static string DeleteMasterMainPic(string fileToUpload)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                MainPicEntity mainMenu = (MainPicEntity)serializer.Deserialize(fileToUpload, typeof(MainPicEntity));
                string sites = "http://server-local12:8282/sites/PGEPortal/";

            [System.Web.Services.WebMethod]
            public static string DeleteMasterMainPic(string fileToUpload)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                MainPicEntity mainMenu = (MainPicEntity)serializer.Deserialize(fileToUpload, typeof(MainPicEntity));
                string sites = "http://server-local12:8282/sites/PGEPortal/";

                            try
                            {
                    SPSite site = new SPSite(sites);
                    using (site)
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true;
                        using (web)
                        {
                            SPFolder folder = web.Folders["MainGallery"];
                            SPFile file = folder.Files[mainMenu.FileName];
                            file.Delete();

                            BaseLogic logic = new BaseLogic();
                            logic.SPDelete<MainPicEntity>(new MainPicEntity() { Id = mainMenu.Id });

                        }
                    }                                                            
                }
                catch (Exception ex)
                {
                    return string.Format("Telah terjadi error. ({0})", ex.Message);
                }
                return "Success";
            }
        #endregion        
                    SPSite site = new SPSite(sites);
                    using (site)
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true;
                        using (web)
                        {
                            SPFolder folder = web.Folders["MainGallery"];
                            SPFile file = folder.Files[mainMenu.FileName];
                            file.Delete();

                            BaseLogic logic = new BaseLogic();
                            logic.SPDelete<MainPicEntity>(new MainPicEntity() { Id = mainMenu.Id });

        #region Master Bottom Pic
            [System.Web.Services.WebMethod]
            public static List<BottomPicEntity> LoadMasterBottomPic()
            {
                List<BottomPicEntity> picList = null;
                try
                {
                    BaseLogic logic = new BaseLogic();
                    picList = logic.SPRead<BottomPicEntity>(new BottomPicEntity() { Path = "" });
                            }
                    }                                                            
                }
                            catch (Exception ex)
                            {
                    return picList;
                }
                return picList;
            }

            [System.Web.Services.WebMethod]
            public static string SaveMasterBottomPic(string fileToUpload, bool isEdit)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                BottomPicEntity BottomMenu = (BottomPicEntity)serializer.Deserialize(fileToUpload, typeof(BottomPicEntity));
                string sites = "http://server-local12:8282/sites/PGEPortal/";
                //int success = 0;
                try
                {
                    SPSite site = new SPSite(sites);

                    using (site)
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true;
                        using (web)
                        {
                            SPFolder picLibrary = web.Lists["BottomGallery"].RootFolder;


                            byte[] picFile = null;

                            using (FileStream fStream = new FileStream(BottomMenu.Path, FileMode.Open))
                            {
                                picFile = new byte[(int)fStream.Length];
                                fStream.Read(picFile, 0, (int)fStream.Length);
                                fStream.Close();
                            }

                            SPFile file = picLibrary.Files.Add(BottomMenu.FileName, picFile);
                            picLibrary.Update();

                            SPDocumentLibrary docLib = (SPDocumentLibrary)web.Lists["BottomGallery"];
                                                    
                            //where docu is my  document library
                            SPListItemCollection items = docLib.Items;
                            string urlPicLib = "";

                            foreach (SPListItem item in items)
                            {
                    return string.Format("Telah terjadi error. ({0})", ex.Message);
                }
                return "Success";
            }
        #endregion        

        #region Master Event
            [System.Web.Services.WebMethod]
            public static List<MainEventEntity> LoadMasterEvent()
            {
                List<MainEventEntity> EventList = null;
                try
                {
                    BaseLogic logic = new BaseLogic();
                    EventList = logic.SPRead<MainEventEntity>(new MainEventEntity() { Tittle= "" });
                }
                catch (Exception)
                {

                    throw;
                                if (item.Name == BottomMenu.FileName)
                                {
                                    urlPicLib = item.Url;
                                    BottomMenu.Path = sites + urlPicLib;
                                }
                            }
                return EventList;
            }
                            
                            // Here to save url db//
            [System.Web.Services.WebMethod]
            public static string SaveMasterEvent(string fileToUpload, bool isEdit)
            {
                BaseLogic logic = new BaseLogic();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                MainEventEntity mainEvent = (MainEventEntity)serializer.Deserialize(fileToUpload, typeof(MainEventEntity));
                string sites = "http://affandi:100/sites/pgeportal/";
                try
                {
                    SPSite site = new SPSite(sites);

                            BaseLogic logic = new BaseLogic();
                            if (isEdit) logic.SPUpdate<BottomPicEntity>(BottomMenu);
                            else logic.SPSave<BottomPicEntity>(BottomMenu);
                    using (site)
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true;
                        using (web)
                        {
                            SPFolder picLibrary = web.Lists["MainGallery"].RootFolder;


                            byte[] picFile = null;

                            using (FileStream fStream = new FileStream(mainEvent.PicturePath, FileMode.Open))
                            {
                                picFile = new byte[(int)fStream.Length];
                                fStream.Read(picFile, 0, (int)fStream.Length);
                                fStream.Close();
                        }

                            SPFile file = picLibrary.Files.Add(mainEvent.FileName, picFile);
                            picLibrary.Update();

                            SPDocumentLibrary docLib = (SPDocumentLibrary)web.Lists["MainGallery"];
                            #region febri
                            //where docu is my  document library
                            SPListItemCollection items = docLib.Items;
                            string urlPicLib = "";
                            string url = "";
                            foreach (SPListItem item in items)
                            {

                                if (item.Name == mainEvent.FileName)
                                {
                                    urlPicLib = item.Url;
                                    mainEvent.PicturePath = sites + urlPicLib;
                    }
                }

                            //Here to save url db
                            if (isEdit) logic.SPUpdate<MainEventEntity>(mainEvent);
                            else logic.SPSave<MainEventEntity>(mainEvent);
                            #endregion

                            #region fandi
                            //string URLIMG = "";
                            //string FileName = "";
                            //FileName = mainMenu.FileName;
                            //URLIMG = site.Url + file.Url;
                            //try
                            //{
                            //    success = logic.SaveImgPic(URLIMG, FileName);

                            //}
                            //catch (Exception ex)
                            //{

                            //    return string.Format("Telah terjadi error Pada saat Simpan File to DB. ({0})", ex.Message);
                            //}
                            #endregion


                        }
                    }
                       
                    
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Message.Contains("duplicate")) return string.Format("Event {0} yang anda masukkan telah tersedia", mainEvent.EventText);
                    else return string.Format("Telah terjadi error. ({0})", sqlEx.Message);
                }
                catch (Exception ex)
                {
                    return string.Format("Telah terjadi error. ({0})", ex.Message);
                }
                return "Berhasil. Master Bottom Picture telah disimpan.";
                return "Berhasil. Master Event telah disimpan.";
            }

            [System.Web.Services.WebMethod]
            public static string DeleteMasterBottomPic(string fileToUpload)
            public static string DeleteMasterEvent(string fileToUpload)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                BottomPicEntity BottomMenu = (BottomPicEntity)serializer.Deserialize(fileToUpload, typeof(BottomPicEntity));
                string sites = "http://server-local12:8282/sites/PGEPortal/";

                MainEventEntity mainEvent = (MainEventEntity)serializer.Deserialize(fileToUpload, typeof(MainEventEntity));
                string sites = "http://affandi:100/sites/pgeportal/";
                try
                {     
                    SPSite site = new SPSite(sites);
                    using (site)
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true;
                        using (web)
                        {
                            SPFolder folder = web.Folders["BottomGallery"];
                            SPFile file = folder.Files[BottomMenu.FileName];
                            SPFolder folder = web.Folders["MainGallery"];
                            SPFile file = folder.Files[mainEvent.FileName];
                            file.Delete();
                        }

                            BaseLogic logic = new BaseLogic();
                        logic.SPDelete<MainEventEntity>(new MainEventEntity() { Id = mainEvent.Id });
                    }
                }
                catch (Exception ex)
                {
                    return "Telah terjadi error";
                }
                return "Success";
            }
        #endregion

        #region Master News
            [System.Web.Services.WebMethod]
            public static List<MainNewsEntity> LoadMasterNews()
            {
                List<MainNewsEntity> NewsList = null;
                try
                {
                    BaseLogic logic = new BaseLogic();
                    NewsList = logic.SPRead<MainNewsEntity>(new MainNewsEntity() { Tittle = "" });

                }
                catch (Exception)
                {
                    
                    throw;
                }
                return NewsList;
            }

            [System.Web.Services.WebMethod]
            public static string SaveMasterNews(string fileToUpload, bool isEdit)
            {
                BaseLogic logic = new BaseLogic();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                MainNewsEntity mainNews = (MainNewsEntity)serializer.Deserialize(fileToUpload, typeof(MainNewsEntity));
                string sites = "http://affandi:100/sites/pgeportal/";
                try
                {
                    SPSite site = new SPSite(sites);

                    using (site)
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true;
                        using (web)
                        {
                            SPFolder picLibrary = web.Lists["MainGallery"].RootFolder;


                            byte[] picFile = null;

                            using (FileStream fStream = new FileStream(mainNews.PicturePath, FileMode.Open))
                            {
                                picFile = new byte[(int)fStream.Length];
                                fStream.Read(picFile, 0, (int)fStream.Length);
                                fStream.Close();
                            }

                            SPFile file = picLibrary.Files.Add(mainNews.FileName, picFile);
                            picLibrary.Update();

                            SPDocumentLibrary docLib = (SPDocumentLibrary)web.Lists["MainGallery"];
                            #region febri
                            //where docu is my  document library
                            SPListItemCollection items = docLib.Items;
                            string urlPicLib = "";
                            string url = "";
                            foreach (SPListItem item in items)
                            {

                                if (item.Name == mainNews.FileName)
                                {
                                    urlPicLib = item.Url;
                                    mainNews.PicturePath = sites + urlPicLib;
                                }
                            }

                            //Here to save url db
                            if (isEdit) logic.SPUpdate<MainNewsEntity>(mainNews);
                            else logic.SPSave<MainNewsEntity>(mainNews);
                            #endregion

                            #region fandi
                            //string URLIMG = "";
                            //string FileName = "";
                            //FileName = mainMenu.FileName;
                            //URLIMG = site.Url + file.Url;
                            //try
                            //{
                            //    success = logic.SaveImgPic(URLIMG, FileName);

                            //}
                            //catch (Exception ex)
                            //{

                            //    return string.Format("Telah terjadi error Pada saat Simpan File to DB. ({0})", ex.Message);
                            //}
                            #endregion

                            logic.SPDelete<BottomPicEntity>(new BottomPicEntity() { Id = BottomMenu.Id });

                        }
                    }

                   
                    }                                                            
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Message.Contains("duplicate")) return string.Format("News {0} yang anda masukkan telah tersedia", mainNews.NewsText);
                    else return string.Format("Telah terjadi error. ({0})", sqlEx.Message);
                }
                catch (Exception ex)
                {
                    return string.Format("Telah terjadi error. ({0})", ex.Message);
                }
                return "Berhasil. Master News telah disimpan.";
            }

            [System.Web.Services.WebMethod]
            public static string DeleteMasterNews(string fileToUpload)
            {
                BaseLogic logic = new BaseLogic();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                MainNewsEntity mainNews = (MainNewsEntity)serializer.Deserialize(fileToUpload, typeof(MainNewsEntity));
                string sites = "http://affandi:100/sites/pgeportal/";
                try
                {
                    SPSite site = new SPSite(sites);
                    using (site)
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true;
                        using (web)
                        {
                            SPFolder folder = web.Folders["MainGallery"];
                            SPFile file = folder.Files[mainNews.PicturePath];
                            file.Delete();
                        }

                        logic.SPDelete<MainNewsEntity>(new MainNewsEntity() { Id = mainNews.Id });
                    }
                    
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
