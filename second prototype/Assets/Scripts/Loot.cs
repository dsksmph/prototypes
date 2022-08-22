using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : InteractiveObject
{
    IEnumerator Start()
    {
        
        Vector3 destination = transform.position;
        if (collectableType == ResourceBD.ResourceItem.CollectableType.Inventory) destination = GameManager.instance.inventoryIcon.position;
        else if (collectableType == ResourceBD.ResourceItem.CollectableType.Collection) destination = GameManager.instance.collectionIcon.position;
        else if (collectableType == ResourceBD.ResourceItem.CollectableType.Currency) destination = GameManager.instance.coinIcon.position;

        yield return StartCoroutine(MoveToTarget(destination));

        InventoryManager.instance.SaveResource(itemType, collectableType);
        Destroy(gameObject);
    }

    IEnumerator MoveToTarget(Vector3 destination)
    {
        float t = 0;
        float time = 0.5f;
        Vector3 startPos = transform.position;
        
        while (t < time)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, destination, t / time);
            yield return null;
        }
        
    }

}
