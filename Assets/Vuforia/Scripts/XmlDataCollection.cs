using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class XmlDataCollection : MonoBehaviour {

	string DotNum;
	string ObsAnw;
	string TskNum;
	string time_cond_1;

	string RingNum;
	string time_cond_2;

	string Con3Num;
	string time_cond_3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DotNum = RanTargetSphere.DotNum ;
		ObsAnw = RanTargetSphere.ObsAnw ;
		TskNum = RanTargetSphere.TskNum.ToString() ;
		time_cond_1 = RanTargetSphere.time_cond_1.ToString ();

		RingNum = RanTargetSphere.RingNum;
		time_cond_2 = RanTargetSphere.time_cond_2.ToString ();

		Con3Num = RanTargetSphere.DotNum;
		time_cond_3 = RanTargetSphere.time_cond_3.ToString ();

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
	void CreateXML_C1(){
		
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
					elementChild2.InnerText = ObsAnw;
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
	void CreateXML_C2(){
		
		string path = Application.dataPath + "/UnityDataCollection.xml";
		if (File.Exists(path))
		{
			XmlDocument xml = new XmlDocument();
			xml.Load(path);
			XmlNode root = xml.SelectSingleNode("objects");
			XmlElement element = xml.CreateElement("block");
			element.SetAttribute("condition", "2");
			XmlElement elementTask = xml.CreateElement("Task");
			elementTask.SetAttribute("Task", TskNum);
			XmlElement elementChild1 = xml.CreateElement("offset");
			elementChild1.InnerText = RingNum;
			elementTask.AppendChild(elementChild1);

			XmlElement elementChild2 = xml.CreateElement("Answer");
			elementChild2.InnerText = ObsAnw;
			elementTask.AppendChild(elementChild2);
			XmlElement elementChild3 = xml.CreateElement("RT");
			elementChild3.InnerText = time_cond_2;
			elementTask.AppendChild(elementChild3);

			element.AppendChild(elementTask);
			root.AppendChild(element);

			xml.AppendChild(root);
			xml.Save(path);
		}
	}
	void CreateXML_C3(){

		string path = Application.dataPath + "/UnityDataCollection.xml";
		if (File.Exists(path))
		{
			XmlDocument xml = new XmlDocument();
			xml.Load(path);
			XmlNode root = xml.SelectSingleNode("objects");
			XmlElement element = xml.CreateElement("block");
			element.SetAttribute("condition", "3");
			XmlElement elementTask = xml.CreateElement("Task");
			elementTask.SetAttribute("Task", TskNum);
			XmlElement elementChild1 = xml.CreateElement("offset");
			elementChild1.InnerText = Con3Num;
			elementTask.AppendChild(elementChild1);

			XmlElement elementChild2 = xml.CreateElement("Answer");
			elementChild2.InnerText = ObsAnw;
			elementTask.AppendChild(elementChild2);
			XmlElement elementChild3 = xml.CreateElement("RT");
			elementChild3.InnerText = time_cond_3;
			elementTask.AppendChild(elementChild3);

			element.AppendChild(elementTask);
			root.AppendChild(element);

			xml.AppendChild(root);
			xml.Save(path);
		}
	}
}
