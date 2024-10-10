using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateDie : FSMSingleton<PlayerStateDie>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        print("플레이어 죽었다.");
        e.gameObject.SetActive(false);
        e.m_isDie = true;
        GameManager.Instance.IsDie();
    }
    public void Execute(PlayerManager e)
    {

    }
    public void Exit(PlayerManager e)
    {
        
    }
}
