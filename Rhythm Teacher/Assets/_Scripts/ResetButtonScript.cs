using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtonScript : MonoBehaviour {

    // Update is called when mouse is clicked
    void OnMouseDown()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
