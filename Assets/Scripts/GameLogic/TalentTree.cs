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
        Talents = new List<TalentData>();
    }
}
