using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Syncfusion.Reporting.Web;
using Syncfusion.Reporting.Web.ReportViewer;

namespace ReportServices.Controllers.demos
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("")]
    public class SamplesReportViewerController : ApiController, IReportController, IReportLogger
    {
        private string resourceRootLoc = "~/Resources/demos/Report/";
        public object GetResource(string key, string resourcetype, bool isPrint)
        {
            return ReportHelper.GetResource(key, resourcetype, isPrint);
        }

        public void LogError(string message, Exception exception, MethodBase methodType, ErrorType errorType)
        {
            ReportServices.WebApiApplication.log.DebugFormat("Logging Error Message Time: {0};  Error: {1}, Method: {2}; ErrorType: {3}", DateTime.Now, message, methodType, errorType == ErrorType.Error ? "Error" : "Info");
        }

        public void LogError(string errorCode, string message, Exception exception, string errorDetail, string methodName, string className)
        {
            ReportServices.WebApiApplication.log.DebugFormat("Logging Error Message Time: {0};  Error: {1}, Method: {2}; ErrorType: {3}", DateTime.Now, message, methodName, "Error");
        }

        public void OnInitReportOptions(ReportViewerOptions reportOption)
        {
            var reportName = reportOption.ReportModel.ReportPath;
            var directoryName = Path.GetDirectoryName(reportName);
            if (directoryName.Length <= 0)
            {
                if (!reportOption.ReportModel.IsDrillthroughReport)
                {
                    reportOption.ReportModel.ReportPath = HttpContext.Current.Server.MapPath(resourceRootLoc + reportName) + ".rdl";
                } else
                {
                    reportOption.ReportModel.ReportPath = HttpContext.Current.Server.MapPath(resourceRootLoc + reportName);
                }
            }

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
        }

        public void OnReportLoaded(ReportViewerOptions reportOption)
        {

        }

        public object PostReportAction(Dictionary<string, object> jsonResult)
        {
            return ReportHelper.ProcessReport(jsonResult, this);
        }
    }
}
