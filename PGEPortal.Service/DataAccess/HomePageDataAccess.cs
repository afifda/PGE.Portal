using PGEPortal.Service.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary;

namespace PGEPortal.Service.DataAccess
{
    public class HomePageDataAccess : BaseSPDataAccess
    {
        //public List<string> GetMainCategory()
        //{
        //    List<string> listMainCategory = new List<string>();
        //    IDataReader reader = null;
        //    try
        //    {
        //        SqlCommand command = new SqlCommand("usp_ReadMainKategoryApp");
        //        command.Parameters.AddWithValue("@LinkAppKategoryName", string.Empty);
        //        command.CommandType = CommandType.StoredProcedure;
        //        OpenConnection(command, this.Connection);
        //        reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            listMainCategory.Add((string)reader["LinkAppKategoryName"]);
        //        }
        //        CloseCommitConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        CloseRollbackConnection();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (reader != null)
        //        {
        //            reader.Close();
        //        }
        //    }
        //    return listMainCategory;
        //}

        public List<MainKategoryChildAppEntity> GetMainCategory()
        {
            DoubleASqlMapper mapData = new DoubleASqlMapper();
            List<MainKategoryChildAppEntity> listMainCategoryChild = null;
            IDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand("usp_Kategory");                
                command.CommandType = CommandType.StoredProcedure;
                OpenConnection(command, this.Connection);
                reader = command.ExecuteReader();
                listMainCategoryChild = mapData.MapDataToEntityList<MainKategoryChildAppEntity>(reader);
                CloseCommitConnection();
            }
            catch (Exception ex)
            {
                CloseRollbackConnection();
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return listMainCategoryChild;
        }

        public List<MainKategoryChildAppEntity> GetMainCategoryChild(int MainCategoryID)
        {
            DoubleASqlMapper mapData = new DoubleASqlMapper();
            List<MainKategoryChildAppEntity> listMainCategoryChild = null;
            IDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand("usp_GetMainKategoryChildByKategoryID");
                command.Parameters.AddWithValue("@MainKategoryAppID", MainCategoryID);
                command.CommandType = CommandType.StoredProcedure;
                OpenConnection(command, this.Connection);
                reader = command.ExecuteReader();
                listMainCategoryChild = mapData.MapDataToEntityList<MainKategoryChildAppEntity>(reader);
                CloseCommitConnection();
            }
            catch (Exception ex)
            {
                CloseRollbackConnection();
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return listMainCategoryChild;
        }

        public List<NewsEntity> GetNews()
        {
            DoubleASqlMapper mapData = new DoubleASqlMapper();
            List<NewsEntity> listNews = new List<NewsEntity>();
            IDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand("usp_GetNews");
                command.CommandType = CommandType.StoredProcedure;
                OpenConnection(command, this.Connection);
                reader = command.ExecuteReader();
                //while (reader.Read())
                //{
                listNews = mapData.MapDataToEntityList<NewsEntity>(reader);
                //}
                CloseCommitConnection();
            }
            catch (Exception ex)
            {
                CloseRollbackConnection();
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return listNews;
        }

        public List<EventEntity> GetEvent()
        {
            DoubleASqlMapper mapData = new DoubleASqlMapper();
            List<EventEntity> listEvent = new List<EventEntity>();
            IDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand("usp_GetEvent");
                command.CommandType = CommandType.StoredProcedure;
                OpenConnection(command, this.Connection);
                reader = command.ExecuteReader();
                //while (reader.Read())
                //{
                listEvent = mapData.MapDataToEntityList<EventEntity>(reader);
                //}
                CloseCommitConnection();
            }
            catch (Exception ex)
            {
                CloseRollbackConnection();
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return listEvent;
        }


        public List<MainPicEntity> GetMainPic()
        {
            DoubleASqlMapper mapData = new DoubleASqlMapper();
            List<MainPicEntity> listMainPic = new List<MainPicEntity>();
            IDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand("usp_GetMainPic");
                command.CommandType = CommandType.StoredProcedure;
                OpenConnection(command, this.Connection);
                reader = command.ExecuteReader();
                //while (reader.Read())
                //{
                listMainPic = mapData.MapDataToEntityList<MainPicEntity>(reader);
                //}
                CloseCommitConnection();
            }
            catch (Exception ex)
            {
                CloseRollbackConnection();
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return listMainPic;
        }


        public List<BottomPicEntity> GetBottomPic()
        {
            DoubleASqlMapper mapData = new DoubleASqlMapper();
            List<BottomPicEntity> listBottomPic = new List<BottomPicEntity>();
            IDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand("usp_GetBottomPic");
                command.CommandType = CommandType.StoredProcedure;
                OpenConnection(command, this.Connection);
                reader = command.ExecuteReader();
                //while (reader.Read())
                //{
                listBottomPic = mapData.MapDataToEntityList<BottomPicEntity>(reader);
                //}
                CloseCommitConnection();
            }
            catch (Exception ex)
            {
                CloseRollbackConnection();
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return listBottomPic;
        }


    }
}
