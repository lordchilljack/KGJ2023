using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public bool reverse = false;
    public bool hardmode = false;
    [SerializeField] private List<Transform> carSpawnPoints = new List<Transform>();
    [SerializeField] List<CarView> cars = new List<CarView>();
    private List<CarView> carsOnRoad = new List<CarView>();
    private int levelLength = 30;
    private int range;
    private float carDistance = 10f;
    private void Awake() {
        Init();
    }
    private void FixedUpdate() {
        for(int i = 0; i < carsOnRoad.Count; i++){
            carsOnRoad[i].reverse = reverse;
        }
    }
    public void Init(){
        List<RoadId> map = GenerateLevelLayout();
        PlaceCars(map);
    }
    public void Stop(){
        for(int i = 0; i < carsOnRoad.Count; i++){
            Destroy(carsOnRoad[i].gameObject);
        }
        carsOnRoad.Clear();
    }
    private List<RoadId> GenerateLevelLayout(){
        List<RoadId> roadLayout = new List<RoadId>();
        for(int i = 0; i < levelLength; i++){
            range = Random.Range(0 , (int)RoadId._234);
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
        CarView carView = cars[Random.Range(0 , cars.Count)];
        carView = Instantiate(carView , carSpawnPoints[roadNum].position + new Vector3(0 , 0 , zTransform) , Quaternion.identity);
        float speed;
        if(hardmode){
            speed = Random.Range(10f , 20f);
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
