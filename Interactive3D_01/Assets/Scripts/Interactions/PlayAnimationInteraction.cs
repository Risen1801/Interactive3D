using UnityEngine;

public class PlayAnimationInteraction : InteractableObject
{
    public Animator animator;

    private bool _isOpen;
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
    }

    public override void TriggerOpenAnimation()
    {
        animator.SetBool("isOpen", true);
        _isOpen = true;
    }
}
