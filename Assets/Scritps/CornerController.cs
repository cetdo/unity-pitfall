using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerController : MonoBehaviour
{
    [SerializeField] private Transform otherSide;
    [SerializeField] private GameObject stageController;

    private float padding = 1.5f;

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player encontrado");
            if (otherSide.gameObject.CompareTag("RightCorner"))
            {
                collision.gameObject.transform.position = new Vector3(otherSide.transform.position.x - padding, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
                stageController.GetComponent<StageController>().GoLeft();
            }
            else if (otherSide.gameObject.CompareTag("LeftCorner"))
            {
                collision.gameObject.transform.position = new Vector3(otherSide.transform.position.x + padding, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
                stageController.GetComponent<StageController>().GoRight();
            }
        }
    }

}
