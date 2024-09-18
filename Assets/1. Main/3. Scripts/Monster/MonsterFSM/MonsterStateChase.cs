using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateChase : FSMSingleton<MonsterStateChase>, FSMState<MonsterController>
{
    public void Enter(MonsterController e)
    {
        
    }
    public void Execute(MonsterController e)
    {
        if (e.CheckDistance(e.m_player.transform.position, e.m_MonsterData.m_sightRange))
        {
            e.Move(e.m_player.transform.position);
            e.Turn(e.m_player.transform.position);
            if (e.CheckDistance(e.m_player.transform.position, e.m_MonsterData.m_attackRange))
            {
                e.ChangeState(MonsterStateAttack.m_Inst);
            }
        }
        else
        {
            e.ChangeState(MonsterStateIdle.m_Inst);
        }
    }
    public void Exit(MonsterController e)
    {
        
    }
}
