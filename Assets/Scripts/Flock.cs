using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    public List<FlockAgent> agents;

    public FlockBehavior behavior;

    [Range(10, 500)]
    public int startingCount = 250;
    public float agentDensity = 0.08f;


    [Range(1f, 100f)]
    public float driveFactor = 10f;

    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;

    [Range(00f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float _squareMaxSpeed;
    float _squareNeighborRadius;
    float _squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return _squareAvoidanceRadius; } }


    // Start is called before the first frame update
    void Start()
    {
        //Create the agents
        _squareMaxSpeed = maxSpeed * maxSpeed;
        _squareNeighborRadius = neighborRadius * neighborRadius;
        _squareAvoidanceRadius= _squareNeighborRadius*avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitCircle * startingCount * agentDensity,
                Quaternion.Euler(Vector3.forward*Random.Range(0,300f)),
                transform
                );
            newAgent.name = "Agent " + i;
            newAgent.Initialise(this);
            agents.Add(newAgent);
        }

    }
    // Update is called once per frame
    void Update()
    {
        //for each agent look in radius and choose movement
        foreach (FlockAgent agent in agents)
        {
        
            List<Transform> context = GetNearbyObjects(agent);
            //testing
            //agent.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);
            Vector2 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if(move.sqrMagnitude > _squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }

    }
    //locate nearby objects
    private List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextCollider = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
        foreach(Collider2D c in contextCollider)
        {
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            } 
        }
        return context;
    }

  
}
