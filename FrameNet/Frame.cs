using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Xml;

namespace FrameNet
{
    public class Frame
    {
        private string name;
        private List<LexicalUnit> lexicalUnits;

        /**
        * Constructor of {@link Frame} class which takes inputStream as input and reads the frame
        *
        * @param inputStream  inputStream to read frame
        */
        public Frame(string name, Stream inputStream){
            this.name = name;
            lexicalUnits = new List<LexicalUnit>();
            var doc = new XmlDocument();
            doc.Load(inputStream);
            foreach (XmlNode lexicalUnitNode in doc.DocumentElement.ChildNodes)
            {
                lexicalUnits.Add(new LexicalUnit(lexicalUnitNode));
            }
        }

        public LexicalUnit GetLexicalUnit(int index){
            return lexicalUnits[index];
        }

        public int Size(){
            return lexicalUnits.Count;
        }

        public string GetName(){
            return name;
        }

    }
}