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
        //누워서 아래로 가라앉는 애니메이션
        print("누워서 아래로 가라앉는 애니메이션");
        Destroy(e, 2);
    }
    public void Exit(MonsterController e)
    {

    }
}
