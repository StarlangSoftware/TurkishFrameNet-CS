using System.Collections.Generic;
using System.Xml;

namespace FrameNet
{
    public class LexicalUnit
    {
        private string synSetId;
        private List<string> frameElements;

        public LexicalUnit(XmlNode node){
            frameElements = new List<string>();
            synSetId = node.Attributes["ID"].Value;
            foreach (XmlNode elementNode in node.ChildNodes)
            {
                frameElements.Add(elementNode.InnerText);
            }
        }

        public int Size(){
            return frameElements.Count;
        }

        public List<string> GetFrameElements(){
            return frameElements;
        }

    }
}