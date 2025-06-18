using Movement;
using UnityEngine;

[RequireComponent(typeof(BaseMovement))]
public class EnemyTrack : MonoBehaviour
{
        [Header("set player target")]
        [SerializeField] private Transform target;
        
        BaseMovement baseMovement;
        
        private void Awake()
        {
            baseMovement = FindFirstObjectByType<BaseMovement>();
        }
    
        private void Update()
        {
            if (target == null || Vector3.Distance(transform.position, target.position) < 2f)
            {
                return;
            }
            Vector3 direction = (target.position - transform.position).normalized;
            baseMovement.Move(direction);
            
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(targetPosition);

        }
}
