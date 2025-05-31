using UnityEngine;

public class InteractionCollider : MonoBehaviour
{
    [SerializeField]
   Player playerRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void Awake()
    {
        playerRef = GetComponentInParent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Person");
        Interaction inter = other.gameObject.GetComponent<Interaction>();
        if (inter)
        {
            
            playerRef.OnFoundNewInteraction(inter);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Interaction inter = other.gameObject.GetComponent<Interaction>();
        if (inter)
        {
            playerRef.OnMissingInteraction(inter);
        }
    }





}
