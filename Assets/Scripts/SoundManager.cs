using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipRefSO audioClipRefSO;

    private void Start()
    {
        OrderManager.Instance.OnRecipeSuccessed += OrderManeger_OnRecipeSuccessed;
        OrderManager.Instance.OnRecipeFailed += OrderManager_OnRecipeFailed;
        CuttingCounter.OnCut += CuttingCounter_OnCut;
        KitchenObjectHolder.OnDrop += KitchenObjectHolder_OnDrop;
        KitchenObjectHolder.OnPickup += KitchenObjectHolder_OnPickup;
    }

    private void KitchenObjectHolder_OnPickup(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefSO.objectPickup);
    }

    private void KitchenObjectHolder_OnDrop(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefSO.objectDrop);
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefSO.chop);
    }

    private void OrderManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefSO.deliveryFail);
    }

    private void OrderManeger_OnRecipeSuccessed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefSO.deliverySuccess);
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="clips">音效</param>
    /// <param name="position">播放位置</param>
    /// <param name="volume">音量大小</param>
    private void PlaySound(AudioClip[] clips, Vector3 position, float volume = 0.5f)
    {
        int index = Random.Range(0, clips.Length);

        AudioSource.PlayClipAtPoint(clips[index], position, volume);
    }

    /// <summary>
    /// PlaySound重载
    /// </summary>
    /// <param name="clips"></param>
    /// <param name="volume"></param>
    private void PlaySound(AudioClip[] clips, float volume = 1.0f)
    {
        PlaySound(clips, Camera.main.transform.position);
    }
}
