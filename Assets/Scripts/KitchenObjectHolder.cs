using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    public static event EventHandler OnDrop;
    public static event EventHandler OnPickup;

    [SerializeField] private Transform holdPoint;

    private KitchenObject kitchenObject;

    public KitchenObject GetKichenObject()
    {
        return kitchenObject;
    }

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObject.GetKitchenObjectSO();
    }

    /// <summary>
    /// 判断是否有物品
    /// </summary>
    /// <returns>有物品返回true，没有则返回false</returns>
    public bool IsHaveKitchenObject()
    {
        return kitchenObject != null;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        if(this.kitchenObject != kitchenObject && kitchenObject != null && this is BaseCounter)
        {
            OnDrop?.Invoke(this, EventArgs.Empty);
        }else if (this.kitchenObject != kitchenObject && kitchenObject != null && this is Player)
        {
            OnPickup?.Invoke(this, EventArgs.Empty);
        }

        this.kitchenObject = kitchenObject;
        kitchenObject.transform.localPosition = Vector3.zero;
    }

    public Transform GetHoldPoint()
    {
        return holdPoint;
    }

    /// <summary>
    /// 传递食材
    /// </summary>
    /// <param name="sourceHolder">食材来源</param>
    /// <param name="targetHolder">需要传递到的目标</param>
    public void TransferKitchenObject(KitchenObjectHolder sourceHolder, KitchenObjectHolder targetHolder)
    {
        if (sourceHolder.GetKichenObject() == null)
        {
            Debug.LogWarning("源持有者无食材");
            return;
        }
        if (targetHolder.GetKichenObject() != null)
        {
            Debug.LogWarning("目标持有者存在食材");
            return;
        }
        targetHolder.AddKitchenObject(sourceHolder.GetKichenObject());
        sourceHolder.ClearKitchenObject();
    }

    public void AddKitchenObject(KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(holdPoint);
        SetKitchenObject(kitchenObject);
    }

    public void ClearKitchenObject()
    {
        this.kitchenObject = null;
    }
    /// <summary>
    /// 清空柜台
    /// </summary>
    public void DestroyKitchenObject()
    {
        Destroy(kitchenObject.gameObject);
        ClearKitchenObject();
    }

    /// <summary>
    /// 创建新食材
    /// </summary>
    /// <param name="kitchenObjectPrefab">要创建的食材种类</param>
    public void CreateKitchenObject(GameObject kitchenObjectPrefab)
    {
        KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectPrefab, GetHoldPoint()).GetComponent<KitchenObject>();
        SetKitchenObject(kitchenObject);
    }
}
