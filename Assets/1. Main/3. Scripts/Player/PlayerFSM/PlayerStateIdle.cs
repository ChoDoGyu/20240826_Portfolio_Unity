using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : FSMSingleton<PlayerStateIdle>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        print("PlayerStateIdle");
    }
    public void Execute(PlayerManager e)
    {
        
    }
    public void Exit(PlayerManager e)
    {

    }
}