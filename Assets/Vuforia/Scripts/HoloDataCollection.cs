using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

#if WINDOWS_UWP
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Data.Xml.Dom;
#endif


public class HoloDataCollection : MonoBehaviour {
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
		//create the file?
	}



	//find the file and write
	void OpenFileForWrite(){


		#if !UNITY_EDITOR && UNITY_METRO
		string folderName = ApplicationData.Current.RoamingFolder.Path;
		string fileName = "HoloDataCollection.xml";//可能还没有创建

		Task task = new Task(
		async () => {
		StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
		StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);//可能不是createfile

				XmlDocument xml = await XmlDocument.LoadFromFileAsync(file);
				IXmlNode root = xml.SelectSingleNode("object");//这里的返回值是接口IXmlNode，不知道怎么写呢
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
				xml.SaveToFileAsync(file);//save xml document to the file
		});
		task.Start();
		task.Wait();

		#endif


	}
}
