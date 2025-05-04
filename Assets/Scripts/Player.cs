using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]
    Interaction currentInteraction;
    [SerializeField]
    List<Interaction> currentCloseInteractions = new List<Interaction>();

    [SerializeField]
    bool isInteracting= false;


    public GameObject ObjectPlayerLookingAt
    {
        get
        {
            if (currentInteraction)
                return currentInteraction.gameObject;
            else return null;
        }
    }

    public Interaction CurrentPlayerInteraction 
    {
        get
        {
            return currentInteraction;
        }
        set
        {
            currentInteraction = value;
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

                currentInteraction = newInteraction;
                //QUI TRIGGERARE LA UI DELL'INTERAZIONE COL BOTTONE E TESTO
                GameManager.instance.ShowInteractionPrompt(currentInteraction, newInteraction.interactionPromptPos, newInteraction.offsetPrompt);
            }
        }
    }

    public void OnEndInteraction(Interaction oldInteraction)
    {
        if (currentCloseInteractions.Contains(oldInteraction))
        {
            currentCloseInteractions.Remove(oldInteraction);
            if (oldInteraction == currentInteraction)
            {
                currentInteraction = null;
                if (currentCloseInteractions.Count <= 0)
                {
                    GameManager.instance.HideInteractionPrompt();
                }
                else
                {
                    Interaction nextInter = currentCloseInteractions[0];
                    GameManager.instance.ShowInteractionPrompt(nextInter, nextInter.interactionPromptPos, nextInter.offsetPrompt);
                }
            }
        }
    }


    public void Interact()
    {
        if (currentInteraction)
        {
            isInteracting = true;
            currentInteraction.OnPlayerStartInteracting();
        }
    }


}
