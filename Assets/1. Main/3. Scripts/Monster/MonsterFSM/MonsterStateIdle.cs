using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateIdle : FSMSingleton<MonsterStateIdle>,FSMState<MonsterController>
{

    public void Enter(MonsterController e)
    {

    }
    public void Execute(MonsterController e)
    {
        if (e.m_player.transform != null)
        {
            if (e.CheckDistance(e.m_player.transform.position, e.m_MonsterData.m_sightRange))
            {
                e.ChangeState(MonsterStateChase._Inst);
            }
            
        }
    }
    public void Exit(MonsterController e) 
    {
        
    }
}
