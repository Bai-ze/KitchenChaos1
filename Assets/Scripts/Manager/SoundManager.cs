using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClipRefSO audioClipRefSO;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OrderManager.Instance.OnRecipeSuccessed += OrderManeger_OnRecipeSuccessed;
        OrderManager.Instance.OnRecipeFailed += OrderManager_OnRecipeFailed;
        CuttingCounter.OnCut += CuttingCounter_OnCut;
        KitchenObjectHolder.OnDrop += KitchenObjectHolder_OnDrop;
        KitchenObjectHolder.OnPickup += KitchenObjectHolder_OnPickup;
        TrashCounter.OnObjectTrshed += TrashCounter_OnObjectTrshed;
    }

    private void TrashCounter_OnObjectTrshed(object sender, System.EventArgs e)
    {
        print("11");
        PlaySound(audioClipRefSO.trash);
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

    public void PlayStepSound(float volume = 1f)
    {
        PlaySound(audioClipRefSO.footstep);
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
    private void PlaySound(AudioClip[] clips, float volume = 0.1f)
    {
        PlaySound(clips, Camera.main.transform.position);
    }
}
