using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Windows.Forms;


using ESRI.ArcGIS.Geodatabase;

using ESRI.ArcGIS.Geometry;







namespace ArcGISTool

{

    public partial class StreamReachIndex : Form

    {

        public string sStreamFile { get; set; }

        public string sReachFile { get; set; }

        public string sShapefileNameOut { get; set; }

        public StreamReachIndex()

        {

            InitializeComponent();

        }

        private void StreamReachIndex_Load(object sender, EventArgs e)

        {

            this.textBox_streamfile.Text = @"C:\data\vector\hydrology\huc819040507\stream_saga.shp";

            this.textBox_reachfile.Text = @"C:\data\vector\hydrology\huc819040507\reach_saga.shp";

        }

        private void button_ok_Click(object sender, EventArgs e)

        {

            sStreamFile = this.textBox_streamfile.Text;

            sReachFile = this.textBox_reachfile.Text;

            string sOIDFieldName = "HydroID";

            string sID = "index";

            int iOIDIndex = -1;

            int iOID = -1;

            int iIDIndex = -1;

            int iEnumID = -1;

            //read stream shapefile

            IFeatureWorkspace pFeatureWorkspaceStream = ArcGISCommon.OpenFeatureWorkspace(sStreamFile);

            IFeatureClass pFeatureClassStream = pFeatureWorkspaceStream.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(sStreamFile));

            int iFeatureCountStream = pFeatureClassStream.FeatureCount(null);

            IFeatureWorkspace pFeatureWorkspaceReach = ArcGISCommon.OpenFeatureWorkspace(sReachFile);

            IFeatureClass pFeatureClassReach = pFeatureWorkspaceReach.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(sReachFile));

            //create the query filter for search

            IQueryFilter pQueryFilter = new QueryFilter();

            iOIDIndex = pFeatureClassStream.FindField(sOIDFieldName);

            IFeature pFeatureStream = null;

            ISelectionSet pSelectionSet = null;

            IEnumIDs pEnumIDs = null;

            IList<IPoint> pFromPointList = null;  //List to store the from points

            IList<IPoint> pToPointList = null;         //List to store the to points            

            for (int iStreamIndex = 0; iStreamIndex < iFeatureCountStream; iStreamIndex++)

            {

                //select the reach feature of the stream

                #region

                //find out the stream segment id from the orignal feature class

                pFeatureStream = pFeatureClassStream.GetFeature(iStreamIndex);

                iOID = Convert.ToInt32(pFeatureStream.get_Value(iOIDIndex));

                //set the where clause

                pQueryFilter.WhereClause = sOIDFieldName + "=" + iOID.ToString();

                pSelectionSet = pFeatureClassReach.Select(pQueryFilter, esriSelectionType.esriSelectionTypeIDSet, esriSelectionOption.esriSelectionOptionNormal, null);

                //use an IEnumIDs to read the SelectionSet IDs

                pEnumIDs = pSelectionSet.IDs;

                iEnumID = pEnumIDs.Next();

                pFromPointList = new List<IPoint>();

                pToPointList = new List<IPoint>();

                int[,] IndexArray = new int[pSelectionSet.Count, 2];  //Array to store the index of reaches

                #endregion

                //get all the "from points" and "to points"

                #region

                IFeature pFeature = null;

                IPolyline pPolyline = null;

                IPoint pFromPoint = null;

                IPoint pToPoint = null;

                while (iEnumID != -1)    //-1 is returned after the last valid ID has been reached

                {

                    pFeature = pFeatureClassReach.GetFeature(iEnumID);

                    pPolyline = pFeature.Shape as IPolyline;

                    pFromPoint = pPolyline.FromPoint;

                    pToPoint = pPolyline.ToPoint;

                    pFromPointList.Add(pFromPoint);

                    pToPointList.Add(pToPoint);

                    iEnumID = pEnumIDs.Next();

                }

                //reset the enum ids and find the start point and end point 

                pEnumIDs.Reset();

                #endregion

                //search the start point from the list, theory: if any "to point" has the 

                //same location with the current "from point", then the "from point" of that "to point" is the new current from point.

                #region

                int iCurrentPoint = 0;

                bool findflag = false;  //search flag

                while (!findflag)

                {

                    pFromPoint = pFromPointList[iCurrentPoint];    //also search from the first point

                    for (int iToPoint = 0; iToPoint < pToPointList.Count; iToPoint++)

                    {

                        pToPoint = pToPointList[iToPoint];   //the "to point" of all polylines

                        //the x and y location are used to determine whether two points are identical when that are really close

                        double diff = Math.Pow((pFromPoint.X - pToPoint.X), 2) + Math.Pow((pFromPoint.Y - pToPoint.Y), 2);

                        if (diff < 0.1)  //they are the same point

                        {

                            iCurrentPoint = iToPoint;  //move the cousor from current point to the new found point and search its lead

                            break;

                        }

                        else

                        {

                            //not found, check whether search every point or not

                            //if search entire list and has not luck, then this is the "from point" of entire stream

                            //and the current point is the index already

                            if (iToPoint == (pToPointList.Count - 1))

                            {

                                findflag = true;

                                break;

                            }

                        }

                    }

                }

                #endregion

                //build index from the "from point" from last step, the index of the first point alway set as "1"

                #region

                IndexArray[iCurrentPoint, 0] = 1;

                IndexArray[iCurrentPoint, 1] = 2;

                int iArrayIndex = iCurrentPoint;

                int iCurrentIndex = 1;

                while (iCurrentIndex <= pToPointList.Count)    //Only search the length of the list

                {

                    pToPoint = pToPointList[iArrayIndex];  //the "to point" of the current reach

                    //search the "from point" from the list

                    for (int iStartPoint = 0; iStartPoint < pFromPointList.Count; iStartPoint++)

                    {

                        pFromPoint = pFromPointList[iStartPoint];

                        //difference is used to determine whether two points are identical

                        double diff = Math.Pow((pFromPoint.X - pToPoint.X), 2) + Math.Pow((pFromPoint.Y - pToPoint.Y), 2);

                        if (diff < 0.1)

                        {

                            //find the downstream reach and its index should be current one plus 1

                            IndexArray[iStartPoint, 0] = IndexArray[iArrayIndex, 0] + 1;

                            IndexArray[iStartPoint, 1] = IndexArray[iArrayIndex, 1] + 1;

                            iArrayIndex = iStartPoint; //move the cousor to the founded point index

                            iCurrentIndex = iCurrentIndex + 1; // always plus one when founded

                            break;

                        }

                        else

                        {

                            //search entire list and don't have any luck? because you are searching the "to point" of the last reach in this stream

                            if (iStartPoint == (pToPointList.Count - 1))

                            {

                                iCurrentIndex = pToPointList.Count + 1;

                                break;

                            }

                        }

                    }

                }

                #endregion

                //save the index in the ID field   

                #region

                //find the field index of ID in reach

                iIDIndex = pFeatureClassReach.FindField(sID);

                ////set the start point field value as 0 and save the value

                iEnumID = pEnumIDs.Next();

                int iIndex = 0;

                while (iEnumID != -1)    //-1 is reutned after the last valid ID has been reached

                {

                    int iNewValue = IndexArray[iIndex, 0];

                    pFeature = pFeatureClassReach.GetFeature(iEnumID);

                    pFeature.set_Value(iIDIndex, iNewValue);

                    pFeature.Store();

                    iEnumID = pEnumIDs.Next();

                    iIndex = iIndex + 1;

                }

                #endregion

            }

            MessageBox.Show("Finished!");

        }

    }

}

