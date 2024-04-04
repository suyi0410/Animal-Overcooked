using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            // 盘子中不能放这种物品
            return false;
        }
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            // 盘子中已经有了这种物品
            return false;
        } else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }
    }
}