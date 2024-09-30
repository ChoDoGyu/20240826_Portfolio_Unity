using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateDamage : FSMSingleton<PlayerStateDamage>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        print("�÷��̾� �´´�.");
    }
    public void Execute(PlayerManager e)
    {
        if (e.m_hpManager.m_hp > 0)
        {
            //������ �ִϸ��̼� ����� �Ϸ�Ǹ� ���� ������ ������...
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
