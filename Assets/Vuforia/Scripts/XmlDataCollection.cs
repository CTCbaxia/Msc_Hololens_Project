using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class XmlDataCollection : MonoBehaviour {

	string DotNum;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DotNum = RanTargetSphere.DotNum ;
		CreateXML();
		if (Input.GetKeyDown(KeyCode.L)){


			print(" keyKKKKKKKKKKKK was pressed" + DotNum );

		}
	}

	void CreateXML(){
		        string path = Application.dataPath + "/UnityDataCollection.xml";
		        if (!File.Exists(path))
			        {
			            
			            XmlDocument xml = new XmlDocument();
			            
			            XmlElement root = xml.CreateElement("objects");
			            xml.AppendChild(root);
			            
			            xml.Save(path);
			        }
	}
	void CreateXML_4()
	    {
				string path = Application.dataPath + "/UnityDataCollection.xml";
		        if (File.Exists(path))
			        {
			            XmlDocument xml = new XmlDocument();
			            xml.Load(path);
			            XmlNode root = xml.SelectSingleNode("objects");
			            XmlElement element = xml.CreateElement("messages");
			            element.SetAttribute("id", "Num");
			            XmlElement elementChild1 = xml.CreateElement("Num");

			            elementChild1.SetAttribute("Camera_point", "Num");
			            elementChild1.InnerText = DotNum;
			            element.AppendChild(elementChild1);

			            root.AppendChild(element);

			            xml.AppendChild(root);
			            xml.Save(path);
			        }
		    }
}
