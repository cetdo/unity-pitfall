using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    private readonly int id;
    private readonly int ground;
    private readonly int enemies;
    private readonly bool scorpion;
    private int coin;


    public Stage(int id, int coin, int ground, int enemies, bool scorpion)
    {
        this.id = id;
        this.coin = coin;
        this.ground = ground;
        this.enemies = enemies;
        this.scorpion = scorpion;
    }
    public int GetId() { return id; }
    public int GetCoin() { return coin; }
    public int GetGround() { return ground;}
    public int GetEnemies() {  return enemies;}
    public bool IsScorpion() {  return scorpion;}

    public void CollectCoin()
    {
        this.coin = 0;
    }

}
