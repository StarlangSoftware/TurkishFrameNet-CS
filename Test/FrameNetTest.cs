using System.Collections.Generic;
using NUnit.Framework;

namespace Test
{
    public class FrameNetTest
    {
        FrameNet.FrameNet frameNet;
        
        [SetUp]
        public void Setup()
        {
            frameNet = new FrameNet.FrameNet();
        }

        [Test]
        public void TestFrameSize() {
            Assert.AreEqual(139, frameNet.Size());
        }

        [Test]
        public void TestLexicalUnitSize() {
            var count = 0;
            for (var i = 0; i < frameNet.Size(); i++){
                count += frameNet.GetFrame(i).LexicalUnitSize();
            }
            Assert.AreEqual(2561, count);
        }

        [Test]
        public void TestFrameElementSize() {
            var count = 0;
            for (var i = 0; i < frameNet.Size(); i++){
                count += frameNet.GetFrame(i).FrameElementSize();
            }
            Assert.AreEqual(1665, count);
        }

        [Test]
        public void TestDistinctFrameElements() {
            var elements = new HashSet<string>();
            for (var i = 0; i < frameNet.Size(); i++){
                for (var j = 0; j < frameNet.GetFrame(i).FrameElementSize(); j++) {
                    elements.Add(frameNet.GetFrame(i).GetFrameElement(j));
                }
            }
            Assert.AreEqual(289, elements.Count);
        }

    }
}