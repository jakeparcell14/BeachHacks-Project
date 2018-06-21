using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarterNoteScript : NoteScript {

    // Use this for initialization
    void Start()
    {
        notes = new bool[] { true, false, false, false };

        bpm = beatsPerMinute.GetComponent<BeatsPerMinute>().bpm;
    }
}
