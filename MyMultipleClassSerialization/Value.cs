using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyMultipleClassSerialization
{

    public class Value
    {
        [XmlElement("Values")]
        public int Id { get; set; }
        public double DValue { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Value()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public Value(int id,double value)
        {
            Id = id;
            DValue = value;
        }
    
    }
}
