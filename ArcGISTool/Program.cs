using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ESRI.ArcGIS;
using ESRI.ArcGIS.esriSystem;

namespace ArcGISTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Starting at ArcGIS 10.0, all stand-alone Engine applications must explicitly bind to a particular ArcGIS product before calling ArcObjects code.
            //http://help.arcgis.com/en/sdk/10.0/arcobjects_net/componenthelp/index.html#//004600000022000000
            RuntimeManager.Bind(ProductCode.Desktop);
            //The AoInitialize object must be used by developers to initialize each application with a suitable license(s) in order for it to run successfully 
            //on any machine it is deployed on to. License configuration must be undertaken at application start time, before any ArcObjects are accessed. Failure to do so will result in application errors. 
            //http://help.arcgis.com/en/sdk/10.0/arcobjects_net/componenthelp/index.html#//004200000006000000
            var aoi = new ESRI.ArcGIS.esriSystem.AoInitialize();
            //Check the product license is available with the IsProductCodeAvailable method. 
            //Check extension licenses are available (if required) with the IsExtensionCodeAvailable method.
            ESRI.ArcGIS.esriSystem.esriLicenseStatus productLicenseStatus = aoi.IsProductCodeAvailable(ESRI.ArcGIS.esriSystem.esriLicenseProductCode.esriLicenseProductCodeAdvanced);
            ESRI.ArcGIS.esriSystem.esriLicenseStatus extensionLicenseStatus = aoi.IsExtensionCodeAvailable(ESRI.ArcGIS.esriSystem.esriLicenseProductCode.esriLicenseProductCodeAdvanced,
                                  ESRI.ArcGIS.esriSystem.esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst);
            if (productLicenseStatus == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAvailable
                && extensionLicenseStatus == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseAvailable)
            {
                //Initialize the application with the product license.
                productLicenseStatus = aoi.Initialize(ESRI.ArcGIS.esriSystem.esriLicenseProductCode.esriLicenseProductCodeAdvanced);
                if (productLicenseStatus == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseCheckedOut)
                {
                    //As required, check out the extension(s) c by calling the CheckOutExtension methods.
                    extensionLicenseStatus = aoi.CheckOutExtension(ESRI.ArcGIS.esriSystem.esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst);
                    if (extensionLicenseStatus == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseCheckedOut)
                    {
                        Application.Run(new ArcGISWindows());
                        //As required, check in the extension(s) c by calling the CheckInExtension methods.
                        aoi.CheckInExtension(ESRI.ArcGIS.esriSystem.esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst);
                        //Shutdown the application.
                        aoi.Shutdown();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(@"ERROR: Extension license check out failed." + Environment.NewLine + extensionLicenseStatus);
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(@"ERROR: Product license check out failed." + Environment.NewLine + productLicenseStatus);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(@"ERROR: Product or Extension license not available." + Environment.NewLine + productLicenseStatus +"and "+ extensionLicenseStatus);
            }
        }
    }
}
