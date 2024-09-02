using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : FSM<PlayerManager>
{
    [HideInInspector]
    public PlayerMove m_move;
    [HideInInspector]
    public PlayerAttack m_attack;
    private Camera m_camera;
    void Awake()
    {
        m_move = GetComponent<PlayerMove>();
        m_attack = GetComponent<PlayerAttack>();
        m_camera = Camera.main;
        InitState(this, PlayerStateIdle.m_Inst);
    }
    void Update()
    {
        MouseClick();
    }
    void MouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            m_move.m_agent.isStopped = false;
            RaycastHit hit;
            if (Physics.Raycast(m_camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.TryGetComponent<IClickable>(out IClickable iTmp))
                {
                    iTmp.Click(this, hit.point);
                }
            }
            m_attack.UseSkill1();
            //if (EventSystem.current.IsPointerOverGameObject() == false)
            //{

            //}
        }
    }
    
}
