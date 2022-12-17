using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public List<GameObject> popUps = new List<GameObject>();
    public int popUpIndex = 0;
    public GameObject popupSpawner; //public Transform instead?

    public GameObject checkmarkImg;
    public GameObject nextButton;
    public GameObject backButton;

    public Vector3 handStartPos = new Vector3();

    public GameObject wristbandMenuHand;
    WristbandManager wristbandManager;
    public SpawnManager spawnManager;

    public bool hasScaled = false;


    private void Start()
    {
        
        handStartPos = wristbandMenuHand.transform.position;
        SetPanelbyIndex(popUpIndex);


    }


    private void Update()
    {
        if (popUpIndex == 0)
        {
            nextButton.SetActive(true);
        }

        //task is complete if:  1st page is active && if user looked at their wristband menu
        if (popUpIndex == 1 && wristbandMenuHand.activeInHierarchy && handStartPos != wristbandMenuHand.transform.position) 
        {
            checkmarkImg.SetActive(true);
            nextButton.SetActive(true);
        }

        //task is complete if:  2nd page is active && if the user spawned more than 1 objects
        else if (popUpIndex == 2) //tut2 shows: spawn 2 objects
        {
            if (spawnManager.spawnedObjectList.Count > 1)
            {
                checkmarkImg.SetActive(true);
                nextButton.SetActive(true);
                backButton.SetActive(true);

                StartCoroutine(hasBeenScaled());
                //Debug.Log("COROUTINE STARTED AAAAAAAAAAAAAA");
            }
        }

        //task is complete if:  3rd page is active && if the user scaled one of the objects
        else if (popUpIndex == 3) //tut3 shows: spawn 2 objects
        {
            backButton.SetActive(true);

            if (hasScaled == true)
            {
                checkmarkImg.SetActive(true);
                nextButton.SetActive(true);

            }

        }


    }


    private void SetPanelbyIndex(int inputIndex)
    {
        foreach (GameObject obj in popUps)
        {
            if (popUps.IndexOf(obj) == inputIndex)
            {
                obj.gameObject.SetActive(true);
            }
            else
            {
                obj.gameObject.SetActive(false);
            }
        }
    }


    public void SetIndex() //call this function in the button on the tutorial to go onto next page
    {
        
        checkmarkImg.SetActive(false);
        nextButton.SetActive(false);
        popUpIndex++;
        SetPanelbyIndex(popUpIndex);

    }

    public void SetBackIndex() //call this function in the button on the tutorial to go onto previous page
    {
        if(popUpIndex > 0)
        {
            checkmarkImg.SetActive(false);
            nextButton.SetActive(false);
            popUpIndex--;
            SetPanelbyIndex(popUpIndex);
        }
        

    }


    //used for Tutorial index 2 to check if the user scaled an object successfully
    IEnumerator hasBeenScaled()
    {
        while (hasScaled == false)
        {
            Debug.Log("SCALED OBJECT AAAAAAAAAAAAAAAAAA");
            foreach (GameObject gameObj in spawnManager.spawnedObjectList)
            {

                if (gameObj.transform.localScale.x > 1)
                {
                    hasScaled = true;
                    // Debug.Log("SCALED OBJECT AAAAAAAAAAAAAAAAAA");
                }

            }
            yield return new WaitForSeconds(1f);
        }
        
    }


}
