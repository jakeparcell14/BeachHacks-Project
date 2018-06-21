using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonScript : MonoBehaviour {

    public bool onPressed;
	// Use this for initialization
	void Start () {
        onPressed = false;
	}

    void OnMouseDown()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>(); //Get the renderer via GetComponent or have it cached previously

        if (onPressed)
        {
            renderer.color = new Color(124 / 255f, 124 / 255f, 124 / 255f, 1f); // Set to grey
            onPressed = false;
        }
        else
        {
            renderer.color = new Color(32 / 255f, 184 / 255f, 77 / 255f, 1f); // Set to green
            onPressed = true;
        }
    }
}
