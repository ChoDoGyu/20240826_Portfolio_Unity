using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateAttack : FSMSingleton<MonsterStateAttack>, FSMState<MonsterController>
{
    public void Enter(MonsterController e)
    {
        e.m_monsterAgent.stoppingDistance = e.m_MonsterData.m_attackRange;
        e.m_aniManager.ParameterBool("Attack", true);
    }
    public void Execute(MonsterController e)
    {
        if (e.CheckDistance(e.m_player.transform.position, e.m_MonsterData.m_attackRange))
        {
            e.Turn(e.m_player.transform.position);
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
        e.m_monsterAgent.stoppingDistance = 1;
        e.m_aniManager.ParameterBool("Attack", false);
    }


}
