using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSFX;
    private bool lvlCompleted = false;

    // Start is called before the first frame update
    private void Start()
    {
        finishSFX = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (!lvlCompleted)
            {
                finishSFX.Play();
                lvlCompleted = true;
                Invoke("CompleteLevel", 2f);
                
            }
            
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
