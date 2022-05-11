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

    [Header("Verb Storage")]
    //Verb Inventory details
    public InventoryObject verbInventory;


    private void Awake()
    {
        camScript = FindObjectOfType<PlayerCam>();

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //Updates scripts when state changes
        if (camScript.currentState == menuState.menuDisabled)
        {
            MyInput();
            SpeedControl();
        }
        else
        {

        }
        rb.drag = groundDrag;
    }

    //Checks for colliding with verb objects, adds to inventory
    public void OnTriggerEnter(Collider other)
    {
        var verb = other.GetComponent<Verb>();

        if (verb)
        {
            verbInventory.AddItem(verb.verbScriptableObj, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        //ensures verbInventory is absolutely cleared.
        verbInventory.Container.Clear();
    }

    private void FixedUpdate()
    {
        //moves player every frame
        MovePlayer();
    }

    void MyInput()
    {
        //sets inputs
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
        //calculates move values
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

}
