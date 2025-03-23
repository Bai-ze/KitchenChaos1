using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    /// <summary>
    /// 播放打开冷藏食物柜的动画
    /// </summary>
    public void PlayOpen()
    {
        anim.SetTrigger("OpenClose");
    }
}
