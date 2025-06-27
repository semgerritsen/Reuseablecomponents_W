using Interfaces;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class BaseMovement : MonoBehaviour, IMovement
    {
        [Header("Movement speed")]
        [SerializeField] public float moveSpeed = 7.5f;
        
        private CharacterController controller;
        
        // get the character controller component on Awake
        private void Awake() => controller = GetComponent<CharacterController>();

        /// <summary>
        /// this method moves the character in the specified direction using de Direction parameter.
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Vector3 direction)
        {
            //calculate the movement based on the direction and move speed
            Vector3 move = direction.normalized * moveSpeed;
            controller.SimpleMove(move);
        }
    }
} 