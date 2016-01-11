using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using PGEPortal.Service.Entity;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using PGEPortal.Service.BusinessLogic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Script.Services;

namespace PGE.Portal.Layouts
{
    [Guid("1aa2f88c-84c8-42f9-b349-451ceaf205df")]
    public partial class GenericPortal : IHttpHandler
    {
        //public const string TEMP_FILE = "TempFile";
        string TEMP_FILE = Path.GetTempPath();
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["Method"];
            switch (method.ToLower())
            {
                case "maincategory":
                    GetMainCategory(context);
                    break;               
                case "news":
                    GetNews(context);
                    break;
                case "event":
                    GetEvent(context);
                    break;
                case "mainpic":
                    GetMainPic(context);
                    break;
                case "bottompic":
                    GetBottomPic(context);
                    break;
                case"uploadimage":
                    string LinkTo = context.Request.Params["link"];
                    UploadFileImage(context, LinkTo);
                    break;
                case "uploadimagenews":
                    string Tittle = context.Request.Params["tittle"];
                    string DateNews = context.Request.Params["datenews"];
                    string NewsText = context.Request.Params["text"];
                    UploadFileImageNews(context, Tittle, DateNews, NewsText);
                    break;
                case "uploadimageevent":
                    string TittleEvent = context.Request.Params["tittle"];
                    string DateEvent = context.Request.Params["dateevent"];
                    string EventText = context.Request.Params["text"];
                    UploadFileImageEvent(context, TittleEvent, DateEvent, EventText);
                    break;
                    
            }
        }

        //private void GetMainCategory(HttpContext context)
        //{
        //    List<string> listMainCategory = new MasterDataLogic().GetMainCategory();
        //    context.Response.Write(new JavaScriptSerializer().Serialize(listMainCategory));
        //}

         private void GetMainCategory(HttpContext context)
        {
            SPWeb theSite = SPContext.Current.Site.OpenWeb();
            SPUser theUser = theSite.CurrentUser;
            List<MainKategoryChildAppEntity> listMainCategory = new MasterDataLogic().GetMainCategory();
            if (!theUser.IsSiteAdmin)
            {
                MainKategoryChildAppEntity adminCategory = listMainCategory.Where(l => l.LinkAppName == "Admin").FirstOrDefault();
                if (adminCategory != null) listMainCategory.Remove(adminCategory);
            }
            context.Response.Write(new JavaScriptSerializer().Serialize(listMainCategory));
        }

         #region separated
         //private void GetMainCategoryChild(HttpContext context)
        //{
        //    List<MainKategoryChildAppEntity> listMainCategory = new MasterDataLogic().GetMainCategoryChild(2);
        //    context.Response.Write(new JavaScriptSerializer().Serialize(listMainCategory));
        //}

        //private void GetMainCategoryChildTwo(HttpContext context)
        //{
        //    List<MainKategoryChildAppEntity> listMainCategory = new MasterDataLogic().GetMainCategoryChild(4);
        //    context.Response.Write(new JavaScriptSerializer().Serialize(listMainCategory));
        //}

        //private void GetMainCategoryChildThree(HttpContext context)
        //{
        //    List<MainKategoryChildAppEntity> listMainCategory = new MasterDataLogic().GetMainCategoryChild(5);
        //    context.Response.Write(new JavaScriptSerializer().Serialize(listMainCategory));
        //}

        //private void GetMainCategoryChildFour(HttpContext context)
        //{
        //    List<MainKategoryChildAppEntity> listMainCategory = new MasterDataLogic().GetMainCategoryChild(6);
        //    context.Response.Write(new JavaScriptSerializer().Serialize(listMainCategory));
        //}

        //private void GetMainCategoryChildFive(HttpContext context)
        //{
        //    List<MainKategoryChildAppEntity> listMainCategory = new MasterDataLogic().GetMainCategoryChild(7);
        //    context.Response.Write(new JavaScriptSerializer().Serialize(listMainCategory));
         //}
        #endregion
        
        private void GetNews(HttpContext context)
        {
            List<NewsEntity> listNews = new MasterDataLogic().GetNews();
            context.Response.Write(new JavaScriptSerializer().Serialize(listNews));
        }

        private void GetEvent(HttpContext context)
        {
            List<EventEntity> listEvent = new MasterDataLogic().GetEvent();
            context.Response.Write(new JavaScriptSerializer().Serialize(listEvent));
        }

