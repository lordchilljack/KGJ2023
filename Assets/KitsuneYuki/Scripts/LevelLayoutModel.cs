using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLayoutModel
{
    private int levelLength = 30;
    private int range;
    public List<roadId> GenerateLevelLayout(){
        List<roadId> roadLayout = new List<roadId>();
        for(int i = 0; i < levelLength; i++){
            range = Random.Range(0 , (int)roadId._234);
            roadId r = (roadId)range;
            roadLayout.Add(r);
        }
        return roadLayout;
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
