using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    [SerializeField] private float speedMultiplier;
    public float groundDrag;
    public Transform orientation;

    // Input tracking vars
    float horizonalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    //ref for enabling movement
    public PlayerCam camScript;


    private void Awake()
    {
        camScript = FindObjectOfType<PlayerCam>();

    }

    [Header("Verb Storage")]
    //Verb Inventory details
    public InventoryObject verbInventory;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Time.timeScale = 1;
    }

    private void Update()
    {

        if (camScript.currentState == menuState.menuDisabled)
        {
            MyInput();
            SpeedControl();
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        rb.drag = groundDrag;
    }

    //Checks for colliding with verb objects, adds to inventory
    public void OnTriggerEnter(Collider other)
    {
        var verb = other.GetComponent<Verb>();

        if (verb)
        {
            verbInventory.AddItem(verb.verb, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        verbInventory.Container.Clear();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        horizonalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


    }

    private void MovePlayer()
    {
        // movement direction math
        moveDirection = orientation.forward * verticalInput + orientation.right * horizonalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * speedMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

}
