using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventory : MonoBehaviour
{
    public List<ItemData> m_items;//�������� ���� ����Ʈ
    [SerializeField]
    private Transform m_slotParent;//Slot�� �θ� �Ǵ� Bag�� ���� ��
    [SerializeField]
    public EquipmentSlot[] m_slots;//Bag�� ������ ��ϵ� Slot�� ���� ��

    public Inventory m_inventory;

#if UNITY_EDITOR
    private void OnValidate()//OnValidate()����� ����Ƽ �����Ϳ��� �ٷ� �۵��� �ϴ� ������ �Ѵ�
    {
        m_slots = m_slotParent.GetComponentsInChildren<EquipmentSlot>();//m_slotParent �̰� �������� ������ ���� ��
    }

#endif
    void Awake()
    {
        FreshSlot();//������ ���۵Ǹ� m_items�� ����ִ� �������� �κ��丮�� �־��ش�.
    }
    public void FreshSlot()//�������� �����ų� ������ Slot�� ������ �ٽ� �����Ͽ� ȭ�鿡 �����ִ� ���
    {
        int i = 0;
        for (; i < m_items.Count && i < m_slots.Length; i++)
        {
            m_slots[i].m_Item = m_items[i];
        }
        for (; i < m_slots.Length; i++)
        {
            m_slots[i].m_Item = null;
        }
    }
    public void AddEquipmentItem(ItemData item)
    {
        m_items.Add(item);
        FreshSlot();
    }
    public void ReMoveEquipmentItem(ItemData item)
    {
        m_items.Remove(item);
        FreshSlot();
    }
}
