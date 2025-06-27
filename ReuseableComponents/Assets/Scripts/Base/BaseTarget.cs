using Targets;
using UI;
using UnityEngine;

public class BaseTarget : MonoBehaviour
{
    //how many points this target is worth
    [SerializeField] private int pointsWorth;
    
    protected TargetSpawner spawner;
    
    public event System.Action onHit;

    //find the target spawner in the scene
    protected virtual void Awake()
    {
        spawner = FindFirstObjectByType<TargetSpawner>();
    }

    /// <summary>
    /// when the target is hit, this method is called.
    /// first it calls the onHit event
    /// after that it adds points via the score manager which are then displayed in the UI
    /// then it calls the spawner's OnTargetDestroyed method to notify it that a target has been destroyed
    /// then it destroys the target
    /// </summary>
    public virtual void OnHit()
    {
        if (onHit != null)
        {
            onHit?.Invoke();
            ScoreManager.Instance.AddPoints(pointsWorth);
            spawner?.OnTargetDestroyed();
            Destroy(this.gameObject);
        }
    }
}
