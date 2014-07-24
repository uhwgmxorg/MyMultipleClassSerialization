using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyMultipleClassSerialization
{
    public class Result
    {

        [XmlElement("Result")]
        public double ResultValue { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Result()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resultValue"></param>
        public Result(double resultValue)
        {
            ResultValue = resultValue;
        }
    }
}
