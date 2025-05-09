using UnityEngine;
using System;

public class DialogueEvents
{
    public event Action<string, Interaction> OnEnterDialogue;

    public void EnterDialogue(string knotName, Interaction interact = null)
    {
        OnEnterDialogue?.Invoke(knotName, interact); //? controlla se è nullo o no

    }

}
