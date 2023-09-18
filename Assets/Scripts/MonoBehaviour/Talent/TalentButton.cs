using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
public class TalentButton : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private Button btn;
    [SerializeField] private string nodeName;
    [SerializeField] private int Level;
    [SerializeField] private int MaxLevel;
    [SerializeField] private bool isUnlocked = false;
    [SerializeField] private int MinReqLevel;
    [SerializeField] private Color ColorFull;
    [SerializeField] private Color ColorAvailable;
    [SerializeField] private Color ColorUnavailable;


    public List<TalentButton> ParentNodes = new List<TalentButton>();
    public List<TalentButton> ChildNodes = new List<TalentButton>();





    void Start()
    {
        updateTalent();
        UnlockNode();
        setColor();
    }

    public void UnlockNode() {
        if(!isUnlocked){
            btn.interactable = false;
            bool canUnlock = true;
            foreach (TalentButton talent in ParentNodes)
            {
                if(talent.Level < MinReqLevel) canUnlock = false;
            }
            if(canUnlock){
                isUnlocked = true;
                btn.interactable = true;
            }
            setColor();
        }
    }

    public void CheckChildUnlock(){
        foreach(TalentButton talent in ChildNodes){
                Debug.Log(talent.nodeName); 
            if(!talent.isUnlocked) {
                talent.UnlockNode();
            }
        }
    }

    public void getTalent(){
        Level +=1;
        UnlockNode();
        CheckChildUnlock();
        updateTalent();
        setColor();
    }

    public void setColor(){
        if(Level >= MaxLevel){
            btn.targetGraphic.color = ColorFull;
        } else if (!isUnlocked) {
            btn.targetGraphic.color = ColorUnavailable;
        } else {
            btn.targetGraphic.color = ColorAvailable;
        }
    }


    public void updateTalent(){
        TalentData talent = SaveManager.Instance.Data.playerStats.PlayerTalentTree.Talents.Find(talent => talent.id == id);
        if(talent == null) {
            TalentData talentData = new TalentData
            {
                id = id,
                MaxLevel = MaxLevel,
                nodeName = nodeName,
                Level = Level,
                isUnlocked = isUnlocked,
                MinReqLevel = MinReqLevel
            };
            SaveManager.Instance.Data.playerStats.PlayerTalentTree.Talents.Add(talentData);
        } else {
            Level = talent.Level;
            isUnlocked = talent.isUnlocked;
            setColor();
        }
    }
}

[System.Serializable]
public class TalentData
{
    public int id;
    public int MaxLevel;
    public string nodeName;
    public int Level;
    public bool isUnlocked;
    public int MinReqLevel;
    
}