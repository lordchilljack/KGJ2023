using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading.Tasks;

public class GM : MonoBehaviour
{
    public int PlayerHP = 3;
    public int MealHP = 100;
    public float ReverseTimer = 10;
    public int ReverseChargeSpeed = 1;
    public bool ReachEnd;
    public int PlayerMoney = 100;
    public int OneOderPayment = 100;
    [SerializeField] private CarSpawner Carspawnser;
    [SerializeField] private HouseBehavior Housebehavior;
    [SerializeField] private RoadBehavior Roadbehavior;
    [SerializeField] private Player player;
    [SerializeField] private HealthBar healthBar, foodHealthBar;
    [SerializeField] private GameObject FinalUI;
    [SerializeField] private List<AudioClip> Sountracks =new List<AudioClip>();
    [SerializeField] private Image TimeBar;

    // Start is called before the first frame update
    void Start()
    {
        //  PlayerHP = 3;
        //  MealHP = 100;
        //  ReverseTimer = 10;
        Carspawnser.GameFinishEvent += PopFinishUI;
        player.LoseBlood += PlayerHPCtrl;
        player.LoseFood += FoodDamaged;
        player.ReverseTime += TimeReverse;
        player.NormalTime += TimeNormal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    async void PlayerHPCtrl()
    {
        if (PlayerHP >= 1)
        {
            healthBar.GetComponent<AudioSource>().clip = Sountracks[3- PlayerHP];
            healthBar.GetComponent<AudioSource>().Play();
            PlayerHP--;
            healthBar.SetTo(PlayerHP / 3f);
            if (PlayerHP <= 0)
            {
                player.active = false;
                Carspawnser.Stop();
                Housebehavior.stop = true;
                Roadbehavior.stop = true;
                await Task.Delay(3000);
                PopFinishUI();
            }
        }  
    }
    void PopFinishUI()
    {
        player.active = false;
        Carspawnser.Stop();
        Housebehavior.stop = true;
        Roadbehavior.stop = true;
        healthBar.gameObject.SetActive(false);
        foodHealthBar.gameObject.SetActive(false);
        TimeBar.gameObject.SetActive(false);
        FinalUI.SetActive(true);
        int paymoney;
        if (PlayerHP == 0)
        {
            FinalUI.transform.Find("comment").GetComponent<TextMeshProUGUI>().text = "You didn't made it";
            FinalUI.transform.Find("Rating").GetComponent<Image>().sprite = Resources.Load<Sprite>("middleFinger");
            FinalUI.transform.Find("comment").GetComponent<TextMeshProUGUI>().color = Color.red;
            FinalUI.transform.Find("Delivery Value").GetComponent<TextMeshProUGUI>().text = "0";
            FinalUI.transform.Find("Delivery Value").GetComponent<TextMeshProUGUI>().color = Color.red;
            paymoney = 0;
        }
        else
        {
            FinalUI.transform.Find("comment").GetComponent<TextMeshProUGUI>().text = "You made it to the destination!";
            FinalUI.transform.Find("comment").GetComponent<TextMeshProUGUI>().color = Color.white;
            if (MealHP >= 66) FinalUI.transform.Find("Rating").GetComponent<Image>().sprite = Resources.Load<Sprite>("thumbs-up"); 
            else FinalUI.transform.Find("Rating").GetComponent<Image>().sprite = Resources.Load<Sprite>("thumbs-down");
            FinalUI.transform.Find("Delivery Value").GetComponent<TextMeshProUGUI>().text = OneOderPayment.ToString();
            FinalUI.transform.Find("Delivery Value").GetComponent<TextMeshProUGUI>().color = Color.white;
            paymoney = (int)(MealHP / 100.0f * OneOderPayment);
        }
        FinalUI.transform.Find("Food Value").GetComponent<TextMeshProUGUI>().text = MealHP.ToString();
        FinalUI.transform.Find("Actual value").GetComponent<TextMeshProUGUI>().text = paymoney.ToString();
        var Totalvalue = paymoney - 20;
        if (Totalvalue > 0)
        {
            FinalUI.transform.Find("Total value").GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        else if (Totalvalue < 0)
        {
            FinalUI.transform.Find("Total value").GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            FinalUI.transform.Find("Total value").GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        FinalUI.transform.Find("Total value").GetComponent<TextMeshProUGUI>().text = Totalvalue.ToString();
        FinalUI.transform.Find("Player Old Value").GetComponent<TextMeshProUGUI>().text = PlayerMoney.ToString();
        PlayerMoney += Totalvalue;
        FinalUI.transform.Find("Player Value").GetComponent<TextMeshProUGUI>().text = PlayerMoney.ToString();
        if (PlayerMoney < 0)
        {
            FinalUI.transform.Find("playnext").gameObject.SetActive(false);
            FinalUI.transform.Find("GoEnding").gameObject.SetActive(true);
        }
        else if (PlayerMoney > 1000)
        {
            FinalUI.transform.Find("playnext").gameObject.SetActive(false);
            FinalUI.transform.Find("GoEnding").gameObject.SetActive(true);
        }
        else
        {
            //resetlevel
        }
    }

    private void FoodDamaged()
    {
        if (MealHP <= 0) return;
        MealHP -= 1;
        foodHealthBar.SetTo(MealHP / 100f);
    }

    private void TimeReverse()
    {
        if (ReverseTimer < 0)
        {
            TimeNormal();
            return;
        }
        ReverseTimer -= Time.fixedDeltaTime;
        TimeBar.fillAmount = ReverseTimer / 10.0f;
        if(!this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Play();
        }
        Carspawnser.reverse = true;
        Roadbehavior.reverse = true;
        Housebehavior.reverse = true;
    }
    private void TimeNormal()
    {
        if (this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Stop();
        }
        if (ReverseTimer < 10)
        {
            ReverseTimer+= (Time.fixedDeltaTime);
            TimeBar.fillAmount = ReverseTimer / 10.0f;
        }
        Carspawnser.reverse = false;
        Roadbehavior.reverse = false;
        Housebehavior.reverse = false;
    }
    public void GotoEnd()
    {
        if (PlayerMoney >= 1000)
        {
            SceneManager.LoadScene(4);
        }
        if (PlayerMoney < 0)
        {
            SceneManager.LoadScene(5);
        }
    }
    public void PlayNextRound()
    {
        player.active = true;
        Carspawnser.Init();
        Housebehavior.stop = false;
        Roadbehavior.stop = false;
        healthBar.SetFull();
        foodHealthBar.SetFull();
        PlayerHP = 3;
        MealHP = 100;
        ReverseTimer = 10;
        healthBar.gameObject.SetActive(true);
        foodHealthBar.gameObject.SetActive(true);
        TimeBar.gameObject.SetActive(true);
        FinalUI.SetActive(false);
    }
}
