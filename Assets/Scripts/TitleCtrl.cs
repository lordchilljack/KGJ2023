using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TitleCtrl : MonoBehaviour
{
    private List<string> _keyStrokeHistory;
    public GameObject HiddenButton;
    public GameObject HelpMenu;
    public int ChozenSeed;

    void Awake()
    {
        _keyStrokeHistory = new List<string>();
    }

    // Start is called before the first frame update
    void Start()
    {
        RandBG();
    }

    // Update is called once per frame
    void Update()
    {
        KeyCode keyPressed = DetectKeyPressed();
        if (keyPressed == KeyCode.R)
        {
            RandBG();
        }
            AddKeyStrokeToHistory(keyPressed.ToString());
        
        if (GetKeyStrokeHistory().Equals("UpArrow,UpArrow,DownArrow,DownArrow,LeftArrow,RightArrow,LeftArrow,RightArrow,B,A"))
        {
            HiddenButton.SetActive(true);
            ClearKeyStrokeHistory();
        }
    }

    private KeyCode DetectKeyPressed()
    {
        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                return key;
            }
        }
        return KeyCode.None;
    }

    private void AddKeyStrokeToHistory(string keyStroke)
    {
        if (!keyStroke.Equals("None"))
        {
            _keyStrokeHistory.Add(keyStroke);
            if (_keyStrokeHistory.Count > 10)
            {
                _keyStrokeHistory.RemoveAt(0);
            }
        }
    }

    private string GetKeyStrokeHistory()
    {
        return String.Join(",", _keyStrokeHistory.ToArray());
    }

    private void ClearKeyStrokeHistory()
    {
        _keyStrokeHistory.Clear();
    }
    public void CallHelp()
    {
        if(!HelpMenu.gameObject.activeSelf) HelpMenu.gameObject.SetActive(true);
        else HelpMenu.gameObject.SetActive(false);
    }

    private void RandBG()
    {
        ChozenSeed = UnityEngine.Random.Range(0, 5);
        switch (ChozenSeed)
        {
            case 0:
                this.GetComponent<Image>().sprite = Resources.Load<Sprite>("title0");
                break;
            case 1:
                this.GetComponent<Image>().sprite = Resources.Load<Sprite>("title1");
                break;
            case 2:
                this.GetComponent<Image>().sprite = Resources.Load<Sprite>("title2");
                break;
            case 3:
                this.GetComponent<Image>().sprite = Resources.Load<Sprite>("title3");
                break;
            case 4:
                this.GetComponent<Image>().sprite = Resources.Load<Sprite>("title4");
                break;

        }
    }
}
