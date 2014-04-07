using NUnit.Framework;

namespace Braces
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var right = "adf{var f(){ var a=new array[]{2, 3, 4}; call(a);}";
            Assert.IsFalse(Braces.Ok(right));
            right += "; }";
            Assert.IsTrue(Braces.Ok(right));
        }
    }
}
