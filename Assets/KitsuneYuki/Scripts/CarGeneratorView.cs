using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGeneratorView : MonoBehaviour
{
    [SerializeField] List<Transform> carSpawnLocations = new List<Transform>();
    [SerializeField] private List<GameObject> cars = new List<GameObject>();
    public void Initialize(){

    }
    public void GenerateOnOne(){
        GameObject car = PickCar();
        Instantiate(car , carSpawnLocations[0]);
    }
    public void GenerateOnTwo(){
        GameObject car = PickCar();
        Instantiate(car , carSpawnLocations[1]);
    }
    public void GenerateOnThree(){
        GameObject car = PickCar();
        Instantiate(car , carSpawnLocations[2]);
    }
    public void GenerateOnFour(){
        GameObject car = PickCar();
        Instantiate(car , carSpawnLocations[3]);
    }
    private GameObject PickCar(){
        int carNum = Random.Range(0 , cars.Count);
        return cars[carNum];
    }
}
