using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowPath : MonoBehaviour
{
    public float speed;
    public bool stop;

    private Transform target;
    private int pointIndex;

    void Start()
    {
        stop = false;
        pointIndex = 0;
        target = FollowPath.points[0];
    }

    
    void Update()
    {
        if (stop == false)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.5f)
            {
                GetNextPoint();
            }
        }
    }

    void GetNextPoint()
    {
        if(pointIndex >= FollowPath.points.Length - 1)
        {
            stop = true;
        }
        else
        {
            pointIndex++;
            target = FollowPath.points[pointIndex];
        }
    }
}
