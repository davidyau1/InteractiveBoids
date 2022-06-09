using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/PlayerAvoidance")]

public class PlayerAvoidanceBehavior : FilteredFlockBehavior
{
    PlayerMovement _player;

    public int squareAvoidanceRadius;

    //get player
    void FindPlayer()
    {
        _player = FindObjectOfType<PlayerMovement>();
    }
    /// <summary>
    /// Work out movement to void player
    /// </summary>
    /// <param name="agent"></param>
    /// <param name="context"></param>
    /// <param name="flock"></param>
    /// <returns>Movement to avoid movement</returns>
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
