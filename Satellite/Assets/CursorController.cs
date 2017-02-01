﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public GameObject cross;
    public GameObject ring;

    GameObject lerpObject;


    Vector3 startPos;
    Vector3 targetPos;
    float timeStartedLerping;
    float travelTime;
    bool isLerping = false;

    GameManager gameManager;
    StateManager stateManager;

    void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
        stateManager = FindObjectOfType<StateManager>();
    }

    void FixedUpdate()
    {
        if (isLerping)
        {
            float timeSinceStarted = Time.time - timeStartedLerping;
            float percentageComplete = timeSinceStarted / travelTime;

            if (gameManager.currentFocus != null && gameManager.currentFocus.transform.position != gameManager.mainCamera.transform.position)
            {
                LerpUI(cross, gameManager.focusScreenPos, 0.2f);
            }
            else if (isLerping == false && gameManager.currentFocus == null)
            {
                LerpUI(cross, gameManager.screenCenter, 0.2f);
            }

            lerpObject.transform.position = Vector3.Lerp(startPos, targetPos,Mathf.Pow(percentageComplete, 2));

            if (percentageComplete >= 1)
            {
                isLerping = false;
            }
        }
    }

    void LerpUI(GameObject element, Vector3 focus, float tTime)
    {
        if (isLerping == false)
        {
            isLerping = true;
            lerpObject = element;
            startPos = element.transform.position;
            timeStartedLerping = Time.time;         
            travelTime = tTime;
            targetPos = focus;
        }
    }

}