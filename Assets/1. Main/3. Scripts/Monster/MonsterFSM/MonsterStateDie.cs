using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateDie : FSMSingleton<MonsterStateDie>, FSMState<MonsterController>
{
    public void Enter(MonsterController e)
    {
        print("���� �״´�");
    }
    public void Execute(MonsterController e)
    {
        //������ �Ʒ��� ����ɴ� �ִϸ��̼�
        print("������ �Ʒ��� ����ɴ� �ִϸ��̼�");
        Destroy(e, 2);
    }
    public void Exit(MonsterController e)
    {

    }
}
