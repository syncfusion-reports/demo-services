using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;
using Syncfusion.Reporting.Web.ReportViewer;
using Syncfusion.Reporting.Web.ReportDesigner;
using Syncfusion.Reporting.Web;
using System.Reflection;


namespace ReportServices.Controllers.demos
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("")]
    public class SamplesReportDesignerController : ApiController, IReportDesignerController, IReportLogger
    {
        const string CachePath = "Cache\\";

        internal ExternalServer Server
        {
            get;
            set;
        }

        internal string ServerURL
        {
            get;
            set;
        }

        internal string AuthorizationHeaderValue
        {
            get;
            set;
        }

        public SamplesReportDesignerController()
        {
            ExternalServer externalServer = new ExternalServer();
            this.Server = externalServer;
            this.ServerURL = "Sample";
            externalServer.ReportServerUrl = this.ServerURL;
            ReportDesignerHelper.ReportingServer = externalServer;
        }

        [HttpPost]
        public void UploadReportAction()
        {
            ReportDesignerHelper.ProcessDesigner(null, this, HttpContext.Current.Request.Files[0]);
        }

        [HttpGet]
        public object GetImage(string key, string image)
        {
            return ReportDesignerHelper.GetImage(key, image, this);
        }

        [HttpPost]
        public object PostDesignerAction(Dictionary<string, object> jsonResult)
        {
            return ReportDesignerHelper.ProcessDesigner(jsonResult, this, null);
        }

        public object PostReportAction(Dictionary<string, object> jsonResult)
        {
            return ReportHelper.ProcessReport(jsonResult, this as IReportController);
        }

        public void OnInitReportOptions(ReportViewerOptions reportOption)
        {
            var resourcesPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Scripts");

            reportOption.ReportModel.ExportResources.Scripts = new List<string>
            {
                resourcesPath + @"\reports\common\ej.reporting.common.min.js",
                resourcesPath + @"\reports\common\ej.reporting.widgets.min.js",
                //Chart component script
                resourcesPath + @"\reports\data-visualization\ej.chart.min.js",
                //Gauge component scripts
                resourcesPath + @"\reports\data-visualization\ej.lineargauge.min.js",
                resourcesPath + @"\reports\data-visualization\ej.circulargauge.min.js",
                //Map component script
                resourcesPath + @"\reports\data-visualization\ej.map.min.js",
                //Report Viewer Script
                resourcesPath + @"\reports\ej.report-viewer.min.js"
            };

            reportOption.ReportModel.ExportResources.DependentScripts = new List<string>
            {
                "https://code.jquery.com/jquery-1.10.2.min.js"
            };

            reportOption.ReportModel.ReportingServer = this.Server;
            reportOption.ReportModel.ReportServerUrl = this.ServerURL;
            reportOption.ReportModel.ReportServerCredential = new NetworkCredential("Sample", "Passwprd");
        }

        public void OnReportLoaded(ReportViewerOptions reportOption)
        {
        }

        public object GetResource(string key, string resourcetype, bool isPrint)
        {
            return ReportHelper.GetResource(key, resourcetype, isPrint);
        }

        public bool UploadFile(HttpPostedFile httpPostedFile)
        {
            string targetFolder = HttpContext.Current.Server.MapPath("~/");
            string fileName = !string.IsNullOrEmpty(ReportDesignerHelper.SaveFileName) ? ReportDesignerHelper.SaveFileName : Path.GetFileName(httpPostedFile.FileName);
            targetFolder += CachePath;

            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }

            if (!Directory.Exists(targetFolder + "\\" + ReportDesignerHelper.EJReportDesignerToken))
            {
                Directory.CreateDirectory(targetFolder + "\\" + ReportDesignerHelper.EJReportDesignerToken);
            }

            httpPostedFile.SaveAs(targetFolder + "\\" + ReportDesignerHelper.EJReportDesignerToken + "\\" + fileName);
            return true;
        }

        public List<FileModel> GetFiles(FileType fileType)
        {
            List<FileModel> databases = new List<FileModel>();
            var folderPath = HttpContext.Current.Server.MapPath("~/") + CachePath + ReportDesignerHelper.EJReportDesignerToken + "\\";

            if (Directory.Exists(folderPath))
            {
                DirectoryInfo dinfo = new DirectoryInfo(folderPath);
                FileInfo[] Files = dinfo.GetFiles(this.GetFileExtension(fileType));

                foreach (FileInfo file in Files)
                {
                    databases.Add(new FileModel() { Name = file.Name, Path = "../" + CachePath + ReportDesignerHelper.EJReportDesignerToken + "/" + file.Name });
                }
            }

            return databases;
        }

        private string GetFileExtension(FileType fileType)
        {
            if (fileType == FileType.Sdf)
            {
                return "*.sdf";
            }
            else if (fileType == FileType.Xml)
            {
                return "*.xml";
            }

            return "*.rdl";
        }

        public string GetFilePath(string fileName)
        {
            string targetFolder = HttpContext.Current.Server.MapPath("~/");
            targetFolder += CachePath;

            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }

            if (!Directory.Exists(targetFolder + "\\" + ReportDesignerHelper.EJReportDesignerToken))
            {
                Directory.CreateDirectory(targetFolder + "\\" + ReportDesignerHelper.EJReportDesignerToken);
            }

            var folderPath = HttpContext.Current.Server.MapPath("~/") + CachePath + ReportDesignerHelper.EJReportDesignerToken + "\\";
            return folderPath + fileName;
        }


        public FileModel GetFile(string filename, bool isOverride)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message, Exception exception, MethodBase methodType, ErrorType errorType)
        {
            ReportServices.WebApiApplication.log.DebugFormat("Logging Error Message Time: {0};  Error: {1}, Method: {2}; ErrorType: {3}", DateTime.Now, message, methodType, errorType == ErrorType.Error ? "Error" : "Info");
        }

        public void LogError(string errorCode, string message, Exception exception, string errorDetail, string methodName, string className)
        {
            ReportServices.WebApiApplication.log.DebugFormat("Logging Error Message Time: {0};  Error: {1}, Method: {2}; ErrorType: {3}", DateTime.Now, message, methodName, "Error");
        }

    }
}