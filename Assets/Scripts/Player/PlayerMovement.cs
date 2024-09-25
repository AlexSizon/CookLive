using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 25.0f;
        private CharacterController _controller;
        private float _horizontal;
        private float _vertical;
        private int accelerationCoefficient = 0;
        private const int ACCELERATION_MODIFIER = 2;
        private const KeyCode ACCELERATION_KEY = KeyCode.LeftShift;
        private const KeyCode UNLOCK_CURSOR_KEY = KeyCode.Escape;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            SetCursorLockState(false);
        }

        private void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");

            if (Input.GetKey(UNLOCK_CURSOR_KEY)) SetCursorLockState(true);
            if (Input.GetKeyDown(ACCELERATION_KEY))
            {
                Debug.Log(accelerationCoefficient);
                accelerationCoefficient += ACCELERATION_MODIFIER;
                Debug.Log(accelerationCoefficient);
            }

            if (Input.GetKeyUp(ACCELERATION_KEY)) accelerationCoefficient -= ACCELERATION_MODIFIER;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.W)) MovePlayer();
        }


        private void MovePlayer()
        {
            Vector3 moveDirection = Vector3.zero;
            moveDirection = new Vector3(_horizontal, 0, _vertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= (speed + accelerationCoefficient);
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
}