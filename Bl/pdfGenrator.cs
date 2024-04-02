using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace DBMidProject.Bl
{
    public class AdvancedPdfGenerator
    {
        public static void GeneratePdf(DataTable dataTable, string titlePdf, string imagePath, List<string> Info)
        {
            try
            {
                PdfDocument document = new PdfDocument();


                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont titleFont = new XFont("Arial", 18, XFontStyle.Bold);
                XFont headingFont = new XFont("Arial", 14, XFontStyle.Bold);
                XFont contentFont = new XFont("Arial", 12);
                XFont tableHeaderFont = new XFont("Arial", 12, XFontStyle.Bold);
                XFont tableFont = new XFont("Arial", 10);
                XColor titleColor = XColors.Teal;
                XColor tableHeaderColor = XColors.Teal;

                double marginLeft = 70;
                double marginRight = 20;
                double marginTop = 30;

                double contentWidth = page.Width - marginLeft - marginRight;

                // Draw title, author, subject, and keywords at the top
                DrawCenteredTitle(gfx, titlePdf, titleFont, titleColor, page.Width, marginTop);
                // Load the image
                XImage image = XImage.FromFile(imagePath);

                // Calculate the position to center the image on the page
                double imageX = page.Width - marginLeft - image.PixelWidth * 0.35; // Adjust the scale factor as needed
                                                                                   // Adjust the scale factor as needed
                double imageY = marginTop + 35;

                // Draw the image on the page
                gfx.DrawImage(image, imageX, imageY, image.PixelWidth * 0.35, image.PixelHeight * 0.35); // Adjust the scale factor as needed


                // Move down for the table
                double currentY = imageY + image.PixelHeight * 0.75 + 10;

                // Draw title, author, subject, and keywords at the top

                DrawLeftAlignedText(gfx, Info[0], contentFont, XColors.Black, marginLeft, marginTop + 80);
                DrawLeftAlignedText(gfx, Info[1], contentFont, XColors.Black, marginLeft, marginTop + 95);
                DrawLeftAlignedText(gfx, Info[2], contentFont, XColors.Black, marginLeft, marginTop + 115);

                // Move down for the table
                currentY = marginTop + 200;

                // Draw the table headers and get the updated Y position
                double tableY = DrawTableHeaders(gfx, dataTable, tableHeaderFont, tableHeaderColor, tableFont, marginLeft, currentY, contentWidth);

                // Draw the table data
                DrawTableData(gfx, dataTable, tableFont, marginLeft, tableY, contentWidth);

                string fileName = string.Empty;
                using (SaveFileDialog fdb = new SaveFileDialog())
                {
                    fdb.Filter = "pdf files (.pdf)|.pdf|All files(.) | . ";
                    fdb.DefaultExt = "pdf";
                    if (fdb.ShowDialog() == DialogResult.OK)
                    {
                        fileName = fdb.FileName;
                    }
                }

                document.Save(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message);
            }
        }


        private static void DrawLeftAlignedText(XGraphics gfx, string text, XFont font, XColor color, double marginLeft, double yPos)
        {
            gfx.DrawString(text, font, new XSolidBrush(color), new XPoint(marginLeft, yPos));
        }
        private static double DrawTableHeaders(XGraphics gfx, DataTable dataTable, XFont headerFont, XColor headerColor, XFont cellFont, double x, double y, double pageWidth)
        {
            try
            {
                double xPos = x;
                double yPos = y;

                // Calculate total content width
                double totalContentWidth = dataTable.Columns.Cast<DataColumn>().Sum(col => GetColumnWidth(gfx, dataTable, col.Ordinal, headerFont, cellFont));

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    string columnName = dataTable.Columns[i].ColumnName;

                    // Adjust column width based on the total content width
                    double columnWidth = GetColumnWidth(gfx, dataTable, i, headerFont, cellFont) * (pageWidth / totalContentWidth);
                    XRect rect = new XRect(xPos, yPos, columnWidth, 20);

                    gfx.DrawRectangle(new XSolidBrush(headerColor), rect);
                    gfx.DrawString(columnName, headerFont, XBrushes.White, rect, XStringFormats.Center);
                    xPos += columnWidth;
                }

                return yPos + 20;
            }
            catch (Exception ex)
            {
                throw new Exception("Error drawing table headers: " + ex.Message);
            }
        }


        private static void DrawTableData(XGraphics gfx, DataTable dataTable, XFont cellFont, double x, double y, double pageWidth)
        {
            try
            {
                double yPos = y;

                // Calculate total content width
                double totalContentWidth = dataTable.Columns.Cast<DataColumn>().Sum(col => GetColumnWidth(gfx, dataTable, col.Ordinal, cellFont, cellFont));

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    double xPos = x;

                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        string cellValue = dataTable.Rows[i][j].ToString();

                        // Adjust column width based on the total content width
                        double columnWidth = GetColumnWidth(gfx, dataTable, j, cellFont, cellFont) * (pageWidth / totalContentWidth);
                        XRect rect = new XRect(xPos, yPos, columnWidth, 20);

                        XBrush cellBrush = GetCellBrush(dataTable.Rows[i][j]);
                        gfx.DrawRectangle(cellBrush, rect);
                        gfx.DrawString(cellValue, cellFont, XBrushes.Black, rect, XStringFormats.Center);

                        xPos += columnWidth;
                    }

                    yPos += 20;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error drawing table data: " + ex.Message);
            }
        }


        private static double GetColumnWidth(XGraphics gfx, DataTable dataTable, int columnIndex, XFont headerFont, XFont cellFont)
        {
            try
            {
                double headerWidth = gfx.MeasureString(dataTable.Columns[columnIndex].ColumnName, headerFont).Width;

                double maxCellWidth = headerWidth;

                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    double cellWidth = gfx.MeasureString(dataTable.Rows[j][columnIndex].ToString(), cellFont).Width;
                    if (cellWidth > maxCellWidth)
                    {
                        maxCellWidth = cellWidth;
                    }
                }

                return Math.Max(headerWidth, maxCellWidth) + 10;
            }
            catch (Exception ex)
            {
                throw new Exception("Error calculating column width: " + ex.Message);
            }
        }

        private static XBrush GetCellBrush(object cellValue)
        {
            try
            {
                if (cellValue is int intValue && intValue > 50)
                {
                    return new XSolidBrush(XColors.LightGreen);
                }
                else
                {
                    return XBrushes.White;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting cell brush: " + ex.Message);
            }
        }

        private static void DrawCenteredTitle(XGraphics gfx, string text, XFont font, XColor color, double pageWidth, double yPos)
        {
            try
            {
                XSize textSize = gfx.MeasureString(text, font);
                double xPos = (pageWidth - textSize.Width) / 2;
                gfx.DrawString(text, font, new XSolidBrush(color), new XPoint(xPos, yPos));
            }
            catch (Exception ex)
            {
                throw new Exception("Error drawing centered title: " + ex.Message);
            }
        }
    }
}
