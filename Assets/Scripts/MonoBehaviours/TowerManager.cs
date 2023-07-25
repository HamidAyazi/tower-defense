using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField]
    private TowerScriptableObject TowerType;
    private Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        Debug.Log( Resources.Load<TowerTypesList>(typeof(TowerTypesList).Name));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(TowerType.TowerPrefab, GetMouseWorldPosition(), Quaternion.identity);
        }
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 MouseWorldPosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        MouseWorldPosition.z = 0f;
        return MouseWorldPosition;
    }
}
