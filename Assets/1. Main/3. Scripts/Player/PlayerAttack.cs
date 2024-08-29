using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//enum형으로 공격 스킬이 뭔지 정한 다음
//공격하면 오브젝트 하나로 됨
//스킬 데이터는 리스트에 넣어놓고 정할때마다 바꿔서 적용하면 됨
public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    GameObject m_attackAreaObj;
    [SerializeField]
    public AttackAreaManager[] m_attakAreas;
    private Camera m_camera;

    void Awake()
    {
        
        m_camera = Camera.main;
        m_attakAreas = m_attackAreaObj.GetComponentsInChildren<AttackAreaManager>();
        for (int i = 0; i < m_attakAreas.Length; i++)
        {
            m_attakAreas[i].gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        

    }
    void Attack()
    {
        if(Input.GetMouseButton(0))
        {
            
        }
        else if(Input.GetMouseButton(1))
        {

        }
    }
}
