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

        /// <summary>
        /// Checks if the given lexical unit exists in any frame in the frame set.
        /// </summary>
        /// <param name="synSetId">Id of the lexical unit</param>
        /// <returns>True if any frame contains the given lexical unit, false otherwise.</returns>
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

        /// <summary>
        /// Returns an array of frames that contain the given lexical unit in their lexical units
        /// </summary>
        /// <param name="synSetId">Id of the lexical unit.</param>
        /// <returns>An array of frames that contains the given lexical unit.</returns>
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

        /// <summary>
        /// Returns number of frames in the frame set.
        /// </summary>
        /// <returns>Number of frames in the frame set.</returns>
        public int Size()
        {
            return _frames.Count;
        }

        /// <summary>
        /// Returns the element at the specified position in the frame list.
        /// </summary>
        /// <param name="index">index of the element to return</param>
        /// <returns>The element at the specified position in the frame list.</returns>
        public Frame GetFrame(int index)
        {
            return _frames[index];
        }
    }
}