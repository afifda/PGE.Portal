using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGEPortal.Service.DataAccess;
using PGEPortal.Service.Entity;

namespace PGEPortal.Service.BusinessLogic
{
    public class MasterDataLogic : BaseLogic
    {
        //public object GetInputProgramPage(MainMenuEntity User = null)
        //{

        //    MasterDataDataAccess dataAccess = new MasterDataDataAccess();
        //    List<MasterKategoriProgramEntity> kategori = SPRead<MasterKategoriProgramEntity>(new MasterKategoriProgramEntity() { KP_Kode = 0 });


        //    var inputPage = new
        //    {
        //        Kategori = kategori,                
        //    };
        //    return inputPage;
        //}
        public List<MainKategoryChildAppEntity> GetMainCategory()
        {
            return new HomePageDataAccess().GetMainCategory();
        }

        public List<MainKategoryChildAppEntity> GetMainCategoryChild(int MainCategoryID)
        {
            return new HomePageDataAccess().GetMainCategoryChild(MainCategoryID);
        }
        public List<NewsEntity> GetNews()
        {
            return new HomePageDataAccess().GetNews();
        }

        public List<EventEntity> GetEvent()
        {
            return new HomePageDataAccess().GetEvent();
        }

        public List<MainPicEntity> GetMainPic()
        {
            return new HomePageDataAccess().GetMainPic();
        }

        public List<BottomPicEntity> GetBottomPic()
        {
            return new HomePageDataAccess().GetBottomPic();
        }
    }
}
