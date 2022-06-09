using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//abstract class for flock behaviours
public abstract class FlockBehavior : ScriptableObject
{
    public abstract Vector2 CalculateMove(FlockAgent agent, List<Transform>context,Flock flock);

}
