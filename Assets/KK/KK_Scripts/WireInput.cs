// Written by Kristina Koseva, 19.12.2022 //
// "Concept & Development of an XR Interface Prototyping Tool" //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this script gets assigned by the WireManager to the startObject on a created wire
public class WireInput : MonoBehaviour
{
    
    WireManager wireManager;
    public GameObject endObjectReference;



    //when the first connected obj(with a button component) is pressed in Play Mode, toggle SetActive on the 2nd connected obj
    public void EnableOther()
    {
        //Debug.Log(endObjectReference + "AAAAAAAAAAAAAAAAAAAAAAAAAA");
        endObjectReference.SetActive(!endObjectReference.activeSelf);
        

    }




}
