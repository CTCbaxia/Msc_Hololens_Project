using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanTargetSphere : MonoBehaviour {

	public GameObject sphere1;
	public GameObject sphere2;
	public GameObject sphere3;
	public GameObject sphere4;
	public GameObject sphere5;
	public GameObject sphere6;
	public GameObject sphere7;
//	Random Ran = new Random();

	// Use this for initialization
	void Start () {
		sphere1.SetActive (false);
		sphere2.SetActive (false);
		sphere3.SetActive (false);
		sphere4.SetActive (false);
		sphere5.SetActive (false);
		sphere6.SetActive (false);
		sphere7.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)){

			SphPosition_1 ();
			print(" keyQ was pressed");
			print (Random.Range (0,10));
		}
		if (Input.GetKeyDown(KeyCode.W)){

			SphPosition_2 ();
			print(" keyW was pressed");

		}
		if (Input.GetKeyDown (KeyCode.E)) {

			SphPosition_3 ();
			print(" keyE was pressed");
		}
		if (Input.GetKeyDown (KeyCode.R)) {

			SphPosition_4 ();
			print(" keyR was pressed");

		}
		if (Input.GetKeyDown (KeyCode.T)) {

			SphPosition_5 ();
			print(" keyT was pressed");

		}
		if (Input.GetKeyDown (KeyCode.Y)) {

			SphPosition_6 ();
			print(" keyY was pressed");
		}
		if (Input.GetKeyDown (KeyCode.U)) {

			SphPosition_7 ();
			print(" keyU was pressed");
		}


	}



	void SphPosition_1(){
		sphere1.SetActive (true);
		sphere2.SetActive (false);
		sphere3.SetActive (false);
		sphere4.SetActive (false);
		sphere5.SetActive (false);
		sphere6.SetActive (false);
		sphere7.SetActive (false);



	}

	void SphPosition_2(){
		sphere1.SetActive (false);
		sphere2.SetActive (true);
		sphere3.SetActive (false);
		sphere4.SetActive (false);
		sphere5.SetActive (false);
		sphere6.SetActive (false);
		sphere7.SetActive (false);

	
	}

	void SphPosition_3(){
		sphere1.SetActive (false);
		sphere2.SetActive (false);
		sphere3.SetActive (true);
		sphere4.SetActive (false);
		sphere5.SetActive (false);
		sphere6.SetActive (false);
		sphere7.SetActive (false);
	}

	void SphPosition_4(){
		sphere1.SetActive (false);
		sphere2.SetActive (false);
		sphere3.SetActive (false);
		sphere4.SetActive (true);
		sphere5.SetActive (false);
		sphere6.SetActive (false);
		sphere7.SetActive (false);
	}
	void SphPosition_5(){
		sphere1.SetActive (false);
		sphere2.SetActive (false);
		sphere3.SetActive (false);
		sphere4.SetActive (false);
		sphere5.SetActive (true);
		sphere6.SetActive (false);
		sphere7.SetActive (false);
	}
	void SphPosition_6(){
		sphere1.SetActive (false);
		sphere2.SetActive (false);
		sphere3.SetActive (false);
		sphere4.SetActive (false);
		sphere5.SetActive (false);
		sphere6.SetActive (true);
		sphere7.SetActive (false);
	}
	void SphPosition_7(){
		sphere1.SetActive (false);
		sphere2.SetActive (false);
		sphere3.SetActive (false);
		sphere4.SetActive (false);
		sphere5.SetActive (false);
		sphere6.SetActive (false);
		sphere7.SetActive (true);
	}
}
