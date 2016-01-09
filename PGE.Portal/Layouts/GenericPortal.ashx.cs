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
            }
        }

        //private void GetMainCategory(HttpContext context)
        //{
        //    List<string> listMainCategory = new MasterDataLogic().GetMainCategory();
        //    context.Response.Write(new JavaScriptSerializer().Serialize(listMainCategory));
        //}

         private void GetMainCategory(HttpContext context)
        {
            List<MainKategoryChildAppEntity> listMainCategory = new MasterDataLogic().GetMainCategory();
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
    }
}
