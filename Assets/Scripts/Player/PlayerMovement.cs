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
        private const int ACCELERATION_MODIFIER=2;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            SetCursorLockState(false);
        }

        private void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            
            if (Input.GetKey(KeyCode.Escape)) SetCursorLockState(true);
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                accelerationCoefficient += ACCELERATION_MODIFIER;
            }
            if (Input.GetKeyUp(KeyCode.RightShift))accelerationCoefficient -= ACCELERATION_MODIFIER;

            MovePlayer();
        }


        private void MovePlayer()
        {
            Vector3 moveDirection = Vector3.zero;
            moveDirection = new Vector3(_horizontal, 0, _vertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= (speed+accelerationCoefficient);
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