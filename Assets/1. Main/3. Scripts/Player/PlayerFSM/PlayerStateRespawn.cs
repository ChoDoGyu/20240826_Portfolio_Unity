using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateRespawn : FSMSingleton<PlayerStateRespawn>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        e.m_isDie = false;
        e.transform.position = e.m_spawnPoint.position;
        e.m_hpManager.m_hp = e.m_playerStaus.m_hp / 2;
        e.ChangeState(PlayerStateIdle.m_Inst);
        e.gameObject.SetActive(true);
    }
    public void Execute(PlayerManager e)
    {
        
    }
    public void Exit(PlayerManager e)
    {

    }
}
