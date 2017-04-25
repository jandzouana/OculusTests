using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour {
	private Vector3 startPosition;
	private Vector3 initialPosition;
	private Vector3 endPosition;
	private float t, s;

	private bool hasTouched;
	public float timeLower;
	public float timeUpper;
	//specify how far you can push the button
	public float distance;
	//how far you need to push the button to trigger an action
	public float distanceTrigger;


	public void OnTriggerEnter(Collider hand){
		if(hand.name.Contains("hand")){
			hasTouched = true;
		}
	}
	public void OnTriggerExit(Collider hand){
			if(hand.name.Contains("hand")){
			hasTouched = false;
		}
	}
	// Use this for initialization
	void Start () {
		hasTouched = false;
		initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		endPosition = new Vector3(transform.position.x, transform.position.y-distance, transform.position.z);
		startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//If the player's hand/finger has collided, then lower button in timeLower time
		if(hasTouched){
			s=0;
			t+=Time.deltaTime/timeLower;
			transform.position = Vector3.Lerp(startPosition, endPosition, t);
		}
		//If the player is no longer touching the button, reset button to original position
		else{
			t=0;
			s+=Time.deltaTime/timeUpper;
			startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			transform.position = Vector3.Lerp(startPosition, initialPosition, s);
		}
	}
}
