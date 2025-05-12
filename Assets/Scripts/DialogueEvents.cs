using UnityEngine;
using System;
using Ink.Runtime;
using System.Collections.Generic;

public class DialogueEvents
{
    public event Action<string, Interaction, List<Choice>> onEnterDialogue;
    public event Action onExitDialogue;
    public event Action onSubmitPressed;
    public event Action<int> onUpdateChoiceIndex;

    public void EnterDialogue(string knotName, Interaction interact = null, List<Choice> dialogueChoices=null)
    {
        onEnterDialogue?.Invoke(knotName, interact, dialogueChoices); //? controlla se è nullo o no

    }


    public void SubmitPressed()
    {
        onSubmitPressed?.Invoke(); //? controlla se è nullo o no


    }



    public void UpdateChoiceIndex(int index)
    {
        onUpdateChoiceIndex?.Invoke(index);
    }

    public void ExitDialogue()
    {
        onExitDialogue?.Invoke();
    }



}
