using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClibing;

    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] private GameObject floor;
 

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClibing = true;

        }else if (isLadder && Mathf.Abs(vertical) < 0f)
        {
            isClibing = true;
        }
    
    }

    private void FixedUpdate()
    {
        if (isClibing)
        {
            rbPlayer.gravityScale = 0;
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, vertical * speed);
        }
        else
        {
            rbPlayer.gravityScale = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isLadder = collision.CompareTag("Ladder");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClibing = false;
        }
    }

}
