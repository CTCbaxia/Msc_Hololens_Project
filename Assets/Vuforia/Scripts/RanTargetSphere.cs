using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanTargetSphere : MonoBehaviour {

    public GameObject Dot1, Dot2, Dot3, Dot4, Dot5, Dot6, Dot7;
    public int trials = 14;
	public GameObject Scene_Ins;
	public GameObject Scene_Cond_1;
//	public GameObject Scene_Rest;
	public static string DotNum;
	public static string ObjAsw;

	private bool press_button;
	private float time_cond_1 = 0;
	private float time_rest = 0;
//	private bool scene_ins;
	private bool scene_rest;
	private bool scene_cond_1;
    bool RanCount = false;
    int[] arr;
    int i;
    int j;
    int k = 0;
    int index;
    int tmp;
    int TrialNum;



    // Use this for initialization
    void Start () {
		Scene_Cond_1.SetActive (false);
		Scene_Ins.SetActive (false);
	    }
    
    // Update is called once per frame
    void Update () {
			//Press A to show instruction scene
			if (Input.GetKeyDown (KeyCode.A)) {
					Scene_Ins.SetActive (true);
					Scene_Cond_1.SetActive (false);
					print(" ------welcome to the instruction ");
//					scene_ins = true;
			}

			//press S to start the trial or repeat the trial
			if (Input.GetKeyDown (KeyCode.S)) {
					Scene_Ins.SetActive (false);
					Scene_Cond_1.SetActive (false);
					print(" ------welcome to  condition 1 ");
					press_button = true;
			}

			//start the trial
			if(press_button || time_cond_1 > 4){
					press_button = false;
					scene_cond_1 = false; //quit the trial
					Scene_Cond_1.SetActive (false);
					print("time_rest:  "+time_rest);
					print("time_cond_1:  "+time_cond_1);//get the time for the trial
					time_rest = 0;
					time_cond_1 = 0; //initialize the count time
					

					scene_cond_1 = true;
					RanTarget ();	
					GameObject.Find("XmlData").SendMessage("CreateXML_4");

		    }


			//have a rest for 1 second
			if(scene_cond_1 && time_rest <=1 ){
				time_rest += Time.deltaTime;
			}

			//count time for every trial
			if(scene_cond_1 && time_cond_1<= 4 && time_rest >1){
				Scene_Cond_1.SetActive (true);
				time_cond_1 += Time.deltaTime;

				//if the observer gives the answer
				if(Input.GetKeyDown(KeyCode.J) ){
					press_button = true;
					ObjAsw = "nonright";//change to 0
				}
				if(Input.GetKeyDown(KeyCode.K) ){
					press_button = true;
					ObjAsw = "right";//change to 1
				}

			}


	        //Practice: repeat the random showing target function per second, start from 2 second
//		        if(Input.GetKeyDown(KeyCode.Z)){
//			            InvokeRepeating("RanTarget", 2.0f, 0.5f);
//			    }

	    }

    //generate equimultiple random target dot
    void RanTarget(){
	print ("run RanTarget");
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
	        if (k >= 14) {
		            k = 0;
		            RanCount = false;
		            print("finish the first round");
		        }

	        //show random target
	        if (RanCount) {
//			            print(k);
		            TrialNum = arr [k];
//			            print (TrialNum);
		        }


	        if (TrialNum >= 1 && TrialNum <= 2) {
		            k++;
		            DotPosition_1 ();
		        }
	        if (TrialNum >= 3 && TrialNum <= 4) {
		            k++;
		            DotPosition_2 ();
		        }
	        if (TrialNum >= 5 && TrialNum <= 6) {
		            k++;
		            DotPosition_3 ();
		        }
	        if (TrialNum >= 7 && TrialNum <= 8) {
		            k++;
		            DotPosition_4 ();
		        }
	        if (TrialNum >= 9 && TrialNum <= 10) {
		            k++;
		            DotPosition_5 ();
		        }
	        if (TrialNum >= 11 && TrialNum <= 12) {
		            k++;
		            DotPosition_6 ();
		        }
	        if (TrialNum >= 13 && TrialNum <= 14) {
		            k++;
		            DotPosition_7 ();
		        }



	    }

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
}
