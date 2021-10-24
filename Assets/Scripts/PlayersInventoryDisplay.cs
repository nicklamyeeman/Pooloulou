using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersInventoryDisplay : MonoBehaviour
{
    public Image[] inventories;
    public int width;

    public void ChangeColor(int index, string color)
    {
        inventories[index].color = (color == "Red") ? Color.red : Color.yellow;
    }

    public void addItems(Dictionary<int, int> items)
    {
        foreach (var item in items)
        {
            float newWidth = item.Value * width;
            print(newWidth);
            inventories[item.Key].rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
        }
    }
}