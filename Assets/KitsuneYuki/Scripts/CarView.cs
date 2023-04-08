using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarView : MonoBehaviour
{
    [SerializeField] private Rigidbody rgBody;
    private float carSpeed = 10f , liveTime = 10f;
    private void Awake() {
        Destroy(gameObject , liveTime);
    }
    private void FixedUpdate() {
        rgBody.velocity = new Vector3(0 , rgBody.velocity.y , -carSpeed);
    }
}
