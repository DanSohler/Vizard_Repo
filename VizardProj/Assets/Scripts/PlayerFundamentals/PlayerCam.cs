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

    menuState currentState;
    bool stateRotator = true;

    private void Start()
    {
        currentState = menuState.menuDisabled;
        // locks cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
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
        if (Input.GetKeyDown("space"))
        {
            stateRotator = !stateRotator;
            if (stateRotator)
            {
                currentState = menuState.menuEnabled;
            }
            if (!stateRotator)
            {
                currentState = menuState.menuDisabled;
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
    public enum menuState
    {
      menuEnabled,
      menuDisabled
    }
}
