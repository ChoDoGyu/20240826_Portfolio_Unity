using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateDie : FSMSingleton<PlayerStateDie>, FSMState<PlayerManager>
{
    public void Enter(PlayerManager e)
    {
        print("�÷��̾� �׾���.");
        e.gameObject.SetActive(false);
        e.m_isDie = true;
        GameManager.Instance.IsDie();
        e.m_aniManager.ParameterBool("Death", true);
    }
    public void Execute(PlayerManager e)
    {

    }
    public void Exit(PlayerManager e)
    {
        e.m_aniManager.ParameterBool("Death", false);
    }
}
