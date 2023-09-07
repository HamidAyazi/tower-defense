using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaypointsScript : MonoBehaviour
{
    private static List<Vector3> points;

    void Awake() {
        points = new List<Vector3>();
    }
    public static void AddPoint(Vector3 TilePosition) { points.Add(TilePosition); }
    public static Vector3 GetPosition(int index) { return points[index]; }
    public static int GetCount() { return points.Count; }

}
