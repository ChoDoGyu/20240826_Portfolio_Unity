using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSpawnManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> m_monsterList = new List<GameObject>();

    [SerializeField]
    float m_range = 1f;

    Vector3 m_point;

    SpawnAreaManager m_spawnAreaManager;

    private void Awake()
    {
        m_spawnAreaManager = GetComponent<SpawnAreaManager>();
    }
    private void Start()
    {
        SpawnInPoints();
        //SpawnInOnePoint();
    }
    void CreateMonster(Transform point, int monsterNumber)
    {
        var obj = Instantiate(m_monsterList[monsterNumber]);
        obj.transform.SetParent(transform, false);
        //obj.transform.SetParent(m_spawnAreaManager.m_spawnAreaList[], false);
        if (RandomPoint(point.position, m_range, out m_point))
        {
            obj.transform.position = m_point;
        }
        //obj.transform.position = m_monsterList[monsterNumber].transform.position;
        
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        NavMeshHit hit;
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            
            if(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    void SpawnInPoints()
    {
        for(int i = 0; i < m_spawnAreaManager.m_spawnAreaList.Count; i++)
        {
            int number = Random.Range(0, m_monsterList.Count);
            CreateMonster(m_spawnAreaManager.m_spawnAreaList[i], number);
        }
    }
    void SpawnInOnePoint()
    {
        int monsterNumber = Random.Range(0, m_monsterList.Count);
        int spawnNumber = Random.Range(0, m_spawnAreaManager.m_spawnAreaList.Count);
        CreateMonster(m_spawnAreaManager.m_spawnAreaList[spawnNumber], monsterNumber);
    }
}
