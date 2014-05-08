using Algorithms.Sources;

using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class RemoteControlTests
    {
        [Test]
        public void Test()
        {
            RemoteControl.ShowMoves("bglqvz");
        }
    }
}