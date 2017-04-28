using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSphereColor : MonoBehaviour {
    private Material originalColor;
    public Material newColor;
    public ButtonInteract buttonScript;
    private bool changedColor;
    private bool canTrigger;

	// Use this for initialization
	void Start () {
        originalColor = gameObject.GetComponent<Renderer>().material;
        changedColor = false;
        canTrigger = false;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("on: " + buttonScript.on);
        if (buttonScript.on && buttonScript.switchTrigger) { 
            gameObject.GetComponent<Renderer>().material = originalColor;
            gameObject.GetComponent<AudioSource>().Stop();
            canTrigger = false;
            changedColor = false;
        }
        else if (buttonScript.switchTrigger)
        {
            gameObject.GetComponent<Renderer>().material = newColor;
            gameObject.GetComponent<AudioSource>().Play();
            changedColor = true;
        }



    }
}
