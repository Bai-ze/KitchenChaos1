using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;
    [SerializeField] private ProgressBarUI progressBarUI;

    private int cuttingCount = 0;

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {
            //手上有食材
            if (IsHaveKitchenObject() == false)
            {
                //当前柜台为空
                TransferKitchenObject(player, this);
            }
            else
            {
                //当前柜台不为空

            }
        }
        else
        {
            // 手上没有食材
            if (IsHaveKitchenObject() == false)
            {
                //当前柜台为空

            }
            else
            {
                //当前柜台不为空
                TransferKitchenObject(this, player);
                progressBarUI.Hide();
            }
        }
    }

    public override void InteractOperate(Player player)
    {
        if (IsHaveKitchenObject())
        {
            if (cuttingRecipeList.TryGetCuttingRecipe(GetKichenObject().GetKitchenObjectSO(), out CuttingRecipe cuttingRecipe) )
            {
                cuttingCount++;

                progressBarUI.UpdateProgress((float)cuttingCount / cuttingRecipe.cuttingCountMax);

                if(cuttingCount == cuttingRecipe.cuttingCountMax)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(cuttingRecipe.output.prefab);
                }
            }
        }
    }
}
