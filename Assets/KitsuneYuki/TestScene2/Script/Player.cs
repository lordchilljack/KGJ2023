using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public event Action LoseBlood , LoseFood , ReverseTime;
    public bool active = true;
    public float loseFoodThreshold = 0.5f;
    private float sensitivity = 0.1f , border = 4f;
    void Update(){
        if(!active) return;
        float mouseX = Input.GetAxisRaw("Mouse X");
        transform.position += Vector3.right * mouseX * sensitivity;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x , -border , border) , transform.position.y , transform.position.z);
        if(Mathf.Abs(mouseX) >= loseFoodThreshold){
            print("扣餐點血");
            LoseFood();
        }
        if(Input.GetKey(KeyCode.Mouse0)){
            print("時光倒流");
            ReverseTime();
        }
    }
    private void OnTriggerEnter(Collider other) {
        print("扣血");
        print("扣餐點血");
        LoseBlood();
        LoseFood();
    }
}
