using System;
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace OrionBanque.Outils
{
    public static class RIB
    {
        public static string DonneCleRIB(string codeBanque, string codeGuichet, string numCompte)
        {
            numCompte = numCompte.Replace("A","1").Replace("J","1")
                                 .Replace("B","2").Replace("K","2").Replace("S","2")
                                 .Replace("C","3").Replace("L","3").Replace("T","3")
                                 .Replace("D","4").Replace("M","4").Replace("U","4")
                                 .Replace("E","5").Replace("N","5").Replace("V","5")
                                 .Replace("F","6").Replace("O","6").Replace("W","6")
                                 .Replace("G","7").Replace("P","7").Replace("X","7")
                                 .Replace("H","8").Replace("Q","8").Replace("Y","8")
                                 .Replace("I","9").Replace("R","9").Replace("Z","9");
            int b = int.Parse(codeBanque, System.Globalization.CultureInfo.CurrentCulture);
            int g = int.Parse(codeGuichet, System.Globalization.CultureInfo.CurrentCulture);
            int c = int.Parse(numCompte, System.Globalization.CultureInfo.CurrentCulture);

            int k = 97 - (((89 * b) + (15 * g) + (3 * c)) % 97);

            return k.ToString("00", System.Globalization.CultureInfo.CurrentCulture);
        }

        public static void CreateRibPdf()
        {
            int x, y;
            x = 50;
            y = 4;
            // Create a font
            XFont font12B = new XFont("Verdana", 6, XFontStyle.Bold);
            XFont font12 = new XFont("Verdana", 6, XFontStyle.Regular);
            XPen pen = new XPen(XColors.Black, 0.5)
            {
                DashStyle = XDashStyle.Solid
            };

            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Créé grâce à PDFsharp";
            document.Info.Author = "OrionBanque";
            document.Info.CreationDate = DateTime.Now;
            document.Info.Subject = "RIB du compte";

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Draw the first Top Line
            gfx.DrawLine(pen, 4, y, page.Width - 4, y);
            gfx.DrawString("RELEVE D'IDENTITE BANCAIRE", font12B, XBrushes.Black, new XRect(0, y, page.Width, page.Height), XStringFormats.TopCenter);
            y += 40;
            
            // Draw the text
            gfx.DrawString("Banque", font12B, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Guichet", font12B, XBrushes.Black, new XRect(x + 50, y, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Compte", font12B, XBrushes.Black, new XRect(x + 100, y, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Clé", font12B, XBrushes.Black, new XRect(x + 180, y, page.Width, page.Height), XStringFormats.TopLeft);
            y += 10;

            gfx.DrawString("55700", font12, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("55700 ", font12, XBrushes.Black, new XRect(x + 50, y, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("3370074882301 ", font12, XBrushes.Black, new XRect(x + 100, y, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("39 ", font12, XBrushes.Black, new XRect(x + 180, y, page.Width, page.Height), XStringFormats.TopLeft);
            y += 30;

            // Draw the separator line
            gfx.DrawLine(pen, 4, y, page.Width - 4, y);

            // Save the document...
            const string filename = "RIB.pdf";
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }
    }
}
