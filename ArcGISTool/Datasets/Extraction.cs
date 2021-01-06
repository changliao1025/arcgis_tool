using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Windows.Forms;

using System.IO;



namespace ArcGISTool
{

    public partial class Extraction : Form
    {

        public int iStartYear { get; set; }

        public int iEndYear { get; set; }

        public string sShapefile { get; set; }

        public string sPrefixIn { get; set; }

        public string sPrefixOut { get; set; }

        public string sPathIn { get; set; }

        public string sPathOut { get; set; }
        public int iFormatIn { get; set; }

        public int iFormatOut { get; set; }
        public Extraction()
        {

            InitializeComponent();

        }



        private void Extraction_Load(object sender, EventArgs e)
        {

            start_date.Format = DateTimePickerFormat.Custom;

            start_date.CustomFormat = "yyyy";

            start_date.ShowUpDown = true;

            end_date.Format = DateTimePickerFormat.Custom;

            end_date.CustomFormat = "yyyy";

            end_date.ShowUpDown = true;

            //format 
            this.comboBox_format0.Items.Clear();

            this.comboBox_format0.Items.Add("ArcGrid");

            this.comboBox_format0.Items.Add("ASCII");

            this.comboBox_format0.Items.Add("BIL");

            this.comboBox_format0.Items.Add("Float Binary");

            this.comboBox_format0.Items.Add("GeoTiff");

            this.comboBox_format0.Items.Add("ENVI");

            this.comboBox_format0.SelectedIndex = 5;



            this.comboBox_format1.Items.Clear();

            this.comboBox_format1.Items.Add("ArcGrid");

            this.comboBox_format1.Items.Add("ASCII");

            this.comboBox_format1.Items.Add("BIL");

            this.comboBox_format1.Items.Add("Float Binary");

            this.comboBox_format1.Items.Add("GeoTiff");

            this.comboBox_format1.Items.Add("ENVI");

            this.comboBox_format1.SelectedIndex = 5;

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



        /// <summary>

        /// 

        /// </summary>

        /// <param name="sender"></param>

        /// <param name="e"></param>

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





        private void button_in_Click(object sender, EventArgs e)
        {



        }

        private void button_out_Click(object sender, EventArgs e)
        {



        }







        private void button_ok_Click(object sender, EventArgs e)
        {



            //input data verification

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

            #endregion

            //retrieve input value

            iStartYear = start_date.Value.Year;

            iEndYear = end_date.Value.Year;

            sPrefixIn = textBox_prefixin.Text;

            sPrefixOut = textBox_prefixout.Text;

            sShapefile = textBox_shapefile.Text;

            sPathIn = textBox_pathin.Text;

            sPathOut = textBox_pathout.Text;

            //start calculation                     
            iFormatIn = comboBox_format0.SelectedIndex;
            iFormatOut = comboBox_format1.SelectedIndex;
            string sPathInYear = null;
            string sPathOutYear = null;
            switch (iFormatIn)
            {

                case 0:  //from ArcGrid
                    #region
                    switch (iFormatOut)
                    {
                        case 0:  //To ArcGrid
                            break;
                        case 4:  //To Geotiff
                            #region
                            for (int iYear = iStartYear; iYear <= iEndYear; iYear++)
                            {

                                sPathInYear = sPathIn + "\\" + iYear.ToString();

                                sPathOutYear = sPathOut + "\\" + iYear.ToString();
                                if (!Directory.Exists(sPathInYear))
                                {

                                    continue;

                                }

                                if (!Directory.Exists(sPathOutYear))
                                {
                                    Directory.CreateDirectory(sPathOutYear);
                                }
                                for (int iDay = 0; iDay <= 382; iDay++)
                                {
                                    string aux_file = sPathInYear + "\\" + sPrefixIn + iYear.ToString() + iDay.ToString("000") + ".aux.xml";
                                    if (File.Exists(aux_file))
                                    {
                                        string sFileIn = sPathInYear + "\\" + sPrefixIn + iYear.ToString() + iDay.ToString("000");
                                        //string sFileOut = sPathOutYear + "\\" + sPrefixOut + iYear.ToString() + iDay.ToString("000");
                                        //ArcGISDataManagement.ExtractRasterByMask(sFileIn, sShapefile, sFileOut);
                                        string sFileOut = sPathOutYear + "\\" + sPrefixOut + iYear.ToString() + iDay.ToString("000") + ".tif";
                                        ArcGISDataManagement.ExtractRasterByMask(sFileIn, sShapefile, sFileOut);
                                    }
                                }
                            }
                            #endregion
                            break;
                        default:
                            break;
                    }
                    #endregion
                    break;
                case 4:  //from Geotiff
                    #region
                    switch (iFormatOut)
                    {
                        case 0:  //To ArcGrid
                            break;
                        case 4:  //To Geotiff
                            #region
                            for (int iYear = iStartYear; iYear <= iEndYear; iYear++)
                            {
                                sPathInYear = sPathIn + "\\" + iYear.ToString();
                                sPathOutYear = sPathOut + "\\" + iYear.ToString();
                                if (!Directory.Exists(sPathInYear))
                                {
                                    continue;
                                }
                                if (!Directory.Exists(sPathOutYear))
                                {
                                    Directory.CreateDirectory(sPathOutYear);
                                }
                                for (int iDay = 0; iDay <= 382; iDay++)
                                {
                                    string sFileIn = sPathInYear + "\\" + sPrefixIn + iYear.ToString() + iDay.ToString("000") + ".tif";
                                    if (File.Exists(sFileIn))
                                    {
                                        string sFileOut = sPathOutYear + "\\" + sPrefixOut + iYear.ToString() + iDay.ToString("000") + ".tif";
                                        ArcGISDataManagement.ExtractRasterByMask(sFileIn, sShapefile, sFileOut);
                                    }
                                }
                            }
                            #endregion
                            break;
                        default:
                            break;
                    }
                    #endregion
                    break;

                case 5: //from ENVI
                    #region
                    switch (iFormatOut)
                    {
                        case 0:  //To ArcGrid
                            break;
                        case 4:  //To Geotiff
                            #region
                            for (int iYear = iStartYear; iYear <= iEndYear; iYear++)
                            {
                                sPathInYear = sPathIn + "\\" + iYear.ToString();
                                sPathOutYear = sPathOut + "\\" + iYear.ToString();
                                if (!Directory.Exists(sPathInYear))
                                {
                                    continue;
                                }
                                if (!Directory.Exists(sPathOutYear))
                                {
                                    Directory.CreateDirectory(sPathOutYear);
                                }
                                for (int iDay = 0; iDay <= 382; iDay++)
                                {
                                    string sFileIn = sPathInYear + "\\" + sPrefixIn + iYear.ToString() + iDay.ToString("000") + ".dat";
                                    if (File.Exists(sFileIn))
                                    {
                                        string sFileOut = sPathOutYear + "\\" + sPrefixOut + iYear.ToString() + iDay.ToString("000") + ".tif";
                                        ArcGISDataManagement.ExtractRasterByMask(sFileIn, sShapefile, sFileOut);
                                    }
                                }
                            }
                            #endregion
                            break;

                        case 5:  //To ENVI classice
                            #region
                            for (int iYear = iStartYear; iYear <= iEndYear; iYear++)
                            {
                                sPathInYear = sPathIn + "\\" + iYear.ToString();
                                sPathOutYear = sPathOut + "\\" + iYear.ToString();
                                if (!Directory.Exists(sPathInYear))
                                {
                                    continue;
                                }
                                if (!Directory.Exists(sPathOutYear))
                                {
                                    Directory.CreateDirectory(sPathOutYear);
                                }
                                for (int iDay = 0; iDay <= 382; iDay++)
                                {
                                    string sFileIn = sPathInYear + "\\" + sPrefixIn + iYear.ToString() + iDay.ToString("000") + ".dat";
                                    if (File.Exists(sFileIn))
                                    {
                                        string sFileOut = sPathOutYear + "\\" + sPrefixOut + iYear.ToString() + iDay.ToString("000") + ".dat";
                                        ArcGISDataManagement.ExtractRasterByMask(sFileIn, sShapefile, sFileOut);
                                    }
                                }
                            }
                            #endregion
                            break;
                        default:
                            break;
                    }
                    #endregion
                    break;
                default:
                    break;
            }






            #region

            //DirectoryInfo dirIn = new DirectoryInfo(sPathInYear);

            //string sMatch = "*" + iYear.ToString() + "*.tif";

            //FileInfo[] matchFiles = dirIn.GetFiles(sMatch);

            //for (int f = 0; f < matchFiles.Length; f++)

            //{

            //    string sFileName = matchFiles[f].FullName;

            //    string sFileOut = sPathOutYear + "\\" + Path.GetFileNameWithoutExtension(sFileName) + ".tif";

            //    ArcGISDataManagement.ClipRasterByMask(sFileName, sShapefile, sFileOut);

            //}

            //define project if appliable

            //to do added

            #endregion



            MessageBox.Show("Finished!");

        }



        private void button_cancel_Click(object sender, EventArgs e)
        {



        }



















    }

}

