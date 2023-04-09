using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBehavior : MonoBehaviour
{
    public bool reverse = false , stop = false;
    [SerializeField] private List<Transform> roadBlocks = new List<Transform>();
    [SerializeField] private Transform spawnPoint , endPoint;
    private float roadSpeed = 0.2f;
    private void FixedUpdate() {
        if(stop) return;
        for(int i = 0; i < roadBlocks.Count; i++){
            if(reverse){
                roadBlocks[i].position += Vector3.forward * roadSpeed;
            }
            else{
                roadBlocks[i].position -= Vector3.forward * roadSpeed;
            }
            if(roadBlocks[i].position.z >= spawnPoint.position.z){
                roadBlocks[i].position = endPoint.position;
            }
            else if(roadBlocks[i].position.z <= endPoint.position.z){
                roadBlocks[i].position = spawnPoint.position;
            }
        }
    }
}
