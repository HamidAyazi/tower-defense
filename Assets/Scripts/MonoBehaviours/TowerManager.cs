using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private TowerScriptableObject SelectedTowerType;
    private TowerTypesList AttackerTowerTypesList;
    private TowerTypesList SupporterTowerTypesList;
    private Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        GetValidTowers();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(SelectedTowerType.TowerPrefab, GetMouseWorldPosition(), Quaternion.identity);
        }
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 MouseWorldPosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        MouseWorldPosition.z = 0f;
        return MouseWorldPosition;
    }
    private void GetValidTowers()
    {
        AttackerTowerTypesList = Resources.Load<TowerTypesList>("AttackerTowerTypesList");
        SupporterTowerTypesList = Resources.Load<TowerTypesList>("SupporterTowerTypesList");
        SelectedTowerType = AttackerTowerTypesList.List[0];
    }
}
