using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    private AudioSource audioSource;

    private float originalVolume;

    private int volume = 5;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalVolume = volume;
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        if (volume == 0)
        {
            audioSource.enabled = false;
        }
        else
        {
            audioSource.enabled = true;
            audioSource.volume = originalVolume * (volume / 10.0f);
        }
        //audioSource.volume = originalVolume * (volume / 10.0f);

    }

    public void ChangeVolume()
    {
        volume++;
        if (volume > 10) volume = 0;

        UpdateVolume();
    }

    public int GetVolume()
    {
        return volume;
    }
}
