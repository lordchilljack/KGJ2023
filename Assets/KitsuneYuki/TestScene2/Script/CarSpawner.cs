using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarSpawner : MonoBehaviour
{
    public event Action GameFinishEvent;
    public bool reverse = false;
    public bool hardmode = false;
    [SerializeField] private List<Transform> carSpawnPoints = new List<Transform>();
    [SerializeField] List<CarView> cars = new List<CarView>();
    [SerializeField] private CheckPoint checkPoint;
    private List<CarView> carsOnRoad = new List<CarView>();
    private int levelLength = 30 , carPassCount = 0;
    private float carDistance = 10f;
    private void Awake() {
        checkPoint.CarPassEvent += CheckMethod;
        Init();
    }
    private void FixedUpdate() {
        for(int i = 0; i < carsOnRoad.Count; i++){
            carsOnRoad[i].reverse = reverse;
        }
    }
    public void Init(){
        carPassCount = 0;
        List<RoadId> map = GenerateLevelLayout();
        PlaceCars(map);
    }
    public void Stop(){
        for(int i = 0; i < carsOnRoad.Count; i++){
            Destroy(carsOnRoad[i].gameObject);
        }
        carsOnRoad.Clear();
    }
    private void CheckMethod(bool rev){
        if(rev){
            carPassCount--;
        }
        else{
            carPassCount++;
        }
        if(carPassCount == carsOnRoad.Count){
            //完成一單
            GameFinishEvent();
        }
    }
    private List<RoadId> GenerateLevelLayout(){
        List<RoadId> roadLayout = new List<RoadId>();
        int range;
        for(int i = 0; i < levelLength; i++){
            range = UnityEngine.Random.Range(0 , (int)RoadId._234);
            RoadId r = (RoadId)range;
            roadLayout.Add(r);
        }
        return roadLayout;
    }
    private void PlaceCars(List<RoadId> roadList){
        float z = 0;
        for(int i = 0; i < roadList.Count; i++){
            switch(roadList[i]){
                case RoadId._1:
                    SpawnCarAt(0 , z);
                    break;
                case RoadId._2:
                    SpawnCarAt(1 , z);
                    break;
                case RoadId._3:
                    SpawnCarAt(2 , z);
                    break;
                case RoadId._4:
                    SpawnCarAt(3 , z);
                    break;
                case RoadId._12:
                    SpawnCarAt(0 , z);
                    SpawnCarAt(1 , z);
                    break;
                case RoadId._13:
                    SpawnCarAt(0 , z);
                    SpawnCarAt(2 , z);
                    break;
                case RoadId._14:
                    SpawnCarAt(0 , z);
                    SpawnCarAt(3 , z);
                    break;
                case RoadId._23:
                    SpawnCarAt(1 , z);
                    SpawnCarAt(2 , z);
                    break;
                case RoadId._24:
                    SpawnCarAt(1 , z);
                    SpawnCarAt(3 , z);
                    break;
                case RoadId._34:
                    SpawnCarAt(2 , z);
                    SpawnCarAt(3 , z);
                    break;
                case RoadId._123:
                    SpawnCarAt(0 , z);
                    SpawnCarAt(1 , z);
                    SpawnCarAt(2 , z);
                    break;
                case RoadId._124:
                    SpawnCarAt(0 , z);
                    SpawnCarAt(1 , z);
                    SpawnCarAt(3 , z);
                    break;
                case RoadId._134:
                    SpawnCarAt(0 , z);
                    SpawnCarAt(2 , z);
                    SpawnCarAt(3 , z);
                    break;
                case RoadId._234:
                    SpawnCarAt(1 , z);
                    SpawnCarAt(2 , z);
                    SpawnCarAt(3 , z);
                    break;
            }
            z += carDistance;
        }
    }
    private void SpawnCarAt(int roadNum , float zTransform){
        int R = UnityEngine.Random.Range(0, cars.Count);
        CarView carView = cars[R];
        carView = Instantiate(carView , carSpawnPoints[roadNum].position + new Vector3(0 , 0 , zTransform) , Quaternion.identity);
        if (roadNum < 2)
        {
            if (R < 2)
            {
                carView.transform.GetChild(0).localScale = new Vector3(1, -1, 1);
            }
            else
            {
                carView.transform.GetChild(0).localScale = new Vector3(1, 1, -1);
            }
        }
        float speed;
        if(hardmode){
            speed = UnityEngine.Random.Range(10f , 20f);
        }
        else{
            speed = 15f;
        }
        carView.Initiate(carSpawnPoints , carDistance , levelLength , speed , hardmode);
        carsOnRoad.Add(carView);
    }
}
public enum RoadId{
    _1,
    _2,
    _3,
    _4,
    _12,
    _13,
    _14,
    _23,
    _24,
    _34,
    _123,
    _124,
    _134,
    _234
}
