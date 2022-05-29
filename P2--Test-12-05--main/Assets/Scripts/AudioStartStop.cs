using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioStartStop : MonoBehaviour
{
    AudioSource myAudioSource;
    public float snoozeTime;
    public bool play = true;
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        StartCoroutine(SoundOut());
    }
    IEnumerator SoundOut()
    {
    while (play == true)
    {   
        if (this.GetComponent<AudioStartStop>().enabled == true)
        {
            myAudioSource.PlayOneShot(myAudioSource.clip);
            yield return new WaitForSeconds(snoozeTime);
        }
    }
    }   
    public void StopSound()
    {
        if (play == true)
        {
        play = false; 
        myAudioSource.GetComponent<AudioSource>().volume = 0.0f;
        //StopCoroutine(SoundOut());
        Debug.Log("Test stop");
        }
        else if (play == false)
        {
        play = true;
        myAudioSource.GetComponent<AudioSource>().volume = 1.0f;
        //Invoke("SoundOut", snoozeTime);
        Debug.Log("Test start");
        }
    }
}