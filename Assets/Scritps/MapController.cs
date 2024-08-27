using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class MapController{

    private enum groundType {safe, ladder, ladderThreeHoles, oneHole, threeHoles, pitfall};
    private enum enemyType {safe, snake, fire, log, rollingLog, threeRolingLogs};
    private enum hascoin {no, above, below};

    [SerializeField] private static Stage[] stages;
    [SerializeField] private static int currentStageIndex;

    static MapController()
    {   
        stages = new Stage[25];
        stages[0] = new Stage(0, (int)hascoin.no, (int)groundType.safe, (int)enemyType.safe, true);

        for (int i = 1; i < stages.Length; i++)
        {
            bool scorpion = Random.Range(0,2) == 0;
            int ground = Random.Range(0,6);
            int enemy = Random.Range(0, 6);
            int coin = Random.Range(0, 3);

            Stage newStage = new Stage(i, coin, ground, enemy, scorpion);
            stages[i] = newStage;
        }

        currentStageIndex = 0;

    }

    internal Stage GoLeft()
    {
        currentStageIndex = currentStageIndex - 1;
        if (currentStageIndex < 0)
        {
            currentStageIndex = stages.Length - 1;
        }
        return stages[currentStageIndex];
    }

    internal Stage GoRight()
    {
        currentStageIndex = currentStageIndex + 1;
        if (currentStageIndex >= stages.Length)
        {
            currentStageIndex = 0;
        }
        return stages[currentStageIndex];
    }

    internal Stage getCurrentStage() { return stages[currentStageIndex]; }

    internal void CollectCoin()
    {
        Stage current = getCurrentStage();

        if (current.GetCoin() != 0)
        {
            current.CollectCoin();
            stages[currentStageIndex] = current;
        }
    }
}
