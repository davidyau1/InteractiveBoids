using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
public class CohesionBehavior : FilteredFlockBehavior
{    /// <summary>
     /// Calculate move
     /// </summary>
     /// <param name="agent">agent</param>
     /// <param name="context">context</param>
     /// <param name="flock">flock</param>
     /// <returns>Movement to stay close to agents</returns>
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (context.Count==0)
        {
            return Vector2.zero;

        }
        Vector2 cohesionMove = Vector2.zero;
        List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);
        int count = 0;

        foreach(Transform item in filteredContext)
        {
            cohesionMove += (Vector2)item.position;
            count++;
        }
        if (count!=0)
        {
            cohesionMove /= count;
        }

        cohesionMove -=(Vector2)agent.transform.position;

        return cohesionMove;

    }
}
