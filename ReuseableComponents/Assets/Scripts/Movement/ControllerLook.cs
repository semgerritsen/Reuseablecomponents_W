using UnityEngine;

namespace Movement
{
    public class ControllerLook : MonoBehaviour
    {
        [Header("Controller Look Settings")] [SerializeField]
        private float sensitivity = 0.75f;

        [SerializeField] private float minY = -80f;
        [SerializeField] private float maxY = 80f;

        private float rotationY = 0f;

        /// <summary>
        /// Handles camera rotation based on controller right stick input.
        /// Vertical look is clamped, horizontal look rotates the parent.
        /// </summary>
        private void Update()
        {
            // Get right stick input for horizontal (X) and vertical (Y) look
            float lookX = Input.GetAxis("RightStickHorizontal") * sensitivity;
            float lookY = Input.GetAxis("RightStickVertical") * sensitivity;
        
            // Adjust and clamp vertical rotation
            rotationY -= lookY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
        
            // Apply vertical rotation to this transform (camera)
            transform.localEulerAngles = new Vector3(rotationY, 0f, 0f);
        
            // Apply horizontal rotation to the parent (player body)
            if (transform.parent != null)
            {
                transform.parent.Rotate(Vector3.up * lookX);
            }
        }
    }
}