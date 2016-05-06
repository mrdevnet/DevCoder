using System;
using System.Collections;
using System.Linq;
using System.Text;


namespace ConvertType
{
    public static class ConvertTypeControl
    {
        private static ArrayList GetTypeControl()
        {

            ArrayList l = new ArrayList();
            l.Add(new string[] { "{0} = txt{1}.Text", "{0} = int.Parse(txt{1}.Text)", "{0} = decimal.Parse(txt{1}.Text)", "{0} = Single.Parse(txt{1}.Text)", "{0} = double.Parse(txt{1}.Text)", "{0} = DateTime.Parse(txt{1}.Text)", "{0} = ckb{1}.Checked", "{0} = short.Parse(txt{1}.Text)", "{0} = byte.Parse(txt{1}.Text)", "{0} = long.Parse(txt{1}.Text)", "{0} = new ArrayList()", "{0} = Guid.NewGuid()" });
            l.Add(new string[] { "char", "nvarchar", "nchar", "varchar", "text", "ntext" });
            l.Add(new string[] { "int" });
            l.Add(new string[] { "money", "smallmoney", "numeric" });
            l.Add(new string[] { "real" });
            l.Add(new string[] { "float" });
            l.Add(new string[] { "datetime", "smalldatetime" });
            l.Add(new string[] { "bit" });
            l.Add(new string[] { "smallint" });
            l.Add(new string[] { "tinyint" });
            l.Add(new string[] { "bigint" });
            l.Add(new string[] { "image", "binary", "timestamp", "varbinary" });
            l.Add(new string[] { "uniqueidentifier" });
            return l;
        }
        private static ArrayList SetTypeControl()
        {

            ArrayList l = new ArrayList();
            l.Add(new string[] { "txt{1}.Text = {0}", "txt{1}.Text = {0}.ToString()", "txt{1}.Text = {0}.ToString()", "txt{1}.Text = {0}.ToString()", "txt{1}.Text = {0}.ToString()", "txt{1}.Text = {0}.ToString(\"dd/MM/yyyy\")", "ckb{1}.Checked = {0}", "txt{1}.Text = {0}.ToString()", "txt{1}.Text = {0}.ToString()", "txt{1}.Text = {0}.ToString()", "ArrayList list{1} = {0} ", "Guid guid{1} = {0}" });
            l.Add(new string[] { "char", "nvarchar", "nchar", "varchar", "text", "ntext" });
            l.Add(new string[] { "int" });
            l.Add(new string[] { "money", "smallmoney", "numeric" });
            l.Add(new string[] { "real" });
            l.Add(new string[] { "float" });
            l.Add(new string[] { "datetime", "smalldatetime" });
            l.Add(new string[] { "bit" });
            l.Add(new string[] { "smallint" });
            l.Add(new string[] { "tinyint" });
            l.Add(new string[] { "bigint" });
            l.Add(new string[] { "image", "binary", "timestamp", "varbinary" });
            l.Add(new string[] { "uniqueidentifier" });
            return l;
        }


        public static string GetControl(string TypeSQL, string PropertiesName, string ColumnName, bool getset)
        {
            ArrayList li;

            if (getset) li = GetTypeControl();
            else li = SetTypeControl();

            string[] typeC = (li[0] as string[]);
            for (int i = 1; i < li.Count; i++)
            {
                string[] str = (li[i] as string[]);
                for (int j = 0; j < str.Length; j++)
                {
                    if (TypeSQL.ToLower() == str[j])
                        return string.Format(typeC[i - 1], PropertiesName, ColumnName);
                }
            }
            return "//null";
        }

    }
}
