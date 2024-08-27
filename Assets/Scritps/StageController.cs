using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    // Start is called before the first frame update
    private Stage currentStage;
    private MapController mapController;
    private Vector3[] movingPartsRespawn;

    [SerializeField] private GameObject[] grounds = new GameObject[6];
    [SerializeField] private GameObject[] enemies = new GameObject[5];
    [SerializeField] private GameObject[] coins = new GameObject[2];
    [SerializeField] private GameObject scorpion;


    void Start()
    {
        mapController = new MapController();
        currentStage = mapController.getCurrentStage();
        movingPartsRespawn = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++) 
        {
            movingPartsRespawn[i] = enemies[i].transform.position;
        }

        renderStage();
    }

    public void renderStage()
    {
        if (currentStage != null)
        {
            SetGround(currentStage.GetGround());
            SetEnemies(currentStage.GetEnemies());
            SetScorpion(currentStage.IsScorpion());
            SetCoin(currentStage.GetCoin());
        }
    }


    private void SetGround(int ground)
    {
        for (int i = 0; i < grounds.Length; i++)
        {
            if (i == ground)
            {
                grounds[i].SetActive(true);
            }
            else
            {
                grounds[i].SetActive(false);
            }
        }
        Debug.Log("Ground atual: "+ ground);
    }

    private void SetEnemies(int enemy)
    {
        if (enemy > 0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (i == enemy)
                {
                    enemies[i].SetActive(true);
                }
                else
                {
                    enemies[i].SetActive(false);
                    enemies[i].transform.position = movingPartsRespawn[i];
                }
            }
        }
        else if (enemy <= 0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                    enemies[i].SetActive(false);
                    enemies[i].transform.position = movingPartsRespawn[i];
            }
        }

    }

    private void SetScorpion(bool scor)
    {
        if (scor)
        {
            scorpion.SetActive(true);
        }
        else
        {
            scorpion.SetActive(false);
        }

    }

    private void SetCoin(int coin)
    {
        if (coin > 0)
        {
            for (int i = 0; i < coins.Length; i++)
            {
                if (coin == i)
                {
                    coins[i].SetActive(true) ;
                }
                else
                {
                    coins[i].SetActive(false);
                }
            }
        }else if (coin <= 0)
        {
            for (int i = 0; i < 2; i++)
            {
                coins[i].SetActive(false);
            }
        }
    }

    public void GoLeft()
    {
        currentStage = mapController.GoLeft();
        renderStage();
        Debug.Log("Current Stage: " + currentStage.GetId());
    }

    public void GoRight() 
    {
        currentStage = mapController.GoRight();
        renderStage();
        Debug.Log("Current Stage: " + currentStage.GetId());
    }

    public void CollectCoin()
    {
        mapController.CollectCoin();
    }

}
