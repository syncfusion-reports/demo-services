# Syncfusion Reporting Services

This Syncfusion Reporting Services repository contains the ASP.NET MVC Services for the `Report Viewer` and `Report Designer` controls. We have built Reports demos and documentation samples using these services.

This section guides you to use the Syncfusion Reporting Services in your applications.

* [Requirements to run the service](#requirements-to-run-the-service)
* [Using the Reporting Services](#using-the-reporting-services)
* [Online Demos](#online-demos)
* [Documentation](#documentation)
* [License](#license)
* [Support and Feedback](#support-and-feedback)

## Requirements to run the service

The samples requires the below requirements to run.

* [Visual Studio 2015/2017](https://visualstudio.microsoft.com/downloads/)
* .Net Framework 4.5 and above

## Using the Reporting Services

Follow the below steps to host the Services in IIS.

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

Follow the below step to test the Reports Services.

* Create `Samples` folder in the root directory.

* Create `ReportViewer.html` file inside `Samples` folder with the below code snippet.

```html

<!DOCTYPE html>
<html style="height: 100%; width: 100%;">

<head>
	<meta charset="utf-8" />
	<title>Report Viewer</title>
	<link href="http://cdn.syncfusion.com/4.1.0.16/js/reports/material/ej.reports.all.min.css" rel="stylesheet" />
    
	<script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
	<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js" type="text/javascript"></script>

	<script src="http://cdn.syncfusion.com/4.1.0.16/js/reports/common/ej.reporting.common.min.js" type="text/javascript"></script>
    <script src="http://cdn.syncfusion.com/4.1.0.16/js/reports/common/ej.reporting.widgets.min.js" type="text/javascript"></script>
    <script src="http://cdn.syncfusion.com/4.1.0.16/js/reports/ej.report-viewer.min.js" type="text/javascript"></script>
</head>

<body>
	<div id="container"></div>
	<script type="text/javascript">
		$(function () {
			$("#container").ejReportViewer(
				{
					reportServiceUrl: "../api/SamplesReportViewer",
					reportPath: 'company-sales'
				});
		});
	</script>
	<style>
		body {
			height: 100%;
			margin: 0;
			width: 100%;
			overflow: hidden;
		}
	</style>
</body>

</html>

```
* Create `ReportDesigner.html` file inside `Samples` folder with the below code snippet.

```html

<!DOCTYPE html>
<html style="height: 100%; width: 100%;">
<head>
	<meta charset="utf-8" />
	<title>Report Designer</title>
	<link href="http://cdn.syncfusion.com/4.1.0.16/js/reports/material/ej.reports.all.min.css" rel="stylesheet" />
	<link href="http://cdn.syncfusion.com/4.1.0.16/js/reports/material/ej.reportdesigner.min.css" rel="stylesheet" />

	<script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
	<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js" type="text/javascript"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/jsrender/0.9.90/jsrender.min.js" type="text/javascript"></script>

    <script src="http://cdn.syncfusion.com/4.1.0.16/js/reports/common/ej.reporting.common.min.js" type="text/javascript"></script>
    <script src="http://cdn.syncfusion.com/4.1.0.16/js/reports/common/ej.reporting.widgets.min.js" type="text/javascript"></script>
    <script src="http://cdn.syncfusion.com/4.1.0.16/js/reports/common/ej.report-designer-widgets.min.js" type="text/javascript"></script>
	<script src="http://cdn.syncfusion.com/4.1.0.16/js/reports/ej.report-viewer.min.js" type="text/javascript"></script>
	<script src="http://cdn.syncfusion.com/4.1.0.16/js/reports/ej.report-designer.min.js" type="text/javascript"></script>

</head>
<body>
	<div id="container"></div>
	<script type="text/javascript">
		$(function () {
			$("#container").ejReportDesigner(
				{
					serviceUrl: "../api/SamplesReportDesigner"
				});
		});
	</script>
	<style>
		body {
			height: 100%;
			margin: 0;
			width: 100%;
			overflow: hidden;
		}
	</style>
</body>
</html>

```

* Press F5 or click the Run button in Visual Studio to launch the application.

* Navigate to `http://localhost:{{Port No}}/Samples/ReportViewer.html` to test the Report Viewer service.

* Navigate to `http://localhost:{{Port No}}/Samples/ReportDesigner.html` to test the Report Designer service.

## Online Demos

We have showcased our Reports services in the following Syncfusion Reports online demos.

* [Syncfusion JavaScript Reports demos](https://reports.syncfusion.com/home/index.html)
* [Syncfusion Angular Reports demos](https://reports.syncfusion.com/home/angular.html)
* [Syncfusion ASP.NET MVC Reports demos](https://reports.syncfusion.com/home/aspnet-mvc.html)
* [Syncfusion ASP.NET WebForms Reports demos](https://reports.syncfusion.com/home/aspnet-web-forms.html)

## Documentation

A complete Syncfusion Reports documentation can be found on [Syncfusion Help](https://reports.syncfusion.com/documentation/).

## License

Refer the [LICENSE](/LICENSE) file.

## Support and Feedback

* For any other queries, reach our [Syncfusion support team](https://www.syncfusion.com/support/directtrac/incidents/newincident) or post the queries through the [community forums](https://www.syncfusion.com/forums).

* To renew the subscription, click [here](https://www.syncfusion.com/sales/products) or contact our sales team at <salessupport@syncfusion.com>.
