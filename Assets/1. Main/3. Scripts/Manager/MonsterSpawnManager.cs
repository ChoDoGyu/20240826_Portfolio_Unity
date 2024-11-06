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

        return obj;
    }

    void SpawnInPoints()
    {

        for(int i = 0; i < m_spawnAreaManager.m_spawnAreaList.Count; i++)
        {
            SpawnMonsterList spawnMonsterList = m_spawnAreaManager.m_spawnAreaList[i].GetComponent<SpawnMonsterList>();

            while (!(spawnMonsterList.m_monsterList.Count == m_spawnNumbers))
            {
                int number = Random.Range(0, m_monsterList.Count);
                GameObject obj = CreateMonster(spawnMonsterList.transform, number);
                MonsterController controller = obj.GetComponent<MonsterController>();
                spawnMonsterList.m_monsterList.Add(obj);
            }
        }
        
    }

}
