using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 2f; // The speed at which the character will move
    public Transform[] waypoints; // The waypoints the character will move between
    private int currentWaypoint = 0; // The current waypoint the character is moving towards
    private bool facingRight = true; // A flag to track the character's facing direction
    private bool enteredWaypoint;

    // Update is called once per frame
    void Update()
    {
        // Move the character towards the current waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

        // If the character has reached the current waypoint, switch to the next waypoint

        if (enteredWaypoint)
        {          
            currentWaypoint++;
            enteredWaypoint = false;

            // If the character has reached the last waypoint, start moving towards the first waypoint again
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }

            // Flip the character's facing direction
            Flip();
        }
    }

    // Flip the character's facing direction
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enteredWaypoint = true;
    }
}
