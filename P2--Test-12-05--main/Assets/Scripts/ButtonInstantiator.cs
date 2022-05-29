using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonInstantiator : MonoBehaviour //  This is the class that will be instantiating buttons in the scene.
{
    public GameObject canvas; // The canvas variable is used to store the GameObject that this script will be attached to, while button stores an array of GameObjects that are being instantiated by this script.
    public GameObject[] button;

    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait; // StartWait starts at 0 seconds and decreases by 1 second every time Update() runs until it reaches 5 seconds (startLeastWait).
    public bool stop; // Stop sets whether or not to stop spawning new buttons when CloseAndStart() executes; if true then CloseAndStart() will execute without spawning any more buttons.

    int randomButton; // RandomButton ranges from 0 to 5; this value determines what index number in button corresponds to each button instance spawned into the scene.

    void Start()
    {
        //StartCoroutine(WaitSpawner());
    }
    
    public void CloseAndStart()
    {
        StopCoroutine(WaitSpawner());
        StartCoroutine(WaitSpawner());
    }

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }
    void lerpPusher()
    {
        
    }

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randomButton = Random.Range(0, 5);

            GameObject newButton = Instantiate(button[randomButton]) as GameObject; // Instantiate creates a new instance of a given object based on its position in the array passed as parameter - here we use this method to create instances for all but one element in our list of elements passed as parameter (button) because we want only one instance per button created
            newButton.transform.SetParent(canvas.transform, false);
            Component[] allExisitingButtons = canvas.GetComponentsInChildren<Lerp>();
            foreach (Lerp lerp in allExisitingButtons)
            {
                if (lerp.gameObject != newButton)
                {
                    lerp.StartLerp();
                }
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }
}

