using System;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Movement.BaseMovement))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] float rotationSpeed = 700f;
        
        private BaseMovement baseMovement;

        public void Start()
        {
            baseMovement = GetComponent<BaseMovement>();
        }

        public void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 inputDirection = new Vector3(h, 0, v);
            inputDirection = transform.TransformDirection(inputDirection);

            baseMovement.Move(inputDirection);

            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, mouseX, 0);
        }
    }
}