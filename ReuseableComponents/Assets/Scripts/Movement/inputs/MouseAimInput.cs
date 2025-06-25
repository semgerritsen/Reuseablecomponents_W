using Interfaces;
using UnityEngine;

namespace Movement.inputs
{
    public class MouseAimInput : MonoBehaviour, IAimInput
    {
        public Ray GetAimDirection()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}