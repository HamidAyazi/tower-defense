using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentManager : MonoBehaviour
{
    [SerializeField] private List<TalentButton> talentButtons = new List<TalentButton>();
    void Start()
    {
        foreach( TalentButton talent in talentButtons){
            talent.loadTalent();
        }
        talentButtons[0].UnlockChildNodes();
    }
}
