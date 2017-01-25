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

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

	void Start ()
    {
        shellUp = true;
        isHome = false;
        isTravelling = false;
        isOrbiting = false;
    }	

	void Update ()
    {
        if (gameManager.mainCamera.transform.position == new Vector3(0, 0, 0))
        {
            isHome = true;
        }
        else
        {
            isHome = false;
        }
        stateDebug();
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
    
    void HomeState()
    {

    }
}
