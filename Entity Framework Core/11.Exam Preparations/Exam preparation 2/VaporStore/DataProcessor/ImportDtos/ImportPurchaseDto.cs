using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ImportDtos
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("Type")]
        public string Type { get; set; }

        [XmlElement("Key")]
        public string Key { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

        [XmlElement("Card")]
        public string Card { get; set; }
    }
}
