using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary;

namespace PGEPortal.Service.Entity
{
    [Table("[MainMenu]", true, false, "", "usp_SaveMainMenu", "usp_ReadMasterMainMenu", "usp_UpdateMainMenu", "usp_DeleteMainMenu")]
    public class MainMenuEntity
    {
        [Column(name: "Id", isDeleteParam: false, isUpdateParam: false, isAllowNull: false, isReadParam: false, isInsertParam: false, isPrimaryKey: true)]
        public int Id { get; set; }

        [Column(name: "MenuName", isDeleteParam: true, isUpdateParam: true, isAllowNull: false, isReadParam: true, isInsertParam: true, isPrimaryKey: false)]
        public string MenuName { get; set; }

        [Column(name: "MenuUrl", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string MenuUrl { get; set; }
    }

    [Table("[MainMenuChild]", true, false, "", "usp_SaveMainMenuChild", "usp_ReadMainMenuChild", "usp_UpdateMainMenuChild", "usp_DeleteMainMenuChild")]   
    public class MainMenuChildEntity
    {
        [Column(name: "Id", isDeleteParam: true, isUpdateParam: true, isAllowNull: false, isReadParam: true, isInsertParam: false, isPrimaryKey: true)]
        public int Id { get; set; }

        [Column(name: "ParentId", isUpdateParam: true, isAllowNull: false, isReadParam: false, isInsertParam: true, isPrimaryKey: false)]
        public int ParentId { get; set; }

        [Column(name: "MenuName", isUpdateParam: false, isAllowNull: false, isInsertParam: false)]
        public string MenuName { get; set; }        
        
        [Column(name: "MenuChildName", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string MenuChildName { get; set; }

        [Column(name: "MenuChildUrl", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string MenuChildUrl { get; set; }
    }

    [Table("[MainKategoryApp]", true, false, "", "usp_SaveMainKategoryApp", "usp_GetMainKategoryApp", "usp_UpdateMainKategoryApp", "usp_DeleteMainKategoryApp")]
    public class MainKategoryAppEntity
    {
        [Column(name: "Id", isDeleteParam: false, isUpdateParam: false, isAllowNull: false, isReadParam: false, isInsertParam: false, isPrimaryKey: true)]
        public int Id { get; set; }

        [Column(name: "LinkAppKategoryName", isDeleteParam: true, isUpdateParam: true, isAllowNull: false, isReadParam: true, isInsertParam: true, isPrimaryKey: true)]
        public string LinkAppKategoryName { get; set; }
      
    }

    [Table("[MainKategoryChildApp]", true, false, "", "usp_SaveMainKategoryChildApp", "usp_GetMainKategoryChildByKategoryID", "usp_UpdateMainKategoryChildApp", "usp_DeleteMainKategoryChildApp")]
    public class MainKategoryChildAppEntity
    {
        [Column(name: "Id", isDeleteParam: true, isUpdateParam: true, isAllowNull: false, isReadParam: true, isInsertParam: false, isPrimaryKey: true)]
        public int Id { get; set; }

        [Column(name: "ParentId", isUpdateParam: true, isAllowNull: false, isReadParam: false, isInsertParam: true, isPrimaryKey: false)]
        public int ParentId { get; set; }

        //[Column(name: "LinkAppKategoryName", isUpdateParam: false, isAllowNull: false, isInsertParam: false)]
        //public string LinkAppKategoryName { get; set; }

        [Column(name: "LinkAppName", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string LinkAppName { get; set; }

        [Column(name: "LinkAppUrl", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string LinkAppUrl { get; set; }

    }

    [Table("[MainPic]", true, false, "", "usp_SaveMainPic", "usp_ReadMasterMainPic", "usp_UpdateMainPic", "usp_DeleteMainPic")]
    public class MainPicEntity
    {
        [Column(name: "Id", isDeleteParam: true, isUpdateParam: false, isAllowNull: false, isReadParam: false, isInsertParam: false, isPrimaryKey: true)]
        public int Id { get; set; }

        [Column(name: "Path", isDeleteParam: false, isUpdateParam: true, isAllowNull: false, isReadParam: true, isInsertParam: true, isPrimaryKey: false)]
        public string Path { get; set; }

        [Column(name: "FileName", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string FileName { get; set; }
    }

    [Table("[BottomPic]", true, false, "", "usp_SaveBottomPic", "usp_ReadMasterBottomPic", "usp_UpdateBottomPic", "usp_DeleteBottomPic")]
    public class BottomPicEntity
    {
        [Column(name: "Id", isDeleteParam: true, isUpdateParam: false, isAllowNull: false, isReadParam: false, isInsertParam: false, isPrimaryKey: true)]
        public int Id { get; set; }

        [Column(name: "Path", isDeleteParam: false, isUpdateParam: true, isAllowNull: false, isReadParam: true, isInsertParam: true, isPrimaryKey: false)]
        public string Path { get; set; }

        [Column(name: "FileName", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string FileName { get; set; }


        [Column(name: "LinkTo", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string LinkTo { get; set; }

    }

    [Table("[Event]", true, false, "", "usp_SaveEvent", "usp_ReadMasterEvent", "usp_UpdateEvent", "usp_DeleteEvent")]
    public class MainEventEntity
    {
        [Column(name: "Id", isDeleteParam: true, isUpdateParam: false, isAllowNull: false, isReadParam: false, isInsertParam: false, isPrimaryKey: true)]
        public int Id { get; set; }

        [Column(name: "Tittle", isDeleteParam: false, isUpdateParam: true, isAllowNull: false, isReadParam: true, isInsertParam: true, isPrimaryKey: false)]
        public string Tittle { get; set; }

        [Column(name: "DataEvent", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public DateTime DateEvent { get; set; }

        [Column(name: "EventText", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string EventText { get; set; }

        [Column(name: "PicturePath", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string PicturePath { get; set; }

        [Column(name: "FileName", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string FileName { get; set; }
    }

    [Table("[News]", true, false, "", "usp_SaveNews", "usp_ReadMasterNews", "usp_UpdateNews", "usp_DeleteNews")]
    public class MainNewsEntity
    {
        [Column(name: "Id", isDeleteParam: true, isUpdateParam: false, isAllowNull: false, isReadParam: false, isInsertParam: false, isPrimaryKey: true)]
        public int Id { get; set; }

        [Column(name: "Tittle", isDeleteParam: false, isUpdateParam: true, isAllowNull: false, isReadParam: true, isInsertParam: true, isPrimaryKey: false)]
        public string Tittle { get; set; }

        [Column(name: "DateNews", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public DateTime DateNews { get; set; }

        [Column(name: "NewsText", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string NewsText { get; set; }

        [Column(name: "PicturePath", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string PicturePath { get; set; }

        [Column(name: "FileName", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string FileName { get; set; }
    }



}
