using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanTargetSphere : MonoBehaviour
{
	public GameObject SubjectA;
	public GameObject SubjectB;

	public GameObject Dot1, Dot2, Dot3, Dot4, Dot5, Dot6, Dot7;
	public GameObject Ring1, Ring2, Ring3, Ring4, Ring5, Ring6, Ring7;
	public int trials = 14;//the number of all trial in one condition
	public GameObject Scene_Ins;
	public GameObject Scene_Cond_1;
	public GameObject Scene_Cond_2;
	public GameObject Scene_Rest;
	public AudioSource Beep_Sound;
	public AudioSource SubjectA_Sound;
	public AudioSource SubjectB_Sound;

	public static string Subject;
	public static string DotNum;//condition1
	public static string RingNum;//condition2
	public static float TimeCond = 0;
	public static string ObsAnw;
	public static int TskNum = 0;

	private bool press_button;
	private float time_rest = 0;
	private float ring_show = 0;

	public static bool scene_cond_1;
	public static bool scene_cond_2;
	public static bool scene_cond_3;
	private bool scene_practice;
	private bool count_time;
	int hm_count = 0;

	bool RanCount = false;
	int[] arr;
	int i;
	int j;
	int k = 0;
	int index;
	int tmp;
	int TrialNum;//the offset for every trial

	bool RanCount_3 = false;
	int[] arr_3;
	int i_3;
	int j_3;
	int k_3 = 0;
	int index_3;
	int tmp_3;
	int TrialNum_3;
	string plane_3;

	//for head movement
	double _nextTime = 0;


	// Use this for initialization
	void Start()
	{
		ShowIns();
//		GameObject.Find("XmlData").SendMessage("CreateCSV_1");
		print(" ------welcome to the instruction ");
		_nextTime = Time.time;
	}


	// Update is called once per frame
	void Update()
	{

		//for logging the head movement data
		if (Time.time > _nextTime) {
			_nextTime = Time.time + 0.1;
			GameObject.Find("XmlData").SendMessage("CollectPeriod");
		}


		//Press Q to show the instruction ===================================
		if (Input.GetKeyDown(KeyCode.Q))
		{
			ShowIns();
			print(" ------welcome to the instruction ");
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			SubjectA.SetActive (true);
			SubjectB.SetActive (false);
			Scene_Ins.SetActive(false);
			Subject = "A";
			SubjectA_Sound.Play ();
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			SubjectB.SetActive (true);
			SubjectA.SetActive (false);
			Scene_Ins.SetActive(false);
			Subject = "B";
			SubjectB_Sound.Play ();
		}

		//Press W to start the practice ===================================
		if (Input.GetKeyDown(KeyCode.W))
		{
			CondScene ();
			Scene_Cond_2.SetActive(false);
			scene_practice = true;
			scene_cond_1 = true;
			scene_cond_2 = false;
			scene_cond_3 = false;

			trials = 7;
			RanCount = false;
			press_button = true;
			time_rest = 2;
			print(" ------welcome to the practice section ");
		}

		//have a rest when having done half of the trials
		if (k == 35)
		{
			HaveARest();
		}

		//press E to start condition1=======================================
		if (Input.GetKeyDown(KeyCode.E))
		{
			GameObject.Find("XmlData").SendMessage("CreateXML");
//			GameObject.Find("XmlData").SendMessage("CreateHM_1");

			CondScene ();
			Scene_Cond_2.SetActive(false);

			scene_practice = false;
			scene_cond_1 = true;
			scene_cond_2 = false;
			scene_cond_3 = false;

			trials = 14;
			RanCount = false;
			press_button = true;
			time_rest = 2;
			print(" ------welcome to  condition 1 ");

		}


		//start all trials
		if (scene_cond_1)
		{
			if (press_button && time_rest >1)
			{
				press_button = false;
				count_time = false;
				hm_count = 0;
				if (!scene_practice && k != 0)
				{                	
					GameObject.Find("XmlData").SendMessage("CreateXML_C1");
				}
				NewTrial();
				//GameObject.Find("XmlData").SendMessage("CollectPeriod");
			}
			//count time for every trial
			if (count_time && TimeCond <= 4)
			{
				Scene_Cond_1.SetActive(true);
				TimeCond += Time.deltaTime;
				ObseverAsw();
			}
			//have a rest for 1 second
			if (count_time && time_rest <= 1 && (press_button || TimeCond > 4)  )
			{
				Scene_Cond_1.SetActive(false);
				time_rest += Time.deltaTime;
				press_button = true;
			}


		}

		//press R to start condition2=======================================
		if (Input.GetKeyDown(KeyCode.R))
		{
			GameObject.Find("XmlData").SendMessage("CreateXML");
			CondScene ();
			Scene_Cond_1.SetActive(false);

			scene_practice = false;
			scene_cond_1 = false;
			scene_cond_2 = true;
			scene_cond_3 = false;

			trials = 28;
			RanCount = false;
			press_button = true;
			time_rest = 2;
			print(" ------welcome to  condition 2 ");
		}


		if (scene_cond_2)
		{

			if (press_button && time_rest > 1)
			{

				press_button = false;
				count_time = false;
				if (k != 0)
				{
					GameObject.Find("XmlData").SendMessage("CreateXML_C2");
				}
				NewTrial();
			}

			if (count_time && TimeCond <= 4)
			{
				Scene_Cond_2.SetActive(true);
				TimeCond += Time.deltaTime;
				ObseverAsw();

			}
			//have a rest for 1 second
			if (count_time && time_rest <= 1 &&(press_button || TimeCond > 4))
			{
				Scene_Cond_2.SetActive(false);
				time_rest += Time.deltaTime;
				press_button = true;
				//GameObject.Find("XmlData").SendMessage("CancelHM");
			}

		}

		//press T to start condition 3=======================================
		if (Input.GetKeyDown(KeyCode.T))
		{
			GameObject.Find("XmlData").SendMessage("CreateXML");
			CondScene ();
			scene_practice = false;
			scene_cond_1 = false;
			scene_cond_2 = false;
			scene_cond_3 = true;

			trials = 70;
			RanCount = false;
			RanCount_3 = false;
			press_button = true;
			time_rest = 2;
			print(" ------welcome to  condition 3 ");

		}

		if (scene_cond_3)
		{
			if (press_button && time_rest >1)
			{
				press_button = false;
				count_time = false;
				if (k != 0)
				{
					GameObject.Find("XmlData").SendMessage("CreateXML_C3");
				}
				NewTrial();
				RanPlane();
			}

			if (count_time && TimeCond <= 4)
			{
				TimeCond += Time.deltaTime;
				ObseverAsw();
				//randomly showing dots in con1 or con2
				if (plane_3 == "con1")
				{
					Scene_Cond_1.SetActive(true);
					Scene_Cond_2.SetActive(false);
				}
				else
				{
					Scene_Cond_2.SetActive(true);
					Scene_Cond_1.SetActive(false);
				}
			}
			//have a rest for 1 second
			if (count_time && time_rest <= 1 && (press_button || TimeCond > 4))
			{
				Scene_Cond_1.SetActive(false);
				Scene_Cond_2.SetActive(false);
				time_rest += Time.deltaTime;
				press_button = true;
			}
		}
	}
	void CondScene(){
		Scene_Ins.SetActive(false);
		SubjectA.SetActive (false);
		SubjectB.SetActive (false);
		Scene_Rest.SetActive(false);
	}
	//initialize for every trial

	void NewTrial()
	{
		time_rest = 0;
		TimeCond = 0;
		count_time = true;
		ObsAnw = " ";
		RanTarget();

	}

	//if the observer gives the answer
	void ObseverAsw()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			press_button = true;
			ObsAnw = "right";//reverse direction, change to 1
			print(TimeCond);
		}

		if (Input.GetKeyDown(KeyCode.K))
		{
			press_button = true;
			ObsAnw = "left";//reverse direction, change to 0
			print(TimeCond);
		}
	}



	void HaveARest(){
		if (press_button) {
			press_button = false;
			count_time = false; //quit the trial

			Scene_Ins.SetActive (false);
			Scene_Cond_1.SetActive (false);
			Scene_Cond_2.SetActive (false);
			Scene_Rest.SetActive (true);
			print (" ------Please have a rest ");

		}
		//continue to trials
		if(Input.GetKeyDown (KeyCode.P)){
			time_rest = 2;
			press_button = true;
			Scene_Rest.SetActive (false);
		}

	}

	void ShowIns() {
		Scene_Ins.SetActive(true);
		Scene_Cond_1.SetActive(false);
		Scene_Cond_2.SetActive(false);
		Scene_Rest.SetActive(false);
		SubjectA.SetActive (false);
		SubjectB.SetActive (false);
		scene_practice = false;
		scene_cond_1 = false;
		scene_cond_2 = false;
		scene_cond_3 = false;

		RanCount = false;
		RanCount_3 = false;
		press_button = false;
		count_time = false;

		k = 0;
		TskNum = 0;
		k_3 = 0;

	}


    //generate equimultiple random target dot
    void RanTarget(){

		print ("run RanTarget" + "k:"+k+"   TskNum:"+TskNum);

	        //generate random arry
	        if (!RanCount) {
		            arr = new int[trials];

		            for (i = 1; i <= trials; i++) {
			                arr [i - 1] = i;
			            }

		            for (j = trials; j >= 1; j--) {
			                index = Random.Range (0,trials); //get 0-trials randomly

			                //exchange the value of arr[index] and arr[j-1]
			                tmp = arr[index];
			                arr [index] = arr [j - 1];
			                arr [j - 1] = tmp;
			            }
		                
		            RanCount = true;
		    }


			if (k >= trials)
			{
				ShowIns();
				print("return to the instruction page-------");
			}


	        //show random target
			if (RanCount) {
	
				TrialNum = arr [k];
				Beep_Sound.Play ();

				if (TrialNum >= 1 && TrialNum <= trials / 7) {
					k++;
					TskNum++;
					DotPosition_1 ();
					RingPosition_1 ();
				}
				if (TrialNum >= trials / 7 + 1 && TrialNum <= trials / 7 * 2) {
					k++;
					TskNum++;
					DotPosition_2 ();
					RingPosition_2 ();
				}
				if (TrialNum >= trials / 7 * 2 + 1 && TrialNum <= trials / 7 * 3) {
					k++;
					TskNum++;
					DotPosition_3 ();
					RingPosition_3 ();
				}
				if (TrialNum >= trials / 7 * 3 + 1 && TrialNum <= trials / 7 * 4) {
					k++;
					TskNum++;
					DotPosition_4 ();
					RingPosition_4 ();
				}
				if (TrialNum >= trials / 7 * 4 + 1 && TrialNum <= trials / 7 * 5) {
					k++;
					TskNum++;
					DotPosition_5 ();
					RingPosition_5 ();
				}
				if (TrialNum >= trials / 7 * 5 + 1 && TrialNum <= trials / 7 * 6) {
					k++;
					TskNum++;	
					DotPosition_6 ();
					RingPosition_6 ();
				}
				if (TrialNum >= trials / 7 * 6 + 1 && TrialNum <= trials) {
					k++;
					TskNum++;
					DotPosition_7 ();
					RingPosition_7 ();
				}


			}



	    }


	//generate equimultiple random target dot
	void RanPlane(){

		//generate random arry
		if (!RanCount_3) {
			arr_3 = new int[trials];

			for (i_3 = 1; i_3 <= trials; i_3++) {
				arr_3 [i_3 - 1] = i_3;
			}

			for (j_3 = trials; j_3 >= 1; j_3--) {
				index_3 = Random.Range (0,trials); //get 0-trials randomly

				tmp_3 = arr_3[index_3];
				arr_3 [index_3] = arr_3 [j_3 - 1];
				arr_3 [j_3 - 1] = tmp_3;
			}

			RanCount_3 = true;
		}

		//show random condition
		if (RanCount_3) {
			TrialNum_3 = arr_3 [k_3];

			if (TrialNum_3 >= 1 && TrialNum_3 <= trials/2) {
				k_3++;
				plane_3 = "con1";

			}
			if (TrialNum_3 >= trials / 2 + 1 && TrialNum_3 <= trials) {
				k_3++;
				plane_3 = "con2";

			}

		}
	}
