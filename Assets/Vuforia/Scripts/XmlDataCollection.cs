using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;



public class XmlDataCollection : MonoBehaviour {

	string Subject = "A";
	string DotNum;
	string ObsAnw;
	string TskNum;
	string TimeCond;
	string path;

	string RingNum;
	string Con3Num;
	bool scene_cond_1;
	bool scene_cond_2;
	bool scene_cond_3;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		DotNum = RanTargetSphere.DotNum ;
		ObsAnw = RanTargetSphere.ObsAnw ;
		TskNum = RanTargetSphere.TskNum.ToString() ;
		TimeCond = RanTargetSphere.TimeCond.ToString ();

		RingNum = RanTargetSphere.RingNum;
		Con3Num = RanTargetSphere.DotNum;

		scene_cond_1 = RanTargetSphere.scene_cond_1;
		scene_cond_2 = RanTargetSphere.scene_cond_2;
		scene_cond_3 = RanTargetSphere.scene_cond_3;


//		CreateXML();

		if (Input.GetKeyDown (KeyCode.A)) {
			Subject = "A";
			print ("set subject A");
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			Subject = "B";
		}

	}
//	----------------------- test for HM data--------------0815
	void CollectPeriod(){
		if(scene_cond_1){
			InvokeRepeating ("test1", 0, 0.5F);
		}
		if(scene_cond_2){
			InvokeRepeating ("test2", 0, 0.5F);
		}
		if(scene_cond_3){
			InvokeRepeating ("test3", 0, 0.5F);
		}
	}

	void cancel(){
		CancelInvoke ();
		print ("cancel invoke hm");

	}
	void test1(){
		print ("start invoke hm--1");
	}
	void test2(){
		print ("start invoke hm--2");
	}
	void test3(){
		print ("start invoke hm--3");
	}

//	----------------------- test for HM data--------------0815

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
