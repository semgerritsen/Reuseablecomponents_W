using Movement;
using UnityEngine;

[RequireComponent(typeof(BaseMovement))]
public class EnemyTrack : MonoBehaviour
{
        BaseMovement baseMovement;
        [SerializeField] private Transform target;
        private void Awake()
        {
            baseMovement = FindFirstObjectByType<BaseMovement>();
        }
    
        private void Update()
        {
            if (target == null)
            {
                return;
            }
            Vector3 direction = (target.position - transform.position).normalized;
            baseMovement.Move(direction);
            transform.LookAt(target);
        }
}
