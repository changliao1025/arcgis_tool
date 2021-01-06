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

    public partial class Projection : Form
    {



        public int iStartYear { get; set; }

        public int iEndYear { get; set; }

        public int iProjectOut { get; set; }

        public double dCellsize { get; set; }

        public string sPrefixIn { get; set; }

        public string sPrefixOut { get; set; }

        public string sPathIn { get; set; }

        public string sPathOut { get; set; }

        public Projection()
        {

            InitializeComponent();

        }



        private void Projection_Load(object sender, EventArgs e)
        {

            //define date format

            start_date.Format = DateTimePickerFormat.Custom;

            start_date.CustomFormat = "yyyy";

            start_date.ShowUpDown = true;

            end_date.Format = DateTimePickerFormat.Custom;

            end_date.CustomFormat = "yyyy";

            end_date.ShowUpDown = true;

            //load supported data format for conversion        

            this.comboBox_project1.Items.Clear();

            this.comboBox_project1.Items.Add("WGS 1984");

            this.comboBox_project1.Items.Add("NAD 1983 UTM Zone 6N");

            this.comboBox_project1.Items.Add("Alaska Albers Equal Area Conic");
            this.comboBox_project1.Items.Add("GRS_1980_Authalic_Sphere_ellipsoid_Lambert_Azimuth");

            this.comboBox_project1.SelectedIndex = 1;

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



        private void button_in_Click(object sender, EventArgs e)
        {



        }



        private void button_out_Click(object sender, EventArgs e)
        {



        }



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

            if (this.textBox_cellsize.Text == null)
            {

                MessageBox.Show("Please select cellsuze", "Input error");

                return;

            }





            #endregion

            //retrieve input value

            iStartYear = start_date.Value.Year;

            iEndYear = end_date.Value.Year;

            iProjectOut = comboBox_project1.SelectedIndex;

            dCellsize = Convert.ToDouble(textBox_cellsize.Text);

            sPrefixIn = textBox_prefixin.Text;

            sPrefixOut = textBox_prefixout.Text;

            sPathIn = textBox_pathin.Text;

            sPathOut = textBox_pathout.Text;

            //start calculation

            string sPathInYear = null;

            string sPathOutYear = null;

            ////////////////////////////////

            string sProjection = null;

            string sFileType = "hdf";

            string sCurrentPath = Directory.GetCurrentDirectory();

            switch (iProjectOut)
            {

                case 0:

                    sProjection = sCurrentPath + "\\CoordinateSystem\\Alaska Albers Equal Area Conic.prj";

                    break;

                case 1:

                    sProjection = sCurrentPath + "\\CoordinateSystem\\NAD 1983 UTM Zone 6N.prj";

                    break;

                case 2:

                    sProjection = sCurrentPath + "\\CoordinateSystem\\WGS 1984.prj";

                    break;
                case 3:

                    sProjection = sCurrentPath + "\\CoordinateSystem\\GRS_1980_Authalic_Sphere_ellipsoid_Lambert_Azimuth.prj";

                    break;
            }

            if (!File.Exists(sProjection))
            {

                MessageBox.Show("The projection file does not exist!");

                return;

            }

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

                switch (sFileType)
                {
                    case "grid":
                        for (int iDay = 0; iDay <= 382; iDay++)
                        {
                            string aux_file = sPathInYear + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000") + ".aux.xml";

                            if (File.Exists(aux_file))
                            {

                                string sFileNameIn = sPathInYear + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000");

                                string sFileNameOut = sPathOutYear + "\\" + sPrefixOut + iYear.ToString("0000") + iDay.ToString("000");

                                ArcGISDataManagement.ProjectRaster(sFileNameIn, sFileNameOut, sProjection, dCellsize);

                            }
                        }
                        break;
                    case "tiff":
                        for (int iDay = 0; iDay <= 382; iDay++)
                        {
                            string sFileNameIn = sPathInYear + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000") + ".tif";

                            if (File.Exists(sFileNameIn))
                            {
                                string sFileNameOut = sPathOutYear + "\\" + sPrefixOut + iYear.ToString("0000") + iDay.ToString("000") + ".tif";

                                ArcGISDataManagement.ProjectRaster(sFileNameIn, sFileNameOut, sProjection, dCellsize);
                            }
                        }
                        break;
                    case "hdf":
                        for (int iDay = 0; iDay <= 382; iDay++)
                        {
                            string sFileNameIn = sPathInYear + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000") + ".hdf";

                            if (File.Exists(sFileNameIn))
                            {
                                string sFileNameOut = sPathOutYear + "\\" + sPrefixOut + iYear.ToString("0000") + iDay.ToString("000");

                                ArcGISDataManagement.ProjectRaster(sFileNameIn, sFileNameOut, sProjection, dCellsize);
                            }
                        }
                        break;
                }


                #region

                //parallel computing

                //    DirectoryInfo dirIn = new DirectoryInfo(sPathInYear);

                //    string regex_string = sPrefixIn + iYear.ToString("0000") + "*.tif";

                //    FileInfo[] matchFiles = dirIn.GetFiles(regex_string);

                //    Parallel.ForEach(matchFiles, currentFile =>

                //    {

                //        string sFileNameIn = currentFile.FullName;

                //        string sFileNameOut = sPathOutYear + "\\" + currentFile.Name;

                //        ArcGISDataManagement.ProjectRaster(sFileNameIn, sFileNameOut, sProjection, dCellsize);

                //    }

                //);

                #endregion

            }

            MessageBox.Show("Finished!");

        }



        private void button_cancel_Click(object sender, EventArgs e)
        {



        }





    }

}