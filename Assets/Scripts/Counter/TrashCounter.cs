using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnObjectTrshed;

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {
            player.DestroyKitchenObject();
            OnObjectTrshed?.Invoke(this, EventArgs.Empty);
        }
    }

    public static void ClearStaticData()
    {
        OnObjectTrshed = null;
    }
}
