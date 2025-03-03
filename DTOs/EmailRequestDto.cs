using Email.Models;
using System.Xml.Serialization;

namespace Email.DTOs
{
    //public class EmailRequestDto
    [XmlRoot("request")]
    public class EmailRequestDto
    {
        [XmlElement("header")]
        public Header Header { get; set; }

        [XmlElement("body")]
        public Body Body { get; set; }
    }
    public class Header
    {
        [XmlElement("systemName")]
        public string SystemName { get; set; }

        [XmlElement("tranType")]
        public string TranType { get; set; }

        [XmlElement("requestXML")]
        public string RequestXML { get; set; }

        [XmlElement("referenceNumber")]
        public string ReferenceNumber { get; set; }
    }

    public class Body
    {
        [XmlElement("from")]
        public string From { get; set; }

        [XmlArray("to")]
        [XmlArrayItem("recipient")]
        public List<string> To { get; set; }

        [XmlArray("cc")]
        [XmlArrayItem("cc_recipient")]
        public List<string> Cc { get; set; }

        [XmlArray("bcc")]
        [XmlArrayItem("bcc_recipient")]
        public List<string> Bcc { get; set; }

        [XmlElement("subject")]
        public string Subject { get; set; }

        [XmlElement("body")]
        public string EmailBody { get; set; }

        [XmlArray("attachments")]
        [XmlArrayItem("attachment")]
        public List<Attachment> Attachments { get; set; }

        [XmlElement("replyTo")]
        public string ReplyTo { get; set; }

        [XmlElement("priority")]
        public string Priority { get; set; }
    }

    public class Attachment
    {
        [XmlElement("filename")]
        public string Filename { get; set; }

        [XmlElement("contentType")]
        public string ContentType { get; set; }

        [XmlElement("content")]
        public string Content { get; set; }
    }

}
