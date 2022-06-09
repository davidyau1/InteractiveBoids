using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/Composite")]

public class CompositeBehavior : FlockBehavior
{
    [System.Serializable]
    public struct BehaviourGroup
    {
        public FlockBehavior behavior;
        public float weights;

   
       
    }
    public BehaviourGroup[] behaviours;

    /// <summary>
    /// Calculate move
    /// </summary>
    /// <param name="agent">agent</param>
    /// <param name="context">context</param>
    /// <param name="flock">flock</param>
    /// <returns>Composite Movement</returns>
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector2 move = Vector2.zero;

        foreach (BehaviourGroup behave in behaviours)
        {

            Vector2 partialMove=behave.behavior.CalculateMove(agent,context, flock)*behave.weights;
            if (partialMove!=Vector2.zero)
            {
                //calulate total move by individual behaviours and weight
                if (partialMove.sqrMagnitude>behave.weights*behave.weights)
                {
                    partialMove.Normalize();
                    partialMove *= behave.weights;
                }
            }
            move += partialMove;
        }



        return move;
    }

}
