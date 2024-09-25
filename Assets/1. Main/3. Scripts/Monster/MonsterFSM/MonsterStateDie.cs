using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateDie : FSMSingleton<MonsterStateDie>, FSMState<MonsterController>
{
    public void Enter(MonsterController e)
    {
        print("몬스터 죽는다");
    }
    public void Execute(MonsterController e)
    {

    }
    public void Exit(MonsterController e)
    {

    }
}
