using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentTree
{
    public int StartMoney;
    public int StartHealthPoint;
    public List<TalentData> Talents;
    public TalentTree()
    {
        StartMoney = 100;
        StartHealthPoint = 100;
    }
    // public static setTalent(TalentButton talent){
    //     return Maps.Find(Map => Map.MapID == MapID);
    // }
}
