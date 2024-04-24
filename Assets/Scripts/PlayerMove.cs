using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float PSpeed = 20f;
    private CharacterController mvmtCC;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float mvmtGravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        mvmtCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
    }

    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        movementVector = (inputVector * PSpeed) + (Vector3.up * mvmtGravity*10);
    }

    void MovePlayer()
    {
        mvmtCC.Move(movementVector * Time.deltaTime);
    }
}
