using UnityEngine;

namespace Movement
{
    public class MouseLook : MonoBehaviour
    {
        [Header("Camera settings")] [SerializeField]
        private float sensitivity = 3f;

        [SerializeField] private float minY = -80f;
        [SerializeField] private float maxY = 80f;

        private float rotationY = 0f;

        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            rotationY -= mouseY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            transform.localEulerAngles = new Vector3(rotationY, 0f, 0f);
            if (transform.parent != null)
            {
                transform.parent.Rotate(Vector3.up * mouseX);
            }
        }
    }
}