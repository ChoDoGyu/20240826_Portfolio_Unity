using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour//, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private ItemData m_item;
    public ItemData m_Item
    {
        get
        {
            return m_item;
        }
    }

    [SerializeField]
    Image m_itemImage;

    //아이템 이미지의 투명도 조절
    private void SetColor(float alpha)
    {
        Color color = m_itemImage.color;
        color.a = alpha;
        m_itemImage.color = color;
    }

    public void AddItem(ItemData item)
    {
        m_item = item;
        m_itemImage.sprite = m_item.m_itemImage;

        SetColor(1);
    }

    public void ClearSlot()
    {
        m_item = null;
        m_itemImage.sprite = null;
        SetColor(0);
    }
}
