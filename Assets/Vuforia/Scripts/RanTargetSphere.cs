using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanTargetSphere : MonoBehaviour {

    public GameObject Dot1, Dot2, Dot3, Dot4, Dot5, Dot6, Dot7;
    public int trials = 14;
	public GameObject Scene_Ins;
	public GameObject Scene_Cond_1;
//	public GameObject Scene_Rest;

	private float time_cond_1 = 0;
	private float time_rest = 0;
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
	        Dot1.SetActive (false);
	        Dot2.SetActive (false);
	        Dot3.SetActive (false);
	        Dot4.SetActive (false);
	        Dot5.SetActive (false);
	        Dot6.SetActive (false);
	        Dot7.SetActive (false);
	Scene_Cond_1.SetActive (false);
	Scene_Ins.SetActive (false);
	    }
    
    // Update is called once per frame
    void Update () {

	//        print(Time.deltaTime);

	        //test with keyboard to show corresponding Dot
	        if (Input.GetKeyDown(KeyCode.Q)){

		            DotPosition_1 ();
		            print(" keyQ was pressed");

		        }
	        if (Input.GetKeyDown(KeyCode.W)){

		            DotPosition_2 ();
		            print(" keyW was pressed");

		        }
	        if (Input.GetKeyDown (KeyCode.E)) {

		            DotPosition_3 ();
		            print(" keyE was pressed");
		        }
	        if (Input.GetKeyDown (KeyCode.R)) {

		            DotPosition_4 ();
		            print(" keyR was pressed");

		        }
	        if (Input.GetKeyDown (KeyCode.T)) {

		            DotPosition_5 ();
		            print(" keyT was pressed");

		        }
	        if (Input.GetKeyDown (KeyCode.Y)) {

		            DotPosition_6 ();
		            print(" keyY was pressed");
		        }
	        if (Input.GetKeyDown (KeyCode.U)) {

		            DotPosition_7 ();
		            print(" keyU was pressed");
		        }

	        //test random target
			if (Input.GetKeyDown (KeyCode.A)) {
					Scene_Ins.SetActive (true);
					Scene_Cond_1.SetActive (false);
					print(" ------test random target------Press A");
			}
			//press S to start the trial or repeat the trial
			if(Input.GetKeyDown (KeyCode.S) || time_cond_1 > 4){
					print(" ------test random target------Press S");
					Scene_Ins.SetActive (false);
					Scene_Cond_1.SetActive (true);
//						scene_cond_1 = false;//condition1 start

					print("time_cond_1:  "+time_cond_1);
					time_cond_1 = 0; //initialize the count time

					scene_cond_1 = true;
					RanTarget ();

		    }

			//count time for every trial
			if(scene_cond_1 && time_cond_1<= 4){
				time_cond_1 += Time.deltaTime;
			Scene_Cond_1.SetActive (true);

			}
		//if press the button or overtime
		if(Input.GetKeyDown (KeyCode.S)){
			Scene_Ins.SetActive (false);
//			Scene_Rest.SetActive (true);//have a rest 
			Scene_Cond_1.SetActive (false);

		}

	        //repeat the random showing target function per second, start from 2 second
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
	        Dot1.SetActive (true);
	        Dot2.SetActive (false);
	        Dot3.SetActive (false);
	        Dot4.SetActive (false);
	        Dot5.SetActive (false);
	        Dot6.SetActive (false);
	        Dot7.SetActive (false);
	    }

    void DotPosition_2(){
	        Dot1.SetActive (false);
	        Dot2.SetActive (true);
	        Dot3.SetActive (false);
	        Dot4.SetActive (false);
	        Dot5.SetActive (false);
	        Dot6.SetActive (false);
	        Dot7.SetActive (false);
	    }

    void DotPosition_3(){
	        Dot1.SetActive (false);
	        Dot2.SetActive (false);
	        Dot3.SetActive (true);
	        Dot4.SetActive (false);
	        Dot5.SetActive (false);
	        Dot6.SetActive (false);
	        Dot7.SetActive (false);
	    }


    void DotPosition_4(){
	        Dot1.SetActive (false);
	        Dot2.SetActive (false);
	        Dot3.SetActive (false);
	        Dot4.SetActive (true);
	        Dot5.SetActive (false);
	        Dot6.SetActive (false);
	        Dot7.SetActive (false);
	    }

    void DotPosition_5(){
	        Dot1.SetActive (false);
	        Dot2.SetActive (false);
	        Dot3.SetActive (false);
	        Dot4.SetActive (false);
	        Dot5.SetActive (true);
	        Dot6.SetActive (false);
	        Dot7.SetActive (false);
	    }

    void DotPosition_6(){
	        Dot1.SetActive (false);
	        Dot2.SetActive (false);
	        Dot3.SetActive (false);
	        Dot4.SetActive (false);
	        Dot5.SetActive (false);
	        Dot6.SetActive (true);
	        Dot7.SetActive (false);
	    }

    void DotPosition_7(){
	        Dot1.SetActive (false);
	        Dot2.SetActive (false);
	        Dot3.SetActive (false);
	        Dot4.SetActive (false);
	        Dot5.SetActive (false);
	        Dot6.SetActive (false);
	        Dot7.SetActive (true);
	    }
}
