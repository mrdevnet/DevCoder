using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using ConvertType;

namespace StringLayer
{
    public static class Procedures
    {
        public static string Insert(Table table )
        {
            try
            {            
            string k1, k2, b,t;
            k1=k2=b=t="";
            StringBuilder k1b = new StringBuilder();
            StringBuilder k2b = new StringBuilder();
            StringBuilder bb = new StringBuilder();
            StringBuilder S = new StringBuilder();

            Table tb = new Table();
            tb = table;

            foreach (Column col in tb.Columns)
            {
                if (!col.Identity)
                {                   
                    switch (col.DataType.SqlDataType.ToString().ToLower())
                    {
                        case "char":
                        case "nchar":
                        case "varchar":
                        case "nvarchar":
                        case "binary":
                        case "varbinary":
                        case "datetime2":
                        case "time":
                        case "datetimeoffset": t = string.Format(" {0}({1}),", col.DataType.SqlDataType.ToString(), col.DataType.MaximumLength.ToString()); break;

                        case "varcharmax":
                        case "nvarcharmax":
                        case "varbinarymax": t = string.Format(" {0},", col.DataType.SqlDataType.ToString().Replace("Max","(Max)")); break;

                        default: t = string.Format(" {0},", col.DataType.SqlDataType.ToString()); break;

                    }

                    k1b.AppendFormat("\r\n    @{0}{1}", col.Name.ToString(), t);
                    k2b.AppendFormat("\r\n        [{0}],", col.Name.ToString());
                    bb.AppendFormat("\r\n        @{0},", col.Name.ToString());
                }
            }
           

            k1 = k1b.ToString();
            k2 = k2b.ToString();
            b = bb.ToString();

            k1 = k1.Substring(0, k1.Length - 1);
            k2 = string.Format("\r\n    ({0}\r\n    )", k2.Substring(0, k2.Length - 1) );
            b =  string.Format("\r\n    ({0}\r\n    )",b.Substring(0, b.Length - 1) );

            S.AppendFormat("\r\nCreate PROCEDURE [dbo].[{0}_Insert]", table.Name.ToString());
                S.Append(k1);
                S.Append("\r\nAs");
                S.AppendFormat("\r\n    Insert Into [{0}]",table.Name.ToString());
                S.Append(k2);
                S.Append("\r\n    Values");
                S.Append(b);

           return S.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();

            }
           
        }
        public static string Update(Table table)
        {
            try
            {
            string k1="",k2 = "",dk ="",t="";

            StringBuilder k1b = new StringBuilder();
            StringBuilder k2b = new StringBuilder();
            StringBuilder dkb = new StringBuilder();
            StringBuilder S = new StringBuilder();

            foreach (Column col in table.Columns)
            {
                switch (col.DataType.SqlDataType.ToString().ToLower())
                {
                    case "char":
                    case "nchar":
                    case "varchar":
                    case "nvarchar":
                    case "binary":
                    case "varbinary":
                    case "datetime2":
                    case "time":
                    case "datetimeoffset": t = string.Format(" {0}({1}),", col.DataType.SqlDataType.ToString(), col.DataType.MaximumLength.ToString()); break;

                    case "varcharmax":
                    case "nvarcharmax":
                    case "varbinarymax": t = string.Format(" {0},", col.DataType.SqlDataType.ToString().Replace("Max", "(Max)")); break;

                    default: t = string.Format(" {0},", col.DataType.SqlDataType.ToString()); break;

                }

                k1b.AppendFormat("\r\n    @{0}{1}",col.Name.ToString(),t);

                if(!col.InPrimaryKey)
                    k2b.AppendFormat("\r\n        [{0}]= @{0}," ,col.Name.ToString());
                else
                    dkb.AppendFormat("([{0}]= @{0}) And ", col.Name.ToString() );
               
            }
            k1 = k1b.ToString();
            k2 = k2b.ToString();
            dk = dkb.ToString();

            k1 = k1.Substring(0,k1.Length - 1);
            k2 = string.Format(" {0}",k2.Substring(0,k2.Length - 1));
            dk = string.Format("\r\n    Where {0}",dk.Substring(0,dk.Length - 4));

                S.AppendFormat("\r\nCreate PROCEDURE [dbo].[{0}_Update]", table.Name);
                S.Append(k1);
                S.Append("\r\nAs");
                S.AppendFormat("\r\n    Update [{0}]  Set", table.Name);
                S.Append(k2);
                S.Append(dk);

            return S.ToString();
            }
            catch
            {
                return " Can not create object !";

            }
        }
        public static string Delete(Table table)
        {
            try
            {
            string k1 = "", dk = "",t="";
            StringBuilder k1b = new StringBuilder();
            StringBuilder dkb = new StringBuilder();
            StringBuilder S = new StringBuilder();

            foreach (Column col in table.Columns)
            {
                if (col.InPrimaryKey)
                {
                    switch (col.DataType.SqlDataType.ToString().ToLower())
                    {
                        case "char":
                        case "nchar":
                        case "varchar":
                        case "nvarchar":
                        case "binary":
                        case "varbinary":
                        case "datetime2":
                        case "time":
                        case "datetimeoffset": t = string.Format(" {0}({1}),", col.DataType.SqlDataType.ToString(), col.DataType.MaximumLength.ToString()); break;

                        case "varcharmax":
                        case "nvarcharmax":
                        case "varbinarymax": t = string.Format(" {0},", col.DataType.SqlDataType.ToString().Replace("Max", "(Max)")); break;

                        default: t = string.Format(" {0},", col.DataType.SqlDataType.ToString()); break;

                    }

                    k1b.AppendFormat("\r\n    @{0}{1}",col.Name.ToString(),t);
                    dkb.AppendFormat(" ([{0}]= @{0}) And", col.Name.ToString());
                }

            }
            k1 = k1b.ToString();
            dk = dkb.ToString();

            k1 = k1.Substring(0, k1.Length - 1);
            dk = string.Format("\r\n    Where {0}", dk.Substring(0, dk.Length - 4));

                  S.AppendFormat("\r\nCreate PROCEDURE [dbo].[{0}_Delete]", table.Name);
                  S.Append(k1);
                  S.Append("\r\nAs");
                  S.AppendFormat("\r\n    Delete [{0}]", table.Name.ToString());
                  S.Append(dk);

            return S.ToString();
            }
            catch
            {
                return " Can not create object !";

            }
        }
        public static string SelectAll(Table table)
        {
            StringBuilder S = new StringBuilder();
                S.AppendFormat("\r\nCreate PROCEDURE [dbo].[{0}_SelectAll]", table.Name);
                S.Append("\r\nAs");
                S.AppendFormat("\r\n    Select * From [{0}]",table.Name);

            return S.ToString();
        }
        public static string SelectTop(Table table)
        {
            StringBuilder S = new StringBuilder();
            S.AppendFormat("\r\nCreate PROCEDURE [dbo].[{0}_SelectTop]",table.Name);
            S.Append("\r\n@Top	Nvarchar(10),");
            S.Append("\r\n@Where	Nvarchar(200),");
            S.Append("\r\n@Order	Nvarchar(200)");
            S.Append("\r\nAS");
            S.Append("\r\n    Declare @SQL Nvarchar(500)");
            S.AppendFormat("\r\n    Set @SQL = 'Select Top (' + @Top + ') * From [{0}]'",table.Name);
            S.Append("\r\n    if Len(@Top) = 0 ");
            S.Append("\r\n        Begin");
            S.AppendFormat("\r\n            Set @SQL = 'Select * From [{0}]'", table.Name);
            S.Append("\r\n        End");
            S.Append("\r\n    If len(@Where) >0 ");
            S.Append("\r\n        Begin");
            S.Append("\r\n            Set @SQL = @SQL + ' Where ' + @Where");
            S.Append("\r\n        End");
            S.Append("\r\n    If Len(@Order) >0");
            S.Append("\r\n        Begin");
            S.Append("\r\n            Set @SQL = @SQL + ' Order By ' + @Order");
            S.Append("\r\n        End");
            S.Append("\r\n    Execute sp_executesql @SQL ");

            return S.ToString();
        }
        public static string SelectPage(Table table)
        {
            try
            {
                StringBuilder S = new StringBuilder();
                StringBuilder k = new StringBuilder();
                foreach (Column cl in table.Columns)
                    if (cl.InPrimaryKey) k.AppendFormat("{0},", cl.Name);

                S.AppendFormat("\r\nCreate PROCEDURE [dbo].[{0}_SelectPage]", table.Name);
                S.Append("\r\n    @CurrentPage int,");
                S.Append("\r\n    @PageSize int,");
                S.Append("\r\n    @RowCount int output");
                S.Append("\r\nAs");
                S.Append("\r\n    With TablePaging As");
                S.Append("\r\n    (");
                S.Append("\r\n        Select ROW_NUMBER()");
                S.AppendFormat("\r\n        Over(Order By {0}) As RowNum,*", (k.Length > 0) ? k.ToString().Substring(0, k.Length - 1) : table.Columns[0].ToString());
                S.AppendFormat("\r\n        From [{0}]", table.Name);
                S.Append("\r\n    )");
                S.AppendFormat("\r\n    Select @RowCount = Count(*) from  [{0}]",table.Name);
                S.Append("\r\n    Select * From TablePaging");
                S.Append("\r\n    Where RowNum Between (@CurrentPage - 1) * @PageSize + 1 And @CurrentPage * @PageSize");
                S.Append("\r\n    Order By RowNum");
                return S.ToString();
            }
            catch 
            {
                return " Can not create object !";
            }
            
            
        }
        public static string SelectByID(Table table)
        {
            try
            {
            string k1 = "", dk = "",t="";
            StringBuilder k1b = new StringBuilder();
            StringBuilder dkb = new StringBuilder();
            StringBuilder S = new StringBuilder();

            foreach (Column col in table.Columns)
            {
                if (col.InPrimaryKey)
                {
                    switch (col.DataType.SqlDataType.ToString().ToLower())
                    {
                        case "char":
                        case "nchar":
                        case "varchar":
                        case "nvarchar":
                        case "binary":
                        case "varbinary":
                        case "datetime2":
                        case "time":
                        case "datetimeoffset": t = string.Format(" {0}({1}),", col.DataType.SqlDataType.ToString(), col.DataType.MaximumLength.ToString()); break;

                        case "varcharmax":
                        case "nvarcharmax":
                        case "varbinarymax": t = string.Format(" {0},", col.DataType.SqlDataType.ToString().Replace("Max", "(Max)")); break;

                        default: t = string.Format(" {0},", col.DataType.SqlDataType.ToString()); break;

                    }

                    k1b.AppendFormat("\r\n    @{0}{1}", col.Name.ToString(), t);
                    dkb.AppendFormat(" ([{0}]= @{0}) And", col.Name.ToString());
                }

            }
            k1 = k1b.ToString();
            dk = dkb.ToString();

            k1 = k1.Substring(0, k1.Length - 1);
            dk = string.Format("\r\n    Where {0}",dk.Substring(0, dk.Length - 4));

            S.AppendFormat("\r\nCreate PROCEDURE [dbo].[{0}_SelectByID]",table.Name.ToString());
                  S.Append(k1);
                  S.Append("\r\nAs");
                  S.AppendFormat("\r\n    Select * From [{0}]" , table.Name.ToString());
                  S.Append(dk);

            return S.ToString();
            }
            catch
            {
                return " Can not create object !";

            }
        }
        public static string TestByID(Table table)
        {
            try
            {
            string  dk = "", t = "",sl="";
            StringBuilder k1b = new StringBuilder();
            StringBuilder dkb = new StringBuilder();
            StringBuilder slb = new StringBuilder();
            StringBuilder S = new StringBuilder();

            foreach (Column col in table.Columns)
            {
                if (col.InPrimaryKey)
                {
                    switch (col.DataType.SqlDataType.ToString().ToLower())
                    {
                        case "char":
                        case "nchar":
                        case "varchar":
                        case "nvarchar":
                        case "binary":
                        case "varbinary":
                        case "datetime2":
                        case "time":
                        case "datetimeoffset": t = string.Format(" {0}({1}),", col.DataType.SqlDataType.ToString(), col.DataType.MaximumLength.ToString()); break;

                        case "varcharmax":
                        case "nvarcharmax":
                        case "varbinarymax": t = string.Format(" {0},", col.DataType.SqlDataType.ToString().Replace("Max", "(Max)")); break;

                        default: t = string.Format(" {0},", col.DataType.SqlDataType.ToString()); break;

                    }

                    k1b.AppendFormat("\r\n    @{0}{1}", col.Name.ToString(), t);
                    slb.AppendFormat("[{0}],", col.Name.ToString());
                    dkb.AppendFormat(" ([{0}]= @{0}) And", col.Name.ToString());
                   
                }

            }
            sl = slb.ToString();
            dk = dkb.ToString();

            sl = sl.Substring(0, sl.Length - 1);
            dk = string.Format("\r\n    Where {0}", dk.Substring(0, dk.Length - 4));

            S.AppendFormat("\r\nCreate PROCEDURE [dbo].[{0}_TestByID]",table.Name.ToString() );
                  S.Append(k1b.ToString());
                  S.Append("\r\n    @TestID Bit Output");
                  S.Append("\r\nAs");
                  S.AppendFormat("\r\n    Select {0} From [{1}] ",sl,table.Name.ToString());
                  S.Append(dk);
                  S.Append("\r\n    If(@@rowcount =0) Set @TestID = 0");
                  S.Append("\r\n    Else Set @TestID = 1");
            return S.ToString();
            }
            catch
            {
                return " Can not create object !";

            }
        }
    }
}

