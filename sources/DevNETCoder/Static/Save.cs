using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.SqlServer.Management.Smo;

namespace DevNETCoder.Static
{
    public static class Save
    {
        public static Server SVName = null;
        public static Database Database = null;
        public static string DBName = "";
        public static string Connection = "";
        public static string DBConnect = "";
        public static string PathSave = "";
        public static DataTable Servers = null;
        public static ArrayList GetColumn(string table)
        {
            ArrayList colname = new ArrayList();
            Database database = SVName.Databases[DBName];
            Table tb = database.Tables[table];

            foreach (Column col in tb.Columns)
            {
                //IsPrimaryKey day
                colname.Add(col.Name + ":" + col.DataType.SqlDataType.ToString() + ":" + col.DataType.MaximumLength.ToString());
            }
            return colname;
        }
        public static ArrayList GetTable(string dbName)
        {
            ArrayList colTB = new ArrayList();
            Database database = SVName.Databases[dbName];
            foreach (Table tb in database.Tables)
            {
                if (!tb.IsSystemObject) 
                    colTB.Add(tb.Name.ToString());
            }
            return colTB;
        }
        public static ArrayList GetDataType(string table)
        {
            ArrayList colType = new ArrayList();
            Database database = SVName.Databases[DBName];
            Table tb = database.Tables[table];

            foreach (Column col in tb.Columns)
            {
                //IsPrimaryKey day
                colType.Add(col.DataType.SqlDataType.ToString());
            }
            return colType;
        }
        public static ArrayList GetPrimaryKey(string table)
        {
            ArrayList colKey = new ArrayList();
            Database database = SVName.Databases[DBName];
            Table tb = database.Tables[table];
            foreach (Column col in tb.Columns)
            {
                if (col.InPrimaryKey)
                    colKey.Add(col.InPrimaryKey);
            }
            return colKey;
        }
        
    }
    public static class RunSave
    {
        public static Table TableRun = null;
        public static string DBConnect = "";
        public static Database DatabaseQ = null;
        public static Database DatabaseC = null;
    }

}
