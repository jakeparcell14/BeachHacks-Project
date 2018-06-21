using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudimentPlayerScript : MonoBehaviour
{

    public GameObject measure;

    private int noteCounter;

    private bool[] notes;

    public GameObject met;
    public GameObject startButton;

    private SpriteRenderer circle1;
    private SpriteRenderer circle2;
    private SpriteRenderer circle3;
    private SpriteRenderer circle4;


    public void Start()
    {
        notes = measure.GetComponent<MeasureScript>().notes;

        circle1 = met.GetComponent<MetronomeScript>().GetComponent<SpriteRenderer>();
        circle2 = met.GetComponent<MetronomeScript>().count2.GetComponent<SpriteRenderer>();
        circle3 = met.GetComponent<MetronomeScript>().count3.GetComponent<SpriteRenderer>();
        circle4 = met.GetComponent<MetronomeScript>().count4.GetComponent<SpriteRenderer>();


        noteCounter = 0;
    }

    private void Update()
    {
        if(measure.GetComponent<MeasureScript>().measureFull)
        {
            notes = measure.GetComponent<MeasureScript>().notes;
        }
    }

    public IEnumerator CoPlayer(float sixteenthNote)
    {
        Debug.Log("New Player Process confirmed");

        while (true)
        {
            if (measure.GetComponent<MeasureScript>().measureFull)
            {
                if (notes[noteCounter])
                {
                    // make metronome beep on every count
                    gameObject.transform.GetComponent<AudioSource>().Play();
                }

                // changes color to green if met is on its count and off if not
                switch (noteCounter)
                {
                    case 0:
                        circle1.color = Color.green;
                        circle2.color = Color.black;
                        circle3.color = Color.black;
                        circle4.color = Color.black;
                        break;
                    case 4:
                        circle2.color = Color.green;
                        circle1.color = Color.black;
                        circle3.color = Color.black;
                        circle4.color = Color.black;
                        break;

                    case 8:
                        circle3.color = Color.green;
                        circle1.color = Color.black;
                        circle2.color = Color.black;
                        circle4.color = Color.black;
                        break;

                    case 12:
                        circle4.color = Color.green;
                        circle1.color = Color.black;
                        circle2.color = Color.black;
                        circle3.color = Color.black;
                        break;
                }

                noteCounter++;

                if (noteCounter >= 16)
                {
                    noteCounter = 0;


                    if (!startButton.GetComponent<StartButtonScript>().startButtonPressed)
                    {
                        break;
                    }
                }

                yield return new WaitForSeconds(sixteenthNote);
            }
            else
            {
                break;
            }
        }
        met.GetComponent<MetronomeScript>().rudimentPlaying = false;
    }
}


    