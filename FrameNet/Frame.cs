using System.Collections.Generic;

namespace FrameNet
{
    public class Frame
    {
        private string name;
        private List<string> lexicalUnits;
        private List<string> frameElements;

        /**
        * Constructor of {@link Frame} class which takes inputStream as input and reads the frame
        *
        * @param inputStream  inputStream to read frame
        */
        public Frame(string name)
        {
            this.name = name;
            lexicalUnits = new List<string>();
            frameElements = new List<string>();
        }

        public void AddLexicalUnit(string lexicalUnit)
        {
            lexicalUnits.Add(lexicalUnit);
        }

        public void AddFrameElement(string frameElement)
        {
            frameElements.Add(frameElement);
        }

        public bool LexicalUnitExists(string synSetId)
        {
            return lexicalUnits.Contains(synSetId);
        }

        public string GetLexicalUnit(int index)
        {
            return lexicalUnits[index];
        }

        public string GetFrameElement(int index)
        {
            return frameElements[index];
        }

        public int LexicalUnitSize()
        {
            return lexicalUnits.Count;
        }

        public int FrameElementSize()
        {
            return frameElements.Count;
        }

        public string GetName()
        {
            return name;
        }
    }
}