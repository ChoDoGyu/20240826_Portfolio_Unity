using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateDamage : FSMSingleton<MonsterStateDamage>, FSMState<MonsterController>
{
    public void Enter(MonsterController e)
    {
        e.m_monsterAgent.isStopped = true;
        print("몬스터 맞는다.");
        //e.m_monsterRigidbody.MovePosition(e.transform.position - e.m_playerdir.normalized);
    }
    public void Execute(MonsterController e)
    {
        if(e.m_hpManager.m_hp > 0)
        {
            //데미지 애니메이션 재생이 완료되면 상태 변경이 맞을듯...
            e.ChangeState(MonsterStateIdle.m_Inst);
        }
        else
        {
            e.ChangeState(MonsterStateDie.m_Inst);
        }
        //if (e.m_player.m_isDie)
        //{
        //    e.ChangeState(MonsterStateReset.m_Inst);
        //}
    }
    public void Exit(MonsterController e)
    {
        e.m_monsterAgent.isStopped = false;
    }
}
