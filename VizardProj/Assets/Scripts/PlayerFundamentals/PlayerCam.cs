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

    public menuState currentState;
    [HideInInspector] public bool stateRotator = true;

    //Holds all slots
    public List<GameObject> slotList;

    private void Start()
    {
        currentState = menuState.menuDisabled;
        // locks cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (currentState == menuState.menuDisabled)
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
            //flips bool to opposite of current state
            stateRotator = !stateRotator;
            if (stateRotator)
            {
                currentState = menuState.menuEnabled;
                SlotManage();
            }
            if (!stateRotator)
            {
                currentState = menuState.menuDisabled;
                SlotManage();
            }
        }

        //sets menu state
        OnAnimatorMove();
    }

    private void OnAnimatorMove()
    {
        if (currentState == menuState.menuEnabled)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        if (currentState == menuState.menuDisabled)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void SlotManage()
    {
        if (currentState == menuState.menuEnabled)
        {
            foreach (var obj in slotList)
            {
                obj.SetActive(true);
            }
        }
        if (currentState == menuState.menuDisabled)
        {
            foreach (var obj in slotList)
            {
                obj.SetActive(false);
            }
        }
    }

    public enum menuState
    {
      menuEnabled,
      menuDisabled
    }
}
