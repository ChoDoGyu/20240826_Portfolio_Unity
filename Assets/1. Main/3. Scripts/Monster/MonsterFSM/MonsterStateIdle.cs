using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateIdle : FSMSingleton<MonsterStateIdle>,FSMState<MonsterController>
{

    public void Enter(MonsterController e)
    {
        print("몬스터 아이들");
    }
    public void Execute(MonsterController e)
    {
        if (e.m_player.transform != null)
        {
            //Debug.Break();

            if (e.CheckDistance(e.m_player.transform.position, e.m_MonsterData.m_sightRange))
            {
                e.ChangeState(MonsterStateChase.m_Inst);
            }
        }
        //if (e.m_player.m_isDie)
        //{
        //    e.ChangeState(MonsterStateReset.m_Inst);
        //}
    }
    public void Exit(MonsterController e) 
    {
        
    }
}
