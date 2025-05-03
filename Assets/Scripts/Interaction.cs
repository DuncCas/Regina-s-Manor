using System;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    [SerializeField]
    SphereCollider interactionCollider;

    bool playerLookingAtMe = false;

    private void Awake()
    {
        interactionCollider= GetComponent<SphereCollider>();
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

    public void OnPlayerLooking()
    {
        Debug.Log("Mi guarda");
    }


    public void OnPlayerStopLooking()
    {
        Debug.Log("Non mi guarda");
    }
}
