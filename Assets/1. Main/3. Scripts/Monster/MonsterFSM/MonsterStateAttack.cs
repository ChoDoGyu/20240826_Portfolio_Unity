using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateAttack : FSMSingleton<MonsterStateAttack>, FSMState<MonsterController>
{
    public void Enter(MonsterController e)
    {
        e.m_monsterAgent.stoppingDistance = e.m_MonsterData.m_attackRange;
    }
    public void Execute(MonsterController e)
    {
        if (e.CheckDistance(e.m_player.transform.position, e.m_MonsterData.m_attackRange))
        {
            if (Time.time > e.m_lastAttackTime + e.m_MonsterData.m_attackDelay)
            {
                e.Turn(e.m_player.transform.position);
                Debug.Log("Monster Attack!!");
                e.m_player.m_hpManager.ReduceHp(e.m_MonsterData.m_damage);
                e.m_player.ChangeState(PlayerStateDamage.m_Inst);
                e.m_lastAttackTime = Time.time;
            }
        }
        else
        {
            e.ChangeState(MonsterStateIdle.m_Inst);
        }
        if (e.m_player.m_isDie)
        {
            e.ChangeState(MonsterStateReset.m_Inst);
        }

    }
    public void Exit(MonsterController e)
    {
        e.m_monsterAgent.stoppingDistance = 3;
    }
}
