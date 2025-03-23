using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : KitchenObjectHolder
{
    [SerializeField] private GameObject selectedCounter;

    public virtual void Interact(Player player)
    {
        Debug.LogWarning("交互没有重写");
    }

    public virtual void InteractOperate(Player player)
    {

    }

    public void SelectedCouter()
    {
        selectedCounter.SetActive(true);
    }
    public void CancelSelect()
    {
        selectedCounter.SetActive(false);
    }
    
}
