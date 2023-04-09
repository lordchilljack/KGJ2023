using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndCtrl2 : MonoBehaviour
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
        SceneManager.LoadScene(0);
    }
    private void BGRand()
    {
        int ChozenSeed = UnityEngine.Random.Range(0, 6);
        switch (ChozenSeed)
        {
            case 0:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("BE(1)");
                break;
            case 1:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("BE(2)");
                break;
            case 2:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("BE(3)");
                break;
            case 3:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("BE(4)");
                break;
            case 4:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("BE(5)");
                break;
            case 5:
                Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("BE(6)");
                break;
        }
    }
}
