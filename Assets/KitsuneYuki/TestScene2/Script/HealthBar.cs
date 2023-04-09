using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image upper;
    private Coroutine runningRoutine;
    private float fillSpeed = 0.5f;
    public void SetTo(float percent){
        if(runningRoutine != null){
            StopCoroutine(runningRoutine);
        }
        runningRoutine = StartCoroutine(DelaySetTo(percent));
    }
    private IEnumerator DelaySetTo(float percent){
        while(Mathf.Abs(upper.fillAmount - percent) >= 0.001f){
            upper.fillAmount = Mathf.Lerp(upper.fillAmount , percent , fillSpeed);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }
    public void SetFull(){
        upper.fillAmount = 1f;
    }
}
