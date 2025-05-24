using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class DialogueBoxManager : MonoBehaviour
{
    public TextMeshProUGUI interactionNameText;
    public Image speakerImage;
    public TextMeshProUGUI dialogueText;
    public ChoiceButton[] choiceButtons = new ChoiceButton[3];
    PlayerInputSystem inputSystem;

    private void Awake()
    {
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].SetUpIndexes(i);
        }
    }

    public void SetUpDialogueBox(string dialogue, string name="", Sprite speakerImage=null, List<Choice> choices=null)
    {
       SetUpName(name);
       SetUpDialogue(dialogue);
        if (speakerImage != null ) SetUpImage(speakerImage);
        if (choices.Count > 0)
        {
            Debug.Log("Disabilita");
            GameManager.instance.UIControllerEvents.DisableSubmit();
            SetUpChoices(choices);
        }
        
       
    }

    private void SetUpChoices(List<Choice> choices)
    {
    
        int totChoices= choices.Count;
        for (int i = 0; i < totChoices; i++)
        {
            Choice choice = choices[i];
            Debug.Log(choice.text);
            choiceButtons[i].SetUpChoice(choice.text);
            choiceButtons[i].SetUpIndexes(i);
            choiceButtons[i].gameObject.SetActive(true);
            if (i == 0)
            {
                //choiceButtons[i].GetComponent<Button>().sel;
                //GameManager.instance.dialogueEvents.UpdateChoiceIndex(0);
            }
        }
    }

    private void SetUpName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            //RIMUOVERE IMMAGINE CON SEZIONE NOME
        }
        else
        {
            string currentName = interactionNameText.text;
            if (name != currentName)
            {
                interactionNameText.text = name;
            }
        }
        
    }

    private void SetUpDialogue(string dialogue)
    {
        string currentDialogue = dialogueText.text;
        if (dialogue != currentDialogue)
        {
            dialogueText.text = dialogue;
        }
    }

    private void SetUpImage(Sprite speakerImage)
    {
        if (speakerImage)
        {
            Sprite currentImage = this.speakerImage.sprite;
            if (currentImage != null || currentImage != speakerImage)
            {
                this.speakerImage.sprite = speakerImage;
            }
        }
        else
        {
            this.speakerImage.sprite = null;
            this.speakerImage.gameObject.SetActive(false);
        }
        

    }


    public void ClearChoices()
    {
       foreach(ChoiceButton choice in choiceButtons)
        {
            choice.ClearAndHide();
        }
    }



}
