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
        [Column(name: "MenuName", isDeleteParam: true, isUpdateParam: true, isAllowNull: false, isReadParam: true, isInsertParam: true, isPrimaryKey: false)]
        public string MenuName { get; set; }

        [Column(name: "MenuUrl", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string MenuUrl { get; set; }
    }

    [Table("[MainMenuChild]", true, false, "", "usp_SaveMainMenuChild", "usp_ReadMainMenuChild", "usp_UpdateMainMenuChild", "usp_DeleteMainMenuChild")]
   
    public class MainMenuChildEntity
    {
        [Column(name: "Id", isDeleteParam: true, isUpdateParam: false, isAllowNull: false, isReadParam: true, isInsertParam: false, isPrimaryKey: true)]
        public int Id { get; set; }
        [Column(name: "ParentId", isUpdateParam: true, isAllowNull: false, isInsertParam: true, isForeignKey: true, refTable: "MainMenu", refColumn: "Id", refDisplayColumn: "Area_Nama", columnDisplayLink: "MenuName")]
        public int ParentId { get; set; }
        [Column(name: "MenuName", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string MenuName { get; set; }

        [Column(name: "MenuChildName", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string MenuChildName { get; set; }
        [Column(name: "MenuChildUrl", isUpdateParam: true, isAllowNull: false, isInsertParam: true)]
        public string MenuChildUrl { get; set; }
    }
}
