using UnityEngine;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float sensitivity = 5f;
        public Camera playerCamera;
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
            cameraRotate = new Vector3(_mouseY * sensitivity, 0, 0);
            playerRotate = new Vector3(0, -_mouseX * sensitivity, 0);
            transform.eulerAngles = transform.eulerAngles - playerRotate;
            var tempCameraRotation = playerCamera.transform.eulerAngles - cameraRotate;
            if (tempCameraRotation.x >= 75f && tempCameraRotation.x <= 285f) return;
            playerCamera.transform.eulerAngles = tempCameraRotation;
        }
    }
}