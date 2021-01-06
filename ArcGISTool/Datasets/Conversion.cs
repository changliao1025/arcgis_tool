using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Windows.Forms;

using System.IO;

using System.Threading;

using System.Threading.Tasks;



namespace ArcGISTool

{

    public partial class Conversion : Form

    {



        public int iStartYear { get; set; }

        public int iEndYear { get; set; }

        public int iFormatIn { get; set; }

        public int iFormatOut { get; set; }

        public string sPrefixIn { get; set; }

        public string sPrefixOut { get; set; }

        public string sPathIn { get; set; }

        public string sPathOut { get; set; }



        public Conversion()

        {

            InitializeComponent();

        }



        private void Convert_Load(object sender, EventArgs e)

        {

            //define date format

            start_date.Format = DateTimePickerFormat.Custom;

            start_date.CustomFormat = "yyyy";

            start_date.ShowUpDown = true;

            end_date.Format = DateTimePickerFormat.Custom;

            end_date.CustomFormat = "yyyy";

            end_date.ShowUpDown = true;

            //load supported data format for conversion, these formats are listed by alphabet  

            this.comboBox_format0.Items.Clear();

            this.comboBox_format0.Items.Add("ArcGrid");

            this.comboBox_format0.Items.Add("ASCII");

            this.comboBox_format0.Items.Add("BIL");

            this.comboBox_format0.Items.Add("Float Binary");

            this.comboBox_format0.Items.Add("GeoTiff");

            this.comboBox_format0.Items.Add("Image");

            this.comboBox_format0.SelectedIndex = 0;



            this.comboBox_format1.Items.Clear();

            this.comboBox_format1.Items.Add("ArcGrid");

            this.comboBox_format1.Items.Add("ASCII");

            this.comboBox_format1.Items.Add("BIL");

            this.comboBox_format1.Items.Add("Float Binary");

            this.comboBox_format1.Items.Add("GeoTiff");

            this.comboBox_format1.Items.Add("Image");

            this.comboBox_format1.SelectedIndex = 1;

        }



        private void start_date_ValueChanged(object sender, EventArgs e)

        {

            if (start_date.Value > end_date.Value)

            {

                end_date.Value = start_date.Value;

            }

        }



        private void end_date_ValueChanged(object sender, EventArgs e)

        {

            if (start_date.Value > end_date.Value)

            {

                start_date.Value = end_date.Value;

            }

        }



        private void textBox_prefixin_TextChanged(object sender, EventArgs e)

        {

            string sTemp = textBox_prefixin.Text;

            if (sTemp.Length > 0)

            {

                char cFirstChar = (sTemp.Substring(0, 1).ToCharArray())[0];

                if (char.IsNumber(cFirstChar))

                {

                    MessageBox.Show("Please make sure the file prefix does NOT start with number");

                    textBox_prefixin.Text = "";

                }

                this.textBox_prefixout.Text = this.textBox_prefixin.Text;

            }

        }



        private void textBox_prefixout_TextChanged(object sender, EventArgs e)

        {

            string sTemp = textBox_prefixout.Text;

            if (sTemp.Length > 0)

            {

                char cFirstChar = (sTemp.Substring(0, 1).ToCharArray())[0];

                if (char.IsNumber(cFirstChar))

                {

                    MessageBox.Show("Please make sure the file prefix does NOT start with number");

                    return;

                }

            }

        }



        /// <summary>

        /// 

        /// </summary>

        /// <param name="sender"></param>

        /// <param name="e"></param>

        private void button_in_Click(object sender, EventArgs e)

        {



        }



        private void button_out_Click(object sender, EventArgs e)

        {



        }

        /// <summary>

        /// 

        /// </summary>

        /// <param name="sender"></param>

        /// <param name="e"></param>

        private void button_ok_Click(object sender, EventArgs e)

