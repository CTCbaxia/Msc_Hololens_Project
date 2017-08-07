using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanTargetSphere : MonoBehaviour {

    public GameObject Dot1, Dot2, Dot3, Dot4, Dot5, Dot6, Dot7;
	public GameObject Ring1, Ring2, Ring3, Ring4, Ring5, Ring6, Ring7;
    public int trials = 14;//the number of all trial in one condition
	public GameObject Scene_Ins;
	public GameObject Scene_Cond_1;
	public GameObject Scene_Cond_2;
	public GameObject Scene_Rest;
	public AudioSource Beep_Sound;

	public static string DotNum;//condition1
	public static string RingNum;//condition2
	public static float TimeCond = 0;
	public static string ObsAnw;
	public static int TskNum = 0;

	private bool press_button;
	private float time_rest = 0;
	private float ring_show = 0;

	private bool count_time;
	private bool scene_cond_1;
	private bool scene_cond_2;
	private bool scene_cond_3;
	private bool scene_practice;

    bool RanCount = false;

    int[] arr;
    int i;
    int j;
    int k = 0;
    int index;
	int index_con3;
    int tmp;
    int TrialNum;//the offset for every trial




    // Use this for initialization
    void Start () {
		Scene_Ins.SetActive (false);
		Scene_Cond_1.SetActive (false);
		Scene_Cond_2.SetActive (false);
		Scene_Rest.SetActive (false);

	    }
    
    // Update is called once per frame
    void Update () {
			//Press A to show instruction scene
			if (Input.GetKeyDown (KeyCode.A)) {
					Scene_Ins.SetActive (true);
					Scene_Cond_1.SetActive (false);
					Scene_Cond_2.SetActive (false);
					print(" ------welcome to the instruction ");

			}


//			//Press S to start the practice ===================================
//	        if(Input.GetKeyDown(KeyCode.S)){
//					Scene_Ins.SetActive (false);
//					// TBD - discriminate condition 1/2/3
//
//					trials = 7;
//					RanCount = false;
//					scene_practice = true;
//					press_button = true;
//					print(" ------welcome to the practice section ");
//				
//		    }

			//have a rest when having done half of the trials
			if (k == 4) {
				HaveARest ();
			}

			//press D to start condition1=======================================
			if (Input.GetKeyDown (KeyCode.D)) {
					//GameObject.Find("XmlData").SendMessage("CreateCSV_1");
					Scene_Ins.SetActive (false);
					Scene_Cond_2.SetActive (false);
					Scene_Rest.SetActive (false);

					scene_practice = false;
					scene_cond_1 = true;
					scene_cond_2 = false;

					trials = 7;
					RanCount = false;
					press_button = true;
						
					print(" ------welcome to  condition 1 ");

			}

			//start all trials
			if(scene_cond_1){


				if(press_button || TimeCond > 4){
					press_button = false;
					count_time = false; //quit the trial
					GameObject.Find("XmlData").SendMessage("CreateXML_C1");
//					GameObject.Find("XmlData").SendMessage("DataCollectCSV_1");

					NewTrial()

				}

				//have a rest for 1 second
				if(count_time && time_rest <=1 ){
					Scene_Cond_1.SetActive (false);
					time_rest += Time.deltaTime;
				}

				//count time for every trial
				if(count_time && TimeCond<= 4 && time_rest >1){
					Scene_Cond_1.SetActive (true);
					TimeCond += Time.deltaTime;
					ObsAnw = " ";//为什么在这里赋值就有用
					ObseverAsw ();

				}
			}
			

			//press F to start condition2=======================================
			if (Input.GetKeyDown (KeyCode.F)) {
					Scene_Ins.SetActive (false);
					Scene_Cond_1.SetActive (false);
					
					scene_practice = false;
					scene_cond_1 = false;
					scene_cond_2 = true;

					trials = 7;
					RanCount = false;
					press_button = true;
					
					print(" ------welcome to  condition 2 ");

			}
			if (scene_cond_2) {
				if (press_button || TimeCond > 4) {
					press_button = false;
					count_time = false;
					GameObject.Find("XmlData").SendMessage("CreateXML_C2");

					//initialize for every trial
					time_rest = 0;
					TimeCond = 0; 
					ring_show  = 0;
					count_time = true;

					RanTarget ();
				}
				//have a rest for 1 second
				if(count_time && time_rest <=1 ){
					Scene_Cond_2.SetActive (false);
					time_rest += Time.deltaTime;
					
				}
				if (count_time && TimeCond <= 4 && time_rest > 1) {
					
					TimeCond += Time.deltaTime;
					ring_show  += Time.deltaTime;
					ObsAnw = " ";
					ObseverAsw ();
					if (ring_show < 1) {
						Scene_Cond_2.SetActive (true);

					} else {
						Scene_Cond_2.SetActive (false);
					}

				}
			}


			//press G to start condition 3=======================================
			if(Input.GetKeyDown (KeyCode.G)){
				Scene_Ins.SetActive (false);
				scene_practice = false;
				scene_cond_1 = false;
				scene_cond_2 = false;
				scene_cond_3 = true;

				trials = 7;
				RanCount = false;
				press_button = true;

				print(" ------welcome to  condition 3 ");
			}
			if (scene_cond_3) {
				if (press_button || TimeCond > 4) {

					press_button = false;
					count_time = false;
					GameObject.Find("XmlData").SendMessage("CreateXML_C3");//change to C3

					//initialize for every trial
					time_rest = 0;
					TimeCond = 0; 
					ring_show  = 0;
					count_time = true;

					RanTarget ();
					index_con3 = Random.Range (0,2);//randomly showing dots or rings

				}
				//have a rest for 1 second
				if(count_time && time_rest <=1 ){

					Scene_Cond_1.SetActive (false);
					Scene_Cond_2.SetActive (false);

					time_rest += Time.deltaTime;

				}
				if (count_time && TimeCond <= 4 && time_rest > 1) {

					TimeCond += Time.deltaTime;

					ObsAnw = " ";
					ObseverAsw ();
					//generate random bool
					if (index_con3 == 0) {
						Scene_Cond_1.SetActive (true);
					} else {
						ring_show  += Time.deltaTime;

						if (ring_show < 1) {
							Scene_Cond_2.SetActive (true);

						} else {
							Scene_Cond_2.SetActive (false);
						}
					}

				}

			}
			


	    }


	//initialize for every trial
	void NewTrial(){
		time_rest = 0;
		TimeCond = 0; 
		count_time = true;

		RanTarget ();	
	}


	//if the observer gives the answer
	void ObseverAsw(){
		if(Input.GetKeyDown(KeyCode.J) ){
			press_button = true;
			ObsAnw = "nonright";//change to 0
		}
		if(Input.GetKeyDown(KeyCode.K) ){
			press_button = true;
			ObsAnw = "right";//change to 1
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
			press_button = true;
			Scene_Rest.SetActive (false);
		}

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


			//if all trials has been shown, quit condition 1, reshow instruction
			if (k >= trials) {
				k = 0;
				TskNum = 0;
				RanCount = false;
				Scene_Ins.SetActive (true);
				Scene_Cond_1.SetActive (false);
				count_time = false;
				scene_cond_1 = false;
				scene_cond_2 = false;
				print("finish the first round----and return to the instruction page-------");
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
