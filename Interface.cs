using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleSqlBuilder.Interface
{
    [ServiceContract]
    public interface ISelectSqlBuilder
    {
        [OperationContract]
        ISelectSqlBuilder From(string fromClause);

        [OperationContract]
        ISelectSqlBuilder Where(string whereClause);

        /// <summary>
        /// 如果 Where 子句寫參數樣板格式 ( "param = @param" ) 
        /// 則可以額外提供 templateValue 值（例如 @param 填值為 3 ）
        /// 提供核對是否添加 Where 子句
        /// </summary>
        /// <param name="whereClause"></param>
        /// <param name="templateValue"></param>
        /// <returns></returns>
        [OperationContract]
        ISelectSqlBuilder Where(string whereClause, object templateValue);

        [OperationContract]
        ISelectSqlBuilder Select(string selectClause);

        [OperationContract]
        ISelectSqlBuilder Select(ICollection<string> selectClauseList);

        [OperationContract]
        ISelectSqlBuilder OrderBy(string orderByClause);

        [OperationContract]
        ISelectSqlBuilder OrderBy(ICollection<string> orderByClauseList);
    }
}
