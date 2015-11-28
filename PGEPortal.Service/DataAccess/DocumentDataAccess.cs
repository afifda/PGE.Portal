using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PGEPortal.Service.Entity;
using System.Data.SqlClient;
using System.Data;
using UtilityLibrary;

namespace PGEPortal.Service.DataAccess
{
    public class DocumentDataAccess : BaseSPDataAccess
    {
        private const string USP_SAVE_MAIN_PIC = "usp_SaveMainPic";
        private const string PARAM_ID = "@Id";
        private const string PARAM_PATH = "@Path";
        private const string PARAM_FILE_NAME = "@FileName";

        public int SaveImgPic(string path,string FileName)
        {
            SqlCommand command = new SqlCommand(USP_SAVE_MAIN_PIC);
            command.CommandType = CommandType.StoredProcedure;
            int rowAffected = 0;
            IDataReader reader = null;
            AddInParameter(command, PARAM_PATH, path);
            AddInParameter(command, PARAM_FILE_NAME, FileName);

            try
            {
                OpenConnection(command, this.Connection);
                rowAffected = command.ExecuteNonQuery();
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

            return rowAffected;
        }
    }
}
