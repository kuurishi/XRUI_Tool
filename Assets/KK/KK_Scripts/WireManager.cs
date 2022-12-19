// Written by Kristina Koseva, 30.11.2022 & 05.12.2022 //
// "Concept & Development of an XR Interface Prototyping Tool" //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Oculus.Interaction;


public class WireManager : MonoBehaviour
{

    #region attributes    

    public OVRHand hand;
    bool isIndexFingerPinching;

    //-----------creates the wire:------------//
    
    private Vector3 startPoint; 
    public GameObject startObject; //sets the first selected object as start object && startPoint of the wire
    public bool isStartObjectSet = false;

    private Vector3 handPoint; //always sets end pos to hand pos when startPoint is first created

    private Vector3 endPoint; //can set it only when wireStartPoint1 exists and a 2nd object is selected
    public GameObject endObject; //sets the first selected object as start object && startPoint of the wire
    public bool isEndObjectSet = false;

    public GameObject wirePrefab; //add the wire prefab!
    public List<GameObject> createdWires = new List<GameObject>();
    public GameObject currentWire;
    
    //-----------accessed only after wire is created && swiped:------------//

    public bool isWireCreated = false; //used in the tutorial manager too

    #endregion



    #region functions to create a wire

    private void SetPinching() 
    {
        // accesses pinching from OVR scripts
        isIndexFingerPinching = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
    }


    // (rn checks all pinches, later should only check for pinches when Preview mode is active) !!!!!
    public void UpdateWireState()
    {
        SetPinching(); //access pinching from OVR scripts

        //if im pinching && the startObject position is free, populate it and create the startPoint
        if (isIndexFingerPinching == true)
        {
            //Debug.Log("I'm pinching.");

            if (isStartObjectSet == false && startObject != null)
            {
                startPoint = startObject.transform.position;
                isStartObjectSet = true;
                CreateWire(startPoint, startPoint);
                Debug.Log("Start Point SET");
            }
            
        }

        //if im pinching && startPoint is created && endPoint is free, create and populate the endPoint
        if (isStartObjectSet == true && isIndexFingerPinching == true)
        {
            handPoint = hand.transform.position;
            if (currentWire != null) 
            {
                currentWire.GetComponent<LineRenderer>().SetPosition(1, handPoint);
                Debug.Log("Wire-to-Hand is Created");
            }
           
            
        }

        if (isStartObjectSet == true && isIndexFingerPinching == false && endObject != null )
        {
            endPoint = endObject.transform.position;
            isEndObjectSet = true;
            Debug.Log("End Point SET");

        }
            


        //if both start and endPoint are created, Create the Wire and reset the points
        if (isStartObjectSet == true & isEndObjectSet == true)
        {

            if (currentWire != null)
            {

                currentWire.GetComponent<LineRenderer>().SetPosition(1, endPoint);
                createdWires.Add(currentWire);

                currentWire = null;
                Debug.Log("Wire-to-End is Created and added to the list of created wires");

                isWireCreated = true;

                WireInput wireInput = startObject.AddComponent<WireInput>();
                wireInput.endObjectReference = endObject;

                if (startObject.GetComponentInChildren<PointableUnityEventWrapper>() != null)
                {
                    startObject.GetComponentInChildren<PointableUnityEventWrapper>().WhenRelease.AddListener(wireInput.EnableOther);
                }
                else if (startObject.GetComponentInChildren<InteractableUnityEventWrapper>() != null)
                {
                    startObject.GetComponentInChildren<InteractableUnityEventWrapper>().WhenSelect.AddListener(wireInput.EnableOther);
                }

            }
            

            isStartObjectSet = false;
            startObject = null;

            isEndObjectSet = false;
            endObject = null;
        }
        if (currentWire != null && isIndexFingerPinching == false && isStartObjectSet && isEndObjectSet == false && endObject == null )
        {
            
            GameObject.Destroy(currentWire);
            currentWire = null;//destroy object if we release and its not inside an end point;
        }
    }


    // ----------------------------------------------------//
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided on ENTER");

        if (collision.collider.CompareTag("Spawnables"))
        {
            if (isStartObjectSet == false)
            {
                startObject = collision.collider.gameObject;
                Debug.Log("collided enter2");
            }
            if(isEndObjectSet == false && isStartObjectSet == true)
            {
                endObject = collision.collider.gameObject;

            }
    
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collided on EXIT");

        if (collision.collider.CompareTag("Spawnables"))
        {
            if (isStartObjectSet == false)
            {
                startObject = null;
                Debug.Log("collided enter3");
            }
            if (isEndObjectSet == false && isStartObjectSet == true)
            {
                endObject = null;

            }

        }
    }

    

    // ----------------------------------------------------//
    void CreateWire(Vector3 startPoint, Vector3 endPoint)
    {
        // if wire state from hand menu is active
        // && startPoint and endPoint are set, create a wire with index 0 to startPoint, next one to handPos until letgo and index 1 to endPoint when letgo

        GameObject newWire = GameObject.Instantiate(wirePrefab);
        newWire.GetComponent<LineRenderer>().SetPosition(0, startPoint);
        newWire.GetComponent<LineRenderer>().SetPosition(1, endPoint);
        currentWire = newWire;
        isWireCreated = true;
        Debug.Log("Wire Created SUCCESSFULLY");
    }

    #endregion


    #region functions-to-do

    //another scriptfor the wiredropdown?
    void WireDropdown()
    {
        // when wire is created, enable its own dropdown menu when swipe down.
        
        // if(isWireCreated = true && isSwipeTriggered)
        // {
        //     DropdownMenu.SetActive(true);
        // }

        
        //when down, can AddComponent by drag and dropping it from the hand menu in the dropdown collider (its own DropdownMenu script)
        //shows the added component visually

    }


    //only plays the interactions when the runtime "Play/Preview" button is pressed
    // ^ this should be its own script ^


    //create Wire manager and when its done instantiating, then can fiddle with WireDropdown() here
    //how do i know which point is set to which object
    //how do i know which wire is connected to which set of objects

    #endregion

}
