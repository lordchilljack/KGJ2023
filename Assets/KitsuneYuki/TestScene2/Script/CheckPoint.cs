using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public event Action<bool> CarPassEvent;
    private void OnTriggerEnter(Collider other) {
        CarView carView = other.GetComponent<CarView>();
        if(carView != null){
            CarPassEvent(carView.reverse);
        }
    }
}
