using Ink.Runtime;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset inkJson;

    Interaction currentInteraction;

    int currentChoiceIndex = -1;

    private Story story;



    private bool inDialogue = false;
    public DialogueBoxManager dialogueBox;

    private void Awake()
    {
        story = new Story(inkJson.text);
    }


    private void OnEnable()
    {
        GameManager.instance.dialogueEvents.onEnterDialogue += EnterDialogue;
        GameManager.instance.dialogueEvents.onSubmitPressed += SubmitPressed;
        GameManager.instance.dialogueEvents.onUpdateChoiceIndex += UpdateChoiceIndex;
        GameManager.instance.dialogueEvents.onExitDialogue += ExitDialogue;
    }



    private void OnDisable()
    {
        GameManager.instance.dialogueEvents.onEnterDialogue -= EnterDialogue;
        GameManager.instance.dialogueEvents.onSubmitPressed -= SubmitPressed;
        GameManager.instance.dialogueEvents.onUpdateChoiceIndex -= UpdateChoiceIndex;
        GameManager.instance.dialogueEvents.onExitDialogue -= ExitDialogue;
    }

    private void UpdateChoiceIndex(int index)
    {
        Debug.Log("updated");
        currentChoiceIndex = index;

    }

    public void EnterDialogue(string knotName, Interaction inter=null, List<Choice> choices = null)
    {
        if (inDialogue)
        {
            return;
        }
        currentInteraction = inter;
        inDialogue = true;
        dialogueBox.gameObject.SetActive(true);
        Debug.Log("Entering dialogue called: " + knotName);

        if (!knotName.Equals(""))
        {
            story.ChoosePathString(knotName);
        }
        else
        {
            Debug.LogWarning("Knot name is null or empty!");
        }
        ContinueOrExitStory();

    }

    private void ContinueOrExitStory()
    {
        dialogueBox.ClearChoices();
        if (story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {
            story.ChooseChoiceIndex(currentChoiceIndex);
            currentChoiceIndex = -1;
            Debug.Log(currentChoiceIndex);
        }
        if (story.canContinue)
        {

            string dialogueLine = story.Continue();

            while (string.IsNullOrEmpty(dialogueLine) && story.canContinue )
            {
                dialogueLine = story.Continue();
            }
            // handle the case where the last line of dialogue is blank
            // (empty choice, external function, etc...)
            if (string.IsNullOrEmpty(dialogueLine) && !story.canContinue)
            {
                ExitDialogue();
            }
            else
            {
                Debug.Log(story.currentChoices);
            dialogueBox.SetUpDialogueBox(dialogueLine, currentInteraction?.interactionName, currentInteraction?.interactionImage, story.currentChoices);
                if (story.currentChoices.Count > 0)
                {
                    GameManager.instance.UIControllerEvents.DisableSubmit();
                }
            }

        }
        else if (story.currentChoices.Count==0) 
        {
            ExitDialogue();
        }
    }

    private void SubmitPressed()
    {
        if (!inDialogue)
        {
            return;
        }



        ContinueOrExitStory();
    }

    public void ExitDialogue()
    {
        Debug.Log("Exiting Dialogue");
        inDialogue=false;
        dialogueBox.gameObject.SetActive(false);
        story.ResetState();
        GameManager.instance.playerControllerEvents.StartMovement();
    }
}
