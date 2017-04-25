using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour {
	private Vector3 startPosition;
	private Vector3 initialPosition;
	private Vector3 endPosition;
    private Vector3 testPosition;

    private float t, s;

	private bool hasTouched;
    private bool leftHasTouched;
    private bool rightHasTouched;

    //specify how fast the button lowers and bounces back to the origial position
	public float timeLower;
	public float timeUpper;
	//specify how far you can push the button
	public float distance;
	//how far you need to push the button to trigger an action
	public float distanceTrigger;

    //script that enables haptic feedback
    public OculusHapticsController OHCscript;

	public void OnTriggerEnter(Collider hand){
		if(hand.name.Contains("hand")) hasTouched = true;
        if (hand.name.Contains("hands:b_l")) leftHasTouched = true;
        else if (hand.name.Contains("hands:b_r")) rightHasTouched = true;
	}

    public void OnTriggerExit(Collider hand)
    {
        if (hand.name.Contains("hands:b_l")) leftHasTouched = false;
        else if (hand.name.Contains("hands:b_r")) rightHasTouched = false;
        if (!(leftHasTouched && rightHasTouched)) hasTouched = false;
    }
	// Use this for initialization
	void Start () {
		hasTouched = leftHasTouched = rightHasTouched = false;
		initialPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        Debug.Log("initial:"+initialPosition);
        testPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        Debug.Log("test: " + testPosition);
        endPosition = new Vector3(transform.localPosition.x, transform.localPosition.y-distance, transform.localPosition.z);
		startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
	}
	
	// Update is called once per frame
	void Update () {
        if (leftHasTouched) OHCscript.SimpleVibrate("left", 0);
        if (rightHasTouched) OHCscript.SimpleVibrate("right", 0);
        //If the player's hand/finger has collided, then lower button in timeLower time
        if (hasTouched){
            s = 0;
			t+=Time.deltaTime/timeLower;
			transform.localPosition = Vector3.Lerp(startPosition, endPosition, t);
		}
		//If the player is no longer touching the button, reset button to original position
		else{
			t=0;
			s+=Time.deltaTime/timeUpper;
			startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = Vector3.Lerp(startPosition, initialPosition, s);
		}
	}
}
