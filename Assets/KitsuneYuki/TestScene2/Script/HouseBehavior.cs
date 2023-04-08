using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBehavior : MonoBehaviour
{
    public bool reverse = false;
    [SerializeField] private List<Transform> houses = new List<Transform>();
    [SerializeField] private Transform spawnPoint , endPoint;
    private float houseSpeed = 0.2f;
    private void FixedUpdate() {
        for(int i = 0; i < houses.Count; i++){
            if(reverse){
                houses[i].transform.position += Vector3.forward * houseSpeed;
            }
            else{
                houses[i].transform.position -= Vector3.forward * houseSpeed;
            }
            if(houses[i].position.z >= spawnPoint.position.z){
                houses[i].position = new Vector3(houses[i].position.x , houses[i].position.y , endPoint.position.z);
            }
            else if(houses[i].position.z <= endPoint.position.z){
                houses[i].position = new Vector3(houses[i].position.x , houses[i].position.y , spawnPoint.position.z);
            }
        }
    }
}
