using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private Transform SelectedTowerType;
    private TowerTypesList AvailableAttackerTowerTypesList;
    private TowerTypesList AvailableSupporterTowerTypesList;
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
            Instantiate(SelectedTowerType, GetMouseWorldPosition(), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedTowerType = AvailableAttackerTowerTypesList.List[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedTowerType = AvailableAttackerTowerTypesList.List[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedTowerType = AvailableSupporterTowerTypesList.List[0];
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
        AvailableAttackerTowerTypesList = Resources.Load<TowerTypesList>("ScriptableObjects/AttackerTowerTypesList");
        AvailableSupporterTowerTypesList = Resources.Load<TowerTypesList>("ScriptableObjects/SupporterTowerTypesList");
        SelectedTowerType = AvailableAttackerTowerTypesList.List[0];
    }
}
