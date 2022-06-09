using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Filter/Layer")]

public class LayerFilter : ContextFilter
{
    /// <summary>
    ///     Filter based on Layer
    /// </summary>
    public LayerMask mask;
    public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform item in original)
        {
            //check if object layer in mask
            if (0 !=(mask&(1 << item.gameObject.layer)))
            {
                filtered.Add(item); 
            } 
        }
        return filtered;
    }
}
