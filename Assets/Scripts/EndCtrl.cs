using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndCtrl : MonoBehaviour
{
    [SerializeField] private GameObject Background;
    // Start is called before the first frame update
    void Start()
    {
        RandBG();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RandBG();
        }
    }
    public void BackToMain()
    {
        SceneManager.LoadScene(1);
    }
    private void RandBG()
    {
        int ChozenSeed = UnityEngine.Random.Range(0, 8);
        switch (ChozenSeed)
        {
            case 0:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("GE(1)");
                break;
            case 1:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("GE(2)");
                break;
            case 2:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("GE(3)");
                break;
            case 3:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("GE(4)");
                break;
            case 4:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("GE(5)");
                break;
            case 5:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("GE(6)");
                break;
            case 6:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("GE(7)");
                break;
            case 7:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("GE(8)");
                break;
        }
    }
}
