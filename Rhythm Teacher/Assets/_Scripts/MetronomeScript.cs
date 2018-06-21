using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeScript : MonoBehaviour
{
    // bpm of the exercise
    private float bpm;

    public GameObject beatsPerMinute;

    // met circle
    private SpriteRenderer circle1;
    private SpriteRenderer circle2;
    private SpriteRenderer circle3;
    private SpriteRenderer circle4;


    // current count the measure is on
    private int metronome;

    public GameObject onButton;
    public GameObject startButton;
    public GameObject rudimentPlayer;
    public GameObject count2;
    public GameObject count3;
    public GameObject count4;


    public bool rudimentPlaying;

    // Use this for initialization
    void Start()
    {

        bpm = beatsPerMinute.GetComponent<BeatsPerMinute>().bpm;

        metronome = 1;

        rudimentPlaying = false;

        // calculates seconds per quarter note
        float duration = (float)60.0 / bpm;

        circle1 = GetComponent<SpriteRenderer>();
        circle2 = count2.GetComponent<SpriteRenderer>();
        circle3 = count3.GetComponent<SpriteRenderer>();
        circle4 = count4.GetComponent<SpriteRenderer>();


        StartCoroutine(CoTimer(duration));
    }

    public IEnumerator CoTimer(float quarterNote)
    {
        while (true)
        {
            if (onButton.GetComponent<OnButtonScript>().onPressed)
            {
                if (startButton.GetComponent<StartButtonScript>().startButtonPressed && !rudimentPlaying)
                {
                    if (metronome == 1)
                    {
                        rudimentPlaying = true;

                        yield return StartCoroutine(rudimentPlayer.GetComponent<RudimentPlayerScript>().CoPlayer(quarterNote / 4));
                    }
                }

                // mute metronome when rudiment is playing
                if (!rudimentPlaying)
                {
                    // make metronome beep on every count
                    gameObject.transform.parent.GetComponent<AudioSource>().Play();
                }

                if (!startButton.GetComponent<StartButtonScript>().startButtonPressed && rudimentPlaying)
                {
                    rudimentPlaying = false;
                }

                    switch(metronome)
                    {
                        case 1:
                            circle1.color = Color.green;
                            circle2.color = Color.black;
                            circle3.color = Color.black;
                            circle4.color = Color.black;
                            break;
                        case 2:
                            circle2.color = Color.green;
                            circle1.color = Color.black;
                            circle3.color = Color.black;
                            circle4.color = Color.black;
                            break;

                        case 3:
                            circle3.color = Color.green;
                            circle1.color = Color.black;
                            circle2.color = Color.black;
                            circle4.color = Color.black;
                            break;

                        case 4:
                            circle4.color = Color.green;
                            circle1.color = Color.black;
                            circle2.color = Color.black;
                            circle3.color = Color.black;
                            break;
                    }
                

                /**
                // changes color to green if met is on its count and off if not
                if (metronome == count)
                {
                    if (!firstLoop)
                    {
                        circle1.color = Color.green;
                    }
                    else
                    {
                        circle1.color = Color.red;
                    }
                }
                else
                {
                    circle1.color = Color.black;
                }
    */

                metronome++;

                if (metronome > 4)
                {
                    metronome = 1;
                }
            }
            else
            {
                circle1.color = Color.black;
                metronome = 1;
            }
            
            yield return new WaitForSeconds(quarterNote);
        }
    }
}

