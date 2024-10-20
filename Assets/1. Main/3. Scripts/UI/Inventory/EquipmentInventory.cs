using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventory : MonoBehaviour
{
    public List<ItemData> m_items;//아이템을 담을 리스트
    [SerializeField]
    private Transform m_slotParent;//Slot의 부모가 되는 Bag을 담을 곳
    [SerializeField]
    public EquipmentSlot[] m_slots;//Bag의 하위에 등록된 Slot을 담을 곳

    public Inventory m_inventory;

#if UNITY_EDITOR
    private void OnValidate()//OnValidate()기능은 유니티 에디터에서 바로 작동을 하는 역할을 한다
    {
        m_slots = m_slotParent.GetComponentsInChildren<EquipmentSlot>();//m_slotParent 이게 정해지지 않으면 에레 뜸
    }

#endif
    void Awake()
    {
        FreshSlot();//게임이 시작되면 m_items에 들어있는 아이템을 인벤토리에 넣어준다.
    }
    public void FreshSlot()//아이템이 들어오거나 나가면 Slot의 내용을 다시 정리하여 화면에 보여주는 기능
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
