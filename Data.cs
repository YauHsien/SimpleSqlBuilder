using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSqlBuilder.Data
{
    [DataContract]
    public class SelectSqlComponents
    {
        ICollection<string> selectClause = new List<string>();
        string fromClause;
        ICollection<string> whereClause = new List<string>();
        ICollection<string> orderByClause = new List<string>();

        [DataMember]
        protected ICollection<string> SelectClause
        {
            get { return selectClause; }
            set { selectClause = value; }
        }

        [DataMember]
        protected string FromClause
        {
            get { return fromClause; }
            set { fromClause = value; }
        }

        [DataMember]
        protected ICollection<string> WhereClause
        {
            get { return whereClause; }
            set { whereClause = value; }
        }

        [DataMember]
        protected ICollection<string> OrderByClause
        {
            get { return orderByClause; }
            set { orderByClause = value; }
        }
    }
}
