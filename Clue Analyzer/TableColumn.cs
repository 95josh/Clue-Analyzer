using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Clue_Analyzer
{
    public class TableColumn : IEquatable<TableColumn>
    {
        //The properties are lowercase first
        //because that is how sqlite stores them
        public string name { get; set; }
        public string type { get; set; }
        public int notnull { get; set; }
        public string dflt_value { get; set; }
        public int pk { get; set; }

        public TableColumn() 
        {

        }

        /// <summary>
        /// Creates a instance of the TableColumn class, 
        /// which is a object that stores information
        /// about a SQLite table column.
        /// </summary>
        /// <param name="n">The name of the column</param>
        /// <param name="t">Type of the column</param>
        /// <param name="nn">Not null (0 no, 1 yes)</param>
        /// <param name="d">Default Value</param>
        /// <param name="p">Primary key? (0 no, 1 yes)</param>
        public TableColumn(string columnName, string columnType, int IsNotNull, string defaultValue, int IsPrimaryKey)
        {
            name = columnName;
            type = columnType;
            notnull = IsNotNull;
            dflt_value = defaultValue;
            pk = IsPrimaryKey;
        }

        public string GetStatementAdd(string tablename)
        {
            string output = "ALTER TABLE " + tablename;
            output += " ADD COLUMN " + name + " " + type;
            if (dflt_value != "")
            {
                output += " DEFAULT \"" + dflt_value + "\"";
            }
            if (notnull == 1)
            {
                output += " NOT NULL";
            }
            return output;
        }

        
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((TableColumn)obj);
        }

        public bool Equals(TableColumn? other)
        {
            if (other == null)
            {
                return false;
            }
            if (name != other.name )
            {
                return false;
            }
            else return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
