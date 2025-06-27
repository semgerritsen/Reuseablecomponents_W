using UnityEngine;
using UnityEngine.Rendering;

namespace Interfaces
{
    public interface IMovement
    {
        /// <summary>
        ///  Moves the object in the specified direction.
        /// </summary>
        /// <param name="direction"></param>
        void Move(Vector3 direction);
    }
}