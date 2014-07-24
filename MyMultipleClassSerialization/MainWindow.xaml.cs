/******************************************************************************/
/*                                                                            */
/*   Program MyMultipleClassSerialization                                     */
/*                                                                            */
/*                                                                            */
/*   14.07.2014 0.0.0 uhwgmxorg Start                                         */
/*                                                                            */
/*                                                                            */
/*                                                                            */
/******************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace MyMultipleClassSerialization
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private const int LIST_SIZE = 10;
        private const string FILE_NAME = "Data.xml";

        private  Random _random  = new Random();

        private Result TheResult { get; set; }
        private List<Value> Values;
        private string FileName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            TheResult = new Result();
        }

        /******************************/
        /*       Button Events        */
        /******************************/
        #region Button Events

        /// <summary>
        /// Load_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            LoadFromXml();
        }

        /// <summary>
        /// Save_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveToXml();
        }

        /// <summary>
        /// NewValues_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewValues_Click(object sender, RoutedEventArgs e)
        {
            if (Values != null)
                Values.Clear();
            else
                Values = new List<Value>();
            Values = CreateRandomValueList();
        }

        /// <summary>
        /// Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion

        /******************************/
        /*      Menu Events          */
        /******************************/
        #region Menu Events

        #endregion

        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events

        /// <summary>
        /// Window_Loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFromXml();
        }

        /// <summary>
        /// Window_Closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveToXml();
        }

        #endregion

        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        /// <summary>
        /// SaveXml
        /// </summary>
        private void SaveToXml()
        {
            XMLSerialize TheXMLExport = new XMLSerialize(TheResult, Values, FILE_NAME);
            TheXMLExport.Save();
        }

        /// <summary>
        /// LoadXml
        /// </summary>
        private void LoadFromXml()
        {
            XMLSerialize TheXMLExport = new XMLSerialize(FILE_NAME);
            Result result = null;
            TheXMLExport.Load(ref result,ref Values);
            TheResult = result;
        }

        /// <summary>
        /// CreateRandomList
        /// </summary>
        /// <returns></returns>
        private List<Value> CreateRandomValueList()
        {
            List<Value> List = new List<Value>();

            for (int i = 0; i < LIST_SIZE; i++)
                List.Add(new Value(i, RandomDouble(0,10,3)));

            if (TheResult == null)
                TheResult = new Result();
            TheResult.ResultValue = List.Average<Value>(x => x.DValue);

            return List;
        }

        /// <summary>
        /// RandomDouble
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="deci"></param>
        /// <returns></returns>
        private double RandomDouble(double min, double max, int deci)
        {
            double d;
            d = _random.NextDouble() * (max - min) + min;
            return Math.Round(d, deci);
        }

        #endregion

    }
}
