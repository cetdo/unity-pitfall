using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0;
    
    [SerializeField] private Text coinCounter;
    [SerializeField] private AudioSource collectSFX;
    [SerializeField] private GameObject stageController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collectSFX.Play();
            collision.gameObject.SetActive(false);
            coins++;
            coinCounter.text = "Treasures: " + coins;
            stageController.GetComponent<StageController>().CollectCoin();
        }
    }
}
