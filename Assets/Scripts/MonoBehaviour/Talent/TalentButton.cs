using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
public class TalentButton : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] private Button btn;
    [SerializeField] private string nodeName;
    [SerializeField] private string nodeDescription;
    [SerializeField] public int Level;
    [SerializeField] private int MaxLevel;
    [SerializeField] private bool isUnlocked = false;
    [SerializeField] private int MinReqLevel;
    [SerializeField] private Color ColorFull;
    [SerializeField] private Color ColorUnavailable;

    [SerializeField] private TMPro.TextMeshProUGUI TName;
    [SerializeField] private TMPro.TextMeshProUGUI Tlevel;
    [SerializeField] private TMPro.TextMeshProUGUI Tdesc;

    public List<TalentButton> ParentNodes = new List<TalentButton>();
    public List<TalentButton> ChildNodes = new List<TalentButton>();


    private void Awake(){
        btn.targetGraphic.color = ColorUnavailable;
    }
    public void UnlockChildNodes() {
        foreach(TalentButton talent in ChildNodes){
            if (!talent.isUnlocked) {
                if(talent.MinReqLevel <= Level) {
                    talent.isUnlocked = true;
                    talent.updateButton();
                    talent.UnlockChildNodes();
                }
            }
        }
    }


    public void getTalent(){
        SoundManager.PlaySound(Sound.ButtonClick);
        Level +=1;

        TName.text = nodeName;
        Tlevel.text = Level.ToString();
        Tdesc.text = nodeDescription;

        UnlockChildNodes();
        updateButton();
        updateTalent();
    }

    public void updateButton(){
        btn.targetGraphic.color = Color.white;
        if(Level >= MaxLevel){
            btn.interactable = false;
            btn.targetGraphic.color = ColorFull;
        } else if (!isUnlocked) {
            btn.interactable = false;
            btn.targetGraphic.color = ColorUnavailable;
        } else {
            //Debug.Log(nodeName);
            btn.interactable = true;
            btn.targetGraphic.color = Color.white;
        }
    }


    public void loadTalent(){
        TalentData talent = SaveManager.Instance.Data.playerStats.PlayerTalentTree.Talents.Find(talent => talent.id == id);
        if(talent == null) {
            TalentData talentData = new TalentData
            {
                id = id,
                Level = Level,
                isUnlocked = isUnlocked
            };
            SaveManager.Instance.Data.playerStats.PlayerTalentTree.Talents.Add(talentData);
        } else {
            Level = talent.Level;
            // isUnlocked = talent.isUnlocked;
        }
    }

    private void updateTalent(){
        int index = SaveManager.Instance.Data.playerStats.PlayerTalentTree.Talents.FindIndex(talent => talent.id == id);
        if (index != -1)
        {
            TalentData talentData = new TalentData
            {
                id = id,
                Level = Level,
                isUnlocked = isUnlocked
            };
            SaveManager.Instance.Data.playerStats.PlayerTalentTree.Talents[index] = talentData;
        }
    }

}

public class TalentData
{
    public int id;
    public int MaxLevel;
    public string nodeName;
    public int Level;
    public bool isUnlocked;
    public int MinReqLevel;
    
}