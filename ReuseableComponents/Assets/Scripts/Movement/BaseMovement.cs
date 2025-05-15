using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(CharacterController))]
    public abstract class BaseMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        protected CharacterController controller;
        protected virtual void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        public void Move(Vector3 direction)
        {
            Vector3 move = direction.normalized * moveSpeed;
            controller.SimpleMove(move);
        }
    }
}