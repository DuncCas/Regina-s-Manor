using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public Canvas canvas;

    public InteractionPrompt interactionPrompt;

    public DialogueEvents dialogueEvents;

    public PlayerControllerEvents playerControllerEvents;

    public UIControllerEvents UIControllerEvents;

    private void Awake()
    {
        instance = this;
        dialogueEvents = new DialogueEvents();  
        playerControllerEvents = new PlayerControllerEvents();
        UIControllerEvents = new UIControllerEvents();  
    }

    private GameManager()
    {
       
    }


    public void ShowInteractionPrompt(Interaction interObj, Transform prompPos, Vector3 offset)
    {
        if (!interactionPrompt.gameObject.activeSelf)
            interactionPrompt.gameObject.SetActive(true);
        interactionPrompt.SetCurrentObj(interObj, prompPos, offset);
    }

    public void HideInteractionPrompt()
    {
        if (interactionPrompt.gameObject.activeSelf)
            interactionPrompt.gameObject.SetActive(false);
    }

    // Add your game mananger members here
    public void Pause(bool paused)
    {
    }
// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
