using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixteenthNoteScript : NoteScript
{

    // Use this for initialization
    void Start()
    {
        notes = new bool[] { true, true, true, true };

        bpm = beatsPerMinute.GetComponent<BeatsPerMinute>().bpm;
    }
}
