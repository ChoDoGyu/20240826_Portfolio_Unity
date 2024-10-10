using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]
    Image m_image;//Image Component를 담을 곳

    private ItemData m_item;
    public ItemData m_Item
    {
        get { return m_item; }//슬롯의 item 정보를 넘겨줄 때 사용
        set
        {
            m_item = value;//item에 들어오는 정보의 값은 m_itme에 저장
            if(m_item != null)
            {
                m_image.sprite = m_Item.m_itemImage;
                m_image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                m_image.color = new Color(1, 1, 1, 0);
            }
            /*
            Inventory.cs 의 List<Item> items에 등록된 아이템이 있다면 itemImage를 image에 저장 
            그리고 Image의 알파 값을 1로 하여 이미지를 표시합니다.
            만약 item이 null 이면 (빈슬롯 이면) Image의 알파 값 0을 주어 화면에 표시하지 않습니다.
             */
        }
    }
}
