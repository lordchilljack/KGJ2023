using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualGameMaster : MonoBehaviour
{
    [SerializeField] private CarSpawner carSpawner;
    [SerializeField] private RoadBehavior roadBehavior;
    [SerializeField] private HouseBehavior houseBehavior;
    [SerializeField] private Player player;
    [SerializeField] private HealthBar healthBar , foodHealthBar;
    private float playerHealth = 3f , foodHealh = 100f;
    private void Awake() {
        carSpawner.GameFinishEvent += GameFinished;
        player.LoseBlood += Damaged;
        player.LoseFood += FoodDamaged;
        player.ReverseTime += TimeReverse;
        player.NormalTime += TimeNormal;
    }
    private void Damaged(){
        playerHealth -= 1;
        healthBar.SetTo(playerHealth / 3f);
        if(playerHealth <= 0){
            PopFinal();
        }
    }
    private void FoodDamaged(){
        foodHealh -= 1;
        foodHealthBar.SetTo(foodHealh / 100f);
        if(foodHealh <= 0){
            PopFinal();
        }
    }
    private void TimeReverse(){
        carSpawner.reverse = true;
        roadBehavior.reverse = true;
        houseBehavior.reverse = true;
    }
    private void TimeNormal(){
        carSpawner.reverse = false;
        roadBehavior.reverse = false;
        houseBehavior.reverse = false;
    }
    private void GameFinished(){
        PopFinal();
    }
    private void PopFinal(){
        carSpawner.Stop();
        player.active = false;
        houseBehavior.stop = true;
        roadBehavior.stop = true;
        print("結算");
    }
}
