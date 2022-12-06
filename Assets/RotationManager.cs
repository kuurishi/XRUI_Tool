// Written by Kristina Koseva, 01.12.2022 //
// "Concept & Development of an XR Interface Prototyping Tool" //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{

    private Vector3 lastEuler;
    public float treshhold;

    private void Start()
    {
        lastEuler = this.transform.eulerAngles;
    }

    void Update()
    {
        float angularMomentum = this.transform.eulerAngles.x - lastEuler.x;
        //Debug.Log(angularMomentum);

        if (Mathf.Abs(angularMomentum) > treshhold)
        {
            if (angularMomentum > 0)
            {
                Debug.Log("+");
            }
            else Debug.Log("-");

        }

        lastEuler = this.transform.eulerAngles;

    }

}
