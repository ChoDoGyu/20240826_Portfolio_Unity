using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public PlayerMove m_move;
    [HideInInspector]
    public PlayerAttack m_attack;
    private Camera m_camera;
    [HideInInspector]//Ŭ���� ���� ������ �������� ���� ����
    public MonsterController m_monsterController;
    [HideInInspector]
    public bool m_playerAttack = false;
    void Awake()
    {
        m_move = GetComponent<PlayerMove>();
        m_attack = GetComponent<PlayerAttack>();
        m_camera = Camera.main;
    }
    void Update()
    {
        MouseClick();
    }
    public bool CheckDistance(Vector3 target, float distance)
    {
        var dist = transform.position - target;
        if (dist.sqrMagnitude <= Mathf.Pow(distance, 2f))
        {
            return true;
        }
        return false;
    }
    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Vector3 pos = Input.mousePosition;
            //transform.LookAt(pos);
            m_move.m_agent.isStopped = false;
            RaycastHit hit;
            
            if (Physics.Raycast(m_camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.TryGetComponent<IClickable>(out IClickable iTmp))
                {
                    iTmp.Click(this, hit.point);
                }
            }
            //if (EventSystem.current.IsPointerOverGameObject() == false)
            //{

            //}
            if (m_playerAttack)
            {
                if (CheckDistance(m_monsterController.transform.position, m_attack.m_curAttackRange * 0.9f))
                {
                    //�ִϸ��̼��� ������ �� �ִϸ��̼ǿ� ������ �ȴ�.
                    m_attack.UseSkill1();
                }
            }


        }
    }
    
}
