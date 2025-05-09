using Ink.Runtime;
using System;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset inkJson;



    private Story story;



    private bool inDialogue = false;
    public DialogueBoxManager dialogueBox;

    private void Awake()
    {
        story = new Story(inkJson.text);
    }


    private void OnEnable()
    {
        GameManager.instance.dialogueEvents.OnEnterDialogue += EnterDialogue;
    }

    private void OnDisable()
    {
        GameManager.instance.dialogueEvents.OnEnterDialogue -= EnterDialogue;
    }



    public void EnterDialogue(string knotName, Interaction inter=null)
    {
        if (inDialogue)
        {
            return;
        }
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
        ConinueOrExitStory(inter);
    }

    private void ConinueOrExitStory(Interaction inter)
    {
        if (story.canContinue)
        {
            string dialogueLine = story.Continue();
            if (inter)
            {
            dialogueBox.SetUpDialogueBox(dialogueLine, inter.interactionName, inter.interactionImage);

            }
            else
            {
                dialogueBox.SetUpDialogueBox(dialogueLine);
            }
        }
        else
        {
            ExitDialogue();
        }
    }

    public void ExitDialogue()
    {
        Debug.Log("Exiting Dialogue");
        inDialogue=false;
        dialogueBox.gameObject.SetActive(false);
        story.ResetState();
    }
}
