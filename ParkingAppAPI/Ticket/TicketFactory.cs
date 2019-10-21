using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using ParkingApp.API.Models;
using System.IO;
using System.Linq;


namespace ParkingApp.API.Ticket
{
    public class TicketFactory : ITicketFactory
    {
        public SlotContext _context;

        public TicketFactory(SlotContext context)
        {
            _context = context;
        }

        public string GenerateTicket(int posX, int posY)
        {
            var file = File.Create("../ticket.pdf");
            PdfWriter writer = new PdfWriter(file, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0));
            PdfDocument pdfDocument = new PdfDocument(writer);
            pdfDocument.SetTagged();
            Document document = new Document(pdfDocument);
            document.Add(new Paragraph("ParkingAppAPI!"));
            document.Add(new Paragraph("***************************"));
            document.Add(new Paragraph($"Your parking slot coords is: X = {posX} Y = {posY}"));
            document.Add(new Paragraph("Have a nice day!"));
            document.Close();

            return "Check the project's root folder to get a ticket; 'ticket.pdf'";
        }
    }
}
