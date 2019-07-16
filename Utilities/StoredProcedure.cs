using System;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Processes stored procedures
/// </summary>
namespace Utilities
{
    public class StoredProcedure
    {
        private DBConnect objDB;
        private SqlCommand objCmd;

        public StoredProcedure()
        {
            objDB = new DBConnect();
            objCmd = new SqlCommand();
        }

        public SqlCommand setUpCommand(string command)
        {
            objCmd = new SqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = command;
            return objCmd;
        }
        public void doUpdate()
        { objDB.DoUpdateUsingCmdObj(objCmd); }
        public DataSet getData()
        { return objDB.GetDataSetUsingCmdObj(objCmd); }

        public DataSet getData(string command)
        {
            setUpCommand(command);
            return objDB.GetDataSetUsingCmdObj(objCmd);
        }

        //misc
        public SqlParameter param(string parameterName, int argumentvalue, SqlDbType type, int sizeLimit = -1)
        { return param(new SqlParameter(parameterName, argumentvalue), type, sizeLimit); }

        public SqlParameter param(string parameterName, DateTime argumentvalue, SqlDbType type, int sizeLimit = -1)
        { return param(new SqlParameter(parameterName, argumentvalue), type, sizeLimit); }



        public SqlParameter param(string parameterName, byte[] argumentvalue, SqlDbType type, int sizeLimit = -1)
        {
            return param(new SqlParameter(parameterName, argumentvalue), type, sizeLimit);
        }

        public SqlParameter param(string parameterName, string argumentvalue, SqlDbType type, int sizeLimit = -1)
        {
            return param(new SqlParameter(parameterName, argumentvalue), type, sizeLimit);
        }

        public SqlParameter param(string parameterName, double argumentvalue, SqlDbType type, int sizeLimit = -1)
        {
            return param(new SqlParameter(parameterName, argumentvalue), type, sizeLimit);
        }

        public SqlParameter param(string parameterName, decimal argumentvalue, SqlDbType type, int sizeLimit = -1)
        {
            return param(new SqlParameter(parameterName, argumentvalue), type, sizeLimit);
        }

        public SqlParameter param(SqlParameter inputParameter, SqlDbType type, int sizeLimit = -1)
        {
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = type;
            inputParameter.Size = ((sizeLimit != -1) ? sizeLimit : 0);
            return inputParameter;
        }

        public void sizeCheck(string[] s, int size)
        {
            if (size != s.Length)
                throw new Exception("Array size length error.");
        }

        public void setUpParameters(SqlParameter[] s)
        {
            objCmd.Parameters.AddRange(s);
        }

        public void setUpParameter(SqlParameter s)
        {
            objCmd.Parameters.Add(s);
        }
    }
}