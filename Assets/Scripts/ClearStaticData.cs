using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 清除注册的事件
/// </summary>
public class ClearStaticData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TrashCounter.ClearStaticData();
        KitchenObjectHolder.ClearStaticData();
        CuttingCounter.ClearStaticData(); 
    }

    
}
