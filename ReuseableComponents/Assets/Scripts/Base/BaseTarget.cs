using Targets;
using UI;
using UnityEngine;

public class BaseTarget : MonoBehaviour
{
    [SerializeField] private int pointsWorth;

    protected CollisionHandler collisionHandler;
    protected DisplayScore displayScore;
    
    public event System.Action onHit;

    protected virtual void Awake()
    {
        collisionHandler = GetComponent<CollisionHandler>();
        displayScore = GetComponent<DisplayScore>();
    }

    public int GetPoints()
    {
        return pointsWorth;
    }

    public virtual void OnHit()
    {
        if (onHit != null)
        {
            onHit?.Invoke();
        }
        ScoreManager.Instance.AddPoints(pointsWorth);
    }
}
