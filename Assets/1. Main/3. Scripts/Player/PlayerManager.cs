using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
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
    }
    void Update()
    {
        MouseClick();
    }
    void MouseClick()
    {
        if (Input.GetMouseButton(0))
        {
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
        }
    }
}
