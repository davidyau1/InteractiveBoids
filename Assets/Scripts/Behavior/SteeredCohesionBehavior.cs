using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/Steered Cohesion")]

//
public class SteeredCohesionBehavior : CohesionBehavior
{
   
    private Vector2 _currentVelocity = Vector2.zero;
    public float agentSmoothTime = 0.5f;

    /// <summary>
    /// Calculate move to follow the majority
    /// </summary>
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector2 cohesionMove = base.CalculateMove(agent, context, flock);

        //smooths out movements

        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref _currentVelocity, agentSmoothTime);

        return cohesionMove;

    }
}
