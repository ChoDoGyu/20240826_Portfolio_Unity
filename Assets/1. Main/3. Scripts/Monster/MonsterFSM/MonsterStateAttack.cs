using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateAttack : FSMSingleton<MonsterStateAttack>, FSMState<MonsterController>
{
    public void Enter(MonsterController e)
    {
        e.m_monsterAgent.stoppingDistance = 10;
    }
    public void Execute(MonsterController e)
    {
        if (e.CheckDistance(e.m_player.transform.position, e.m_MonsterData.m_attackRange))
        {
            if (Time.time > e.m_lastAttackTime + e.m_MonsterData.m_attackDelay)
            {
                Debug.Log("Attack!!");
                e.m_lastAttackTime = Time.time;
            }
        }
        else
        {
            e.ChangeState(MonsterStateIdle._Inst);
        }
    }
    public void Exit(MonsterController e)
    {
        
    }
}
