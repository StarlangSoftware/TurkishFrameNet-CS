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
        public FrameNet(){
            frames = new List<Frame>();
            var assembly = typeof(FrameNet).Assembly;
            var fileListStream = assembly.GetManifestResourceStream("FrameNet.files.txt");
            var streamReader = new StreamReader(fileListStream);
            var line = streamReader.ReadLine();
            while (line != null)
            {
                frames.Add(new Frame(line.Substring(0, line.IndexOf(".xml")), assembly.GetManifestResourceStream("FrameNet.Frames." + line)));
                line = streamReader.ReadLine();
            }
        }

        public int Size(){
            return frames.Count;
        }

        public Frame GetFrame(int index){
            return frames[index];
        }

    }
}