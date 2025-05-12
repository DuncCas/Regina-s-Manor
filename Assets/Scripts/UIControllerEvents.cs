using System;
using UnityEngine;

public class UIControllerEvents
{
    public Action onEnableSubmit;
    public Action onDisableSubmit;

    public void EnableSubmit()
    {
        onEnableSubmit.Invoke();
    }

    public void DisableSubmit()
    {
        onDisableSubmit.Invoke();
    }


}
