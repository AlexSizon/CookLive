using UnityEngine;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float sensitivity = 5f;
        private float _mouseX;
        private float _mouseY;
        private Vector3 cameraRotate;
        private Vector3 playerRotate;

        private void Update()
        {
            _mouseX = Input.GetAxis("Mouse X");
            _mouseY = Input.GetAxis("Mouse Y");
            RotatePlayer();
        }

        private void RotatePlayer()
        {
            cameraRotate = new Vector3(_mouseY* sensitivity, 0, 0);
            playerRotate = new Vector3(0, -_mouseX * sensitivity, 0);
            playerCamera.transform.eulerAngles = playerCamera.transform.eulerAngles - cameraRotate;
            transform.eulerAngles = transform.eulerAngles - playerRotate;
        }
    }
}