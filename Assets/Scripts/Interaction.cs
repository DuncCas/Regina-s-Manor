using System;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Transform interactionPromptPos;
    public Vector3 offsetPrompt;


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
        Debug.Log("Mi guarda");
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
