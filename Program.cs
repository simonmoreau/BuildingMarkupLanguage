using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace BuildingMarkupLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            string bmlPath = args[0];
            string outputPath = args[1];
            Console.WriteLine("Hello World!");

            Project myProject;

            XmlSerializer mySerializer = new XmlSerializer(typeof(Project));
            // To read the file, create a FileStream.  
            FileStream myFileStream = new FileStream(bmlPath, FileMode.Open);
            // Call the Deserialize method and cast to the object type.  
            myProject = (Project)mySerializer.Deserialize(myFileStream);
            
            DrawOutline(outputPath,myProject.Site.Building.Outline);

            
        }

        private static void DrawOutline(string outputPath, string points)
        {
            Svg.Svg drawing = new Svg.Svg();

            List<Svg.Path> paths = new List<Svg.Path>();
            Svg.Path path = new Svg.Path();
            path.Fill = "none";
            path.Stroke = "black";
            path.StrokeWidth = "1";
            path.D = Svg.Svg.PointsToPath(points);
            paths.Add(path);

            drawing.WriteSVG(outputPath,paths);
        }
    }
}
