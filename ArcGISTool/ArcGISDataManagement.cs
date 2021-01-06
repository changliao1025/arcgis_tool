using System;

using System.IO;

using System.Text;

using System.Collections.Generic;

using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;

using ESRI.ArcGIS.Geodatabase;

using ESRI.ArcGIS.DataSourcesRaster;

using ESRI.ArcGIS.DataManagementTools;

using ESRI.ArcGIS.Geoprocessor;

using ESRI.ArcGIS.SpatialAnalystTools;



namespace ArcGISTool

{

    public static class ArcGISDataManagement

    {

        /// <summary>

        /// 

        /// </summary>

        /// <param name="sInRasterPath"></param>

        /// <param name="pClipPolygon"></param>

        /// <param name="pOutFullPath"></param>

        /// <returns></returns>

        public static object ExtractByPolygon(string sInRasterPath, IFeatureClass pClipPolygon, string pOutFullPath)

        {

            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

            ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask pExtract = new ExtractByMask();

            pExtract.in_raster = sInRasterPath;

            pExtract.in_mask_data = pClipPolygon;

            pExtract.out_raster = pOutFullPath;

            object pObject = gp.Execute(pExtract, null);

            return pObject;

        }

               

        /// <summary>

        /// 

        /// </summary>

        /// <param name="sInRasterPath"></param>

        /// <param name="sMaskPath"></param>

        /// <param name="pOutFullPath"></param>

        /// <returns></returns>

        public static object ExtractRasterByMask(string sRasterInPath, string sMaskPath, string sRasterOutPath)

        {
            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            ESRI.ArcGIS.SpatialAnalystTools.ExtractByMask pExtract = new ExtractByMask();
            pExtract.in_raster = sRasterInPath;
            pExtract.in_mask_data = sMaskPath;
            pExtract.out_raster = sRasterOutPath;    
            object pObject = gp.Execute(pExtract, null);
            return pObject;
        }



        /// <summary>

        /// 

        /// </summary>

        /// <param name="sRasterInPath"></param>

        /// <param name="sMaskPath"></param>

        /// <param name="sRasterOutPath"></param>

        /// <returns></returns>

        public static object ClipRaster(string sRasterInPath, string sMaskPath, string sRasterOutPath)

        {

            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

            ESRI.ArcGIS.DataManagementTools.Clip pRaclip=new Clip ();

            pRaclip.in_raster = sRasterInPath;

            pRaclip.in_template_dataset = sMaskPath;          

            pRaclip.out_raster = sRasterOutPath;

            object pObject = gp.Execute(pRaclip, null);

            return pObject;

        }



        /// <summary>

        /// define the projection

        /// </summary>

        /// <param name="sFilePath"></param>

        /// <param name="sOriginPrj"></param>

        /// <returns></returns>

        public static object DefineProjection(string sFilePath, string sOriginPrj)

        {

            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

            ESRI.ArcGIS.DataManagementTools.DefineProjection dp = new ESRI.ArcGIS.DataManagementTools.DefineProjection();

            dp.in_dataset = sFilePath;

            dp.coor_system = sOriginPrj;

            return gp.Execute(dp, null);

        }





        /// <summary>

        /// Convert Projection

        /// </summary>

        /// <param name="sInFilePath"></param>

        /// <param name="sOutFilePath"></param>

        /// <param name="sNewProject"></param>

        /// <param name="sOutCellSize"></param>

        /// <returns></returns>

        public static object ProjectRaster(string sFileIn, string sFileOut, string sNewProject, double dCellSize)

        {

            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

            ProjectRaster pProjectRaster = new ProjectRaster(sFileIn, sFileOut, sNewProject);

            pProjectRaster.cell_size = dCellSize;
            //pProjectRaster.resampling_type = "BILINEAR";
            pProjectRaster.resampling_type = "NEAREST";
            return gp.Execute(pProjectRaster, null);

        }



        public static object SetProperties(string sFileIn, float fNaN)
        {
            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            SetRasterProperties pSetRasterProperties = new SetRasterProperties(sFileIn);           
            //pSetRasterProperties.nodata="1, -9999.0";

            pSetRasterProperties.nodata = "1, " +  fNaN.ToString();

            return gp.Execute(pSetRasterProperties, null);
        }



    }

}

