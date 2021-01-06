using System;

using System.Collections.Generic;

using System.Text;

using ESRI.ArcGIS.Geodatabase;

using ESRI.ArcGIS.DataSourcesRaster;

using ESRI.ArcGIS.DataSourcesFile;

using ESRI.ArcGIS.esriSystem;



namespace ArcGISTool

{



    /// <summary>

    /// ¹²Ïí¾²Ì¬Àà

    /// </summary>

    public static class ArcGISCommon

    {



        public static IWorkspace OpenWorkspace(string sFilePath)

        {

            IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactory() as IWorkspaceFactory;

            IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(sFilePath, 0);

            return pWorkspace;

        }



        public static IRasterWorkspace OpenRasterWorkspace(string sFilePath)

        {            

                IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactory() as IWorkspaceFactory;

                IRasterWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(sFilePath, 0) as IRasterWorkspace;

                return pWorkspace;              

        }





        public static IFeatureWorkspace OpenFeatureWorkspace(string sFilePath)

        {

            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory() as IWorkspaceFactory;

            IFeatureWorkspace pWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(sFilePath), 0);          

            return pWorkspace;

        }



        public static IRasterDataset OpenRasterDataSet(IRasterWorkspace pRasterWorkspace, string sFilename)

        {

            IRasterDataset pRasterDataset = (IRasterDataset)pRasterWorkspace.OpenRasterDataset(sFilename);

            return pRasterDataset;

        }

    }

}

