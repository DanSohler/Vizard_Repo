using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public menuState camCurrentState;
    [HideInInspector] public bool stateRotator = true;

    //Holds all slots
    public List<GameObject> slotList;

    //references slot manager
    SlotManager slotManager;

    //Refs UI items
    public GameObject pauseIcon;
    public GameObject tickIcon;
    public GameObject inventoryBorder;
    public GameObject inventoryScreen;


    //Bool for casting spell in area
    public bool inSpellArea = false;
    public bool castingSpell = false;


    private void Start()
    {
        camCurrentState = menuState.menuDisabled;
        // locks cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pauseIcon.SetActive(false);
        slotManager = FindObjectOfType<SlotManager>();
    }

    private void Update()
    {
        if (camCurrentState == menuState.menuDisabled)
        {
            // gets mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, 0f, 0f);

            // rotate cam and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }

        if (Input.GetKeyDown("space"))
        {
            ChangeMenuState();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (camCurrentState == menuState.menuEnabled)
            {
                if (inSpellArea)
                {
                    castingSpell = true;
                    StartCoroutine(DisableCasting());
                }
            }
            return;
        }

        //sets menu state
        OnAnimatorMove();
    }

    public void ChangeMenuState()
    {
        //flips state to opposite of current state
        if (camCurrentState == menuState.menuEnabled)
        {
            camCurrentState = menuState.menuDisabled;
            tickIcon.SetActive(false);
        }
        else
        {
            camCurrentState = menuState.menuEnabled;
        }
    }

    private void OnAnimatorMove()
    {
        if (camCurrentState == menuState.menuEnabled)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SlotManage();
        }
        if (camCurrentState == menuState.menuDisabled)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            slotManager.ResetSlotChildren();
            SlotManage();
        }
    }

    public void SlotManage()
    {
        if (camCurrentState == menuState.menuEnabled)
        {
            foreach (var obj in slotList)
            {
                obj.SetActive(true);
                pauseIcon.SetActive(true);
                inventoryBorder.SetActive(true);
                inventoryScreen.SetActive(true);
            }
        }
        if (camCurrentState == menuState.menuDisabled)
        {
            foreach (var obj in slotList)
            {
                obj.SetActive(false);
                pauseIcon.SetActive(false);
                slotManager.ResetSlotChildren();
                inventoryBorder.SetActive(false);
                inventoryScreen.SetActive(false);
            }
        }
    }
    public IEnumerator DisableCasting()
    {
        yield return new WaitForSeconds(0.1f);
        castingSpell = false;
        camCurrentState = menuState.menuDisabled;
    }
}

public enum menuState
{
    menuEnabled,
    menuDisabled
}
