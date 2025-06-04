using System;

// Saidas eram "Exporting to PDF..." e "Exporting to Excel..."

public abstract class ReportGenerator
{
    public void GenerateReport()
    {
        ExportReport();
    }

    protected abstract void ExportReport();
}

public class PdfReportGenerator : ReportGenerator
{
    protected override void ExportReport()
    {
        Console.WriteLine("Generating report header...");
    }
}

public class ExcelReportGenerator : ReportGenerator
{
    protected override void ExportReport()
    {
        Console.WriteLine("Exporting to PDF...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var pdfReport = new PdfReportGenerator();
        pdfReport.GenerateReport();

        var excelReport = new ExcelReportGenerator();
        excelReport.GenerateReport();
    }
}