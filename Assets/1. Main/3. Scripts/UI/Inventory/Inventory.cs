using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> m_items;//�������� ���� ����Ʈ
    [SerializeField]
    private Transform m_slotParent;//Slot�� �θ� �Ǵ� Bag�� ���� ��
    [SerializeField]
    private Slot[] m_slots;//Bag�� ������ ��ϵ� Slot�� ���� ��

    public EquipmentInventory m_Equipmentinventory;

#if UNITY_EDITOR
    private void OnValidate()//OnValidate()����� ����Ƽ �����Ϳ��� �ٷ� �۵��� �ϴ� ������ �Ѵ�
    {
        m_slots = m_slotParent.GetComponentsInChildren<Slot>();//m_slotParent �̰� �������� ������ ���� ��
    }

#endif
    void Awake()
    {
        FreshSlot();//������ ���۵Ǹ� m_items�� ����ִ� �������� �κ��丮�� �־��ش�.
    }
    public void FreshSlot()//�������� �����ų� ������ Slot�� ������ �ٽ� �����Ͽ� ȭ�鿡 �����ִ� ���
    {
        int i = 0;
        for(;  i < m_items.Count && i < m_slots.Length; i++)
        {
            m_slots[i].m_Item = m_items[i];
        }
        for(; i < m_slots.Length; i++)
        {
            m_slots[i].m_Item = null;
        }
    }
    public void AddItem(ItemData item)
    {
        if(m_items.Count < m_slots.Length)
        {
            m_items.Add(item);
            FreshSlot();
        }
        else
        {
            print("������ ���� �� �ֽ��ϴ�.");
        }
    }
    public void RemoveItem(ItemData item)
    {
        m_items.Remove(item);
        FreshSlot();
    }
}
