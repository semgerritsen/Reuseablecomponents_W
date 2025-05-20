using UnityEngine;

namespace Movement
{
    public class ControllerLook : MonoBehaviour
    {
        [Header("Controller Look Settings")] [SerializeField]
        private float sensitivity = 3f;

        [SerializeField] private float minY = -80f;
        [SerializeField] private float maxY = 80f;

        private float rotationY = 0f;

        private void Update()
        {
            float lookX = Input.GetAxis("RightStickHorizontal") * sensitivity;
            float lookY = Input.GetAxis("RightStickVertical") * sensitivity;

            rotationY -= lookY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            transform.localEulerAngles = new Vector3(rotationY, 0f, 0f);
            if (transform.parent != null)
            {
                transform.parent.Rotate(Vector3.up * lookX);
            }
        }
    }
}