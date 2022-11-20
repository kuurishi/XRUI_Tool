using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristbandManager : MonoBehaviour
{

    public GameObject userCamera;
    public GameObject userWristbandHand;
    public GameObject wristbandMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Vector3.Angle(userCamera.transform.forward, -userWristbandHand.transform.up);

        if (angle > 90)
        {
            wristbandMenu.SetActive(false);
        }
        else wristbandMenu.SetActive(true);
    }


}
