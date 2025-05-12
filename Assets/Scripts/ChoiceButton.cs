using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    Button btn;
    public TextMeshProUGUI buttonText;
    int currentIndex;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    public void SetUpIndexes(int index)
    {
        currentIndex=index;
    }



    public void SetUpChoice(string text)
    {
        //buttonText.gameObject.SetActive(true);
        buttonText.text = text;
    }



    public void OnSelect()
    {
        Debug.Log("Selected");
        GameManager.instance.dialogueEvents.UpdateChoiceIndex(currentIndex);
        GameManager.instance.dialogueEvents.SubmitPressed();

    }

    public void ClearAndHide()
    {
        gameObject.SetActive(false);
        buttonText.text = "";
    }

}
