using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float sensitivity = 0.1f;
    void Update(){
        float mouseX = Input.GetAxisRaw("Mouse X");
        transform.position += Vector3.right * mouseX * sensitivity;
        if(mouseX >= 0.2f){
            print("扣餐點血");
        }
    }
    private void OnTriggerEnter(Collider other) {
        print("扣血");
    }
}
