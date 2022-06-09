using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehavior : FilteredFlockBehavior
{    /// <summary>
     /// Calculate move
     /// </summary>
     /// <param name="agent">agent</param>
     /// <param name="context">context</param>
     /// <param name="flock">flock</param>
     /// <returns>Movement to align agents</returns>
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (context.Count==0)
        {
            return agent.transform.up;
        }

        Vector2 alignmentMove = Vector2.zero;

        List<Transform> filteredContext=filter==null? context :filter.Filter(agent,context);

        int count = 0;
        foreach (Transform item in filteredContext)
        {
            alignmentMove += (Vector2)item.transform.up;
            count++;
        }
        if (count != 0)
        {
            alignmentMove /= count;
        }
        return alignmentMove;
    }

}
