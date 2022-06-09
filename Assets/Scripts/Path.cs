using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    public List<Transform> waypoints;
    public float radius = 2.5f;
    [SerializeField] private Vector3 _gizmoSize = Vector3.one;
    public bool isFill = true;

    private void Start()
    {
        //get waypoints function called
        FillWithChildren();
    }
    //Get the way points
    public void FillWithChildren()
    {
        if (!isFill) return;
        foreach (Transform child in GetComponentInChildren<Transform>())
        {
            if (!waypoints.Contains(child))
            {
                waypoints.Add(child);

            }
        }
    }

   

}
