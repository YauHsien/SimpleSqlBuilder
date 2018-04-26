using SimpleSqlBuilder.Data;
using SimpleSqlBuilder.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleSqlBuilder.Implementation
{
    public class SelectSqlBuilder : SelectSqlComponents, ISelectSqlBuilder
    {
        private SelectSqlBuilder() { }

        public static SelectSqlBuilder From(string fromClause)
        {
            return new SelectSqlBuilder()
            {
                FromClause = fromClause,
            };
        }

        ISelectSqlBuilder ISelectSqlBuilder.From(string fromClause)
        {
            return From(fromClause);
        }

        public ISelectSqlBuilder OrderBy(string orderByClause)
        {
            OrderByClause.Add(orderByClause);
            return this;
        }

        public ISelectSqlBuilder OrderBy(ICollection<string> orderByClauseList)
        {
            OrderByClause = OrderByClause.Concat(orderByClauseList).ToList();
            return this;
        }

        public ISelectSqlBuilder Select(string selectClause)
        {
            SelectClause.Add(selectClause);
            return this;
        }

        public ISelectSqlBuilder Select(ICollection<string> selectClauseList)
        {
            SelectClause = SelectClause.Concat(selectClauseList).ToList();
            return this;
        }

        public ISelectSqlBuilder Where(string whereClause)
        {
            WhereClause.Add(whereClause);
            return this;
        }

        public ISelectSqlBuilder Where(string whereClause, object templateValue)
        {
            if (templateValue != null && !string.IsNullOrWhiteSpace(templateValue.ToString()))
                WhereClause.Add(whereClause);
            return this;
        }

        public override string ToString()
        {
            string sql =
                string.Format(
                    "select {0}{1}from {2}",
                    SelectClause.ToList().Aggregate((a, b) => a + Environment.NewLine + ", " + b),
                    Environment.NewLine,
                    FromClause
                );

            if (WhereClause.Count() > 0)
                sql =
                    string.Format(
                        "{0}{1}where {2}",
                        sql,
                        Environment.NewLine,
                        WhereClause.ToList().Aggregate((a, b) => a + " and " + b)
                    );

            if (OrderByClause.Count() > 0)
                sql =
                    string.Format(
                        "{0}{1}order by {2}",
                        sql,
                        Environment.NewLine,
                        OrderByClause.ToList().Aggregate((a, b) => a + ", " + b)
                    );

            return sql;
        }
    }
}
