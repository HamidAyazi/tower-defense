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

    public void GetTalentSpeed3x(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.speed3x = true;
    }
    public void GetTalentInfinity(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.infinity = true;
    }
    public void GetTalentBonusCash(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.bonusCash += 3;
    }
    public void GetTalentWaveInterval(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.waveInterval += 1;
    }
    public void GetTalentEarlyWaveBonusPoint(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.earlyWaveBonusPoint += 2;
    }
    public void GetTalentRotationSpeed(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.rotationSpeed += 3f;
    }
    public void GetTalentRange(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.range += 3f;
    }
    public void GetTalentProjectileSpeed(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.ProjectileSpeed += 3f;
    }
    public void GetTalentDamage(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.damage += 3f;
    }
    public void GetTalentAttackSpeed(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.attackSpeed += 3f;
    }
    public void GetTalentBaseHealth(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.baseHealth += 2;
    }
    public void GetTalentStartingMoney(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.startingMoney += 10;
    }
    public void GetTalentEnemyDropCoin(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.EnemyDropCoin += 1; 
    }
    public void GetTalentMaxUpgradeLevel(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.maxUpgradeLevel +=1; 
    }
    public void GetTalentStartingLevel(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.StartingLevel += 1; 
    }
    public void GetTalentDiscount(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.Discount += 3f; 
    }
    public void GetTalentTowerRefund(){
        SaveManager.Instance.Data.playerStats.PlayerTalentTree.TowerRefund += 3f;
    }
}
