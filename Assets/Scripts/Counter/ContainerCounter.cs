using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 仓库类柜台
/// </summary>
public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    [SerializeField] private ContainerCounterVisual containerCounterVisual;


    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject()) return;

        CreateKitchenObject(kitchenObjectSO.prefab);
        
        TransferKitchenObject(this, player);

        containerCounterVisual.PlayOpen();

    }


}
