using System.Collections.Generic;

namespace FrameNet
{
    public class Frame
    {
        private string _name;
        private List<string> _lexicalUnits;
        private List<string> _frameElements;

        /**
        * <summary>Constructor of Frame class which takes inputStream as input and reads the frame</summary>
        *
        * <param name="name">Name of the frame</param>
        */
        public Frame(string name)
        {
            this._name = name;
            _lexicalUnits = new List<string>();
            _frameElements = new List<string>();
        }
        
        /// <summary>
        /// Adds a new lexical unit to the current frame
        /// </summary>
        /// <param name="lexicalUnit">Lexical unit to be added</param>
        public void AddLexicalUnit(string lexicalUnit)
        {
            _lexicalUnits.Add(lexicalUnit);
        }

        /// <summary>
        /// Adds a new frame element to the current frame
        /// </summary>
        /// <param name="frameElement">Frame element to be added</param>
        public void AddFrameElement(string frameElement)
        {
            _frameElements.Add(frameElement);
        }

        /// <summary>
        /// Checks if the given lexical unit exists in the current frame
        /// </summary>
        /// <param name="synSetId">Lexical unit to be searched.</param>
        /// <returns>True if the lexical unit exists, false otherwise.</returns>
        public bool LexicalUnitExists(string synSetId)
        {
            return _lexicalUnits.Contains(synSetId);
        }

        /// <summary>
        /// Accessor for a given index in the lexicalUnit array.
        /// </summary>
        /// <param name="index">Index of the lexical unit</param>
        /// <returns>The lexical unit at position index in the lexicalUnit array</returns>
        public string GetLexicalUnit(int index)
        {
            return _lexicalUnits[index];
        }

        /// <summary>
        /// Accessor for a given index in the frameElements array.
        /// </summary>
        /// <param name="index">Index of the frame element</param>
        /// <returns>The frame element at position index in the frameElements array</returns>
        public string GetFrameElement(int index)
        {
            return _frameElements[index];
        }

        /// <summary>
        /// Returns number of lexical units in the current frame
        /// </summary>
        /// <returns>Number of lexical units in the current frame</returns>
        public int LexicalUnitSize()
        {
            return _lexicalUnits.Count;
        }

        /// <summary>
        /// Returns number of frame elements in the current frame
        /// </summary>
        /// <returns>Number of frame elements in the current frame</returns>
        public int FrameElementSize()
        {
            return _frameElements.Count;
        }

        /// <summary>
        /// Accessor for the name of the frame
        /// </summary>
        /// <returns>Name of the frame</returns>
        public string GetName()
        {
            return _name;
        }
    }
}