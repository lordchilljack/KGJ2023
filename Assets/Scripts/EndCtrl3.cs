using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndCtrl3 : MonoBehaviour
{
    [SerializeField] private GameObject Background;
    // Start is called before the first frame update
    void Start()
    {
        BGRand();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            BGRand();
        }
    }
    public void BackToMain()
    {
        SceneManager.LoadScene(1);
    }
    private void BGRand()
    {
        int ChozenSeed = UnityEngine.Random.Range(0, 5);
        switch (ChozenSeed)
        {
            case 0:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("HE0");
                break;
            case 1:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("HE1");
                break;
            case 2:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("HE2");
                break;
            case 3:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("HE3");
                break;
            case 4:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("HE4");
                break;
        }
    }
}
