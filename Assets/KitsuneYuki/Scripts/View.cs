using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    private Controller controller;
    [SerializeField] private CarGeneratorView carGeneratorView;
    private void Awake() {
        controller = new Controller();
        controller.Main(this);
        carGeneratorView.Initialize();
    }
    public void GenerateOnOne(){
        carGeneratorView.GenerateOnOne();
    }
    public void GenerateOnTwo(){
        carGeneratorView.GenerateOnTwo();
    }
    public void GenerateOnThree(){
        carGeneratorView.GenerateOnThree();
    }
    public void GenerateOnFour(){
        carGeneratorView.GenerateOnFour();
    }
}
