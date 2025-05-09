using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class DialogueBoxManager : MonoBehaviour
{
    public TextMeshProUGUI interactionNameText;
    public Image speakerImage;
    public TextMeshProUGUI dialogueText;



    public void SetUpDialogueBox(string dialogue, string name="", Sprite speakerImage=null)
    {
       SetUpName(name);
       SetUpDialogue(dialogue);
        if (speakerImage != null ) SetUpImage(speakerImage);
       
    }

    private void SetUpName(string name)
    {
        string currentName = interactionNameText.text;
        if (name != currentName)
        {
            interactionNameText.text = name;
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
        Sprite currentImage = this.speakerImage.sprite;
        if (currentImage!= null || currentImage != speakerImage)
        {
            this.speakerImage.sprite = speakerImage;
        }

    }


}
