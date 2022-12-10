// 10.12.2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateManager : MonoBehaviour
{
    public enum appState { PARTS, WIRE, PLAY };
    public appState currentState = appState.PARTS;

    public WireManager wireManager;
    public SpawnManager spawnManager;
    bool deactivatedPrefabs;


    void Update()
    {
        switch (currentState)
        {
            case appState.PARTS:
                //only enables wire & play when there's minimum 2 spawned objects
                if (deactivatedPrefabs)
                {
                    spawnManager.DeactivateGrabbable(true);
                }
                return;


            case appState.WIRE:
                if (!deactivatedPrefabs)
                {
                    spawnManager.DeactivateGrabbable(false);
                    deactivatedPrefabs = true;
                }
                wireManager.UpdateWireState();

                return;


            case appState.PLAY:
                if (!deactivatedPrefabs)
                {
                    spawnManager.DeactivateGrabbable(false);
                    deactivatedPrefabs = true;
                }
                return;
        }
        
    }


    public void SetPartsState()
    {
        currentState = appState.PARTS;
    }

    public void SetWireState()
    {
        currentState = appState.WIRE;
    }

    public void SetPlayState()
    {
        currentState = appState.PLAY;
    }

}
