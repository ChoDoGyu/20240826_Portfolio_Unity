using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateDie : FSMSingleton<PlayerStateDie>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        print("�÷��̾� �׾���.");
        e.gameObject.SetActive(false);
    }
    public void Execute(PlayerManager e)
    {
        
    }
    public void Exit(PlayerManager e)
    {

    }
}
