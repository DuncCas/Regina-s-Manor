using Ink.Parsed;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public string interactionName;
    public Transform interactionPromptPos;
    public Vector3 offsetPrompt;
    public List<string> listOfKnotsNames;
    public Sprite interactionImage;


    bool playerLookingAtMe = false;

    private void Awake()
    {

    }


    public bool PlayerIsLookingMe
    {
        get { return playerLookingAtMe; }
        set { playerLookingAtMe = value; }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayerStartInteracting()
    {
        GameManager.instance.dialogueEvents.EnterDialogue(listOfKnotsNames[0], this);
    }


    public void OnPlayerStopInteracting()
    {
        Debug.Log("Non mi guarda");
    }

    public void OnStartInteraction()
    {

    }


    public void OnEndInteraction()
    {

    }



}
