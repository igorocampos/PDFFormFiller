using System.ComponentModel.DataAnnotations;

namespace PDFFormFiller.Models
{
    public class FieldNaming
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        public string ModelFieldName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string PdfFieldName { get; set; }

        [Range(1, 13)]
        public int Page { get; set; }
    }
}
