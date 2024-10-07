using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSpawnManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> m_monsterList = new List<GameObject>();

    [SerializeField]
    float m_range = 1f;

    Vector3 m_point;
    bool m_spawn = false;

    SpawnAreaManager m_spawnAreaManager;

    [SerializeField, Header("스폰지역마다 소환 숫자")]
    int m_maxMonsterNumber = 3;

    [SerializeField, Header("소환 쿨타임")]
    float m_spawnTime = 30f;
    [SerializeField]
    private float m_spawnLastTime = 0f;
    [SerializeField, Header("각 포인트 소환 숫자")]
    int m_spawnNumbers = 3;

    

    private void Awake()
    {
        m_spawnAreaManager = GetComponent<SpawnAreaManager>();
    }
    private void Start()
    {
        SpawnInPoints();
        //SpawnInOnePoint();
    }
    private void Update()
    {
        if (Time.time > m_spawnLastTime + m_spawnTime)
        {
            SpawnInPoints();
            m_spawnLastTime = Time.time;
        }
    }
    GameObject CreateMonster(Transform point, int monsterNumber)
    {
        float xRandom = Random.Range(-2f, 2f);
        float zRandom = Random.Range(-2f, 2f);
        Vector3 randomPos = new Vector3(xRandom, 0, zRandom);
        GameObject obj = Instantiate(m_monsterList[monsterNumber]);
        obj.transform.position = point.position + randomPos;
        {
            //StartCoroutine(Coroutine_RandomPoint(point.position, m_range));
            //if(m_spawn)
            //{

            //}
            //obj.transform.position = m_monsterList[monsterNumber].transform.position;
        }
        return obj;
    }
    //bool RandomPoint(Vector3 center, float range, out Vector3 result)
    //{
    //    NavMeshHit hit;
    //    for (int i = 0; i < 30; i++)
    //    {
    //        Vector3 randomPoint = center + Random.insideUnitSphere * range;

    //        if(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
    //        {
    //            result = hit.position;
    //            return true;
    //        }
    //    }
    //    result = Vector3.zero;
    //    return false;
    //}

    //IEnumerator Coroutine_RandomPoint(Vector3 center, float range)
    //{
    //    NavMeshHit hit;
    //    do
    //    {
    //        Vector3 randomPoint = center + Random.insideUnitSphere * range;

    //        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
    //        {
    //            m_spawn = true;
    //            m_point = hit.position;

    //        }
    //        else
    //        {
    //            m_point = Vector3.zero;
    //            m_spawn = false;
    //        }
    //        yield return null;
    //    } while (!hit.hit);

    //    yield return null;
    //}

    void SpawnInPoints()
    {
        for(int i = 0; i < m_spawnAreaManager.m_spawnAreaList.Count; i++)
        {
            SpawnMonsterList spawnMonsterList = m_spawnAreaManager.m_spawnAreaList[i].GetComponent<SpawnMonsterList>();
            while(!(spawnMonsterList.m_monsterList.Count == m_spawnNumbers))
            {
                int number = Random.Range(0, m_monsterList.Count);
                GameObject obj = CreateMonster(m_spawnAreaManager.m_spawnAreaList[i], number);
                MonsterController controller = obj.GetComponent<MonsterController>();
                controller.m_startPos = obj.transform.position;
                spawnMonsterList.m_monsterList.Add(obj);
            }
        }
    }
    void SpawnInOnePoint()
    {
        int monsterNumber = Random.Range(0, m_monsterList.Count);
        int spawnNumber = Random.Range(0, m_spawnAreaManager.m_spawnAreaList.Count);
        CreateMonster(m_spawnAreaManager.m_spawnAreaList[spawnNumber], monsterNumber);
    }

}
