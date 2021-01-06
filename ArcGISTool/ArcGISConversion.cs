using System;

using System.Collections.Generic;

using System.Text;

using ESRI.ArcGIS.Geodatabase;

using ESRI.ArcGIS.DataSourcesRaster;

using System.IO;

using System.Runtime.InteropServices;





namespace ArcGISTool

{



    public static class ArcGISConversion

    {

        //from ArcGrid

        #region

        /// <summary>

        /// 

        /// </summary>

        /// <param name="sFileIn"></param>

        /// <param name="sFileOut"></param>

        /// <returns></returns>

        public static object GRID2ASCII(string sFileIn, string sFileOut)

        {

            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

            ESRI.ArcGIS.ConversionTools.RasterToASCII r2a = new ESRI.ArcGIS.ConversionTools.RasterToASCII();

            r2a.in_raster = sFileIn;

            r2a.out_ascii_file = sFileOut;

            return gp.Execute(r2a, null);

        }

        public static object GRID2Binary(string sFileIn, string sFileOut)

        {

            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

            gp.OverwriteOutput =true;

            ESRI.ArcGIS.ConversionTools.RasterToFloat r2f = new ESRI.ArcGIS.ConversionTools.RasterToFloat();

            r2f.in_raster = sFileIn;

            r2f.out_float_file = sFileOut;

            return gp.Execute(r2f, null);

        }
        public static object GRID2GeoTiff(string sFileIn, string sFileOut)
        {
            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            gp.OverwriteOutput = true;
            ESRI.ArcGIS.DataManagementTools.CopyRaster cpr = new ESRI.ArcGIS.DataManagementTools.CopyRaster();
            cpr.in_raster = sFileIn;
            cpr.out_rasterdataset = sFileOut;


            return gp.Execute(cpr, null);

        }
        #endregion

        //from ASCII

        //from BIL

        public static object Bil2ASCII(string sFileIn, string sFileOut)

        {

            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

            ESRI.ArcGIS.ConversionTools.RasterToASCII r2a = new ESRI.ArcGIS.ConversionTools.RasterToASCII();

            r2a.in_raster = sFileIn;

            r2a.out_ascii_file = sFileOut;

            return gp.Execute(r2a, null);

        }

        //from Float Binary

        public static object Binary2GRID(string sFileIn, string sFileOut)

        {

            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

            ESRI.ArcGIS.ConversionTools.FloatToRaster f2r = new ESRI.ArcGIS.ConversionTools.FloatToRaster();

            f2r.in_float_file = sFileIn;

            f2r.out_raster = sFileOut;

            return gp.Execute(f2r, null);

        }

        public static object Binary2TIFF(string sFileIn, string sFileOut)

        {

            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

            ESRI.ArcGIS.ConversionTools.FloatToRaster f2r = new ESRI.ArcGIS.ConversionTools.FloatToRaster();

            f2r.in_float_file = sFileIn;

            f2r.out_raster = sFileOut;

            return gp.Execute(f2r, null);

        }

        //from GeoTiff

        public static object TIFF2Binary(string sFileIn, string sFileOut)

        {

            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

            ESRI.ArcGIS.ConversionTools.RasterToFloat r2f = new ESRI.ArcGIS.ConversionTools.RasterToFloat();

            r2f.in_raster = sFileIn;

            r2f.out_float_file = sFileOut;

            return gp.Execute(r2f, null);

        }

        //from Image



















    }









}