//
//	void SelectSub_A(){
//		SubjectA.SetActive (true);
//
//
//	}
//
//	void SelectSub_B(){
//		SubjectB.SetActive (true);
//		Scene_Ins.SetActive(false);
//
//	}

    //show corresponding Dot 
    void DotPosition_1(){
			DotNum = "-3";
	        Dot1.SetActive (true);
	        Dot2.SetActive (false);
	        Dot3.SetActive (false);
	        Dot4.SetActive (false);
	        Dot5.SetActive (false);
	        Dot6.SetActive (false);
	        Dot7.SetActive (false);
	    }

    void DotPosition_2(){
			DotNum = "-2";
	        Dot1.SetActive (false);
	        Dot2.SetActive (true);
	        Dot3.SetActive (false);
	        Dot4.SetActive (false);
	        Dot5.SetActive (false);
	        Dot6.SetActive (false);
	        Dot7.SetActive (false);
	    }

    void DotPosition_3(){
			DotNum = "-1";
	        Dot1.SetActive (false);
	        Dot2.SetActive (false);
	        Dot3.SetActive (true);
	        Dot4.SetActive (false);
	        Dot5.SetActive (false);
	        Dot6.SetActive (false);
	        Dot7.SetActive (false);
	    }


    void DotPosition_4(){
			DotNum = "0";
	        Dot1.SetActive (false);
	        Dot2.SetActive (false);
	        Dot3.SetActive (false);
	        Dot4.SetActive (true);
	        Dot5.SetActive (false);
	        Dot6.SetActive (false);
	        Dot7.SetActive (false);
	    }

    void DotPosition_5(){
			DotNum = "1";
	        Dot1.SetActive (false);
	        Dot2.SetActive (false);
	        Dot3.SetActive (false);
	        Dot4.SetActive (false);
	        Dot5.SetActive (true);
	        Dot6.SetActive (false);
	        Dot7.SetActive (false);
	    }

    void DotPosition_6(){
			DotNum = "2";
	        Dot1.SetActive (false);
	        Dot2.SetActive (false);
	        Dot3.SetActive (false);
	        Dot4.SetActive (false);
	        Dot5.SetActive (false);
	        Dot6.SetActive (true);
	        Dot7.SetActive (false);
	    }

    void DotPosition_7(){
			DotNum = "3";
	        Dot1.SetActive (false);
	        Dot2.SetActive (false);
	        Dot3.SetActive (false);
	        Dot4.SetActive (false);
	        Dot5.SetActive (false);
	        Dot6.SetActive (false);
	        Dot7.SetActive (true);
	    }



	//show corresponding ring position
	void RingPosition_1(){
			RingNum = "-3";
			Ring1.SetActive (true);
			Ring2.SetActive (false);
			Ring3.SetActive (false);
			Ring4.SetActive (false);
			Ring5.SetActive (false);
			Ring6.SetActive (false);
			Ring7.SetActive (false);
	}
	void RingPosition_2(){
			RingNum = "-2";
			Ring1.SetActive (false);
			Ring2.SetActive (true);
			Ring3.SetActive (false);
			Ring4.SetActive (false);
			Ring5.SetActive (false);
			Ring6.SetActive (false);
			Ring7.SetActive (false);
	}
	void RingPosition_3(){
			RingNum = "-1";
			Ring1.SetActive (false);
			Ring2.SetActive (false);
			Ring3.SetActive (true);
			Ring4.SetActive (false);
			Ring5.SetActive (false);
			Ring6.SetActive (false);
			Ring7.SetActive (false);
	}
	void RingPosition_4(){
			RingNum = "0";
			Ring1.SetActive (false);
			Ring2.SetActive (false);
			Ring3.SetActive (false);
			Ring4.SetActive (true);
			Ring5.SetActive (false);
			Ring6.SetActive (false);
			Ring7.SetActive (false);
	}
	void RingPosition_5(){
			RingNum = "1";
			Ring1.SetActive (false);
			Ring2.SetActive (false);
			Ring3.SetActive (false);
			Ring4.SetActive (false);
			Ring5.SetActive (true);
			Ring6.SetActive (false);
			Ring7.SetActive (false);
	}
	void RingPosition_6(){
			RingNum = "2";
			Ring1.SetActive (false);
			Ring2.SetActive (false);
			Ring3.SetActive (false);
			Ring4.SetActive (false);
			Ring5.SetActive (false);
			Ring6.SetActive (true);
			Ring7.SetActive (false);
	}
	void RingPosition_7(){
			RingNum = "3";
			Ring1.SetActive (false);
			Ring2.SetActive (false);
			Ring3.SetActive (false);
			Ring4.SetActive (false);
			Ring5.SetActive (false);
			Ring6.SetActive (false);
			Ring7.SetActive (true);
	}
}
