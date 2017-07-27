using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanTargetSphere : MonoBehaviour {

	public GameObject Dot1, Dot2, Dot3, Dot4, Dot5, Dot6, Dot7;

	// Use this for initialization
	void Start () {
		Dot1.SetActive (false);
		Dot2.SetActive (false);
		Dot3.SetActive (false);
		Dot4.SetActive (false);
		Dot5.SetActive (false);
		Dot6.SetActive (false);
		Dot7.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		//test with keyboard to show corresponding Dot
		if (Input.GetKeyDown(KeyCode.Q)){

			DotPosition_1 ();
			print(" keyQ was pressed");
			print (Random.Range (0,10));
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
