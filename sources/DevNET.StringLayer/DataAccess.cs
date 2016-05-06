﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StringLayer
{
    public static class DataAccess
    {
        public static string Info()
        {
            StringBuilder dtsql = new StringBuilder();

            dtsql.Append("\r\nusing System;\r\n");
            dtsql.Append("using System.Collections;\r\n");
            dtsql.Append("using System.Data;\r\n");
            dtsql.Append("using System.Data.SqlClient;\r\n");
            dtsql.Append("using DevNET.Data.Connection;\r\n");
            dtsql.Append(" \r\n");

            dtsql.Append("namespace DevNET.Data.DataAccess\r\n");
            dtsql.Append("{\r\n");
            dtsql.Append("    public abstract class SqlHelper\r\n");
            dtsql.Append("    {\r\n");

            dtsql.Append(" \r\n");        
            dtsql.Append("        private static Hashtable parasCache = Hashtable.Synchronized(new Hashtable());\r\n");
            dtsql.Append(" \r\n");
            dtsql.Append("        public static void ExecuteNonQuery(CommandType cmdCommandType, string cmdCommandString, params SqlParameter[] cmdParameters)\r\n");
            dtsql.Append("        {\r\n");
            dtsql.Append("            SqlCommand cmdCommand = new SqlCommand();\r\n");
            dtsql.Append("            SqlConnection connect = new SqlConnection(ConnectionString.Text);\r\n");
            dtsql.Append("            try\r\n");
            dtsql.Append("            {\r\n");
            dtsql.Append("                PrepareCommand(cmdCommand, connect, null, cmdCommandType, cmdCommandString, cmdParameters);\r\n");
            dtsql.Append("                cmdCommand.ExecuteNonQuery();\r\n");
            dtsql.Append("                cmdCommand.Parameters.Clear();\r\n");
            dtsql.Append("                if (connect.State == ConnectionState.Open) connect.Close();\r\n");
            dtsql.Append("            }\r\n");
            dtsql.Append("            catch (SqlException ex)\r\n");
            dtsql.Append("            {\r\n");
            dtsql.Append("                if (connect.State == ConnectionState.Open)\r\n");
            dtsql.Append("                {\r\n");
            dtsql.Append("                    connect.Close();\r\n");
            dtsql.Append("                    SqlConnection.ClearPool(connect);\r\n");
            dtsql.Append("                }\r\n");
            dtsql.Append("                throw ex;\r\n");
            dtsql.Append("            }\r\n");
            dtsql.Append("        }\r\n");
            dtsql.Append(" \r\n");
            dtsql.Append("        public static DataTable ExecuteData(CommandType cmdCommandType, string cmdCommandString, params SqlParameter[] cmdParameters)\r\n");
            dtsql.Append("        {\r\n");
            dtsql.Append("            SqlCommand cmdCommand = new SqlCommand();\r\n");
            dtsql.Append("            SqlConnection connect = new SqlConnection(ConnectionString.Text);\r\n");
            dtsql.Append("            try\r\n");
            dtsql.Append("            {\r\n");
            dtsql.Append("                DataTable dattTopic = new DataTable();\r\n");
            dtsql.Append("                SqlDataAdapter dataTopic = new SqlDataAdapter(cmdCommand);\r\n");
            dtsql.Append("                PrepareCommand(cmdCommand, connect, null, cmdCommandType, cmdCommandString, cmdParameters);\r\n");
            dtsql.Append("                cmdCommand.ExecuteNonQuery();\r\n");
            dtsql.Append("                dataTopic.Fill(dattTopic);\r\n");
            dtsql.Append("                cmdCommand.Parameters.Clear();\r\n");
            dtsql.Append("                if (connect.State == ConnectionState.Open) connect.Close();\r\n");
            dtsql.Append("                return dattTopic;\r\n");
            dtsql.Append("            }\r\n");
            dtsql.Append("            catch (SqlException ex)\r\n");
            dtsql.Append("            {\r\n");
            dtsql.Append("                if (connect.State == ConnectionState.Open)\r\n");
            dtsql.Append("                {\r\n");
            dtsql.Append("                    connect.Close();\r\n");
            dtsql.Append("                    SqlConnection.ClearPool(connect);\r\n");
            dtsql.Append("                }\r\n");
            dtsql.Append("                throw ex;\r\n");
            dtsql.Append("            }\r\n");
            dtsql.Append("        }\r\n");
            dtsql.Append(" \r\n");
            dtsql.Append("        public static SqlDataReader ExecuteReader(CommandType cmdCommandType, string cmdCommandString, params SqlParameter[] cmdParameters)\r\n");
            dtsql.Append("        {\r\n");
            dtsql.Append("            SqlCommand cmdCommand = new SqlCommand();\r\n");
            dtsql.Append("            SqlConnection connect = new SqlConnection(ConnectionString.Text);\r\n");
            dtsql.Append("            try\r\n");
            dtsql.Append("            {\r\n");
            dtsql.Append("                PrepareCommand(cmdCommand, connect, null, cmdCommandType, cmdCommandString, cmdParameters);\r\n");
            dtsql.Append("                SqlDataReader datrDataReader = cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);\r\n");
            dtsql.Append("                cmdCommand.Parameters.Clear();\r\n");
            dtsql.Append("                return datrDataReader;\r\n");
            dtsql.Append("            }\r\n");
            dtsql.Append("            catch (SqlException ex)\r\n");
            dtsql.Append("            {\r\n");
            dtsql.Append("                if (connect.State == ConnectionState.Open)\r\n");
            dtsql.Append("                {\r\n");
            dtsql.Append("                    connect.Close();\r\n");
            dtsql.Append("                    SqlConnection.ClearPool(connect);\r\n");
            dtsql.Append("                }\r\n");
            dtsql.Append("                throw ex;\r\n");
            dtsql.Append("            }\r\n");
            dtsql.Append("        }\r\n");
            dtsql.Append(" \r\n");
            dtsql.Append("        private static void PrepareCommand(SqlCommand cmdCommand, SqlConnection connConnection, SqlTransaction trasTransaction, CommandType cmdCommandType, string cmdCommandString, SqlParameter[] cmdParameters)\r\n");
            dtsql.Append("        {\r\n");
            dtsql.Append("            if (connConnection.State != ConnectionState.Open)\r\n");
            dtsql.Append("            {\r\n");
            dtsql.Append("                connConnection.Open();\r\n");
            dtsql.Append("            }\r\n");
            dtsql.Append("            cmdCommand.Connection = connConnection;\r\n");
            dtsql.Append("            cmdCommand.CommandText = cmdCommandString;\r\n");
            dtsql.Append("            if (trasTransaction != null)\r\n");
            dtsql.Append("            {\r\n");
            dtsql.Append("                cmdCommand.Transaction = trasTransaction;\r\n");
            dtsql.Append("            }\r\n");
            dtsql.Append(" \r\n");
            dtsql.Append("            cmdCommand.CommandType = cmdCommandType;\r\n");
            dtsql.Append("            if (cmdParameters != null)\r\n");
            dtsql.Append("            {\r\n");
            dtsql.Append("                foreach (SqlParameter para in cmdParameters)\r\n");
            dtsql.Append("                {\r\n");
            dtsql.Append("                    cmdCommand.Parameters.Add(para);\r\n");
            dtsql.Append("                }\r\n");
            dtsql.Append("            }\r\n");
            dtsql.Append("        }\r\n");
            dtsql.Append(" \r\n");
            dtsql.Append("        public static void PrepareCommand(SqlCommand cmdCommand, CommandType cmdCommandType, string cmdCommandString, SqlParameter[] cmdParameters)\r\n");
            dtsql.Append("        {\r\n");
            dtsql.Append("            cmdCommand.Parameters.Clear();\r\n");
            dtsql.Append("            cmdCommand.CommandType = cmdCommandType;\r\n");
            dtsql.Append("            cmdCommand.CommandText = cmdCommandString;\r\n");
            dtsql.Append("            if (cmdParameters != null)\r\n");
            dtsql.Append("                foreach (SqlParameter para in cmdParameters)\r\n");
            dtsql.Append("                    cmdCommand.Parameters.Add(para);\r\n");
            dtsql.Append("        }\r\n");
            dtsql.Append(" \r\n");
            dtsql.Append("        public static void CacheParameters(string cacheKey, params SqlParameter[] cmdParameters)\r\n");
            dtsql.Append("        {\r\n");
            dtsql.Append("            parasCache[cacheKey] = cmdParameters;\r\n");
            dtsql.Append("        }\r\n");
            dtsql.Append(" \r\n");
            dtsql.Append("        public static SqlParameter[] GetCachedParameters(string cacheKey)\r\n");
            dtsql.Append("        {\r\n");
            dtsql.Append("            SqlParameter[] cachedParms = (SqlParameter[])parasCache[cacheKey];\r\n");
            dtsql.Append(" \r\n");
            dtsql.Append("            if (cachedParms == null)\r\n");
            dtsql.Append("            {\r\n");
            dtsql.Append("                return null;\r\n");
            dtsql.Append("            }\r\n");
            dtsql.Append("            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];\r\n");
            dtsql.Append("            for (int i = 0, j = cachedParms.Length; i < j; i++)\r\n");
            dtsql.Append("            {\r\n");
            dtsql.Append("                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();\r\n");
            dtsql.Append("            }\r\n");
            dtsql.Append("            return clonedParms;\r\n");
            dtsql.Append("        }\r\n");
            dtsql.Append(" \r\n");
            dtsql.Append("    }\r\n");
            dtsql.Append("}\r\n");

            return dtsql.ToString() ;
        }
    }
}