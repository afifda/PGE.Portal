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

        #region Master Area
            //[System.Web.Services.WebMethod]
            //public static List<MasterAreaEntity> LoadMasterArea()
            //{
            //    List<MasterAreaEntity> areaList = null;
            //    try
            //    {
            //        MasterDataLogic logic = new MasterDataLogic();
            //        areaList = logic.SPRead<MasterAreaEntity>(new MasterAreaEntity() { AreaCode = "" });
            //    }
            //    catch (Exception ex)
            //    {
            //        return areaList;
            //    }
            //    return areaList;
            //}

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

            //[System.Web.Services.WebMethod]
            //public static string DeleteMasterArea(string kodeArea)
            //{
            //    try
            //    {
            //        MasterDataLogic logic = new MasterDataLogic();
            //        logic.SPDelete<MasterAreaEntity>(new MasterAreaEntity() { AreaCode = kodeArea });
            //    }
            //    catch (Exception ex)
            //    {
            //        return "Telah terjadi error";
            //    }
            //    return "Success";
            //}
        #endregion
    }
}
