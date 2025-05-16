using Interfaces;
using UnityEngine;

//todo: use Imovement interface
namespace Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class BaseMovement : MonoBehaviour, IMovement
    {
        [Header("Movement speed")]
        [SerializeField] private float moveSpeed = 5f;
        
        private CharacterController controller;
        private void Awake() => controller = GetComponent<CharacterController>();

        public void Move(Vector3 direction)
        {
            Vector3 move = direction.normalized * moveSpeed;
            controller.SimpleMove(move);
        }
    }
}