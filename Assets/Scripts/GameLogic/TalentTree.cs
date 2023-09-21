using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentTree
{
    public int StartMoney;
    public int StartHealthPoint;
    public int Cash;

    public List<TalentData> Talents;
    public TalentTree()
    {
        Talents = new List<TalentData>();
        Cash = 0;
    }
}