        private void GetMainPic(HttpContext context)
        {
            List<MainPicEntity> listMainPic = new MasterDataLogic().GetMainPic();
            context.Response.Write(new JavaScriptSerializer().Serialize(listMainPic));
        }

        private void GetBottomPic(HttpContext context)
        {
            List<BottomPicEntity> listBottomPic = new MasterDataLogic().GetBottomPic();            
            context.Response.Write(new JavaScriptSerializer().Serialize(listBottomPic));
        }

        private void UploadFileImage(HttpContext context, string LinkTo)
        {
            string result = string.Empty;
            List<BottomPicEntity> attachmentList = new List<BottomPicEntity>();
            BottomPicEntity attachment = new BottomPicEntity();
            if (context.Request.Files.Count > 0)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    //string tempFolder = System.Configuration.ConfigurationManager.AppSettings[TEMP_FILE];
                    string tempFolder =TEMP_FILE;
                    if (!Directory.Exists(tempFolder))
                    {
                        Directory.CreateDirectory(tempFolder);
                    }
                    HttpFileCollection files = context.Request.Files;
                    for(int i=0;i<files.Count;i++)
                    {
                        HttpPostedFile file = files[i];
                        string fnamefile = Path.GetFileName(file.FileName);
                        string fnamepath = Path.GetFullPath(file.FileName);
                        string fname = tempFolder + fnamefile;
                        string ftemporary = fname;
                        file.SaveAs(fname);
                        attachment.Path = fname;
                        attachment.LinkTo = LinkTo;
                        attachment.FileName = fnamefile;
                        attachmentList.Add(attachment);
                    }
                    //call save to list and DB
                     result = SaveMasterBottomPic(attachment, false);
                    //end
                });
            }
            context.Response.Write(new JavaScriptSerializer().Serialize(result));
        }

        private void UploadFileImageNews(HttpContext context, string Tittle, string DateNews, string NewsText)
        {
            string result = string.Empty;
            List<MainNewsEntity> newsList = new List<MainNewsEntity>();
            MainNewsEntity news = new MainNewsEntity();
            if (context.Request.Files.Count > 0)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    //string tempFolder = System.Configuration.ConfigurationManager.AppSettings[TEMP_FILE];
                    string tempFolder = TEMP_FILE;
                    if (!Directory.Exists(tempFolder))
                    {
                        Directory.CreateDirectory(tempFolder);
                    }
                    HttpFileCollection files = context.Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        string fnamefile = Path.GetFileName(file.FileName);
                        string fnamepath = Path.GetFullPath(file.FileName);
                        string fname = tempFolder + fnamefile;
                        string ftemporary = fname;
                        file.SaveAs(fname);
                        news.PicturePath = fname;
                        news.Tittle = Tittle;
                        news.DateNews = Convert.ToDateTime(DateNews);
                        news.NewsText = NewsText;
                        news.FileName = fnamefile;
                        newsList.Add(news);
                    }
                    //call save to list and DB
                    result = SaveMasterNews(news, false);
                    //end
                });
            }
            context.Response.Write(new JavaScriptSerializer().Serialize(result));
        }

        private void UploadFileImageEvent(HttpContext context, string Tittle, string DateEvent, string EventText)
        {
            string result = string.Empty;
            List<MainEventEntity> eventList = new List<MainEventEntity>();
            MainEventEntity events = new MainEventEntity();
            if (context.Request.Files.Count > 0)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    //string tempFolder = System.Configuration.ConfigurationManager.AppSettings[TEMP_FILE];
                    string tempFolder = TEMP_FILE;
                    if (!Directory.Exists(tempFolder))
                    {
                        Directory.CreateDirectory(tempFolder);
                    }
                    HttpFileCollection files = context.Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        string fnamefile = Path.GetFileName(file.FileName);
                        string fnamepath = Path.GetFullPath(file.FileName);
                        string fname = tempFolder + fnamefile;
                        string ftemporary = fname;
                        file.SaveAs(fname);
                        events.PicturePath = fname;
                        events.Tittle = Tittle;
                        events.DateEvent = Convert.ToDateTime(DateEvent);
                        events.EventText = EventText;
                        events.FileName = fnamefile;
                        eventList.Add(events);
                    }
                    //call save to list and DB
                    result = SaveMasterEvent(events, false);
                    //end
                });
            }
            context.Response.Write(new JavaScriptSerializer().Serialize(result));
        }

        public static string SaveMasterBottomPic(BottomPicEntity attachment, bool isEdit)
        {
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

                        using (FileStream fStream = new FileStream(attachment.Path, FileMode.Open))
                        {
                            picFile = new byte[(int)fStream.Length];
                            fStream.Read(picFile, 0, (int)fStream.Length);
                            fStream.Close();
                        }

                        SPFile file = picLibrary.Files.Add(attachment.FileName, picFile);
                        picLibrary.Update();

                        SPDocumentLibrary docLib = (SPDocumentLibrary)web.Lists["BottomGallery"];

                        //where docu is my  document library
                        SPListItemCollection items = docLib.Items;
                        string urlPicLib = "";

                        foreach (SPListItem item in items)
                        {

                            if (item.Name == attachment.FileName)
                            {
                                urlPicLib = item.Url;
                                attachment.Path = (sites + urlPicLib).Replace(" ", "%20");                              
                            }
                        }

                        //Here to save url db
                        BaseLogic logic = new BaseLogic();
                        if (isEdit) logic.SPUpdate<BottomPicEntity>(attachment);
                        else logic.SPSave<BottomPicEntity>(attachment);

                    }
                }
            }

            catch (Exception ex)
            {
                return string.Format("Telah terjadi error. ({0})", ex.Message);
            }
            return "Berhasil. Master Bottom Picture telah disimpan.";
        }

        public static string SaveMasterNews(MainNewsEntity news, bool isEdit)
        {            
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
                        SPFolder picLibrary = web.Lists["NewsGallery"].RootFolder;


                        byte[] picFile = null;

                        using (FileStream fStream = new FileStream(news.PicturePath, FileMode.Open))
                        {
                            picFile = new byte[(int)fStream.Length];
                            fStream.Read(picFile, 0, (int)fStream.Length);
                            fStream.Close();
                        }

                        SPFile file = picLibrary.Files.Add(news.FileName, picFile);
                        picLibrary.Update();

                        SPDocumentLibrary docLib = (SPDocumentLibrary)web.Lists["NewsGallery"];

                        //where docu is my  document library
                        SPListItemCollection items = docLib.Items;
                        string urlPicLib = "";
                        string url = "";
                        foreach (SPListItem item in items)
                        {

                            if (item.Name == news.FileName)
                            {
                                urlPicLib = item.Url;
                                news.PicturePath = (sites + urlPicLib).Replace(" ", "%20");                             
                            }
                        }

                        //Here to save url db
                        BaseLogic logic = new BaseLogic();
                        if (isEdit) logic.SPUpdate<MainNewsEntity>(news);
                        else logic.SPSave<MainNewsEntity>(news);
                        //logic.SPDelete<BottomPicEntity>(new BottomPicEntity() { Id = mainNews.Id });

                    }
                }


            }            
            catch (Exception ex)
            {
                return string.Format("Telah terjadi error. ({0})", ex.Message);
            }
            return "Berhasil. Master News telah disimpan.";
        }

        public static string SaveMasterEvent(MainEventEntity events, bool isEdit)
        {            
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
                        SPFolder picLibrary = web.Lists["EventGallery"].RootFolder;


                        byte[] picFile = null;

                        using (FileStream fStream = new FileStream(events.PicturePath, FileMode.Open))
                        {
                            picFile = new byte[(int)fStream.Length];
                            fStream.Read(picFile, 0, (int)fStream.Length);
                            fStream.Close();
                        }

                        SPFile file = picLibrary.Files.Add(events.FileName, picFile);
                        picLibrary.Update();

                        SPDocumentLibrary docLib = (SPDocumentLibrary)web.Lists["EventGallery"];

                        //where docu is my  document library
                        SPListItemCollection items = docLib.Items;
                        string urlPicLib = "";
                        string url = "";
                        foreach (SPListItem item in items)
                        {
                            if (item.Name == events.FileName)
                            {
                                urlPicLib = item.Url;
                                events.PicturePath = (sites + urlPicLib).Replace(" ", "%20");
                            }
                        }

                        //Here to save url db
                        BaseLogic logic = new BaseLogic();
                        if (isEdit) logic.SPUpdate<MainEventEntity>(events);
                        else logic.SPSave<MainEventEntity>(events);
                    }
                }


            }            
            catch (Exception ex)
            {
                return string.Format("Telah terjadi error. ({0})", ex.Message);
            }
            return "Berhasil. Master Event telah disimpan.";
        }
    }

}
