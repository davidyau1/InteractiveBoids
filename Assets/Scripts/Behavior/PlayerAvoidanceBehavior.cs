using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/PlayerAvoidance")]

public class PlayerAvoidanceBehavior : FilteredFlockBehavior
{
    public Player player;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
        {
            return Vector2.zero;

        }
        Vector2 avoidanceMove = Vector2.zero;
        List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);


        if (Vector2.SqrMagnitude(player.transform.position - agent.transform.position) < flock.SquareAvoidanceRadius)
        {
            avoidanceMove += (Vector2)(agent.transform.position - player.transform.position);
        }

        return avoidanceMove;

    }
}
