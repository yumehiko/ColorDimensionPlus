using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SetGeometory : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D geometory = default;
    [SerializeField] private List<PolygonCollider2D> subtracts = default;

    void Start()
    {
        geometory.pathCount = subtracts.Count+1;
        for (int i = 0; i < subtracts.Count; i++)
        {
            Vector2[] addPath = GetPathWithOffset(subtracts[i]);
            geometory.SetPath(i+1, addPath);
        }
    }


    /// <summary>
    /// ポリゴンのWorld座標を計算して、正しいPath位置に直す。
    /// </summary>
    private Vector2[] GetPathWithOffset(PolygonCollider2D targetPolygon)
    {
        Vector2 targetPosition = targetPolygon.transform.localPosition;
        Vector2[] path = targetPolygon.GetPath(0);

        for(int i = 0; i < path.Length; i++)
        {
            path[i] += targetPosition;
        }

        return path;
    }
}