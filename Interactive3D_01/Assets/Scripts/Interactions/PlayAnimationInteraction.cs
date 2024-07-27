using UnityEngine;

public class PlayAnimationInteraction : InteractableObject
{
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip audioClipOpenDoor;
    public AudioClip audioClipCloseDoor;

    private bool _isOpen;

    private void Start()
    {
        audioSource.playOnAwake = false;
    }

    public override void TriggerInteraction()
    {
        if (_isOpen)
        {
            TriggerClosingAnimation();
        }

        else
        {
            TriggerOpenAnimation();
        }
    }

    public override void TriggerClosingAnimation()
    {
        animator.SetBool("isOpen", false);
        _isOpen = false;
        audioSource.PlayOneShot(audioClipCloseDoor);
    }

    public override void TriggerOpenAnimation()
    {
        animator.SetBool("isOpen", true);
        _isOpen = true;
        audioSource.PlayOneShot(audioClipOpenDoor);
    }
}
