using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
//For at scriptet skal virke, skal i bruge et empty gameobject og en audiosource og en audiolistener. 
//Dette script skal sættes på gameobjectet, text.text skal sættes trækkes op i inspectoren, hvis vi har en tekst, der skal vises.
{
    //  This is the singleton instance of the audio manager class.
    public static AudioManager Instance = null; // The code starts by declaring a public static AudioManager Instance = null;.

    // med Threshold skal i huske at tjekke inspectoren, om den står rigtigt derinde. 5 er en ret god værdi, vil jeg sige.
    public float threshold = 200f; //The next line declares a float threshold = 200f;, which is used to determine when an audio clip should be played and how long it should play for before being replaced with another one.
    public bool trigger = false; // The next line declares a bool trigger = false;, which determines whether or not an audio clip will start playing as soon as it's loaded into memory or if it needs to wait until triggered by something else first.
    public float snoozeTime = 30f; //  Next comes snoozeTime, which is set at 30 seconds in this case.


    // Initialize the singleton instance.
    private void Awake() // The code then goes on to initialize the singleton instance of SoundManager that was declared earlier in Awake().
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null) // It starts off by checking if there already exists an instance of SoundManager (if(Instance == null) {)
        {                     // If there isn't one yet, then we create our own and assign it to the variable Instance so that we can use this object later on in our game logic without having to worry about creating multiple instances of SoundManager throughout our game logic because they're all stored within one singleton object called "Instance".
            Instance = this;  // If there already exists an instance of SoundManager (else if(Instance != this)),
        }                     // The code attempts to create a singleton instance of the AudioManager class.   
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        // The AudioManager won't be destroyed when loading a new scene. 
        DontDestroyOnLoad(gameObject);

    }   // The code above creates an instance of the AudioManager class if it does not exist, and destroys whatever this object is to enforce the singleton.

    void Update()
    {
        if (Input.acceleration.magnitude > threshold)
        {
            Debug.Log("PlayTest aktiveret");
            if (trigger == false)
            {
                trigger = true;
                AudioListener.pause = true;
                AudioListener.volume = 0;

                Invoke("TurnUpVolume", snoozeTime);
            }
        }

        else if (trigger == true)
        {
            trigger = false;
        }

    }
    void TurnUpVolume()
    {
        AudioListener.pause = false;
        AudioListener.volume = 1;
    }
}