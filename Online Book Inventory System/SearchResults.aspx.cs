using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Xml;

namespace Online_Book_Inventory_System
{
    public partial class SearchResults : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string keywords = Request.QueryString["keywords"];
            List<Db.Book> books = DatabaseAccess.Books.GetBooks(keywords);
            Response.ContentType = "text/xml";
            using (XmlWriter writer = XmlWriter.Create(Response.Output))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Books");
                foreach (Db.Book book in books)
                {
                    writer.WriteStartElement("Book");
                    writer.WriteElementString("Id", book.Id.ToString());
                    writer.WriteElementString("Title", (book.Name.Length < 8)? book.Name: book.Name.Substring(0,8)+"...");
                    writer.WriteElementString("Image", book.Image);
                    writer.WriteElementString("Details", (book.Description.Length < 16) ? book.Description : book.Description.Substring(0, 16) + "...");
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            Response.End();
        }
    }

}