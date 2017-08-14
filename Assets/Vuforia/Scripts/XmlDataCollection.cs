using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;



public class XmlDataCollection : MonoBehaviour {
	public GameObject SubjectA;
	public GameObject SubjectB;
	string Subject = "A";
	string DotNum;
	string ObsAnw;
	string TskNum;
	string TimeCond;
	string path;

	string RingNum;
	string Con3Num;

	// Use this for initialization
	void Start () {
		SubjectA.SetActive (false);
		SubjectB.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		DotNum = RanTargetSphere.DotNum ;
		ObsAnw = RanTargetSphere.ObsAnw ;
		TskNum = RanTargetSphere.TskNum.ToString() ;
		TimeCond = RanTargetSphere.TimeCond.ToString ();

		RingNum = RanTargetSphere.RingNum;
		Con3Num = RanTargetSphere.DotNum;


//		CreateXML();

		if (Input.GetKeyDown (KeyCode.A)) {
			Subject = "A";
			SubjectA.SetActive (true);
			print ("set subject A");
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			Subject = "B";
			SubjectB.SetActive (true);
		}

	}
	void SelectSubTest(){
		if(Subject == "A"){
			path = Application.dataPath + "/UnityDataCollection_A.xml";
		}else if(Subject == "B"){
			path = Application.dataPath + "/UnityDataCollection_B.xml";
		}
	}

	void CreateXML(){
		
		SelectSubTest ();
        if (!File.Exists(path))
	        {
	            
	            XmlDocument xml = new XmlDocument();
	            
	            XmlElement root = xml.CreateElement("objects");
	            xml.AppendChild(root);
	            
	            xml.Save(path);
	        }
	}
	void CreateXML_C1(){
		
		SelectSubTest ();
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
				elementChild3.InnerText = TimeCond;
				elementTask.AppendChild(elementChild3);
				
	            element.AppendChild(elementTask);
	            root.AppendChild(element);

	            xml.AppendChild(root);
	            xml.Save(path);
	        }
		    }
	void CreateXML_C2(){
		SelectSubTest ();
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
			elementChild3.InnerText = TimeCond;
			elementTask.AppendChild(elementChild3);

			element.AppendChild(elementTask);
			root.AppendChild(element);

			xml.AppendChild(root);
			xml.Save(path);
		}
	}
	void CreateXML_C3(){

		SelectSubTest ();
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
			elementChild3.InnerText = TimeCond;
			elementTask.AppendChild(elementChild3);

			element.AppendChild(elementTask);
			root.AppendChild(element);

			xml.AppendChild(root);
			xml.Save(path);
		}
	}
}
