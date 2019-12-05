using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        [Required]
        [XmlElement("ProjectionId")]
        public int ProjectionId { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "100000000")]
        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
