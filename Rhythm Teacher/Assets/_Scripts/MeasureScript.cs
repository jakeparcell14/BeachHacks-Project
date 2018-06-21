using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasureScript : MonoBehaviour {

    private int bpm;

    public GameObject beatsPerMinute;

    public static GameObject Count1;
    public static GameObject Count2;
    public static GameObject Count3;
    public static GameObject Count4;

    private bool flag1;
    private bool flag2;
    private bool flag3;
    private bool flag4;

    public bool measureFull;

    // amount of seconds per quarter note
    public float duration;

    public bool[] notes;

    // Use this for initialization
    void Start()
    {
        notes = new bool[16];
        bpm = beatsPerMinute.GetComponent<BeatsPerMinute>().bpm;

        // calculates seconds per quarter note
        duration = (float)60.0 / bpm;

        flag1 = false;
        flag2 = false;
        flag3 = false;
        flag4 = false;
        measureFull = false;
    }

    private void Update()
    {
        if(!measureFull && Count1 != null && Count2 != null && Count3 != null && Count4 != null)
        {
            measureFull = true;
        }
    }

    private void FixedUpdate()
    {
        if (Count1 != null && !flag1)
        {
            flag1 = true;

            GetCountType(1).CopyTo(notes, 0);
        }

        if (Count2 != null && !flag2)
        {
            flag2 = true;
            GetCountType(2).CopyTo(notes, 4);
        }

        if (Count3 != null && !flag3)
        {
            flag3 = true;

            GetCountType(3).CopyTo(notes, 8);
        }

        if (Count4 != null && !flag4)
        {
            flag4 = true;

            GetCountType(4).CopyTo(notes, 12);
        }
    }

    static bool[] GetCountType(int countNumber)
    {
        switch (countNumber)
        {
            case 1:
                return Count1.GetComponent<NoteScript>().notes;

            case 2:
                return Count2.GetComponent<NoteScript>().notes;

            case 3:
                return Count3.GetComponent<NoteScript>().notes;

            case 4:
                return Count4.GetComponent<NoteScript>().notes;

            default:
                return null;
        }
    }
}
