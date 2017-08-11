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
	string Subject = "A";
	string fileName_1;
	string fileName_2;
	string fileName_3;
	string DotNum;
	string ObsAnw;
	string TskNum;
	string TimeCond;

	string RingNum;

	string Con3Num;

	string TskNum_test = "0";
	string DotNum_test = "-3";
	string ObsAnw_test = "1";
	string TimeCond_test = "1.25";



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

		if (Input.GetKeyDown (KeyCode.A)) {
			Subject = "A";
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			Subject = "B";
		}
	}

	void SelectSub(){
		if(Subject == "A"){
			fileName_1 =  "Condition_1_A.csv";
			fileName_2 =  "Condition_2_A.csv";
			fileName_3 =  "Condition_3_A.csv";
		}else if(Subject == "B"){
			fileName_1 =  "Condition_1_B.csv";
			fileName_2 =  "Condition_2_B.csv";
			fileName_3 =  "Condition_3_B.csv";
		}
	}
	//create the new csv file for one subject per condition
	void CreateCSV_1()
	{
		
		SelectSub ();
		#if !UNITY_EDITOR && UNITY_METRO
		string folderName = ApplicationData.Current.RoamingFolder.Path;


		Task task = new Task(

		async () => {

		StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
		StorageFile file = await folder.CreateFileAsync(fileName_1, CreationCollisionOption.OpenIfExists);//create file

		await FileIO.AppendTextAsync(file, "Condition,Task,Offset,Answer,RT,HeadRotation"+"\r\n");

		});

		task.Start();
		task.Wait();


		#endif

	}


	//find the file and write
	void DataCollectCSV_1()
	{

		SelectSub ();
		#if !UNITY_EDITOR && UNITY_METRO
		string folderName = ApplicationData.Current.RoamingFolder.Path;

		Task task = new Task(

		async () => {

		StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
		StorageFile file = await folder.GetFileAsync(fileName_1);//get the file

		await FileIO.AppendTextAsync(file, "1"+","+TskNum_test+","+DotNum_test+","+ ObsAnw_test+","+TimeCond_test+","+"\r\n");

		});

		task.Start();
		task.Wait();


		#endif

	}


}
