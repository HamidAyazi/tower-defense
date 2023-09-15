using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaypointsScript : MonoBehaviour
{
    private static List<Vector3> points;

    private void Awake() {
        points = new List<Vector3>();
    }
    /// <summary>
    /// Add position of the <c>EnemyPathTile</c> to <c>points</c> list.
    /// </summary>
    /// <param name="TilePosition">Position of <c>EnemyPathTile</c>.</param>
    public static void AddPoint(Vector3 TilePosition) { points.Add(TilePosition); }

    /// <summary>
    /// Get position of a <c>EnemyPathTile</c>.
    /// </summary>
    /// <param name="index">Index of the <c>EnemyPathTile</c>.</param>
    /// <returns>Position in Vector3.</returns>
    public static Vector3 GetPosition(int index) { return points[index]; }

    /// <summary>
    /// Get number of placed <c>EnemyPathTile</c>.
    /// </summary>
    /// <returns>Size of the <c>points</c> list.</returns>
    public static int GetCount() { return points.Count; }

}
