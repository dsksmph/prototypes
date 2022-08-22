using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<InventoryCell> cells;
    public List<InventoryCell> collectionCells;
    public ResourceBD resourceBD;
    [SerializeField] private Image tradeButtonImage;
    [SerializeField] private Text tradeButtonText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CheckTradeButton();
    }
    
    public void SaveResource(ResourceBD.ResourceItem.ResourceType itemType, ResourceBD.ResourceItem.CollectableType collectableType)
    {
        InventoryCell foundCell = null;
        List<InventoryCell> tempEmptyCells = new List<InventoryCell>();
        List<InventoryCell> tempCells = new List<InventoryCell>(cells);

        if (collectableType == ResourceBD.ResourceItem.CollectableType.Collection) tempCells = new List<InventoryCell>(collectionCells);
        else if (collectableType == ResourceBD.ResourceItem.CollectableType.Currency)
        {
            GameManager.instance.AddCoin();
            return;
        }


        foreach (var item in tempCells)
        {
            if (item.itemType == ResourceBD.ResourceItem.ResourceType.Null)
            {
                tempEmptyCells.Add(item);
                continue;
            }

            if (item.itemType == itemType && foundCell == null)
            {
                foundCell = item;
            }
        }

        if (foundCell != null)
        {
            foundCell.amount++;
        }
        else
        {
            foundCell = tempEmptyCells[0];
            foreach (var item in resourceBD.itemList)
            {
                if (item.itemType == itemType)
                {
                    foundCell.image.sprite = item.sprite;
                    foundCell.image.color = Color.white;
                    break;
                }
            }

            foundCell.itemType = itemType;
            foundCell.amount = 1;
        }

        foundCell.text.text = foundCell.amount.ToString();
        CheckTradeButton();
    }

    public void TradeCollection()
    {
        foreach (var item in collectionCells)
        {
            if (item.amount > 0) item.amount--;
            item.text.text = item.amount.ToString();
        }

        CheckTradeButton();
    }

    private void CheckTradeButton()
    {
        int counter = 0;
        foreach (var item in collectionCells)
        {
            if (item.amount >= 1) counter++;
        }

        if (counter == collectionCells.Count)
        {
            tradeButtonImage.color = Color.white;
            tradeButtonText.color = Color.white;
        }
        else
        {
            tradeButtonImage.color = new Color(1, 1, 1, 0.1f);
            tradeButtonText.color = new Color(1, 1, 1, 0.1f);
        }
    }
}

[Serializable]
public class InventoryCell
{
    public Image image;
    public Text text;
    public int amount;
    public ResourceBD.ResourceItem.ResourceType itemType = ResourceBD.ResourceItem.ResourceType.Null;
}