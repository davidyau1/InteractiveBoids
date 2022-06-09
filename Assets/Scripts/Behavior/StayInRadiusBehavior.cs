using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behaviour/Stay in Radius")]
public class StayInRadiusBehavior : FlockBehavior
{
    [SerializeField] private Vector2 _center;
    [SerializeField] private float _radius = 15f;
    /// <summary>
    /// Calculate to Keeps flock in certain radius
    /// </summary>
    /// <param name="agent">agent</param>
    /// <param name="context">context</param>
    /// <param name="flock">flock</param>
    /// <returns>Keeps flock in certain radius</returns>
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector2 centerOffset = _center - (Vector2)agent.transform.position;
        float t = centerOffset.magnitude / _radius;
        if (t < 0.9f)
        {
            return Vector2.zero;
        }
        return centerOffset * t * t;//weight of 0.1f

    }
}
