using System;
using System.Collections;
using System.Text;

namespace ConvertType
{
    public static class ConvertTypeSQL
    {
        private static ArrayList ListType()
        {
            
            ArrayList l = new ArrayList();
            l.Add(new string[] { "string", "int", "decimal", "Single", "double", "DateTime", "bool", "short", "byte", "long", "Array", "Guid", "object" });
            l.Add(new string[] { "char", "nvarchar", "nchar", "varchar", "text", "ntext", "nvarcharmax", "varcharmax", "xml" });
            l.Add(new string[] { "int"});
            l.Add(new string[] {"money","smallmoney","numeric"});
            l.Add(new string[] { "real" });
            l.Add(new string[] { "float"});
            l.Add(new string[] { "datetime", "smalldatetime", "date", "time", "datetime2", "datetimeoffset" });
            l.Add(new string[] { "bit" });
            l.Add(new string[] { "smallint" });
            l.Add(new string[] { "tinyint" });
            l.Add(new string[] { "bigint" });
            l.Add(new string[] { "image", "binary", "timestamp", "varbinary", "varbinarymax" });
            l.Add(new string[] { "uniqueidentifier" });
            l.Add(new string[] { "variant" });
            return l; 
            
        }
        
       
        public static string TypeC(string TypeSQL)
        {
            ArrayList li = ListType();
            string[] typeC = (li[0] as string[]);
            for (int i = 1; i < li.Count; i++)
            {
                string[] str = (li[i] as string[]);
                for (int j = 0; j < str.Length; j++)
                {
                    if (TypeSQL.ToLower() == str[j])
                        return typeC[i-1];
                }
            }
            return "object";
        }

    }
}
