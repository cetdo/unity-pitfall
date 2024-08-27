using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    private int curWaypointIndex = 0;
    private SpriteRenderer sprRenderer;

    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject[] waypoints;

    private void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Vector2.Distance(waypoints[curWaypointIndex].transform.position, transform.position) < .1f)
        {
            curWaypointIndex++;
            sprRenderer.flipX = true;
            if (curWaypointIndex >= waypoints.Length)
            {
                curWaypointIndex = 0;
                sprRenderer.flipX = false;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[curWaypointIndex].transform.position, Time.deltaTime * speed);

    }
}
