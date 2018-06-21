using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EigthNoteScript : NoteScript {

	// Use this for initialization
	void Start()
    {
		notes =  new bool[] { true, false, true, false };

        bpm = beatsPerMinute.GetComponent<BeatsPerMinute>().bpm;
    }
}
