using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/PlayerAvoidance")]

public class PlayerAvoidanceBehavior : FilteredFlockBehavior
{
    PlayerMovement _player;

    public int squareAvoidanceRadius;


    void FindPlayer()
    {
        _player = FindObjectOfType<PlayerMovement>();
    }

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        FindPlayer();
        if (context.Count == 0)
        {
            return Vector2.zero;

        }
        Vector2 avoidanceMove = Vector2.zero;
        //List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);


        if (Vector2.SqrMagnitude(_player.transform.position - agent.transform.position) < squareAvoidanceRadius)
        {
            avoidanceMove += (Vector2)(agent.transform.position - _player.transform.position);
        }

        return avoidanceMove;

    }
}
