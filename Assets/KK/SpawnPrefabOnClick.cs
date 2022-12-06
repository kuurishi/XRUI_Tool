// Written by Kristina Koseva, 18.11.2022 //
// "Concept & Development of an XR Interface Prototyping Tool" //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;

public class SpawnPrefabOnClick : MonoBehaviour
{
    
    public static List<GameObject> spawnedObjectList; 

    public GameObject spawnableNameCard; //kinematic object, child of parent
    public GameObject spawnableCurvedInteractive;
    public GameObject spawnableScrollCanvas;

    public GameObject spawnableCube; //gravity objects
    public GameObject spawnableTriangle;
    public GameObject spawnableSphere;

    public Transform spawnPlaceGravity;
    public Transform spawnPlaceKinematic; //parent


    void Start()
    {
        spawnedObjectList = new List<GameObject>();
    }

    void Update()
    {

    }

    public void DeactivateGrabbable() //call this function when player presses the Wire button from main menu
    {
        foreach (GameObject gameObj in spawnedObjectList)
        {
            //if there is grabbable
            //gameObj.GetComponent<Grabbable>().enabled = false;
            //else ?

            //gameObj.GetComponent<HandGrabInteractable>().enabled = false;
            // ???????

        }
    }

    // Kinematic Objects Spawn place is next to the wristband
    public void SpawnNameCard()
    {
        GameObject spawnedNameCard = Instantiate(spawnableNameCard, spawnPlaceKinematic);

        spawnedObjectList.Add(spawnedNameCard);

        //help:  when spawned kinematic obj, it should stay parented to the hand until we move it physically. 

        //sets no parent upon movement so it doesnt follow the hand constantly
        if (spawnedNameCard.transform.hasChanged);
        {
            spawnedNameCard.transform.SetParent(null);

        }
    }

    public void SpawnCurvedInteractive()
    {
        GameObject spawnedCurvedInteractive = Instantiate(spawnableCurvedInteractive, spawnPlaceKinematic);

        spawnedObjectList.Add(spawnedCurvedInteractive);

        //sets no parent upon movement so it doesnt follow the hand constantly
        if (spawnedCurvedInteractive.transform.hasChanged)
        {
            spawnedCurvedInteractive.transform.SetParent(null);

        }

    }

    public void SpawnScrollCanvas()
    {
        GameObject spawnedScrollCanvas = Instantiate(spawnableScrollCanvas, spawnPlaceKinematic);

        spawnedObjectList.Add(spawnedScrollCanvas);

        if (spawnedScrollCanvas.transform.hasChanged)
        {
            spawnedScrollCanvas.transform.SetParent(null);
        }
    }


    //----------------------------------------------------------------------------------------//

    // Gravity Objects Spawn place is on the table
    public void SpawnCube()
    {
        GameObject spawnedObject = Instantiate(spawnableCube, spawnPlaceGravity);
    }

    public void SpawnTriangle()
    {
        GameObject spawnedObject = Instantiate(spawnableTriangle, spawnPlaceGravity);
    }

    public void SpawnSphere()
    {
        GameObject spawnedObject = Instantiate(spawnableSphere, spawnPlaceGravity);
    }

}
