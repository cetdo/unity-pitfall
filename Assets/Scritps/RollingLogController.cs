using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingLogController : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject respawn;

    void Update()
    {
        if (Vector2.Distance(target.transform.position, transform.position) < .1f)
        {
            transform.position = respawn.transform.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);

    }
}

