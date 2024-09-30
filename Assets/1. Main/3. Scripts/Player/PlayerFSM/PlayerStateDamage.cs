using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateDamage : FSMSingleton<PlayerStateDamage>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        print("플레이어 맞는다.");
    }
    public void Execute(PlayerManager e)
    {
        if (e.m_hpManager.m_hp > 0)
        {
            //데미지 애니메이션 재생이 완료되면 상태 변경이 맞을듯...
            e.ChangeState(PlayerStateIdle.m_Inst);
        }
        else
        {
            e.ChangeState(PlayerStateDie.m_Inst);
        }
    }
    public void Exit(PlayerManager e)
    {

    }
}
