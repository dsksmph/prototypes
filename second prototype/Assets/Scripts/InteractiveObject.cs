using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public ResourceBD.ResourceItem.ResourceType itemType;
    public ResourceBD.ResourceItem.CollectableType collectableType;
    [Header("Используется только в мусоре")] public List<Loot> lootTable;

    public void SpawnRandomLoot()
    {
        int lootIndex = Random.Range(0, lootTable.Count);
        var loot = Instantiate(lootTable[lootIndex], GameManager.instance.lootParent);
        loot.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }
}
