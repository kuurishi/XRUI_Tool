// Written by Kristina Koseva, 12.12.2022 //
// "Concept & Development of an XR Interface Prototyping Tool" //

// TLDR': the script allows me to easily change up the menu buttons and their content from the inspector.

// This script is attatched to the SpawnButton game object that we use in SpawnerManager. 

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerButton : MonoBehaviour
{

    private Transform spawnPoint;
    private GameObject objectToSpawn;
    private List<GameObject> spawnedObjects;


    public void SpawnObject()
    {
        GameObject spawnedNameCard = Instantiate(objectToSpawn, spawnPoint);

        spawnedObjects.Add(spawnedNameCard);

        //help:  when spawned kinematic obj, it should stay parented to the hand until we move it physically. 

        //sets no parent upon movement so it doesnt follow the hand constantly
        if (spawnedNameCard.transform.hasChanged)
        {
            spawnedNameCard.transform.SetParent(null);

        }
    }

    public void SetParameters(Transform _spawnPoint, GameObject _objectToSpawn, List<GameObject> _spawnedObjects)
    {
        spawnPoint = _spawnPoint;
        objectToSpawn = _objectToSpawn;
        spawnedObjects = _spawnedObjects;
    }


}
