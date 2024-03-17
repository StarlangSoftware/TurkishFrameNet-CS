using System.Collections.Generic;

namespace FrameNet
{
    public class Frame
    {
        private string _name;
        private List<string> _lexicalUnits;
        private List<string> _frameElements;

        /**
        * Constructor of {@link Frame} class which takes inputStream as input and reads the frame
        *
        * @param inputStream  inputStream to read frame
        */
        public Frame(string name)
        {
            this._name = name;
            _lexicalUnits = new List<string>();
            _frameElements = new List<string>();
        }

        public void AddLexicalUnit(string lexicalUnit)
        {
            _lexicalUnits.Add(lexicalUnit);
        }

        public void AddFrameElement(string frameElement)
        {
            _frameElements.Add(frameElement);
        }

        public bool LexicalUnitExists(string synSetId)
        {
            return _lexicalUnits.Contains(synSetId);
        }

        public string GetLexicalUnit(int index)
        {
            return _lexicalUnits[index];
        }

        public string GetFrameElement(int index)
        {
            return _frameElements[index];
        }

        public int LexicalUnitSize()
        {
            return _lexicalUnits.Count;
        }

        public int FrameElementSize()
        {
            return _frameElements.Count;
        }

        public string GetName()
        {
            return _name;
        }
    }
}