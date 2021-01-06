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
    public partial class SetProperties : Form
    {

        public string sPrefixIn { get; set; }

        public SetProperties()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
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

            sPrefixIn = textBox_prefixin.Text;
            int iStartYear = 2000;
            int iEndYear = 2014;
            string sPathIn = textBox_pathin.Text;

            float fNaNData = -9999;
            for (int iYear = iStartYear; iYear <= iEndYear; iYear++)
            {
                for (int iDay = 1; iDay <= 382; iDay++)
                {
                  //string tiff_file = sPathIn + "\\" + iLayer.ToString("00") + "\\" + sPrefixIn + iDay.ToString("000") + iLayer.ToString("00") + ".tif";
                    string tiff_file = sPathIn + "\\" + iYear.ToString("0000") + "\\" + sPrefixIn + iYear.ToString("0000") + iDay.ToString("000") + ".tif";
                    if (File.Exists(tiff_file))
                    {
                        ArcGISDataManagement.SetProperties(tiff_file, fNaNData);
                    }
                }
            }
            MessageBox.Show("Finished!");
        }

        private void SetProperties_Load(object sender, EventArgs e)
        {
            start_date.Format = DateTimePickerFormat.Custom;

            start_date.CustomFormat = "yyyy";

            start_date.ShowUpDown = true;

            end_date.Format = DateTimePickerFormat.Custom;

            end_date.CustomFormat = "yyyy";

            end_date.ShowUpDown = true;
        }
    }
}
