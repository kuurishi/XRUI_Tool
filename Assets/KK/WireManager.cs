// Written by Kristina Koseva, 30.11.2022 //
// "Concept & Development of an XR Interface Prototyping Tool" //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WireManager : MonoBehaviour
{
    public OVRHand hand;

    private LineRenderer wire; //the wire prefab
    private bool isWireCreated = false; //used to enable wire dropdown

    //public LayerMask whatIsWireable; //only the spawned elements from the "Parts/Components" menu or the available objects with a grabbable script on them
    
    private Vector3 startPoint; //sets the last selected object as wireStartPoint1
    private Vector3 handPoint; //always sets end pos to hand pos when startPoint is first created
    private Vector3 endPoint; //can set it only when wireStartPoint1 exists and a 2nd object is selected

    bool isIndexFingerPinching;


    // access pinching from OVR scripts
    private void SetPinching() 
    {
        isIndexFingerPinching = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
    }


    // check if user is currently pinching
    // (rn checks all pinches, later should only check for pinches when Preview mode is active)
    private void Update()
    {
        SetPinching(); //access pinching

        //set startPoint
        if (isIndexFingerPinching == true)
        {
            Debug.Log("I'm pinching.");
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Spawnables") && isIndexFingerPinching == true)
        {
            startPoint = collision.collider.transform.position;
            Debug.Log("startPoint collided!");

            handPoint = hand.transform.position;
            Debug.Log("endPoint created");

            //endPoint = hand.transform.position;
            Debug.Log("endPoint created");

            CreateWire(startPoint, endPoint);
            Debug.Log("Wire Created Successfully!!");
        }

    }

    void CreateWire(Vector3 startPoint, Vector3 endPoint)
    {
        Debug.Log("wire created");
        //set startPoint
        //if hand is close to spawnedObj AND is pinching true, createWire(thisPos, endPos=handPos)
        

        //set endPoint when  isindexpinching false


        // if wire state from hand menu is active
        // && startPoint and endPoint are set, create a wire with index 0 to startPoint, next one to handPos until letgo and index 1 to endPoint when letgo
        
        isWireCreated = true;
      
    }


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
}
