using System;
using System.IO;
using System.Linq;
using System.Reflection;
using PDFFormFiller.Models;
using iText.Forms;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;

namespace PDFFormFiller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly DBContext _context;

        public ApplicationFormController(DBContext context)
        {
            _context = context;
        }

        // POST: api/ApplicationForm
        [HttpPost]
        public FileStreamResult GetPDFAsync([FromBody] ApplicationForm applicationForm)
        {
            //No need to dispose the MemoryStream. FileStreamResult object returned by File(stream, "application/pdf") will dispose it after rendering.
            //Source: https://github.com/aspnet/Mvc/blob/25eb50120eceb62fd24ab5404210428fcdf0c400/src/Microsoft.AspNetCore.Mvc.Core/FileStreamResult.cs#L76
            Stream stream = new MemoryStream();
            string src = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ESDC-EMP5624.pdf");
            var reader = new PdfReader(src);
            var writer = new PdfWriter(stream);

            //This is necessary in order to read the file fields and fill them. However a new PDF file will be created.
            reader.SetUnethicalReading(true);

            //This is necessary in order to return the stream even after closing the PdfDocument
            writer.SetCloseStream(false);

            PdfDocument pdfDoc = new PdfDocument(reader, writer);
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, false);

            PropertyInfo[] properties = typeof(ApplicationForm).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name != null && _context.FieldNaming.FirstOrDefault(x => x.ModelFieldName == property.Name) is FieldNaming fieldNaming)
                {
                    var value = property.GetValue(applicationForm);
                    switch (value)
                    {
                        //converts false to empty string (to leave it blank on the form)
                        case bool b:
                            value = b ? "true" : "";
                            break;

                        //converts enum to its int value
                        case Enum e:
                            value = Convert.ToInt32(e).ToString();
                            break;
                    }

                    form.GetField(fieldNaming.PdfFieldName).SetValue(value?.ToString() ?? "");
                }
            }

            pdfDoc.Close();

            //You need to reset the stream start position before sending it
            stream.Position = 0;
            return File(stream, "application/pdf");
        }

    }
}
