using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


#if WINDOWS_UWP
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Data.Xml.Dom;
using System;
#endif



public class HoloDataCollection : MonoBehaviour
{

	string DotNum;
	string ObsAnw;
	string TskNum;
	string TimeCond;

	string RingNum;

	string Con3Num;

	string TskNum_test = "0";
	string DotNum_test = "-3";
	string ObsAnw_test = "1";


	// Use this for initialization

	void Start()
	{

	}



	// Update is called once per frame

	void Update()
	{



		DotNum = RanTargetSphere.DotNum;

		ObsAnw = RanTargetSphere.ObsAnw;

		TskNum = RanTargetSphere.TskNum.ToString();

		TimeCond = RanTargetSphere.TimeCond.ToString();


		RingNum = RanTargetSphere.RingNum;

		Con3Num = RanTargetSphere.DotNum;


		//create the file?


	}




	//create the new csv file for one subject per condition
	void CreateCSV_1()
	{

		#if !UNITY_EDITOR && UNITY_METRO

		string folderName = ApplicationData.Current.RoamingFolder.Path;
		string fileName = "DataCollection_1.csv";

		Task task = new Task(

		async () => {

		StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
		StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExisted);//create file

		await FileIO.AppendTextAsync(file, "Condition,Task,Offset,Answer"+"\r\n");
		await FileIO.AppendTextAsync(file, "1,1,1,1"+"\r\n");

		});

		task.Start();
		task.Wait();


		#endif

	}


	//find the file and write
	void DataCollectCSV_1()
	{


		#if !UNITY_EDITOR && UNITY_METRO

		string folderName = ApplicationData.Current.RoamingFolder.Path;
		string fileName = "DataCollection_1.csv";

		Task task = new Task(

		async () => {

		StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
		StorageFile file = await folder.GetFileAsync(fileName);//get the file

		await FileIO.AppendTextAsync(file, "1"+","+TskNum_test+","+DotNum_test+","+ ObsAnw_test+","+TimeCond+","+"\r\n");

		});

		task.Start();
		task.Wait();


		#endif

	}


}
