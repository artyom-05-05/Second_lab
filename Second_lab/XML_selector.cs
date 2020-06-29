using System.Configuration;

namespace Second_lab
{
    public static class XML_selector
    {
        public static void SaveXML(string path, Discount_journal journal)
        {
            switch (ConfigurationManager.AppSettings["how_work_with_XML"])
            {
                case "XML_document":
                    XML_Document.SaveToXML(path, journal);
                    break;
                case "XML_LINQ":
                    LINQ_to_XML.SaveToXML(path, journal);
                    break;
                case "XML_serialization":
                    Auto_serialization.SaveToXML(path, journal);
                    break;
            }
        }

        public static Discount_journal LoadXML(string path)
        {
            switch (ConfigurationManager.AppSettings["how_work_with_XML"])
            {
                case "XML_document":
                    return XML_Document.LoadFromXML(path);
                case "XML_LINQ":
                    return LINQ_to_XML.LoadFromXML(path);
                case "XML_serialization":
                    return Auto_serialization.LoadFromXML(path);
                default:
                    return null;
            }
        }
    }
}
