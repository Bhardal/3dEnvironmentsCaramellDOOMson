using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensivity = 1.5f;

    private Vector2 mouseInput;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * sensivity;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - mouseInput.y, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        }
    }
}
