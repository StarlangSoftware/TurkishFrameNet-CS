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
            Assert.AreEqual(101, frameNet.Size());
        }

        [Test]
        public void TestLexicalUnitSize() {
            var count = 0;
            for (var i = 0; i < frameNet.Size(); i++){
                count += frameNet.GetFrame(i).Size();
            }
            Assert.AreEqual(2001, count);
        }

        [Test]
        public void TestFrameElementSize() {
            var count = 0;
            for (var i = 0; i < frameNet.Size(); i++){
                for (var j = 0; j < frameNet.GetFrame(i).Size(); j++) {
                    count += frameNet.GetFrame(i).GetLexicalUnit(j).Size();
                }
            }
            Assert.AreEqual(8624, count);
        }

        [Test]
        public void TestDistinctFrameElements() {
            var elements = new HashSet<string>();
            for (var i = 0; i < frameNet.Size(); i++){
                for (var j = 0; j < frameNet.GetFrame(i).Size(); j++) {
                    foreach (var element in frameNet.GetFrame(i).GetLexicalUnit(j).GetFrameElements()){
                        elements.Add(element);
                    }
                }
            }
            Assert.AreEqual(179, elements.Count);
        }

    }
}