using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {//手上有KitchenObject

            if (player.GetKichenObject().TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plateKitchenobject))
            {//手上有盘子
                if (IsHaveKitchenObject() == false)
                {//当前柜台为空

                    TransferKitchenObject(player, this);
                }
                else
                {//当前柜台不为空
                    bool isSuccess = plateKitchenobject.AddKitchenObject(GetKitchenObjectSO());
                    if(isSuccess == true)
                    {
                        DestroyKitchenObject();
                    }
                    
                }
            }
            else
            {
                if (IsHaveKitchenObject() == false)
                {//当前柜台为空
                    
                    TransferKitchenObject(player, this);
                }
                else
                {//当前柜台不为空
                    
                }
            }

            //if (IsHaveKitchenObject() == false)
            //{
            //    //当前柜台为空
            //    TransferKitchenObject(player, this);
            //}
            //else
            //{
            //    //当前柜台不为空

            //}
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
            }
        }
    }
}
