using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour//, IPointerClickHandler, IBeginDragHandler, IDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
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

    ////드래그 오버라이드

    ////마우스 드래그 시작 오버드라이드
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    if(m_item != null)
    //    {
    //        //현재 슬롯으로 등록
    //        DragSlot.Instance.m_currentSlot = this;
    //        DragSlot.Instance.DragSetImage(m_itemImage);
    //        DragSlot.Instance.transform.position = eventData.position;
    //    }
    //}
    ////마우스 드래그 중 매 프레임마다 호출되는 오버라이드
    //public void OnDrag(PointerEventData eventData)
    //{
    //    if(m_item != null)
    //    {
    //        DragSlot.Instance.transform.position = eventData.position;
    //    }
    //}
    ////마우스 드래그 종료 오버라이드
    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    DragSlot.Instance.SetColor(0);
    //    DragSlot.Instance.m_currentSlot = null;
    //}
    ////해당 슬롯에 무안가가 마우스 드롭 됐을 때 발생하는 이벤트
    //public void OnDrop(PointerEventData eventData)
    //{
    //    ChangeSlot();
    //}

    ////아이템 바꾸기

    //private void ChangeSlot()
    //{

    //}


}
