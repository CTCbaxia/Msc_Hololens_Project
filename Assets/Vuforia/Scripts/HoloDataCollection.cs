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
	// public GameObject SubjectA;
	// public GameObject SubjectB;
	string Subject = "A";
	string fileName_1;
	string fileName_2;
	string fileName_3;
	string fileName_1_HM;
	string fileName_2_HM;
	string fileName_3_HM;
	bool scene_cond_1;
	bool scene_cond_2;
	bool scene_cond_3;

	string DotNum;
	string ObsAnw;
	string TskNum;
	string TimeCond;
	string RingNum;
	string Con3Num;

	string HoloRotation_x;
	string HoloRotation_y;
	string HoloRotation_z;
	string HoloPostion_x;
	string HoloPostion_y;
	string HoloPostion_z;


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
		scene_cond_1 = RanTargetSphere.scene_cond_1;
		scene_cond_2 = RanTargetSphere.scene_cond_2;
		scene_cond_3 = RanTargetSphere.scene_cond_3;

		if (Input.GetKeyDown(KeyCode.A))
		{
			Subject = "A";
			//  SubjectA.SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			Subject = "B";
			//  SubjectB.SetActive(true);
		}

		//get camera position
		HoloRotation_x = Camera.main.transform.rotation.eulerAngles.x.ToString() ;
		HoloRotation_y = Camera.main.transform.rotation.eulerAngles.y.ToString ();
		HoloRotation_z = Camera.main.transform.rotation.eulerAngles.z.ToString ();

		HoloPostion_x = Camera.main.transform.position.x.ToString();
		HoloPostion_y = Camera.main.transform.position.y.ToString();
		HoloPostion_z = Camera.main.transform.position.z.ToString();

	}
	//for testing without Bluetooth keyboard
	//	void repeatHeadmove()
	//	{
	//    	InvokeRepeating("DataCollectCSV_1", 2.0f, 1.0f);
	//	}

	void SelectSub()
	{
		if (Subject == "A")
		{
			fileName_1 = "Condition_1_A.csv";
			fileName_2 = "Condition_2_A.csv";
			fileName_3 = "Condition_3_A.csv";
			fileName_1_HM = "Condition_1_HM_A.csv";
			fileName_2_HM = "Condition_2_HM_A.csv";
			fileName_3_HM = "Condition_3_HM_A.csv";
		}
		else if (Subject == "B")
		{
			fileName_1 = "Condition_1_B.csv";
			fileName_2 = "Condition_2_B.csv";
			fileName_3 = "Condition_3_B.csv";
			fileName_1_HM = "Condition_1_HM_B.csv";
			fileName_2_HM = "Condition_2_HM_B.csv";
			fileName_3_HM = "Condition_3_HM_B.csv";
		}
	}


	//create the new csv file for one subject per condition
	void CreateCSV_1()
	{
		SelectSub();
		#if !UNITY_EDITOR && UNITY_METRO
		string folderName = ApplicationData.Current.RoamingFolder.Path;

		Task task = new Task(
		async () => {

		StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
		StorageFile file = await folder.CreateFileAsync(fileName_1, CreationCollisionOption.OpenIfExists);//create file

		await FileIO.AppendTextAsync(file, "Condition,Task,Offset,Answer,RT,HeadRotation_x,HeadRotation_y,HeadRotation_z,Headposition_x,Headposition_y,Headposition_z"+"\r\n");

		});
		task.Start();
		task.Wait();
		#endif
	}

	//find the file and write
	void DataCollectCSV_1()
	{
		SelectSub();
		#if !UNITY_EDITOR && UNITY_METRO
		string folderName = ApplicationData.Current.RoamingFolder.Path;

		Task task = new Task(
		async () => {
		StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
		StorageFile file = await folder.GetFileAsync(fileName_1);//get the file

		await FileIO.AppendTextAsync(file, "1"+","+TskNum+","+DotNum+","+ ObsAnw+","+TimeCond+","+HoloRotation_x+","+HoloRotation_y+","+HoloRotation_z+","+HoloPostion_x+","+HoloPostion_y+","+HoloPostion_z+"\r\n");

		});
		task.Start();
		task.Wait();
		#endif
	}

	//create the new csv file for one subject per condition
	void CreateCSV_2()
	{
		SelectSub();
		#if !UNITY_EDITOR && UNITY_METRO
		string folderName = ApplicationData.Current.RoamingFolder.Path;

		Task task = new Task(
		async () => {

		StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
		StorageFile file = await folder.CreateFileAsync(fileName_2, CreationCollisionOption.OpenIfExists);//create file

		await FileIO.AppendTextAsync(file, "Condition,Task,Offset,Answer,RT,HeadRotation_x,HeadRotation_y,HeadRotation_z,Headposition_x,Headposition_y,Headposition_z"+"\r\n");

		});
		task.Start();
		task.Wait();
		#endif
	}

	//find the file and write
	void DataCollectCSV_2()
	{
		SelectSub();
		#if !UNITY_EDITOR && UNITY_METRO
		string folderName = ApplicationData.Current.RoamingFolder.Path;

		Task task = new Task(
		async () => {
		StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
		StorageFile file = await folder.GetFileAsync(fileName_2);//get the file

		await FileIO.AppendTextAsync(file, "2"+","+TskNum+","+RingNum+","+ ObsAnw+","+TimeCond+","+HoloRotation_x+","+HoloRotation_y+","+HoloRotation_z+","+HoloPostion_x+","+HoloPostion_y+","+HoloPostion_z+"\r\n");

		});
		task.Start();
		task.Wait();
		#endif
	}

	//create the new csv file for one subject per condition
	void CreateCSV_3()
	{
		SelectSub();
		#if !UNITY_EDITOR && UNITY_METRO
		string folderName = ApplicationData.Current.RoamingFolder.Path;

		Task task = new Task(
		async () => {

		StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
		StorageFile file = await folder.CreateFileAsync(fileName_3, CreationCollisionOption.OpenIfExists);//create file

		await FileIO.AppendTextAsync(file, "Condition,Task,Offset,Answer,RT,HeadRotation_x,HeadRotation_y,HeadRotation_z,Headposition_x,Headposition_y,Headposition_z"+"\r\n");

		});
		task.Start();
		task.Wait();
		#endif
	}

	//find the file and write
	void DataCollectCSV_3()
	{
		SelectSub();
		#if !UNITY_EDITOR && UNITY_METRO
		string folderName = ApplicationData.Current.RoamingFolder.Path;

		Task task = new Task(
		async () => {
		StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
		StorageFile file = await folder.GetFileAsync(fileName_3);//get the file

		await FileIO.AppendTextAsync(file, "1"+","+TskNum+","+DotNum+","+ ObsAnw+","+TimeCond+","+HoloRotation_x+","+HoloRotation_y+","+HoloRotation_z+","+HoloPostion_x+","+HoloPostion_y+","+HoloPostion_z+"\r\n");

		});
		task.Start();
		task.Wait();
		#endif
	}




	//collect headmovement data
	void CollectPeriod(){
		if(scene_cond_1){
			InvokeRepeating ("DataCollect_HM_1", 0, 0.5F);
		}
		if(scene_cond_2){
			InvokeRepeating ("DataCollect_HM_2", 0, 0.5F);
		}
		if(scene_cond_3){
			InvokeRepeating ("DataCollect_HM_3", 0, 0.5F);
		}
	}
	void cancel(){
		CancelInvoke ();
		print ("cancel invoke hm");

	}

	void CreateHM_1(){
		SelectSub();
		#if !UNITY_EDITOR && UNITY_METRO
		string folderName = ApplicationData.Current.RoamingFolder.Path;

		Task task = new Task(
		async () => {

		StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
		StorageFile file = await folder.CreateFileAsync(fileName_1_HM, CreationCollisionOption.OpenIfExists);//create file

		await FileIO.AppendTextAsync(file, "Condition,Task,HeadRotation_x,HeadRotation_y,HeadRotation_z,Headposition_x,Headposition_y,Headposition_z"+"\r\n");

		});
		task.Start();
		task.Wait();
		#endif
	}

	void DataCollect_HM_1()
	{
		SelectSub();
		#if !UNITY_EDITOR && UNITY_METRO
		string folderName = ApplicationData.Current.RoamingFolder.Path;

		Task task = new Task(
		async () => {
		StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
		StorageFile file = await folder.GetFileAsync(fileName_1_HM);//get the file

		await FileIO.AppendTextAsync(file, "1"+","+TskNum+","+HoloRotation_x+","+HoloRotation_y+","+HoloRotation_z+","+HoloPostion_x+","+HoloPostion_y+","+HoloPostion_z+"\r\n");

		});
		task.Start();
		task.Wait();
		#endif
	}

}

