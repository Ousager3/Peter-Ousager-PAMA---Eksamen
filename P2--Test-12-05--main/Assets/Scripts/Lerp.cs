using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lerp : MonoBehaviour
{                                     
    public float endY;  // final position of the objects               
    public float speed; // how fast it arrives to destination         
    public int spacing; // space between objects            

    public void StartLerp()           
    {                              
        StartCoroutine(LerpPusher()); // loops forever, move to destination defined by endY and spacing
    }                                 

    IEnumerator LerpPusher()          // will repeat through the list of objects in interface and move them towards end position bassed on speed 
    {                                
        endY = transform.position.y - spacing;                  // will loop until difference between endY and t.p.y is less than 0.1f
        while (Mathf.Abs(endY - transform.position.y) > 0.1f)

        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, endY, transform.position.z), speed * Time.deltaTime); 
            yield return null;
        }
    }
}