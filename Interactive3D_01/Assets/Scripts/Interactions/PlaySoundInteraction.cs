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


    public override void TriggerInteraction()
    {
        if (audioSource.isPlaying)
        {
            //audioSource.Pause();
            audioSource.Stop();
            Debug.Log("Audio gestoppt.");
        }

        else
        {
            audioSource.PlayOneShot(audioClip);
            Debug.Log("Audio wird abgespielt: " + audioClip.name);
        }
    }

    public override void TriggerOpenAnimation()
    {
        
    }    
    
    public override void TriggerClosingAnimation()
    {

    }
}
