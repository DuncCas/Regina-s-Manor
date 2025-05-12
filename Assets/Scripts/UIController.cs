using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    Player player;
    PlayerInputSystem playerInputSystem;
    bool canSubmit=true;


    private void Awake()
    {
        playerInputSystem = new PlayerInputSystem();
        player = GetComponent<Player>();
    }

    private void Start()
    {
        playerInputSystem.UI.Submit.performed += ctx => Submit(ctx);
    }

    private void Submit(InputAction.CallbackContext ctx)
    {
        if (canSubmit)
        {
            GameManager.instance.dialogueEvents.SubmitPressed();
        }
        else
        {
            Debug.Log("Fuckno");
        }
    }

    private void EnableSubmit()
    {
        canSubmit = true;
    }

    private void DisableSubmit()
    {
        canSubmit = false;
    }

    private void OnEnable()
    {

        playerInputSystem.UI.Enable();
        GameManager.instance.UIControllerEvents.onEnableSubmit += EnableSubmit;
        GameManager.instance.UIControllerEvents.onDisableSubmit += DisableSubmit;
    }

    private void OnDisable()
    {
        playerInputSystem.UI.Disable();
        GameManager.instance.UIControllerEvents.onEnableSubmit -= EnableSubmit;
        GameManager.instance.UIControllerEvents.onDisableSubmit -= DisableSubmit;
    }
}
