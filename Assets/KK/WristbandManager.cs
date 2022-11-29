using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristbandManager : MonoBehaviour
{

    public GameObject userCamera;
    public GameObject userWristbandHand;
    public GameObject wristbandMenu;

    public GameObject panelMain;
    public GameObject panelComponents;
    public GameObject panelWire;
    public GameObject panelPreview;

    public GameObject lastPanelOpen;

    private void Start()
    {
        lastPanelOpen = panelMain;
    }
    void Update()
    {
        float angle = Vector3.Angle(userCamera.transform.forward, -userWristbandHand.transform.up);

        if (angle > 90)
        {
            wristbandMenu.SetActive(false);
        }
        else wristbandMenu.SetActive(true);
    }


    public void OpenComponentsPanel()
    {
        NextPanel(panelComponents);
    }

    public void OpenWirePanel()
    {
        NextPanel(panelWire);
    }

    public void OpenPreviewPanel()
    {
        NextPanel(panelPreview);
    }


    public void OpenMainPanel()
    {
        NextPanel(panelMain); //close whichever panel is active when we want to go back
    }

    public void NextPanel(GameObject panel)
    {
        lastPanelOpen.SetActive(false);
        panel.SetActive(true);
        lastPanelOpen = panel;
    }

}
