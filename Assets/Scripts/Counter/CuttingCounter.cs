using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    public static event EventHandler OnCut;

    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;
    [SerializeField] private ProgressBarUI progressBarUI;
    [SerializeField] private CuttingCounterVisual CuttingCounterVisual;

    private int cuttingCount = 0;

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {
            //手上有食材
            if (IsHaveKitchenObject() == false)
            {
                //当前柜台为空
                cuttingCount = 0;
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
                Cut();
                progressBarUI.UpdateProgress((float)cuttingCount / cuttingRecipe.cuttingCountMax);

                if(cuttingCount == cuttingRecipe.cuttingCountMax)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(cuttingRecipe.output.prefab);
                }
            }
        }
    }

    private void Cut()
    {
        OnCut?.Invoke(this, EventArgs.Empty);
        cuttingCount++;
        CuttingCounterVisual.PlayCut();
    }

    public static void ClearStaticData()
    {
        OnCut = null;
    }
}
