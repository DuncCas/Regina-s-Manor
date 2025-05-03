using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Interaction currentPlayerLooking;
    [SerializeField]
    List<Interaction> currentCloseInteractions = new List<Interaction>();

    [SerializeField]
    bool isPlayerTalking= false;


    public GameObject ObjectPlayerLookingAt
    {
        get
        {
            if (currentPlayerLooking)
                return currentPlayerLooking.gameObject;
            else return null;
        }
    }

    public Interaction CurrentPlayerInteraction 
    {
        get
        {
            return currentPlayerLooking;
        }
        set
        {
            currentPlayerLooking = value;
        }
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnNewInteraction(Interaction newInteraction)
    {
        if (!currentCloseInteractions.Contains(newInteraction))
        {
            currentCloseInteractions.Add(newInteraction);
            if (currentCloseInteractions.Count == 1)
            {
                currentPlayerLooking = newInteraction;
                newInteraction.OnPlayerLooking();
                //QUI TRIGGERARE LA UI DELL'INTERAZIONE COL BOTTONE E TESTO
            }
        }
    }

    public void OnEndInteraction(Interaction oldInteraction)
    {
        if (currentCloseInteractions.Contains(oldInteraction))
        {
            currentCloseInteractions.Remove(oldInteraction);
            if (oldInteraction == currentPlayerLooking)
            {
                currentPlayerLooking = null;
                oldInteraction.OnPlayerStopLooking();
                //QUI TRIGGERARE LA UI DA TOGLIERE
            }
        }
    }

}
