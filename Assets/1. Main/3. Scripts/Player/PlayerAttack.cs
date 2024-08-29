using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//enum������ ���� ��ų�� ���� ���� ����
//�����ϸ� ������Ʈ �ϳ��� ��
//��ų �����ʹ� ����Ʈ�� �־���� ���Ҷ����� �ٲ㼭 �����ϸ� ��
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
