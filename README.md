# Syncfusion Reporting Services

This Syncfusion Reporting Services repository contains the [ASP.NET MVC Services](https://reports.syncfusion.com/documentation/javascript/report-viewer/create-aspnet-web-api-service/) for the `Report Viewer` and `Report Designer` controls. We have built Reports demos and documentation samples using these services.

This section guides you to use the Syncfusion Reporting Services in your applications.

* [Requirements to run the service](#requirements-to-run-the-service)
* [Using the Reporting Services](#using-the-reporting-services)
* [Testing the Reporting Services](#testing-the-reporting-services)
* [Online Demos](#online-demos)
* [Documentation](#documentation)
* [License](#license)
* [Support and Feedback](#support-and-feedback)

## Requirements to run the service

The samples requires the below requirements to run.

* [Visual Studio 2015/2017](https://visualstudio.microsoft.com/downloads/)
* .Net Framework 4.5 and above

## Using the Reporting Services

* Open the solution file `ReportsSamplesService.sln` in Visual Studio.

* The following Reports dependencies will be installed automatically at compile time.

Package | Purpose
--- | ---
`Syncfusion.Reporting.Web` | Builds the server-side implementations.
`Syncfusion.Reporting.JavaScript` | contains reporting components scripts and style sheets.
`Syncfusion.Extensions.BarcodeCRI` | Used for Rendering Barcode.

* Build and host your application in IIS.

* After hosting in IIS, Use the below services for running Reports samples.

Control | Service URL
--- | ---
`Report Viewer` | `http://localhost/{{IIS virtual path Name}}/api/SamplesReportViewer`
`Report Designer` | `http://localhost/{{IIS virtual path Name}}/api/SamplesReportDesigner`

## Testing the Reporting Services

* Open the solution file `ReportsSamplesService.sln` in Visual Studio.

* Press F5 or click the Run button in Visual Studio to launch the application.

* Navigate to `http://localhost:{{Port No}}/Samples/ReportViewer.html` to test the Report Viewer service.

* Navigate to `http://localhost:{{Port No}}/Samples/ReportDesigner.html` to test the Report Designer service.

## Online Demos

We have showcased our Reports Services in the following Syncfusion Reports online demos.

* [Syncfusion JavaScript Reports demos](https://reports.syncfusion.com/home/index.html)
* [Syncfusion Angular Reports demos](https://reports.syncfusion.com/home/angular.html)
* [Syncfusion ASP.NET MVC Reports demos](https://reports.syncfusion.com/home/aspnet-mvc.html)
* [Syncfusion ASP.NET WebForms Reports demos](https://reports.syncfusion.com/home/aspnet-web-forms.html)

## Documentation

A complete Syncfusion Reports documentation can be found on [Syncfusion Help](https://reports.syncfusion.com/documentation/).

## License

Refer the [LICENSE](/LICENSE) file.

## Support and Feedback

* For any other queries, reach our [Syncfusion support team](https://www.syncfusion.com/support/directtrac/incidents/newincident), [Feedback portal](https://www.syncfusion.com/feedback/reporting-tool) or post the queries through the [community forums](https://www.syncfusion.com/forums/report).

* To renew the subscription, click [here](https://www.syncfusion.com/sales/products/report) or contact our sales team at <salessupport@syncfusion.com>.
