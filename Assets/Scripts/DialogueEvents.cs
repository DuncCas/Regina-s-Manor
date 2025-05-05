using UnityEngine;
using System;

public class DialogueEvents
{
    public event Action<string> OnEnterDialogue;

    public void EnterDialogue(string knotName)
    {
        OnEnterDialogue?.Invoke(knotName); //? controlla se è nullo o no

    }

}
