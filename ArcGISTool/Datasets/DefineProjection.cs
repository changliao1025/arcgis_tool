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

    public partial class DefineProjection : Form

    {

        public int iStartYear { get; set; }

        public int iEndYear { get; set; }

        public int iProjection { get; set; }



        public string sPrefixIn { get; set; }



        public string sPathIn { get; set; }





        public DefineProjection()

        {

            InitializeComponent();

        }



        private void DefineProjection_Load(object sender, EventArgs e)

        {

            //define date format

            start_date.Format = DateTimePickerFormat.Custom;

            start_date.CustomFormat = "yyyy";

            start_date.ShowUpDown = true;

            end_date.Format = DateTimePickerFormat.Custom;

            end_date.CustomFormat = "yyyy";

            end_date.ShowUpDown = true;

            //load supported data format for conversion

            this.comboBox_projection.Items.Clear();

            this.comboBox_projection.Items.Add("Alaska Albers Equal Area Conic");

            this.comboBox_projection.Items.Add("NAD 1983 UTM Zone 6N");

            this.comboBox_projection.Items.Add("WGS 1984");

            this.comboBox_projection.SelectedIndex = 1;



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



            }

        }

        private void button_in_Click(object sender, EventArgs e)

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

            if (this.textBox_pathin.Text == null || !Directory.Exists(textBox_pathin.Text))

            {

                MessageBox.Show("Please select input path", "Input error");

                return;

            }



            #endregion

            //retrieve input value 

            iStartYear = start_date.Value.Year;

            iEndYear = end_date.Value.Year;

            iProjection = comboBox_projection.SelectedIndex;

            sPrefixIn = textBox_prefixin.Text;

            sPathIn = textBox_pathin.Text;

            //start calculation

            string sPathInYear = null;

            string sProjection = null;

            string sCurrentPath = Directory.GetCurrentDirectory();

            switch (iProjection)

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

            }

            if (!File.Exists(sProjection))

            {

                MessageBox.Show("The projection file does not exist!");

                return;

            }

            for (int iYear = iStartYear; iYear <= iEndYear; iYear++)

            {

                sPathInYear = sPathIn + "\\" + iYear.ToString();



                for (int iDay = 1; iDay <= 382; iDay++)

                {

                    string aux_file = sPathInYear + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000") + ".aux.xml";

                    if (File.Exists(aux_file))

                    {

                        string sFileNameIn = sPathInYear + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000");

                        ArcGISDataManagement.DefineProjection(sFileNameIn, sProjection);

                    }

                }

                #region

                //    parallel method

                //    DirectoryInfo dirIn = new DirectoryInfo(sPathInYear);

                //    string regex_string = sPrefixIn + iYear.ToString("0000") + "*.tif";

                //    FileInfo[] matchFiles = dirIn.GetFiles(regex_string);

                //    Parallel.ForEach(matchFiles, currentFile =>

                //        {

                //            string sFileName = currentFile.FullName;

                //            ArcGISDataManagement.DefineProjection(sFileName, sProjection);

                //        }

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

