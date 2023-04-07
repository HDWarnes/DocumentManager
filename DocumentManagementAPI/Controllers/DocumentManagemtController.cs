using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentManagemtController : ControllerBase
    {
        // GET: api/DocumentManagemt
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // Open an existing PDF document
            PdfReader reader = new PdfReader("input.pdf");
            PdfStamper stamper = new PdfStamper(reader, new FileStream("output.pdf", FileMode.Create));

            // Get the PDF form fields
            AcroFields formFields = stamper.AcroFields;

            // Get the field names
            List<string> fieldNames = new List<string>(formFields.Fields.Keys);

            // Close the PDF document
            reader.Close();

            // Output the field names
           
            return fieldNames;
        }

        // GET: api/DocumentManagemt/5
        [HttpGet("{id}", Name = "Get")]
        public List<string> Get(int id)
        {
            // Open an existing PDF document
            PdfReader reader = new PdfReader("input.pdf");
            PdfStamper stamper = new PdfStamper(reader, new FileStream("output.pdf", FileMode.Create));

            // Get the PDF form fields
            AcroFields formFields = stamper.AcroFields;

            // Get the field names
            List<string> fieldNames = new List<string>(formFields.Fields.Keys);

            // Close the PDF document
            reader.Close();

            // Output the field names

            return fieldNames;
        }

        // POST: api/DocumentManagemt
        [HttpPost]
        public void Post([FromBody] string value)
        {
            PdfReader reader = new PdfReader("input.pdf");
            PdfStamper stamper = new PdfStamper(reader, new FileStream("output.pdf", FileMode.Create));

            // Get the PDF form fields
            AcroFields formFields = stamper.AcroFields;
            // Modify the value of a form field
            formFields.SetField("Given Name Text Box", "New Value");

            // Close the PDF stamper
            stamper.Close();
        }

        // PUT: api/DocumentManagemt/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/DocumentManagemt/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
