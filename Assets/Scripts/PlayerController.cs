using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    public float sensitivityX = 4f;
    public float sensitivityY = 2f;



    Rigidbody rb;
    private float playerHeight;
    private float raycastDistance;
    public float speed;
    
    //Input
    public PlayerInputSystem playerInputSystem;
    private InputAction move;
    private InputAction jump;
    private InputAction look;
    private InputAction interaction;
    Vector3 moveDirection =new Vector3(0,0,0);
    Vector2 lookRotation = new Vector2(0,0);
    
    //Jump
    private bool isJumping;
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f; // Multiplies gravity when falling down
    public float ascendMultiplier = 2f; // Multiplies gravity for ascending to peak of jump
    private bool isGrounded = true;
    public LayerMask groundLayer;
    private float groundCheckTimer = 0f;
    private float groundCheckDelay = 0.3f;

    //LookRotation
    public float rotationPower = 0.2f;
    public float rotationLerp= 10f;
    private Quaternion nextRotation;

    private void Awake()
    {
        playerInputSystem= new PlayerInputSystem();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerHeight = GetComponent<CapsuleCollider>().height * transform.localScale.y;
        raycastDistance = (playerHeight / 2) + 0.2f;
        playerInputSystem.Player.Look.performed += ctx => lookRotation = ctx.ReadValue<Vector2>();
        playerInputSystem.Player.Look.canceled += ctx => lookRotation = Vector2.zero;
        playerInputSystem.Player.Interact.performed += ctx => Interact(ctx);
        //nextRotation = lookRotation;

        // Hides the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        move = playerInputSystem.Player.Move;
        move.Enable();
        jump= playerInputSystem.Player.Jump;
        jump.Enable();
        look = playerInputSystem.Player.Look;
        look.Enable();
        interaction = playerInputSystem.Player.Interact;
        interaction.Enable();

    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        look.Disable();
        interaction.Disable();
    }

    // Update is called once per frame
    void Update()
    {

        moveDirection = move.ReadValue<Vector2>(); //Calcolo la direzione a seconda di quali pulsanti ho premuto
        lookRotation= look.ReadValue<Vector2>();
        //transform.rotation *= Quaternion.AngleAxis(lookRotation.x * rotationPower, Vector3.up);
        lookRotation*=rotationPower;
        transform.Rotate(Vector3.up, lookRotation.x, Space.World);
        //transform.Rotate(Vector3.right, lookRotation.y, Space.World);
        //nextRotation = Quaternion.Lerp(transform.rotation, nextRotation, Time.deltaTime * rotationLerp);
        
        if (isJumping && isGrounded)
        {
            OnJump();
        }

        // Checking when we're on the ground and keeping track of our ground check delay
        if (!isGrounded && groundCheckTimer <= 0f)
        {
            Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;
            isGrounded = Physics.Raycast(rayOrigin, Vector3.down, raycastDistance, groundLayer);
        }
        else
        {
            groundCheckTimer -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        MovePlayer();
        ApplyJumpPhysics();
    }

    void MovePlayer()
    {

        Vector3 movement = (transform.right * moveDirection.x + transform.forward * moveDirection.y).normalized;
        Vector3 targetVelocity = movement * speed;

        // Apply movement to the Rigidbody
        Vector3 velocity = rb.linearVelocity;
        velocity.x = targetVelocity.x;
        velocity.z = targetVelocity.z;
        rb.linearVelocity = velocity;

        // If we aren't moving and are on the ground, stop velocity so we don't slide
        if (isGrounded && moveDirection.x == 0 && moveDirection.y == 0)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }

    void OnJump()
    {
        isGrounded = false;
        isJumping = false;
        groundCheckTimer = groundCheckDelay;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z); // Initial burst for the jump
    }

    void ApplyJumpPhysics()
    {
        if (rb.linearVelocity.y < 0)
        {
            // Falling: Apply fall multiplier to make descent faster
            rb.linearVelocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.fixedDeltaTime;
        } // Rising
        else if (rb.linearVelocity.y > 0)
        {
            // Rising: Change multiplier to make player reach peak of jump faster
            rb.linearVelocity += Vector3.up * Physics.gravity.y * ascendMultiplier * Time.fixedDeltaTime;
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        isJumping = true;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Premuto");
        Player player= GetComponent<Player>();
        player.Interact();
    }


}
