using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartButtonTextScript : MonoBehaviour {


    public GameObject onButton;

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<Text>().color = new Color(124, 124, 124);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (onButton.GetComponent<OnButtonScript>().onPressed)
        {
            gameObject.GetComponent<Text>().color = new Color(255, 255, 255);
        }
        else
        {
            gameObject.GetComponent<Text>().color = new Color(124 / 255f, 124 / 255f, 124 / 255f, 255);
        }
    }
}
