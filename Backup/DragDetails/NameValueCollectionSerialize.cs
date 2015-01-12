using System;
using System.Collections.Specialized;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Data;

namespace DragDetails
{
    /// <summary>
    /// http://csharpfeeds.com/post.aspx?id=1324
    /// </summary>
    [Serializable]
    class NameValueCollectionSerialize : IXmlSerializable
    {
        /// <summary>
        /// http://www.koders.com/csharp/fid148F5392E358D59D33A4088B691860C3BE3C246E.aspx
        /// </summary>
        /// <returns></returns>
        public DataTable CreatePropertyTable()
        {
            DataTable table = new DataTable();

            // create table columns
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Value", typeof(string));

            DataRow row = null;

            // create table from keys and values of properties
            foreach (string key in this.Properties)
            {
                row = table.NewRow();
                row["Name"] = key;
                row["Value"] = this.Properties[key];
                table.Rows.Add(row);
            }

            // return created table
            return table;
        }


        #region Private members

        private NameValueCollection properties;

        #endregion



        #region Constructors

        public NameValueCollectionSerialize()
        {

        }



        public NameValueCollectionSerialize

                (NameValueCollection properties)
        {

            this.properties = properties;

        }

        #endregion



        #region Properties

        [XmlIgnore]

        public NameValueCollection Properties
        {

            get { return this.properties; }

            set { this.properties = value; }

        }

        #endregion



        #region IXmlSerializable Members

        XmlSchema IXmlSerializable.GetSchema()
        {

            return null;

        }



        void IXmlSerializable.ReadXml(XmlReader reader)
        {

            this.properties = new NameValueCollection();

            while (reader.MoveToNextAttribute())

                this.properties.Add

                    (reader.Name, reader.Value);



            reader.Read();

        }



        void IXmlSerializable.WriteXml(XmlWriter writer)
        {

            foreach (string key in this.properties.Keys)
            {

                writer.WriteStartElement("property");

                string value = this.properties[key];

                writer.WriteAttributeString(key, value);

                writer.WriteEndElement();

            }

        }

        #endregion

    }
}

