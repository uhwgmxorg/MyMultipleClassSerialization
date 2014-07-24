using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MyMultipleClassSerialization
{
    public class XMLSerialize
    {
        [XmlElement("Result")]
        public Result TheResult { get; set; }
        [XmlElement("Values")]
        public List<Value> TheValues { get; set; }
        [XmlIgnore]
        public string FileName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public XMLSerialize()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName"></param>
        public XMLSerialize(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Constructor
        /// <param name="theResult"></param>
        /// <param name="theValues"></param>
        /// <param name="fileName"></param>
        public XMLSerialize(Result theResult, List<Value> theValues, string fileName)
        {
            TheResult = theResult;
            TheValues = theValues;
            FileName = fileName;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="fileName"></param>
        public void Save()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XMLSerialize));

                var XmlWriter = new StreamWriter(FileName);
                serializer.Serialize(XmlWriter, this);
                XmlWriter.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="theResult"></param>
        /// <param name="theValues"></param>
        public void Load(ref Result theResult,ref List<Value> theValues)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XMLSerialize));

                using (StreamReader rd = new StreamReader(FileName))
                {
                    var XmlImport = serializer.Deserialize(rd) as XMLSerialize;
                    theResult = XmlImport.TheResult;
                    theValues = XmlImport.TheValues;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
