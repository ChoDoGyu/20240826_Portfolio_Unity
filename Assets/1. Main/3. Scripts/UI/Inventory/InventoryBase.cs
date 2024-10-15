using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�κ��ڸ� ���̽��ν� �κ��丮 ���Ե��� ��Ͻ�Ű�� ����� �غ� �Ϸ��Ѵ�.
//�߻�Ŭ������ �ۼ��Ͽ� �κ��丮 ���̽� ��ü������ �ν��Ͻ� �� �� ���� �Ѵ�.
abstract public class InventoryBase : MonoBehaviour
{
    [SerializeField]
    protected GameObject m_inventroyBase;//Inventory �ֻ��� �θ�(Ȱ��/ ��Ȱ�� ����)
    [SerializeField]
    protected GameObject m_inventroySlotsParent;//slot���� ���� �θ� ���ӿ�����Ʈ

    protected void Awake()
    {
        if(m_inventroyBase.activeSelf)
        {
            m_inventroyBase.SetActive(false);
        }

    }

}
