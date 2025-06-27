using UnityEngine;

namespace Interfaces
{
    public interface IAimInput
    {
        /// <summary>
        ///  Gets the aim direction as a Ray.
        /// </summary>
        /// <returns></returns>
        Ray GetAimDirection();
    }
}