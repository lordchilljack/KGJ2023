using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarView : MonoBehaviour
{
    [HideInInspector] public bool reverse = false;
    private bool hardmode = false;
    private int index = 0 , levelLength;
    private float carSpeed = 10f;
    private List<Vector3> trace = new List<Vector3>();
    [SerializeField] private Rigidbody rgBody;
    private void FixedUpdate() {
        if(reverse){
            index = Mathf.Clamp(index , 0 , levelLength - 1);
            Vector3 vec = trace[index] - transform.position;
            if(transform.position.z < trace[index].z){
                float xMovement;
                if(Mathf.Abs(vec.x) < 0.1f){
                    xMovement = 0;
                }
                else{
                    if(vec.x > 0){
                        xMovement = 1;
                    }
                    else{
                        xMovement = -1;
                    }
                }
                rgBody.velocity = Vector3.forward * carSpeed + new Vector3(xMovement , 0 , 0) * carSpeed/2;
            }
            else{
                index--;
            }
        }
        else{
            index = Mathf.Clamp(index , 0 , levelLength - 1);
            Vector3 vec = trace[index] - transform.position;
            if(transform.position.z > trace[index].z){
                float xMovement;
                if(Mathf.Abs(vec.x) < 0.1f){
                    xMovement = 0;
                }
                else{
                    if(vec.x > 0){
                        xMovement = 1;
                    }
                    else{
                        xMovement = -1;
                    }
                }
                rgBody.velocity = Vector3.back * carSpeed + new Vector3(xMovement , 0 , 0) * carSpeed/2;
            }
            else{
                index++;
            }
        }
    }
    public void Initiate(List<Transform> roads , float carDistance , int levelLength , float carSpeed , bool hardmode){
        this.carSpeed = carSpeed;
        this.hardmode = hardmode;
        GenerateTrace(roads , carDistance , levelLength);
    }
    private void GenerateTrace(List<Transform> roads , float carDistance , int levelLength){
        float z = transform.position.z;
        int length = levelLength + levelLength;
        this.levelLength = length;
        float x;
        for(int i = 0; i < length; i++){
            if(hardmode){
                x = roads[Random.Range(0 , roads.Count)].position.x;
            }
            else{
                x = transform.position.x;
            }
            trace.Add(new Vector3(x , transform.position.y , z));
            z -= carDistance;
        }
    }
}
