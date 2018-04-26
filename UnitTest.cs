using NUnit.Framework;
using SimpleSqlBuilder.Implementation;
using SimpleSqlBuilder.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSqlBuilder.Test.UnitTest
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void TestSelectSqlBuilder()
        {
            string expected =
@"select [a]
, [b]
, c
from [d]
where [e] is null and f = @f
order by [g], [h] desc, i asc";
            string observed;

            ISelectSqlBuilder selectSqlBuilder =
                SelectSqlBuilder
                    .From("[d]")
                    .Select("[a]")
                    .Select(new List<string>() { "[b]", "c", })
                    .Where("[e] is null")
                    .Where("f = @f", 3)
                    .Where("[g] = @g", "")
                    .Where("h = @h", null)
                    .OrderBy("[g]")
                    .OrderBy(new List<string>() { "[h] desc", "i asc", });

            observed = selectSqlBuilder.ToString();

            Assert.AreEqual(expected, observed);
        }
    }
}
