using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Controller
{
    private const int secToMillisec = 1000;
    private float generateCarRate = 1f;
    private View view;
    private LevelLayoutModel levelLayoutModel;
    public void Main(View view){
        this.view = view;
        levelLayoutModel = new LevelLayoutModel();
        CreateLevel();
    }
    private async void CreateLevel(){
        List<roadId> levelLayout = levelLayoutModel.GenerateLevelLayout();
        for(int i = 0; i < levelLayout.Count; i++){
            switch(levelLayout[i]){
                case roadId._1:
                    view.GenerateOnOne();
                    break;
                case roadId._2:
                    view.GenerateOnTwo();
                    break;
                case roadId._3:
                    view.GenerateOnThree();
                    break;
                case roadId._4:
                    view.GenerateOnFour();
                    break;
                case roadId._12:
                    view.GenerateOnOne();
                    view.GenerateOnTwo();
                    break;
                case roadId._13:
                    view.GenerateOnOne();
                    view.GenerateOnThree();
                    break;
                case roadId._14:
                    view.GenerateOnOne();
                    view.GenerateOnFour();
                    break;
                case roadId._23:
                    view.GenerateOnTwo();
                    view.GenerateOnThree();
                    break;
                case roadId._24:
                    view.GenerateOnTwo();
                    view.GenerateOnFour();
                    break;
                case roadId._34:
                    view.GenerateOnThree();
                    view.GenerateOnFour();
                    break;
                case roadId._123:
                    view.GenerateOnOne();
                    view.GenerateOnTwo();
                    view.GenerateOnThree();
                    break;
                case roadId._124:
                    view.GenerateOnOne();
                    view.GenerateOnTwo();
                    view.GenerateOnFour();
                    break;
                case roadId._134:
                    view.GenerateOnOne();
                    view.GenerateOnThree();
                    view.GenerateOnFour();
                    break;
                case roadId._234:
                    view.GenerateOnTwo();
                    view.GenerateOnThree();
                    view.GenerateOnFour();
                    break;
            }
            await Task.Delay((int)(generateCarRate * secToMillisec));
        }
    }
}
