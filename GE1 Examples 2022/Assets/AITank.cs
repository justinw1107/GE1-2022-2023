using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AITank : MonoBehaviour {

    public float radius = 10;
    public int numWaypoints = 5;
    public int current = 0;
    List<Vector3> waypoints = new List<Vector3>();
    public float speed = 10;
    public Transform player;    

    public void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            // Task 1
            // Put code here to draw the gizmos
            // Use sin and cos to calculate the positions of the waypoints 
            // You can draw gizmos using
            // Gizmos.color = Color.green;
            // Gizmos.DrawWireSphere(pos, 1);

            float theta = (Mathf.PI * 2.0f) / numWaypoints;
            for (int i=0;i<numWaypoints;i++)
            {
                float theta2 = i * theta;
                Vector3 pos = new Vector3(Mathf.Sin(theta2) * radius, 0, Mathf.Cos(theta2) * radius);
                pos = transform.TransformPoint(pos);
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(pos, 1);
            }
        }
    }

    // Use this for initialization
    void Awake () {
        // Task 2
        // Put code here to calculate the waypoints in a loop and 
        // Add them to the waypoints List

        float theta = (Mathf.PI * 2.0f) / numWaypoints;
        for (int i=0;i<numWaypoints;i++)
        {
            float theta2 = i * theta;
            Vector3 pos = new Vector3(Mathf.Sin(theta2) * radius, 0, Mathf.Cos(theta2) * radius);
            pos = transform.TransformPoint(pos);
            waypoints.Add(pos);
        }

    }

    // Update is called once per frame
    void Update () {
        // Task 3
        // Put code here to move the tank towards the next waypoint
        // When the tank reaches a waypoint you should advance to the next one
        Vector3 moveTarget = waypoints[current] - transform.position;
        if (moveTarget.magnitude < 1)
        {
            current = (current + 1) % waypoints.Count;
        }

        moveTarget.Normalize();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveTarget), Time.deltaTime*5);
        transform.Translate(moveTarget*speed*Time.deltaTime, Space.World);

        // Task 4
        // Put code here to check if the player is in front of or behind the tank
        Vector3 movePlayer = player.position - transform.position;
        if (Vector3.Dot(transform.forward, movePlayer)<0)
        {
            GameManager.Log("Player is behind the tank");
        }
        else
        {
            GameManager.Log("Player is in front of the tank");
        }

        // Task 5
        // Put code here to calculate if the player is inside the field of view and in range
        // You can print stuff to the screen using:
        //GameManager.Log("Hello from th AI tank");
        float fov = Mathf.Acos(Vector3.Dot(transform.forward, movePlayer)/movePlayer.magnitude)*Mathf.Rad2Deg;
        if (fov < 45)
        {
            GameManager.Log("Player is inside the field of view of tank");
        }
        else
        {
            GameManager.Log("Player is outside the field of view of tank");
        }

    }
}
