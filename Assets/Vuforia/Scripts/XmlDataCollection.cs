using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class XmlDataCollection : MonoBehaviour {

	string DotNum;
	string ObjAsw;
	string TskNum;
	string time_cond_1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DotNum = RanTargetSphere.DotNum ;
		ObjAsw = RanTargetSphere.ObjAsw ;
		TskNum = RanTargetSphere.TskNum.ToString() ;
		time_cond_1 = RanTargetSphere.time_cond_1.ToString ();
		CreateXML();

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
			            XmlElement element = xml.CreateElement("block");
						element.SetAttribute("condition", "1");
			            XmlElement elementTask = xml.CreateElement("Task");
			            elementTask.SetAttribute("Task", TskNum);
						XmlElement elementChild1 = xml.CreateElement("offset");
			            	elementChild1.InnerText = DotNum;
						elementTask.AppendChild(elementChild1);

						XmlElement elementChild2 = xml.CreateElement("Answer");
							elementChild2.InnerText = ObjAsw;
						elementTask.AppendChild(elementChild2);
						XmlElement elementChild3 = xml.CreateElement("RT");
							elementChild3.InnerText = time_cond_1;
						elementTask.AppendChild(elementChild3);
						
			            element.AppendChild(elementTask);
			            root.AppendChild(element);

			            xml.AppendChild(root);
			            xml.Save(path);
			        }
		    }
}
