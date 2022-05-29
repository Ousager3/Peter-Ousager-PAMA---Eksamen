using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class AudioStartStop : MonoBehaviour
{
    AudioSource myAudioSource; // The class is called AudioStartStop and it has two fields: myAudioSource, which is an AudioSource, and snoozeTime, which is a float variable that represents the time in seconds before the audio will start playing again after being stopped.

    //Play the music
    //public bool Play;
    public float snoozeTime;
    //Detect when you use the toggle, ensures music isn�t played multiple times
    public bool m_ToggleChange = true;
    public bool play = true;

    void Start() // The Start() function starts an IEnumerator to play sound out of myAudioSource every second for as long as play == true.
    {            //  If play == false then it plays sound out of myAudioSource every second until stopSound() is called or m_ToggleChange becomes true (which means that this object was enabled). 
        //Fetch the AudioSource from the GameObject
        myAudioSource = GetComponent<AudioSource>();
        StartCoroutine(SoundOut()); // The Start() function starts the sound by calling the GetComponent().PlayOneShot(myAudioSource.clip); function on the AudioSource component, then calls the StartCoroutine(SoundOut()); function which starts playing a sound using an IEnumerator object.

        //Ensure the toggle is set to true for the music to play at start-up
    }

    IEnumerator SoundOut()
    {
    while (play == true)
    {
        if (this.GetComponent<AudioStartStop>().enabled == true)
        {
            AudioSource myAudioSource = this.GetComponent<AudioSource>();
            myAudioSource.PlayOneShot(myAudioSource.clip);
            yield return new WaitForSeconds(snoozeTime);
        }
    }

}
    public void StopSound() // The StopSound() function stops playing sounds by setting play = false; in the if statement of the while loop in SoundOut(), and then calls StopCoroutine(SoundOut()); to stop playing sounds with another IEnumerator object.
    {
        if (play == true)
        {
        play = false; 
        myAudioSource.GetComponent<AudioSource>().volume = 0.0f;
        StopCoroutine(SoundOut());
        Debug.Log("Test stop");
        }
        else if (play == false)
        {
        play = true;
        myAudioSource.GetComponent<AudioSource>().volume = 1.0f;
        StartCoroutine(SoundOut());
        Debug.Log("Test start");
        }
        //m_ToggleChange = false;

    }
}