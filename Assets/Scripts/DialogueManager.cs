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
    public Image dialogueBox;
    public TextMeshProUGUI text;

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



    public void EnterDialogue(string knotName)
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
        ConinueOrExitStory();
    }

    private void ConinueOrExitStory()
    {
        if (story.canContinue)
        {
            text.text = "";
            string dialogueLine = story.Continue();
            text.text = dialogueLine;
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
