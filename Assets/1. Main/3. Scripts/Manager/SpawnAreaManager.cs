using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAreaManager : MonoBehaviour
{
    [SerializeField]
    GameObject m_spawnArea;

    [SerializeField]
    public List<Transform> m_spawnAreaList = new List<Transform>();
    void Awake()
    {
        m_spawnAreaList = GetAllChildren(m_spawnArea.transform);
    }
    static List<Transform> GetAllChildren(Transform parent, List<Transform> transformList = null)
    {
        if (transformList == null)
        {
            transformList = new List<Transform>();
        }
        foreach (Transform child in parent)
        {
            transformList.Add(child);
            GetAllChildren(child, transformList);
        }
        return transformList;
    }
}
