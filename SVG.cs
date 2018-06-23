using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Globalization;


namespace BuildingMarkupLanguage.Svg
{

    [XmlRoot(ElementName = "polygon", Namespace = "http://www.w3.org/2000/svg")]
    public class Polygon
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "points")]
        public string Points { get; set; }
        [XmlAttribute(AttributeName = "transform")]
        public string Transform { get; set; }
    }

    [XmlRoot(ElementName = "path", Namespace = "http://www.w3.org/2000/svg")]
    public class Path
    {
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "d")]
        public string D { get; set; }
        [XmlAttribute(AttributeName = "transform")]
        public string Transform { get; set; }
        [XmlAttribute(AttributeName = "stroke-width")]
        public string StrokeWidth { get; set; }
        [XmlAttribute(AttributeName = "stroke")]
        public string Stroke { get; set; }
        [XmlAttribute(AttributeName = "fill")]
        public string Fill { get; set; }

    }

    [XmlRoot(ElementName = "svg", Namespace = "http://www.w3.org/2000/svg")]
    public class Svg
    {
        [XmlElement(ElementName = "polygon", Namespace = "http://www.w3.org/2000/svg")]
        public List<Polygon> Polygon { get; set; }
        [XmlElement(ElementName = "path", Namespace = "http://www.w3.org/2000/svg")]
        public List<Path> Path { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "xlink", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xlink { get; set; }
        [XmlAttribute(AttributeName = "viewBox")]
        public string ViewBox { get; set; }
        [XmlAttribute(AttributeName = "space", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Space { get; set; }
        [XmlAttribute(AttributeName = "height")]
        public string Height { get; set; }
        [XmlAttribute(AttributeName = "width")]
        public string Width { get; set; }

        public Svg()
        {
            this.Version = "1.1";
            this.Id = "Map";
            this.Class = "gen-by-synoptic-designer";
            this.Xmlns = "http://www.w3.org/2000/svg";
            this.Xlink = "http://www.w3.org/1999/xlink";
            this.Height = "100%";
            this.Width = "100%";
            this.Space = "preserve";
            this.ViewBox = "-10 -10 600 600";
        }

        public void WriteSVG(string resultPath, List<Path> paths)
        {
            this.Path = paths;

            StringWriter writer = new StringWriter();

            XmlSerializer ser = new XmlSerializer(typeof(Svg));
            ser.Serialize(writer, this);
            string svgFileContents = writer.ToString();
            writer.Close();

            File.WriteAllText(resultPath, svgFileContents);
        }

        public static string PointsToPath(string points)
        {
            string[] coordinates = points.Split(' ');
            string result = "";
            bool startingPoint = true;

            foreach (string coordinate in coordinates)
            {
                string command = "L ";
                if (startingPoint) { command = "M "; startingPoint = false; }
                //"-4.061,-16.7242 -4.061,-17.4829 -5.291,-17.4829 -5.291,-16.3916 -5.291,-15.6329 -4.061,-15.6329 -4.061,-16.7242"
                string x = coordinate.Split(",")[0];
                string y = coordinate.Split(",")[1];

                double xValue = double.Parse(x, CultureInfo.InvariantCulture);
                double yValue = double.Parse(y, CultureInfo.InvariantCulture);

                result = result + command + xValue.ToString(CultureInfo.InvariantCulture) + " " + yValue.ToString(CultureInfo.InvariantCulture) + " ";
            }

            return result + "z ";
        }
    }

}
