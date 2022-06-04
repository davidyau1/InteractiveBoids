using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    Flock _agentFlock;
    public Flock AgentFlock { get => _agentFlock;}

    private Collider2D _agentCollider;
    public Collider2D AgentCollider { get => _agentCollider; }
    // Start is called before the first frame update
    void Start() =>_agentCollider = GetComponent<Collider2D>();
    
    public void Initialise(Flock flock)
    {
        _agentFlock = flock;
    }
    // Update is called once per frame
    public void Move(Vector2 velocity)
    {
        transform.up = velocity.normalized;        //rotate ai

        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
