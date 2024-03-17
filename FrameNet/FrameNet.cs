using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace FrameNet
{
    public class FrameNet
    {
        private List<Frame> _frames;

        /**
        * A constructor of {@link FrameNet} class which reads all frame files inside the files.txt file. For each
        * filename inside that file, the constructor creates a FrameNet.Frame and puts in inside the frames {@link ArrayList}.
        */
        public FrameNet()
        {
            _frames = new List<Frame>();
            var assembly = typeof(FrameNet).Assembly;
            var fileListStream = assembly.GetManifestResourceStream("FrameNet.framenet.xml");
            var doc = new XmlDocument();
            doc.Load(fileListStream);
            foreach (XmlNode frameNode in doc.DocumentElement.ChildNodes)
            {
                var frame = new Frame(frameNode.Attributes["NAME"].Value);
                var lexicalUnits = frameNode.FirstChild;
                foreach (XmlNode lexicalUnitNode in lexicalUnits.ChildNodes)
                {
                    frame.AddLexicalUnit(lexicalUnitNode.InnerText);
                }

                var frameElements = lexicalUnits.NextSibling;
                foreach (XmlNode frameElementNode in frameElements.ChildNodes)
                {
                    frame.AddFrameElement(frameElementNode.InnerText);
                }
                _frames.Add(frame);
            }
        }

        public bool LexicalUnitExists(string synSetId)
        {
            foreach (var frame in _frames)
            {
                if (frame.LexicalUnitExists(synSetId))
                {
                    return true;
                }
            }

            return false;
        }

        public List<Frame> GetFrames(string synSetId)
        {
            var result = new List<Frame>();
            foreach (var frame in _frames)
            {
                if (frame.LexicalUnitExists(synSetId))
                {
                    result.Add(frame);
                }
            }

            return result;
        }

        public int Size()
        {
            return _frames.Count;
        }

        public Frame GetFrame(int index)
        {
            return _frames[index];
        }
    }
}