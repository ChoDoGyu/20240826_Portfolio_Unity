using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateReset : FSMSingleton<MonsterStateReset>, FSMState<MonsterController>
{
    public void Enter(MonsterController e)
    {
        print("����");
        e.m_aniManager.ParameterBool("Run", true);
    }
    public void Execute(MonsterController e)
    {
        e.m_hpManager.m_hp = e.m_MonsterData.m_hp;
        e.Move(e.m_startPos);
        e.Turn(e.m_startPos);
        float distance = Vector3.Distance(e.transform.position, e.m_startPos);
        if(e.CheckDistance(e.m_startPos, 1.2f))
        {
            e.ChangeState(MonsterStateIdle.m_Inst);
        }
    }
    public void Exit(MonsterController e)
    {
        e.m_aniManager.ParameterBool("Run", false);
    }
}
