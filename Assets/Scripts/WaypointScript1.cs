using System.Collections;
using UnityEngine;
//Credit: Code from JL Unity tutorial, modify for personal use.

public class WaypointScript1 : MonoBehaviour {

    public Animator animator;
    public string nameOnChair = "none";

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    [SerializeField]
    private float waitSecs = 0f;

    [SerializeField]
    public bool movingChairs = false;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

	// Use this for initialization
	private void Start () {

        
        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	private void Update () {
        
        if (movingChairs) {
            StartCoroutine(waitBeforeMove(waitSecs));
        }
	}


    private void Move()
    {
        // If object reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {

            // Move Object from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            // If Object reaches position of waypoint it moved towards
            // then waypointIndex is increased by 1
            // and Object starts to move to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }

    private IEnumerator waitBeforeMove(float num){
        yield return new WaitForSeconds(waitSecs);
        //waitSecs = 0;

        Move();
    }
}