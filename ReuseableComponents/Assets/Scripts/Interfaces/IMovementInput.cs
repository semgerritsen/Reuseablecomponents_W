using UnityEngine;

namespace Interfaces
{
    public interface IMovementInput
    {
        /// <summary>
        ///   Gets the movement direction based on user input.
        /// </summary>
        /// <returns></returns>
        Vector3 GetMovementDirection();
    }
}