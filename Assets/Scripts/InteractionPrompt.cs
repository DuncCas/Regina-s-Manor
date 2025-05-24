using UnityEngine;

public class InteractionPrompt : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    GameObject currentAttached;
    Transform currentAttachedTransform;
    private Vector3 offset;
    Canvas canvas;
    public float clampAngle;

    public GameObject CurrentAttached
    {
        get { return currentAttached; }
    }

    public void SetCurrentObj(Interaction objToInteract, Transform promptPos, Vector3 offsetObj)
    {
        currentAttached = objToInteract.gameObject;
        currentAttachedTransform = promptPos;
        offset = offsetObj; 
    }
    private void Awake()
    {
        canvas = gameManager.canvas;
        gameManager = GameManager.instance;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (currentAttached != null)
        {

            // Position image in front of the target
            Vector3 worldPos = currentAttachedTransform.position + currentAttachedTransform.forward * offset.z + Vector3.up * offset.y;
            canvas.transform.position = worldPos;

            // Make it face the camera
            canvas.transform.LookAt(Camera.main.transform);
            canvas.transform.Rotate(0, 180, 0); // correct flipped canvas

            Vector3 toCamera = Camera.main.transform.position - canvas.transform.position;
            toCamera.y = 0; // ignore vertical

             // allowed yaw rotation
            float angleToCamera = Vector3.SignedAngle(currentAttachedTransform.forward, toCamera, Vector3.up);

            float clampedAngle = Mathf.Clamp(angleToCamera, -clampAngle, clampAngle);

            Quaternion clampedRotation = Quaternion.AngleAxis(clampedAngle, Vector3.up) * Quaternion.LookRotation(-currentAttachedTransform.forward);

            canvas.transform.rotation = clampedRotation;
        }

    }
}
