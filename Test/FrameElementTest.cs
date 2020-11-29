using FrameNet;
using NUnit.Framework;

namespace Test
{
    public class FrameElementTest
    {
        
        [Test]
        public void TestFrameElement() {
            var frameElement = new FrameElement("Agent$Apply_Heat$TUR10-0100230");
            Assert.AreEqual("Agent", frameElement.GetFrameElementType());
            Assert.AreEqual("Apply_Heat", frameElement.GetFrame());
            Assert.AreEqual("TUR10-0100230", frameElement.GetId());
            Assert.AreEqual("Agent$Apply_Heat$TUR10-0100230", frameElement.ToString());
        }
    }
}