using System;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace BuildingMarkupLanguage
{
	[XmlRoot(ElementName="space")]
	public class Space {
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName="area")]
	public class Area {
		[XmlElement(ElementName="space")]
		public List<Space> Space { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="layout")]
		public string Layout { get; set; }
		[XmlElement(ElementName="area")]
		public List<Area> Areas { get; set; }
	}

	[XmlRoot(ElementName="storey")]
	public class Storey {
		[XmlElement(ElementName="area")]
		public List<Area> Areas { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="TotalHeight")]
		public string TotalHeight { get; set; }
	}

	[XmlRoot(ElementName="building")]
	public class Building {
		[XmlElement(ElementName="storey")]
		public List<Storey> Storey { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="TotalHeight")]
		public string TotalHeight { get; set; }
		[XmlAttribute(AttributeName="Outline")]
		public string Outline { get; set; }
	}

	[XmlRoot(ElementName="site")]
	public class Site {
		[XmlElement(ElementName="building")]
		public Building Building { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName="project")]
	public class Project {
		[XmlElement(ElementName="site")]
		public Site Site { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
	}

}
