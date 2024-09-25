using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateDamage : FSMSingleton<MonsterStateDamage>, FSMState<MonsterController>
{
    public void Enter(MonsterController e)
    {
        print("���� �´´�.");
    }
    public void Execute(MonsterController e)
    {
        if(e.m_hpManager.m_hp > 0)
        {
            //������ �ִϸ��̼� ����� �Ϸ�Ǹ� ���� ������ ������...
            e.ChangeState(MonsterStateIdle.m_Inst);
        }
        else
        {
            e.ChangeState(MonsterStateDie.m_Inst);
        }
    }
    public void Exit(MonsterController e)
    {

    }
}
