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
        if(!e.m_isDie)
        {
            e.transform.position = e.m_spawnPoint.position;
            e.m_hpManager.m_hp = e.m_playerStaus.m_hp / 2;
            e.ChangeState(PlayerStateIdle.m_Inst);
        }
    }
    public void Exit(PlayerManager e)
    {
        
    }
}
