using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class FirstPersonControls : MonoBehaviour
{
    [Header("MOVEMENT SETTINGS")]
    [Space(5)]
    // Public variables to set movement and look speed, and the player camera
    public float moveSpeed; // Speed at which the player moves
    public float lookSpeed; // Sensitivity of the camera movement
    public float gravity = -9.81f; // Gravity value
    public float jumpHeight = 1.0f; // Height of the jump
    public Transform playerCamera; // Reference to the player's camera
                                   // Private variables to store input values and the character controller
    private Vector2 moveInput; // Stores the movement input from the player
    private Vector2 lookInput; // Stores the look input from the player
    private float verticalLookRotation = 0f; // Keeps track of vertical camera rotation for clamping
    private Vector3 velocity; // Velocity of the player
    private CharacterController characterController; // Reference to the CharacterController component

    [Header("Slots")]
    [Space(5)]
    public GameObject slot1GameObject;
    public int Counter1;
    public GameObject slot2GameObject;
    public int Counter2;
    public GameObject slot3GameObject;
    public int Counter3;

    [Header("Shooting Controls")]
    public bool CanShoot;
    public GameObject projectilePrefab; 
    public Transform firePoint; 
    public float projectileSpeed = 20f; 
  

    [Header("CROUCH SETTINGS")]
    [Space(5)]
    public float crouchHeight = 1f; // Height of the player when crouching
    public float standingHeight = 2f; // Height of the player when standing
    public float crouchSpeed = 8f; // Speed at which the player moves when crouching
    public bool isCrouching = false; // Whether the player is currently crouching

    [Header("General")]
    [Space(5)]
    public SideEffects sideEffects;
    private void Awake()
    {
        // Get and store the CharacterController component attached to this GameObject
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        // Create a new instance of the input actions
        var playerInput = new Controls();

        // Enable the input actions
        playerInput.Player.Enable();

        // Subscribe to the movement input events
        playerInput.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>(); // Update moveInput when movement input is performed
        playerInput.Player.Movement.canceled += ctx => moveInput = Vector2.zero; // Reset moveInput when movement input is canceled

        // Subscribe to the look input events
        playerInput.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>(); // Update lookInput when look input is performed
        playerInput.Player.Look.canceled += ctx => lookInput = Vector2.zero; // Reset lookInput when look input is canceled

        playerInput.Player.Slot1.performed += ctx => Slot1();
        playerInput.Player.Slot2.performed += ctx => Slot2();
        playerInput.Player.Slot3.performed += ctx => Slot3();

        playerInput.Player.Shoot.performed += ctx => Shoot();

    }


    private void Update()
    {
        Move();
        LookAround();
        ApplyGravity();
    }


    public void Move()
    {
        // Create a movement vector based on the input
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        // Transform direction from local to world space
        move = transform.TransformDirection(move);

        // Adjust speed if crouching
        float currentSpeed;
        if (isCrouching)
        {
            currentSpeed = crouchSpeed;
        }
        else
        {
            currentSpeed = moveSpeed;
        }


        // Move the character controller based on the movement vector and speed
        characterController.Move(move * currentSpeed * Time.deltaTime);
    }

    public void LookAround()
    {
        // Get horizontal and vertical look inputs and adjust based on sensitivity
        float LookX = lookInput.x * lookSpeed;
        float LookY = lookInput.y * lookSpeed;

        // Horizontal rotation: Rotate the player object around the y-axis
        transform.Rotate(0, LookX, 0);

        // Vertical rotation: Adjust the vertical look rotation and clamp it to prevent flipping
        verticalLookRotation -= LookY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        // Apply the clamped vertical rotation to the player camera
        playerCamera.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
    }

    public void ApplyGravity()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f; // Small value to keep the player grounded
        }

        velocity.y += gravity * Time.deltaTime; // Apply gravity to the velocity
        characterController.Move(velocity * Time.deltaTime); // Apply the velocity to the character
    }

    public void Slot1() 
    {
        Counter1++;
        Counter2 = 0;
        Counter3 = 0;
        Debug.Log("Light");
        

        if (Counter1 == 1) 
        {
            CanShoot = false;
            slot1GameObject.SetActive(true);
            slot2GameObject.SetActive(false);
            slot3GameObject.SetActive(false);
        }

        if (Counter1 == 2) 
        {
            Counter1 = 0;
            slot1GameObject.SetActive(false);
            slot2GameObject.SetActive(false);
            slot3GameObject.SetActive(false);
           
        }


    }

    public void Slot2() 
    {
        Counter1 = 0;
        Counter2++;
        Counter3 = 0;

        Debug.Log("Tazer");


        if (Counter2 == 1)
        {
            CanShoot = true;
            slot1GameObject.SetActive(false);
            slot2GameObject.SetActive(true);
            slot3GameObject.SetActive(false);
        }

        if (Counter2 == 2)
        {
            CanShoot = false;
            Counter2 = 0;
            slot1GameObject.SetActive(false);
            slot2GameObject.SetActive(false);
            slot3GameObject.SetActive(false);

        }
    }

    public void Slot3() 
    {
        Counter1 = 0;
        Counter2 = 0;
        Counter3++;

        Debug.Log("PickUp");

        // Perform a raycast from the camera's position forward
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;
        // Debugging: Draw the ray in the Scene view
        Debug.DrawRay(playerCamera.position, playerCamera.forward *
        2f, Color.red, 2f);

        if (Physics.Raycast(ray, out hit, 2f))
        {
            // Check if the hit object has the tag "PickUp"
            if (hit.collider.CompareTag("Pill"))
            {
                sideEffects = hit.collider.GetComponent<SideEffects>();
                sideEffects.PickUpPill();
                Debug.Log("pill interacted");
                Destroy(hit.collider.transform.parent.gameObject);
            }
            
        
        }
}

    public void Shoot() 
    {
        if (CanShoot) 
        {
            Debug.Log("Shoot");
           
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * projectileSpeed;

           
            Destroy(projectile, 3f);
        }
    
    }

}
