using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectItem : MonoBehaviour, IClickable
{
    [Header("아이템")]
    public ItemData m_itemData;
    //[Header("아이템 이미지")]
    //public SpriteRenderer m_itemImage;


    public void Click(PlayerManager player, Vector3 hitPos)
    {
        if (player == null)
            return;
        //player.m_moveCheck = true;
        //player.m_movePoint = new Vector3(hitPos.x, player.transform.position.y, hitPos.z);
        player.m_inventory.AddItem(this.m_itemData);
        Destroy(this.gameObject);
    }
}
