using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using ParkingApp.API.Models;
using System;
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

        public string GenerateTicket(Guid guid)
        {
            // find an exact slot:
            var slot = _context.Slots.FirstOrDefault(s => s.Id == guid);

            //var file = File.Create("../ticket.pdf");
            //var writer = new PdfWriter("../ticket.pdf");
            //var pdfDocument = new PdfDocument(writer);
            //pdfDocument.SetTagged();
            //var document = new Document(pdfDocument);
            //document.Add(new Paragraph("ParkingAppAPI!"));
            //document.Add(new Paragraph("***************************"));
            //document.Add(new Paragraph($"Your parking slot coords is: X = {slot.PosX} Y = {slot.PosY}"));
            //document.Add(new Paragraph("Have a nice day!"));
            //document.Close();

            return "Check the project's root folder to get a ticket; 'ticket.pdf'";
        }
    }
}
