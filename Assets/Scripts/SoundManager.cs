using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private float volume = 1f;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        volume = PlayerPrefs.GetFloat("SoundEffectsVolume", 1f);
    }
    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        Player.Instance.OnPickedSomething += Player_OnPickedSomething;
        BaseCounter.OnAnyObjectPlacedHere += BaseCounter_OnAnyObjectPlacedHere;
        TrashCounter.OnAnyObjectTrashed += TrashCounter_OnAnyObjectTrashed;
    }

    private void TrashCounter_OnAnyObjectTrashed(object sender, System.EventArgs e)
    {
        TrashCounter cuttingCounter = sender as TrashCounter;
        PlaySound(audioClipRefsSO.trash, cuttingCounter.transform.position);
    }

    private void BaseCounter_OnAnyObjectPlacedHere(object sender, System.EventArgs e)
    {
        BaseCounter cuttingCounter = sender as BaseCounter;
        PlaySound(audioClipRefsSO.objectDrop, cuttingCounter.transform.position);
    }

    private void Player_OnPickedSomething(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectPickup, Player.Instance.transform.position);
    }

    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(audioClipRefsSO.chop, cuttingCounter.transform.position);
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipRefsSO.deliverySuccess, deliveryCounter.transform.position);
    }
    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipRefsSO.deliveryFail, deliveryCounter.transform.position);
    }
    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
    private void PlaySound(AudioClip[] audioClips, Vector3 position, float volumeMuliplier = 1f)
    {
        PlaySound(audioClips[Random.Range(0, audioClips.Length)], position, volumeMuliplier * volume);
    }
    public void PlayFootstepsSound(Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipRefsSO.footstep, position, volume);
    }
    public void ChangeVolume()
    {
        volume += 0.1f;
        if (volume > 1f)
        {
            volume = 0f;
        }
        PlayerPrefs.SetFloat("SoundEffectsVolume", volume);
        PlayerPrefs.Save();
    }
    public float GetVolume()
    {
        return volume;
    }
}
