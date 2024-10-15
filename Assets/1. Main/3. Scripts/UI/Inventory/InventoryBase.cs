using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//인벤코리 베이스로써 인벤토리 슬롯들을 등록시키고 사용할 준비를 완료한다.
//추상클래스로 작성하여 인벤토리 베이스 자체적으로 인스턴스 할 수 없게 한다.
abstract public class InventoryBase : MonoBehaviour
{
    [SerializeField]
    protected GameObject m_inventroyBase;//Inventory 최상위 부모(활성/ 비활성 목적)
    [SerializeField]
    protected GameObject m_inventroySlotsParent;//slot들을 담을 부모 게임오브젝트

    protected void Awake()
    {
        if(m_inventroyBase.activeSelf)
        {
            m_inventroyBase.SetActive(false);
        }

    }

}
