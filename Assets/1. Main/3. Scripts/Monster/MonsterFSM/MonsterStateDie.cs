using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateDie : FSMSingleton<MonsterStateDie>, FSMState<MonsterController>
{
    public void Enter(MonsterController e)
    {
        e.m_monsterAgent.isStopped = true;
        print("몬스터 죽는다");
        print("누워서 아래로 가라앉는 애니메이션");
        Destroy(e.gameObject, 2f);
        //e.m_player.m_attackAreaUnit.m_unitList.Remove(e.gameObject);
        e.m_player.m_attackAreaUnit.m_unitList.Remove(e);
        e.m_isDie = true;

    }
    public void Execute(MonsterController e)
    {
        //누워서 아래로 가라앉는 애니메이션
        

    }
    public void Exit(MonsterController e)
    {

    }
}
