using System;

namespace FrameNet
{
    public class FrameElement
    {
        private string _frameElementType;
        private string _frame;
        private string _id;

        /**
        * <summary>A constructor of {@link FrameElement} class which takes frameElement string which is in the form of
        * frameElementType$id and parses this string into frameElementType and id. If the frameElement string does not
        * contain '$' then the constructor return a NONE type frameElement.</summary>
        *
        * <param name="frameElement">Argument string containing the argumentType and id</param>
        */
        public FrameElement(string frameElement)
        {
            if (frameElement.Contains("$"))
            {
                _frameElementType = frameElement.Substring(0, frameElement.IndexOf("$", StringComparison.Ordinal));
                _frame = frameElement.Substring(frameElement.IndexOf("$", StringComparison.Ordinal) + 1, frameElement.LastIndexOf("$", StringComparison.Ordinal) - frameElement.IndexOf("$", StringComparison.Ordinal) - 1);
                _id = frameElement.Substring(frameElement.LastIndexOf("$", StringComparison.Ordinal) + 1);
            }
            else
            {
                _frameElementType = "NONE";
            }
        }

        /**
         * <summary>Another constructor of {@link FrameElement} class which takes frameElementType and id as inputs and
         * initializes corresponding attributes</summary>
         *
         * <param name="frameElementType">  Type of the frameElement</param>
         * <param name="frame">  Type of the frame</param>
         * <param name="id">  Id of the frameElement</param>
         */
        public FrameElement(string frameElementType, string frame, string id)
        {
            this._frameElementType = frameElementType;
            this._frame = frame;
            this._id = id;
        }

        /**
         * <summary>Accessor for frameElementType.</summary>
         *
         * <returns>Return frameElementType.</returns>
         */
        public string GetFrameElementType()
        {
            return _frameElementType;
        }

        /**
         * <summary>Accessor for frame.</summary>
         *
         * <returns>Return frame.</returns>
         */
        public string GetFrame()
        {
            return _frame;
        }

        /**
         * <summary>Accessor for id.</summary>
         *
         * <returns> id.</returns>
         */
        public string GetId()
        {
            return _id;
        }

        /**
         * <summary>toString converts an {@link FrameElement} to a string. If the frameElementType is "NONE" returns only "NONE", otherwise
         * it returns argument string which is in the form of frameElementType$id</summary>
         *
         * <returns> string form of frameElement</returns>
         */
        public override string ToString()
        {
            if (_frameElementType == "NONE")
            {
                return _frameElementType;
            }

            return _frameElementType + "$" + _frame + "$" + _id;
        }
    }
}