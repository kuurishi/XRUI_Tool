// Written by Kristina Koseva, 18.11.2022 //
// "Concept & Development of an XR Interface Prototyping Tool" //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{

    /*
    public GameObject spawnableNameCard; //kinematic object, child of parent
    public GameObject spawnableCurvedInteractive;
    public GameObject spawnableScrollCanvas;

    public GameObject spawnableCube; //gravity objects
    public GameObject spawnableTriangle;
    public GameObject spawnableSphere;

    public Transform spawnPlaceGravity;
    */

    public List<Sprite> buttonImageList;

    public List<GameObject> spawnedObjectList;
    public Transform spawnPlaceKinematic; //parent


    [SerializeField]
    public List<GameObject> spawnableList; //with buttons that upon click spawn what i want them to spawn
    public GameObject spawnButton; //base prefab
    public Transform buttonParent; //parent where spawnable buttons should spawn (child to Panel_Components)

    public WireManager wireManager;
    public WireInput wireInput;

    void Start()
    {
        spawnedObjectList = new List<GameObject>();

        PopulateSpawnableList();

    }


    public void PopulateSpawnableList()
    {

        foreach (GameObject spawnableObject in spawnableList)
        {
            GameObject button = GameObject.Instantiate(spawnButton, buttonParent);
            button.GetComponentInChildren<Image>().overrideSprite = buttonImageList[spawnableList.IndexOf(spawnableObject)];
            button.GetComponent<SpawnerButton>().SetParameters(spawnPlaceKinematic, spawnableObject, spawnedObjectList);
        }


    }

    public void DeactivateGrabbable(bool isGrabbable) //call this function when player presses the Wire button from main menu
    {
        foreach (GameObject gameObj in spawnedObjectList)
        {
            //gameObj.GetComponent<Grabbable>().enabled = false; //disabling this doesnt do anything
            

            if (gameObj.GetComponentInChildren<HandGrabInteractable>() != null)
            {
                gameObj.GetComponentInChildren<HandGrabInteractable>().enabled = isGrabbable;
            }


        }
    }



    /*
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
    */

}
