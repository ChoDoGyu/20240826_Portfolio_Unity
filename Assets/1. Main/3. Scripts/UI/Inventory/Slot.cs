using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    Image m_itemImage;//Image Component를 담을 곳

    private ItemData m_item;

    public ItemData m_Item
    {
        get { return m_item; }//슬롯의 item 정보를 넘겨줄 때 사용
        set
        {
            m_item = value;//item에 들어오는 정보의 값은 m_itme에 저장
            if(m_item != null)
            {
                m_itemImage.sprite = m_Item.m_itemImage;
                m_itemImage.color = new Color(1, 1, 1, 1);
            }
            else
            {
                m_itemImage.color = new Color(1, 1, 1, 0);
            }
            /*
            Inventory.cs 의 List<Item> items에 등록된 아이템이 있다면 itemImage를 image에 저장 
            그리고 Image의 알파 값을 1로 하여 이미지를 표시합니다.
            만약 item이 null 이면 (빈슬롯 이면) Image의 알파 값 0을 주어 화면에 표시하지 않습니다.
             */
        }
    }

    Inventory m_inventory;

    void Start()
    {
        m_inventory = GetComponentInParent<Inventory>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RightClick();
    }
    void RightClick()
    {
        switch(m_item.m_itemCategoryNum)
        {
            case 0://투구
                if (m_inventory.m_Equipmentinventory.m_slots[0].m_Item)
                {
                    ItemData itemData = m_inventory.m_Equipmentinventory.m_slots[0].m_Item;
                    m_inventory.m_Equipmentinventory.ReMoveEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[0].m_Item);
                    m_inventory.RemoveItem(m_item);
                    m_inventory.m_Equipmentinventory.m_slots[0].m_Item = this.m_item;
                    this.m_item = itemData;
                    m_inventory.AddItem(m_item);
                    m_inventory.m_Equipmentinventory.AddEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[0].m_Item);
                }
                else
                {
                    m_inventory.m_Equipmentinventory.m_slots[0].m_Item = m_item;
                    m_inventory.RemoveItem(m_Item);
                    m_item = null;
                    m_inventory.m_Equipmentinventory.AddEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[0].m_Item);
                }
                break;
            case 1://무기
                if (m_inventory.m_Equipmentinventory.m_slots[1].m_Item)
                {
                    ItemData itemData = m_inventory.m_Equipmentinventory.m_slots[1].m_Item;
                    m_inventory.m_Equipmentinventory.ReMoveEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[1].m_Item);
                    m_inventory.RemoveItem(m_item);
                    m_inventory.m_Equipmentinventory.m_slots[1].m_Item = this.m_item;
                    this.m_item = itemData;
                    m_inventory.AddItem(m_item);
                    m_inventory.m_Equipmentinventory.AddEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[1].m_Item);
                }
                else
                {
                    m_inventory.m_Equipmentinventory.m_slots[1].m_Item = m_item;
                    m_inventory.RemoveItem(m_Item);
                    m_item = null;
                    m_inventory.m_Equipmentinventory.AddEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[1].m_Item);
                }
                break;
            case 2://갑옷
                if (m_inventory.m_Equipmentinventory.m_slots[2].m_Item)
                {
                    ItemData itemData = m_inventory.m_Equipmentinventory.m_slots[2].m_Item;
                    m_inventory.m_Equipmentinventory.ReMoveEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[2].m_Item);
                    m_inventory.RemoveItem(m_item);
                    m_inventory.m_Equipmentinventory.m_slots[2].m_Item = this.m_item;
                    this.m_item = itemData;
                    m_inventory.AddItem(m_item);
                    m_inventory.m_Equipmentinventory.AddEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[2].m_Item);
                }
                else
                {
                    m_inventory.m_Equipmentinventory.m_slots[2].m_Item = m_item;
                    m_inventory.RemoveItem(m_Item);
                    m_item = null;
                    m_inventory.m_Equipmentinventory.AddEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[2].m_Item);
                }
                break;
            case 3://장갑
                if (m_inventory.m_Equipmentinventory.m_slots[3].m_Item)
                {
                    ItemData itemData = m_inventory.m_Equipmentinventory.m_slots[3].m_Item;
                    m_inventory.m_Equipmentinventory.ReMoveEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[3].m_Item);
                    m_inventory.RemoveItem(m_item);
                    m_inventory.m_Equipmentinventory.m_slots[3].m_Item = this.m_item;
                    this.m_item = itemData;
                    m_inventory.AddItem(m_item);
                    m_inventory.m_Equipmentinventory.AddEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[3].m_Item);
                }
                else
                {
                    m_inventory.m_Equipmentinventory.m_slots[3].m_Item = m_item;
                    m_inventory.RemoveItem(m_Item);
                    m_item = null;
                    m_inventory.m_Equipmentinventory.AddEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[3].m_Item);
                }
                break;
            case 4://신발
                if (m_inventory.m_Equipmentinventory.m_slots[4].m_Item)
                {
                    ItemData itemData = m_inventory.m_Equipmentinventory.m_slots[4].m_Item;
                    m_inventory.m_Equipmentinventory.ReMoveEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[4].m_Item);
                    m_inventory.RemoveItem(m_item);
                    m_inventory.m_Equipmentinventory.m_slots[4].m_Item = this.m_item;
                    this.m_item = itemData;
                    m_inventory.AddItem(m_item);
                    m_inventory.m_Equipmentinventory.AddEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[4].m_Item);
                }
                else
                {
                    m_inventory.m_Equipmentinventory.m_slots[4].m_Item = m_item;
                    m_inventory.RemoveItem(m_Item);
                    m_item = null;
                    m_inventory.m_Equipmentinventory.AddEquipmentItem(m_inventory.m_Equipmentinventory.m_slots[4].m_Item);
                }
                break;
        }
    }

}
