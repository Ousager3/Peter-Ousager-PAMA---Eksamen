using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
// The code starts with the class declaration.
public class MyTabs : MonoBehaviour
{
    // It requires a component of type Button, and it has two variables tabbutton1 and tabcontent2.
    public GameObject tabbutton1;
    public GameObject tabbutton2;
  
    public GameObject tabcontent1;
    public GameObject tabcontent2;
   
    // The Start() function is called when the game starts, so this function will be executed once per frame.
    void Start()
    {
    }
    // The Update() function is called every time the game updates (every frame).
    // This function does not need to be explicitly called because it's automatically invoked by Unity whenever something in the scene changes or needs to update its state.
    void Update()
    {
    }
    // The HideAllTabs() method hides all tabs except for one that we specify as active using SetActive().
    public void HideAllTabs()
    {
        // gør alle tabcontens inactive
        tabcontent1.SetActive(true);
        tabcontent2.SetActive(false);


        //skifter farven på de inactive Tabbuutons når de er inactive.
        tabbutton1.GetComponent<Button>().image.color = new Color32(128, 213, 244, 150);
        tabbutton2.GetComponent<Button>().image.color = new Color32(128, 213, 244, 150);

    }
    // We then change the image color of both buttons to a specific color using GetComponent().image.color = new Color32(128, 213, 244, 150)
    // and GetComponent().image.color = new Color32(128, 213, 244, 255), respectively.
    public void ShowTab1()
    {
        // activer tabcontent 1 og higlighter farven
        HideAllTabs();
        tabcontent1.SetActive(true);
        tabbutton1.GetComponent<Button>().image.color = new Color32(128, 213, 244, 255);

    }
    // The code is a simple example of how to use the Button component in order to create two buttons
    // and then have them change their colors based on which tab is active.
    public void ShowTab2()
    {
        // activer tabcontent 2 og higlighter farven
        HideAllTabs();
        tabcontent2.SetActive(true);
        tabbutton2.GetComponent<Button>().image.color = new Color32(128, 213, 244, 255);

    }


    //en funktion der gør at hver gang man trykker på dem slår de bool værdien
    //tab1 til eller fra tab 1 skal sættte

}
