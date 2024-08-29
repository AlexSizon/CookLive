using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 25.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float sensitivity = 5f;
    private CharacterController _controller;
    private float _horizontal, _vertical;
    private float _mouseX, _mouseY;
    private bool _jump;
    
    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        SetCursorLockState(false);
    }

    // screen drawing update - read inputs here
    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");
        _jump = Input.GetButton("Jump");
        if (Input.GetKey(KeyCode.Escape))
        {
            SetCursorLockState(true);
        }
    }

    // physics simulation update - apply physics forces here
    private void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;

        // is the controller on the ground?

        // feed moveDirection with input.
        moveDirection = new Vector3(_horizontal, 0, _vertical);
        moveDirection = transform.TransformDirection(moveDirection);

        // multiply it by speed.
        moveDirection *= speed;

        float turner = _mouseX * sensitivity;
        if (turner != 0)
        {
            // action on mouse moving right
            transform.eulerAngles += new Vector3(0, turner, 0);
        }

        float looker = -_mouseY * sensitivity;
        if (looker != 0)
        {
            // action on mouse moving right
            transform.eulerAngles += new Vector3(looker, 0, 0);
        }

        // apply gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;

        // make the character move
        _controller.Move(moveDirection * Time.deltaTime);
    }

    private void SetCursorLockState(bool state)
    {
        if (!state)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            return;
        }
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}