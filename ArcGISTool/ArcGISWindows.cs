using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Windows.Forms;





namespace ArcGISTool

{

    public partial class ArcGISWindows : Form

    {

        public ArcGISWindows()

        {

            InitializeComponent();

        }



        private void ArcGISWindows_Load(object sender, EventArgs e)

        {

          

        }            

        private void defineProjectionToolStripMenuItem_Click(object sender, EventArgs e)

        {

            DefineProjection depro = new DefineProjection();

            depro.ShowDialog();

        }

        private void projectionToolStripMenuItem_Click(object sender, EventArgs e)

        {

            Projection pro = new Projection();

            pro.ShowDialog();

        }

        private void extractionByMaskToolStripMenuItem_Click(object sender, EventArgs e)

        {

            Extraction ex = new Extraction();

            ex.ShowDialog();

        }



     



        private void byFolderToolStripMenuItem_Click(object sender, EventArgs e)

        {

            Conversion conbf = new Conversion();

            conbf.ShowDialog();

        }



        private void streamReachToolStripMenuItem_Click(object sender, EventArgs e)

        {

            StreamReachIndex sri = new StreamReachIndex();

            sri.ShowDialog();

        }

        private void setPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetProperties pSetPro = new SetProperties();
            pSetPro.ShowDialog();
        }



       



       



      

    }

}

