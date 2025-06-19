using Targets;
using UI;
using UnityEngine;

public class BaseTarget : MonoBehaviour
{
    [SerializeField] private int pointsWorth;

    protected CollisionHandler collisionHandler;
    protected DisplayScore displayScore;

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
        // Debug.Log($"Target hit! Worth {pointsWorth} points.");
        displayScore.AddPoints(pointsWorth);
        // Implement basic behavior or let derived classes override
    }
}
