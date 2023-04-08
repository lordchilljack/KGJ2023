using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLayoutModel
{
    List<roadId> roadLayout = new List<roadId>();
    int levelLength = 30;
    public void GenerateLevelLayout(){
        for(int i = 0; i < levelLength; i++){
            int range = Random.Range(0 , (int)roadId._234);
            roadId r = (roadId)range;
            roadLayout.Add(r);
        }
    }
}
public enum roadId{
    _1,
    _2,
    _3,
    _4,
    _12,
    _13,
    _14,
    _23,
    _24,
    _34,
    _123,
    _124,
    _134,
    _234
}
// 1   2   3   4