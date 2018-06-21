using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour {

    public bool onButtonPressed;

    public bool startButtonPressed;

    public GameObject onButton;

    // Use this for initialization
    void Start()
    {
        onButtonPressed = false;
        startButtonPressed = false;
    }

    void OnMouseDown()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>(); //Get the renderer via GetComponent or have it cached previously

        onButtonPressed = onButton.GetComponent<OnButtonScript>().onPressed;

        if (onButtonPressed)
        {
            if (startButtonPressed)
            {
                renderer.color = new Color(124 / 255f, 124 / 255f, 124 / 255f, 1f); // Set to grey
                startButtonPressed = false;
            }
            else
            {
                renderer.color = new Color(32 / 255f, 184 / 255f, 77 / 255f, 1f); // Set to green
                startButtonPressed = true;
            }
        }
    }

    private void Update()
    {
        onButtonPressed = onButton.GetComponent<OnButtonScript>().onPressed;

        if (!onButtonPressed && startButtonPressed)
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>(); //Get the renderer via GetComponent or have it cached previously

            renderer.color = new Color(124 / 255f, 124 / 255f, 124 / 255f, 1f); // Set to grey
            startButtonPressed = false;
        }
    }
}
