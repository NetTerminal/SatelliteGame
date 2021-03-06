﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    GameManager gameManager;
    Cutoff cutoff;

    internal bool isHome;
    internal bool shellUp;
    internal bool isTravelling;
    internal bool isOrbiting;
    internal bool isInteracting;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

	void Update ()
    {
        if (gameManager.mainCamera.GetComponent<TargetedLerp>().isLerping == true)
        {
            isTravelling = true;
        }
        else
        {
            isTravelling = false;
        }

        if (gameManager.mainCamera.transform.position == new Vector3(0, 0, 0))
        {
            isHome = true;
            gameManager.lastDestination = null;
        }

        else
        {
            isHome = false;
        }
    }

    void stateDebug()
    {
        if (isHome == true)
        {
            Debug.Log("Player is Home");
        }

        if (isTravelling == true)
        {
            Debug.Log("Player is Travelling");
        }

        if (isOrbiting == true)
        {
            Debug.Log("Player is Orbiting");
        }
    }
}
