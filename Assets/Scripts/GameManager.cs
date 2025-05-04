using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public Canvas canvas;

    public InteractionPrompt interactionPrompt;

    private void Awake()
    {
        instance = this;
    }

    private GameManager()
    {
        // initialize your game manager here. Do not reference to GameObjects here (i.e. GameObject.Find etc.)
        // because the game manager will be created before the objects
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
