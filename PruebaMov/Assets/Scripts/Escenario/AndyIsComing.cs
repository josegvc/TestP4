using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndyIsComing : MonoBehaviour {

	private Animator anim;

	void Start(){
		anim = GetComponent <Animator> ();
	}

	void OnTriggerEnter(){

		anim.SetBool ("Muerte", true);

	}

	void OnTriggerExit(){
	
		anim.SetBool ("Muerte", false);
	}
}
