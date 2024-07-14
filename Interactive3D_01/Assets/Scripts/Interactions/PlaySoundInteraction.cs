using UnityEngine;

public class PlaySoundInteraction : InteractableObject
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
    }

    public override void TriggerClosingAnimation()
    {
        if(audioSource.isPlaying)
        {
            //audioSource.Pause();
            audioSource.Stop();
        }

        else
        {
            audioSource.Play();
        }
    }

    public override void TriggerInteraction()
    {
        
    }

    public override void TriggerOpenAnimation()
    {
        
    }
}
