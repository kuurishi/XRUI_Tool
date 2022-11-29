using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabOnClick : MonoBehaviour
{
    
    public List<GameObject> spawnableObjects; //id like to make this easier. scriptable object list?

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
        
    }

    void Update()
    {

    }



    // Kinematic Objects Spawn place is next to the wristband
    public void SpawnNameCard()
    {
        GameObject spawnedNameCard = Instantiate(spawnableNameCard, spawnPlaceKinematic);

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

        //help:  when spawned kinematic obj, it should stay parented to the hand until we move it physically. 

        //sets no parent upon movement so it doesnt follow the hand constantly
        if (spawnedCurvedInteractive.transform.hasChanged)
        {
            spawnedCurvedInteractive.transform.SetParent(null);

        }

    }

    public void SpawnScrollCanvas()
    {
        GameObject spawnedScrollCanvas = Instantiate(spawnableScrollCanvas, spawnPlaceKinematic);

        if(spawnedScrollCanvas.transform.hasChanged)
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
