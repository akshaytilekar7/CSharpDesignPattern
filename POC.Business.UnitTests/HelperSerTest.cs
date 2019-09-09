using NUnit.Framework;
using POC.Business.Service;

namespace POC.Business.UnitTests
{
    public class HelperSerTest
    {
        [Test]
        public void IsEven_Return_True_If_No_Is_Even()
        {
            var helperSerObj = new HelperSer();
            var res = helperSerObj.IsEven(2);

            Assert.IsTrue(res);
        }

        [Test]
        public void IsEven_Return_False_If_No_Is_NotEven()
        {
            var helperSerObj = new HelperSer();
            var res = helperSerObj.IsEven(3);

            Assert.IsFalse(res);
        }
    }
}
