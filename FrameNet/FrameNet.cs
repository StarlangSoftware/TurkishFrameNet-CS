using System.Collections.Generic;
using System.IO;

namespace FrameNet
{
    public class FrameNet
    {
        private List<Frame> frames;

        /**
        * A constructor of {@link FrameNet} class which reads all frame files inside the files.txt file. For each
        * filename inside that file, the constructor creates a FrameNet.Frame and puts in inside the frames {@link ArrayList}.
        */
        public FrameNet()
        {
            frames = new List<Frame>();
            var assembly = typeof(FrameNet).Assembly;
            var fileListStream = assembly.GetManifestResourceStream("FrameNet.files.txt");
            var streamReader = new StreamReader(fileListStream);
            var line = streamReader.ReadLine();
            while (line != null)
            {
                var streamName = "FrameNet.AllFrames." + line;
                frames.Add(new Frame(line.Substring(0, line.IndexOf(".xml")),
                    assembly.GetManifestResourceStream(streamName)));
                line = streamReader.ReadLine();
            }
        }

        public bool LexicalUnitExists(string synSetId)
        {
            foreach (var frame in frames)
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
            foreach (var frame in frames)
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
            return frames.Count;
        }

        public Frame GetFrame(int index)
        {
            return frames[index];
        }
    }
}