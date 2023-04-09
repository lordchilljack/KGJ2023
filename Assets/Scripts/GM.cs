using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public int PlayerHP = 3;
    public int MealHP = 100;
    public float ReverseTimer = 10;
    public int ReverseChargeSpeed = 1;
    public bool ReachEnd;
    public int PlayerMoney = 100;
    [SerializeField] private CarSpawner Carspawnser;
    [SerializeField] private HouseBehavior Housebehavior;
    [SerializeField] private RoadBehavior Roadbehavior;
    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {
        //  PlayerHP = 3;
        //  MealHP = 100;
        //  ReverseTimer = 10;
        Carspawnser.GameFinishEvent += PopFinishUI;
        player.LoseBlood += PlayerHPCtrl;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IsplayerDead(int PlayerHP)
    {
        if (PlayerHP <= 0)
        {
            print("算餐失敗");
            //進結算畫面 -油錢 20
        }
    }
    void IsPlayerBroke(int PlayerMoney)
    {
        if (PlayerMoney <= 0)
        {
            print("破產");
            //load 破產結局
        }
    }
    void IsPLayerWin(int PLayerMoney)
    {
        if (PlayerMoney <= 1000)
        {
            print("財富自由");
            //load 破產結局
        }
    }
    void PlayerHPCtrl()
    {
        if (PlayerHP >= 1)
        {
            PlayerHP--;
        }  
    }
    void PopFinishUI()
    {
        player.active = false;
        Carspawnser.Stop();
        Housebehavior.stop = true;
        Roadbehavior.stop = true;
    }
}
