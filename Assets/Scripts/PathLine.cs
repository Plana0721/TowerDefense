using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PathLine : MonoBehaviour
{
    public Transform[] waypoints;
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer line = GetComponent<LineRenderer>();
        line.positionCount = waypoints.Length;

        for(int i=0; i<waypoints.Length; i++)
        {
            line.SetPosition(i, waypoints[i].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