        {

            //verify user data input

            #region

            if (this.textBox_prefixin.Text == null || textBox_prefixin.Text == "")

            {

                MessageBox.Show("Please input file prefix", "Input error");

                return;

            }

            if (this.textBox_prefixout.Text == null || textBox_prefixin.Text == "")

            {

                MessageBox.Show("Please output file prefix", "Input error");

                return;

            }

            if (this.textBox_pathin.Text == null || !Directory.Exists(textBox_pathin.Text))

            {

                MessageBox.Show("Please select input path", "Input error");

                return;

            }

            if (this.textBox_pathout.Text == null)

            {

                MessageBox.Show("Please select output path", "Input error");

                return;

            }

            iFormatIn = comboBox_format0.SelectedIndex;

            iFormatOut = comboBox_format1.SelectedIndex;

            if (iFormatIn == iFormatOut)

            {

                MessageBox.Show("Please choose different format");

                return;

            }

            #endregion

            //retrieve input value

            #region

            iStartYear = start_date.Value.Year;

            iEndYear = end_date.Value.Year;

            sPrefixIn = textBox_prefixin.Text;

            sPrefixOut = textBox_prefixout.Text;

            sPathIn = textBox_pathin.Text;

            sPathOut = textBox_pathout.Text;

            if (!Directory.Exists(sPathOut))

            {

                Directory.CreateDirectory(sPathOut);

            }

            #endregion

            //start calculation

            string sPathInYear = null;

            string sPathOutYear = null;

            switch (iFormatIn)

            {

                case 0:  //from ArcGrid

                    #region

                    {

                        switch (iFormatOut)

                        {

                            #region

                            case 1:  // to ASCII

                                for (int iYear = iStartYear; iYear <= iEndYear; iYear++)

                                {

                                    sPathInYear = sPathIn + "\\" + iYear.ToString();

                                    sPathOutYear = sPathOut + "\\" + iYear.ToString();

                                    if (!Directory.Exists(sPathOutYear))

                                    {

                                        Directory.CreateDirectory(sPathOutYear);

                                    }

                                    for (int iDay = 0; iDay <= 382; iDay++)

                                    {

                                        string aux_file = sPathInYear + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000") + ".aux.xml";

                                        if (File.Exists(aux_file))

                                        {

                                            string sFileNameIn = sPathInYear + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000");

                                            string sFileNameOut = sPathOutYear + "\\" + sPrefixOut + iYear.ToString("0000") + iDay.ToString("000") + ".txt";

                                            ArcGISConversion.GRID2ASCII(sFileNameIn, sFileNameOut);

                                        }

                                    }

                                }

                                break;

                            case 2:// to BIL

                                break;

                            case 3:// to binary float

                                for (int iYear = iStartYear; iYear <= iEndYear; iYear++)

                                {

                                    sPathInYear = sPathIn + "\\" + iYear.ToString();

                                    sPathOutYear = sPathOut + "\\" + iYear.ToString();

                                    if (!Directory.Exists(sPathOutYear))

                                    {

                                        Directory.CreateDirectory(sPathOutYear);

                                    }

                                    for (int iDay = 0; iDay <= 382; iDay++)

                                    {

                                        string aux_file = sPathInYear + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000") + ".aux.xml";

                                        if (File.Exists(aux_file))

                                        {

                                            string sFileNameIn = sPathInYear + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000");

                                            string sFileNameOut = sPathOutYear + "\\" + sPrefixOut + iYear.ToString("0000") + iDay.ToString("000") + ".flt";

                                            ArcGISConversion.GRID2Binary(sFileNameIn, sFileNameOut);

                                        }

                                    }

                                }

                                break;

                            case 4:// to geotiff
                                for (int iYear = iStartYear; iYear <= iEndYear; iYear++)
                                {

                                    sPathInYear = sPathIn + "\\" + iYear.ToString();

                                    sPathOutYear = sPathOut + "\\" + iYear.ToString();

                                    if (!Directory.Exists(sPathOutYear))
                                    {

                                        Directory.CreateDirectory(sPathOutYear);

                                    }

                                    for (int iDay = 0; iDay <= 382; iDay++)
                                    {

                                        string aux_file = sPathInYear + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000") + ".aux.xml";

                                        if (File.Exists(aux_file))
                                        {

                                            string sFileNameIn = sPathInYear + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000");

                                            string sFileNameOut = sPathOutYear + "\\" + sPrefixOut + iYear.ToString("0000") + iDay.ToString("000") + ".tif";

                                            ArcGISConversion.GRID2GeoTiff(sFileNameIn, sFileNameOut);

                                        }

                                    }

                                }

                                break;

                            #endregion

                        }

                    }

                    #endregion

                    break;

                case 1: //from ASCII

                    #region

                    switch (iFormatOut)

                    {

                        case 0:

                        case 1:

                        case 2:

                        case 3:

                        case 4:

                            for (int iYear = iStartYear; iYear <= iEndYear; iYear++)

                            {

                                sPathInYear = sPathIn + "\\" + iYear.ToString();

                                sPathOutYear = sPathOut + "\\" + iYear.ToString();

                                if (!Directory.Exists(sPathOutYear))

                                {

                                    Directory.CreateDirectory(sPathOutYear);

                                }

                                DirectoryInfo dirIn = new DirectoryInfo(sPathInYear);

                                string regex_string = sPrefixIn + iYear.ToString("0000") + "*.flt";

                                FileInfo[] matchFiles = dirIn.GetFiles(regex_string);

                                Parallel.ForEach(matchFiles, currentFile =>

                                    {

                                        string sFileNameIn = currentFile.FullName;

                                        string sFileNameOut = sPathOutYear + "\\" + Path.GetFileNameWithoutExtension(currentFile.Name) + ".tif ";

                                        ArcGISConversion.TIFF2Binary(sFileNameIn, sFileNameOut);

                                    }

                            );

                            }

                            break;

                    }

                    #endregion

                    break;

                case 2: //from BIL

                    #region

                    switch (iFormatOut)

                    {

                        case 0: break;

                        case 1: //to binary

                            //for (int iYear = iStartYear; iYear <= iEndYear; iYear++)

                            //{

                            //    sPathInYear = sPathIn + "\\" + iYear.ToString();

                            //    sPathOutYear = sPathOut + "\\" + iYear.ToString();

                            //    if (!Directory.Exists(sPathOutYear))

                            //    {

                            //        Directory.CreateDirectory(sPathOutYear);

                            //    }

                            //    DirectoryInfo dirIn = new DirectoryInfo(sPathInYear);

                            //    for (int iDay = 0; iDay <= 382; iDay++)

                            //    {

                            //        string sFileIn = sPathInYear + "\\" + sPrefixIn + iYear.ToString() + iDay.ToString("000") + ".tif";

                            //        if (File.Exists(sFileIn))

                            //        {

                            //            string sFileOut = sPathOutYear + "\\" + sPrefixOut + iYear.ToString() + iDay.ToString("000") + ".flt";

                            //            ArcGISConversion.TIFF2Binary(sFileIn, sFileOut);

                            //        }

                            //    }

                            //}

                            for (int iYear = iStartYear; iYear <= iEndYear; iYear++)

                            {

                                sPathInYear = sPathIn + "\\" + iYear.ToString();

                                sPathOutYear = sPathOut + "\\" + iYear.ToString();

                                if (!Directory.Exists(sPathOutYear))

                                {

                                    Directory.CreateDirectory(sPathOutYear);

                                }

                                DirectoryInfo dirIn = new DirectoryInfo(sPathInYear);

                                string sMatch = "*" + iYear.ToString() + "*.bil";

                                FileInfo[] matchFiles = dirIn.GetFiles(sMatch);

                                for (int f = 0; f < matchFiles.Length; f++)

                                {

                                    string sFileNameIn = sPathInYear + "\\" + matchFiles[f].Name;

                                    string sFileNameOut = sPathOutYear + "\\" + Path.GetFileNameWithoutExtension(matchFiles[f].Name) + ".txt";

                                    ArcGISConversion.Bil2ASCII(sFileNameIn, sFileNameOut);

                                }

                            }

                            break;

                        case 2: break;

                        default:

                            break;

                    }

                    #endregion

                    break;

                case 3://from Float Binary

                    #region

                    {

                        switch (iFormatOut)

                        {

                            case 0:  //to ArcGrid

                                for (int iYear = iStartYear; iYear <= iEndYear; iYear++)
                                {
                                    sPathInYear = sPathIn + "\\" + iYear.ToString();
                                    sPathOutYear = sPathOut + "\\" + iYear.ToString();
                                    if (!Directory.Exists(sPathOutYear))
                                    {
                                        Directory.CreateDirectory(sPathOutYear);
                                    }
                                    DirectoryInfo dirIn = new DirectoryInfo(sPathInYear);
                                    string sMatch = sPrefixIn + iYear.ToString() + "*.flt";
                                    FileInfo[] matchFiles = dirIn.GetFiles(sMatch);
                                    for (int f = 0; f < matchFiles.Length; f++)
                                    {
                                        string sFileNameIn = matchFiles[f].FullName;
                                        string sFileNameOut = sPathOutYear + "\\" + Path.GetFileNameWithoutExtension(matchFiles[f].Name);
                                        ArcGISConversion.Binary2GRID(sFileNameIn, sFileNameOut);
                                    }                                                       
                                }                        
                                break;

                            case 1:  // to ArcGrid

                                for (int iYear = iStartYear; iYear <= iEndYear; iYear++)

                                {

                                    sPathInYear = sPathIn + "\\" + iYear.ToString();

                                    sPathOutYear = sPathOut + "\\" + iYear.ToString();

                                    if (!Directory.Exists(sPathOutYear))

                                    {

                                        Directory.CreateDirectory(sPathOutYear);

                                    }

                                    DirectoryInfo dirIn = new DirectoryInfo(sPathInYear);

                                    string sMatch = "*" + iYear.ToString() + "*.bil";

                                    FileInfo[] matchFiles = dirIn.GetFiles(sMatch);

                                    for (int f = 0; f < matchFiles.Length; f++)

                                    {

                                        string sFileName = sPathInYear + "\\" + Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(matchFiles[f].Name));

                                        string sFileNameOut = sPathOutYear + "\\+" + Path.GetFileNameWithoutExtension(matchFiles[f].Name) + ".flt";

                                        ArcGISConversion.Bil2ASCII(matchFiles[f].Name, sFileNameOut);

                                    }

                                }

                                break;

                            case 2:// to ASCII

                                for (int iYear = iStartYear; iYear <= iEndYear; iYear++)

                                {

                                    sPathInYear = sPathIn + "\\" + iYear.ToString();

                                    sPathOutYear = sPathOut + "\\" + iYear.ToString();

                                    if (!Directory.Exists(sPathOutYear))

                                    {

                                        Directory.CreateDirectory(sPathOutYear);

                                    }

                                }

                                break;

                            case 3:  //none

                                break;

                            case 4:

                                for (int iYear = iStartYear; iYear <= iEndYear; iYear++)

                                {

                                    sPathInYear = sPathIn + "\\" + iYear.ToString();

                                    sPathOutYear = sPathOut + "\\" + iYear.ToString();

                                    if (!Directory.Exists(sPathOutYear))

                                    {

                                        Directory.CreateDirectory(sPathOutYear);

                                    }

                                    DirectoryInfo dirIn = new DirectoryInfo(sPathInYear);

                                    string regex_string = sPrefixIn + iYear.ToString("0000") + "*.flt";

                                    FileInfo[] matchFiles = dirIn.GetFiles(regex_string);

                                    for (int f = 0; f < matchFiles.Length; f++)

                                    {

                                        string sFileNameIn = matchFiles[f].FullName;

                                        string sFileNameOut = sPathOutYear + "\\" + Path.GetFileNameWithoutExtension(matchFiles[f].Name) + ".tif ";

                                        ArcGISConversion.Binary2TIFF(sFileNameIn, sFileNameOut);

                                    }                              

                                }                             

                                break;

                            case 5:  //none

                                break;

                        }

                    }

                    #endregion

                    break;

                case 4://from Geotiff
                    for (int iYear = iStartYear; iYear <= iEndYear; iYear++)
                    {

                        sPathInYear = sPathIn + "\\" + iYear.ToString();

                        sPathOutYear = sPathOut + "\\" + iYear.ToString();

                        if (!Directory.Exists(sPathOutYear))
                        {

                            Directory.CreateDirectory(sPathOutYear);

                        }

                        for (int iDay = 0; iDay <= 382; iDay++)
                        {

                            string tiff_file = sPathInYear + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000") + ".tif";

                            if (File.Exists(tiff_file))
                            {                             

                                string sFileNameOut = sPathOutYear + "\\" + sPrefixOut + iYear.ToString("0000") + iDay.ToString("000") + ".flt";

                                ArcGISConversion.TIFF2Binary(tiff_file, sFileNameOut);

                            }

                        }

                    }

                    break;

                case 5://from Image

                    #region

                    {

                        switch (iFormatOut)

                        {

                            case 0:  //none

                                break;

                            case 1:  // to ArcGrid

                                for (int iYear = iStartYear; iYear <= iEndYear; iYear++)

                                {

                                    sPathInYear = sPathIn + "\\" + iYear.ToString();

                                    sPathOutYear = sPathOut + "\\" + iYear.ToString();

                                    if (!Directory.Exists(sPathOutYear))

                                    {

                                        Directory.CreateDirectory(sPathOutYear);

                                    }

                                }

                                break;

                            case 2:// to geotiff

                                break;

                            case 3:  //none

                                break;

                            case 4:  //none

                                break;

                            case 5:  //none

                                break;

                        }

                    }

                    #endregion

                    break;

                default: //

                    break;

            }

            MessageBox.Show("Finished!");

        }



        private void button_cancel_Click(object sender, EventArgs e)

        {

            this.Dispose();

            this.Close();

        }

    }

}

