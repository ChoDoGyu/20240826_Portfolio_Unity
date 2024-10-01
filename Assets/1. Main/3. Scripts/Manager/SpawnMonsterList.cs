using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsterList : MonoBehaviour
{
    public List<GameObject> m_monsterList = new List<GameObject>();

    private void Update()
    {
        DieCheck();
    }
    void DieCheck()
    {
        
        for(int i = m_monsterList.Count - 1; i >= 0; i--)
        {
            MonsterController monsterController = m_monsterList[i].GetComponent<MonsterController>();
            if (monsterController.m_isDie)
            {
                m_monsterList.Remove(m_monsterList[i]);
            }
        }
    }
}
