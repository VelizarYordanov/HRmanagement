using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRmanagement.DAO
{
    public abstract class DaoBase
    {
        public string InsertSqlBuilder(string TableName, IEnumerable<string> ColumnNames)
        {
            string sql = "insert into " +
                TableName + "s" + 
                " (" +
                string.Join(", ", ColumnNames) +
                ") values (" ;

            IEnumerable<string> parameters = ColumnNames.Select(c => "@" + c);

            sql += string.Join(", ", parameters);

            sql += ");";

            return sql;
        }

        public string UpdateSqlBuilder(string TableName, IEnumerable<string> ColumnNames)
        {
            string sql = "update " + TableName + "s set ";
            sql += string.Join(", ", ColumnNames.Select(c => c + " = @" + c).ToArray());
            sql += " where id = @id;";

            return sql;
        }
    }
}
