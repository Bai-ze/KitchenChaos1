using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    [SerializeField] private PlateCompleteVisual plateCompleteVisual;

    private List<KitchenObjectSO> kitchenObjectSOList = new List<KitchenObjectSO>();
    public bool AddKitchenObjectSO(KitchenObjectSO kitchenObjectSO)
    {
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            return false;
        }
        if (validKitchenObjectSOList.Contains(kitchenObjectSO) == false)
        {
            return false;
        }

        plateCompleteVisual.ShowKitchenObject(kitchenObjectSO);
        kitchenObjectSOList.Add(kitchenObjectSO);
        return true;
    }
}
