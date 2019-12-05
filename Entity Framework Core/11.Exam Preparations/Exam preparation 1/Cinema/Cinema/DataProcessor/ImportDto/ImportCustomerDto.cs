using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
    public class ImportCustomerDto
    {

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [Required]
        [Range(12, 110)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "100000000")]
        [XmlElement("Balance")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public List<ImportTicketDto> Tickets { get; set; }
    }
}
