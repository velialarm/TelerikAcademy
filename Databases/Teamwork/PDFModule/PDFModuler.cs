namespace PDFModule
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Conflux.ContainerData.PdfExport;
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    public class PDFModuler
    {
        public void Export(List<PdfExportContainer> data, string savePath)
        {
            Document document = new Document();
            FileStream fileStream = File.Create(savePath);
            PdfWriter.GetInstance(document, fileStream);
            document.Open();

            PdfPTable table = new PdfPTable(5);
            table.TotalWidth = 440f;
            table.LockedWidth = true;
            float[] widths = new float[] { 60f, 60f, 60f, 200f, 60f };
            table.SetWidths(widths);
            PdfPCell cell = new PdfPCell();
            bool firstDate = true;
            DateTime temp = DateTime.Now;
            decimal result = 0.00m;
            decimal grandResult = 0.00m;

            //// HEADER
            cell = new PdfPCell(new Phrase("Aggregate sales report"));
            cell.BackgroundColor = new BaseColor(189, 216, 218);
            cell.Colspan = 5;
            cell.HorizontalAlignment = 1;
            cell.PaddingTop = 10f;
            cell.PaddingBottom = 10f;
            table.AddCell(cell);

            //// FONT
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            Font bold = new Font(font, 12, Font.BOLD);

            foreach (var pdfExportContainer in data)
            {
                if (firstDate)
                {
                    temp = pdfExportContainer.Date;
                    firstDate = false;

                    //// First date
                    cell = new PdfPCell(new Phrase("Date: " + pdfExportContainer.Date.ToString("d")));
                    cell.Colspan = 5;
                    cell.BackgroundColor = new BaseColor(223, 239, 240);
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);

                    //// Products header
                    cell = new PdfPCell(new Phrase("Product", bold));
                    cell.BackgroundColor = new BaseColor(189, 216, 218);
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Quantity", bold));
                    cell.BackgroundColor = new BaseColor(189, 216, 218);
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Unit Price", bold));
                    cell.BackgroundColor = new BaseColor(189, 216, 218);
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Location", bold));
                    cell.BackgroundColor = new BaseColor(189, 216, 218);
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Sum", bold));
                    cell.BackgroundColor = new BaseColor(189, 216, 218);
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);
                }

                if (temp == pdfExportContainer.Date)
                { 
                    //// Table data
                    table.AddCell(pdfExportContainer.ProductName);
                    table.AddCell(pdfExportContainer.Quantity.ToString());
                    table.AddCell(pdfExportContainer.Price.ToString());
                    table.AddCell("Supermarket " + pdfExportContainer.Location);
                    decimal sum = pdfExportContainer.Quantity * pdfExportContainer.Price;
                    table.AddCell(sum.ToString());

                    result += sum;
                }
                else
                {
                    //// Date
                    cell = new PdfPCell(new Phrase("Total sum for " + pdfExportContainer.Date.ToString("d")));
                    cell.Colspan = 4;
                    cell.HorizontalAlignment = 2;
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);
                    temp = pdfExportContainer.Date;

                    //// Sum
                    cell = new PdfPCell(new Phrase(result.ToString(), bold));
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);

                    temp = pdfExportContainer.Date;
                    grandResult += result;
                    result = 0m;

                    cell = new PdfPCell(new Phrase("Date: " + pdfExportContainer.Date.ToString("d")));
                    cell.Colspan = 5;
                    cell.BackgroundColor = new BaseColor(217, 217, 217);
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);
                    temp = pdfExportContainer.Date;

                    //// Products header
                    cell = new PdfPCell(new Phrase("Product", bold));
                    cell.BackgroundColor = new BaseColor(189, 216, 218);
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Quantity", bold));
                    cell.BackgroundColor = new BaseColor(189, 216, 218);
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Unit Price", bold));
                    cell.BackgroundColor = new BaseColor(189, 216, 218);
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Location", bold));
                    cell.BackgroundColor = new BaseColor(189, 216, 218);
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Sum", bold));
                    cell.BackgroundColor = new BaseColor(189, 216, 218);
                    cell.PaddingBottom = 5f;
                    cell.PaddingLeft = 5f;
                    table.AddCell(cell);

                    //// Table data
                    table.AddCell(pdfExportContainer.ProductName);
                    table.AddCell(pdfExportContainer.Quantity.ToString());
                    table.AddCell(pdfExportContainer.Price.ToString());
                    table.AddCell("Supermarket " + pdfExportContainer.Location);

                    decimal sum = pdfExportContainer.Quantity * pdfExportContainer.Price;
                    table.AddCell(sum.ToString());

                    result += sum;
                }
            }

            //// Last result sum
            cell = new PdfPCell(new Phrase("Total sum for " + temp.ToString("d")));
            cell.Colspan = 4;
            cell.HorizontalAlignment = 2;
            cell.PaddingBottom = 5f;
            cell.PaddingLeft = 5f;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(result.ToString(), bold));
            cell.PaddingBottom = 5f;
            cell.PaddingLeft = 5f;
            table.AddCell(cell);

            //// Grand total
            grandResult += result;
            cell = new PdfPCell(new Phrase("Grand total: "));
            cell.Colspan = 4;
            cell.HorizontalAlignment = 2;
            cell.PaddingBottom = 5f;
            cell.PaddingLeft = 5f;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(grandResult.ToString(), bold));
            cell.PaddingBottom = 5f;
            cell.PaddingLeft = 5f;
            table.AddCell(cell);

            document.Add(table);
            document.Close();
        }
    }
}
