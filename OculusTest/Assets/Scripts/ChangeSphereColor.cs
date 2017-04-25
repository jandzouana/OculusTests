using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSphereColor : MonoBehaviour {
    private Material originalColor;
    public Material newColor;
    public ButtonInteract buttonScript;
    private bool changedColor;

	// Use this for initialization
	void Start () {
        originalColor = gameObject.GetComponent<Renderer>().material;
        changedColor = false;
    }
	
	// Update is called once per frame
	void Update () {
        //switch back to original color.
        /*
        if (changedColor && buttonScript.switchTrigger)
        {
            gameObject.GetComponent<Renderer>().material = originalColor;

        }
        */
        if (buttonScript.switchTrigger && !changedColor)
        {
            gameObject.GetComponent<Renderer>().material = newColor;
            changedColor = true;
        }

    }
}
