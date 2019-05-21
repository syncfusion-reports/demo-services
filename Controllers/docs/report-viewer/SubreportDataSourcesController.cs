using ReportServices.Model;
using Syncfusion.Reporting.Web.ReportViewer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ReportServices.Controllers.docs
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SubreportDataSourcesController : ApiController, IReportController
    {
        //Post action for processing the rdl/rdlc report 
        public object PostReportAction(Dictionary<string, object> jsonResult)
        {
            return ReportHelper.ProcessReport(jsonResult, this);
        }

        //Get action for getting resources from the report
        [System.Web.Http.ActionName("GetResource")]
        [AcceptVerbs("GET")]
        public object GetResource(string key, string resourcetype, bool isPrint)
        {
            return ReportHelper.GetResource(key, resourcetype, isPrint);
        }

        //Method will be called when initialize the report options before start processing the report     
        public void OnInitReportOptions(ReportViewerOptions reportOption)
        {
            if (reportOption.SubReportModel != null)
            {
                // Opens the report from application Resources folder using FileStream and loads the sub report stream.
                FileStream reportStream = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath(@"~/Resources/docs/product-list.rdlc"), FileMode.Open, FileAccess.Read);
                reportOption.SubReportModel.Stream = reportStream;                
            }
            else
            {
                FileStream reportStream = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath(@"~/Resources/docs/product-list-main.rdlc"), FileMode.Open, FileAccess.Read);
                reportOption.ReportModel.Stream = reportStream;
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

        //Method will be called when reported is loaded
        public void OnReportLoaded(ReportViewerOptions reportOption)
        {
            //You can update report options here
            if (reportOption.SubReportModel != null)
            {
                //Set child subreport data source
                reportOption.SubReportModel.DataSources = new Syncfusion.Reporting.Web.ReportDataSourceCollection();
                reportOption.SubReportModel.DataSources.Add(new Syncfusion.Reporting.Web.ReportDataSource { Name = "list", Value = ProductList.GetData() });
            }
            else
            {
                reportOption.SubReportModel.DataSources = new Syncfusion.Reporting.Web.ReportDataSourceCollection();
                reportOption.SubReportModel.DataSources.Add(new Syncfusion.Reporting.Web.ReportDataSource { Name = "list", Value = ProductList.GetData() });
            }
        }
    }
}