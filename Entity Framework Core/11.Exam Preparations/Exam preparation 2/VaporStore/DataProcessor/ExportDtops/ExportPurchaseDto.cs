using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDtops
{
    [XmlType("Purchase")]
    public class ExportPurchaseDto
    {
        [XmlElement("Card")]
        public string Card { get; set; }

        [XmlElement("Cvc")]
        public string Cvc { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

        public ExportGameDto Game { get; set; }
    }

    [XmlType("Game")]
    public class ExportGameDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("Genre")]
        public string Genre { get; set; }

        [XmlAttribute("Price")]
        public decimal Price { get; set; }
    }
}