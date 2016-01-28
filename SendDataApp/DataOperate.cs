using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace SendDataApp
{
    public class DataOperate
    {
        private const string SQL_SELECT_PARAM_BY_PARAMNAME = "SELECT * FROM PARAM WHERE PARAMNAME=@Paramname";
        private const string SQL_SELECT_DEVICE_BY_DEVICEDESC = "SELECT * FROM DEVICE WHERE DEVICEDESC=@Devicedesc";

        private const string SQL_INSERT_ORIGINALDATA = "INSERT INTO ORIGINALDATA (DeviceID, InsertTime, ParamID, ParamValue) VALUES(@DeviceID, @InsertTime, @ParamID, @ParamValue)";

        private const string PARAM_PARAM_NAME = "@Paramname";
        private const string PARAM_DEVICE_DESC = "@Devicedesc";


        private const string PARAM_DATA_ID = "@ID";
        private const string PARAM_DATA_DEVICEID = "@DeviceID";
        private const string PARAM_DATA_INSERTTIME = "@InsertTime";
        private const string PARAM_DATA_PARAMID = "@ParamID";
        private const string PARAM_DATA_PARAMVALUE = "@ParamValue";


        public IList<DeviceInfo> GetDeviceByDeviceDesc(string devicedesc)
        {
            IList<DeviceInfo> device = new List<DeviceInfo>();

            SqlParameter param = new SqlParameter(PARAM_DEVICE_DESC, SqlDbType.NVarChar);

            param.Value = devicedesc;

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_DEVICE_BY_DEVICEDESC, param))
            {
                while (rdr.Read())
                {
                    DeviceInfo newdevice = new DeviceInfo(rdr.GetInt32(0), rdr.GetDouble(1), rdr.GetDouble(2), rdr.GetString(3));
                    device.Add(newdevice);
                }
            }

            return device;
        }


        public IList<ParamInfo> GetParamByParamName(string paramname)
        {
            IList<ParamInfo> paramall = new List<ParamInfo>();

            SqlParameter param = new SqlParameter(PARAM_PARAM_NAME, SqlDbType.NVarChar);

            param.Value = paramname;

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_PARAM_BY_PARAMNAME, param))
            {
                while (rdr.Read())
                {
                    ParamInfo newparam = new ParamInfo(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3));
                    paramall.Add(newparam);
                }
            }

            return paramall;
        }



        public string GetParamDescByParamName(string paramname)
        {
            string desc = "";

            IList<ParamInfo> paramall = GetParamByParamName(paramname);

            desc = paramall[0].ParamDesc;

            return desc;
        }

        public int GetDeviceIDbyDeviceDesc(string devicedesc)
        {
            int deviceid = 0;

            IList<DeviceInfo> deviceall = GetDeviceByDeviceDesc(devicedesc);

            deviceid = deviceall[0].DeviceID;

            return deviceid;
        }


        public void InsertData(OriginalDataInfo datainfo)
        {

            StringBuilder moniterPlaceSQL = new StringBuilder();
            //获得每个命令的参数数组
            SqlParameter[] moniterPlaceParms = GetMoniterPlaceParameters();

            SqlCommand cmd = new SqlCommand();

            //设置的参数
            
            moniterPlaceParms[0].Value = datainfo.DeviceID;
            moniterPlaceParms[1].Value = datainfo.InsertTime;
            moniterPlaceParms[2].Value = datainfo.ParamID;
            moniterPlaceParms[3].Value = datainfo.ParamValue;
           

            foreach (SqlParameter parm in moniterPlaceParms)
                cmd.Parameters.Add(parm);
            //创建数据库连接
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
            {
                //插入数据
                moniterPlaceSQL.Append(SQL_INSERT_ORIGINALDATA);
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = moniterPlaceSQL.ToString();

                //读取输出的查询
                using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    rdr.Read();
                }
                //清除参数
                cmd.Parameters.Clear();
            }




        }


        private SqlParameter[] GetMoniterPlaceParameters()
        {
            SqlParameter[] sqlParams = SqlHelper.GetCachedParameters(SQL_INSERT_ORIGINALDATA);
            if (sqlParams == null)
            {
                sqlParams = new SqlParameter[]{
                   
                    new SqlParameter(PARAM_DATA_DEVICEID, SqlDbType.Int),
                    new SqlParameter(PARAM_DATA_INSERTTIME, SqlDbType.DateTime),
                    new SqlParameter(PARAM_DATA_PARAMID,SqlDbType.Int),
                    new SqlParameter(PARAM_DATA_PARAMVALUE, SqlDbType.Float)
                };
                SqlHelper.CacheParameters(SQL_INSERT_ORIGINALDATA, sqlParams);
            }
            return sqlParams;

        }





    }
}
