using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private ItemInfo[] item;
    private bool itemDropped = false;

    private ItemInfo GetRandomItem() 
    {
        var randomIndex = Random.Range(0, item.Length);
        return item[randomIndex];
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !itemDropped)
        {
            var randomItem = GetRandomItem();
            Debug.Log("Вы нашли " + randomItem.ItemName + " - " + randomItem.Description);
            itemDropped = true;
            Destroy(gameObject);
        }
    }
}
