using UnityEngine;

public class PlayAnimationInteraction : InteractableObject
{
    public Animator animator;
    public override void TriggerInteraction()
    {
        if (isOpen)
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
        isOpen = false;
    }

    public override void TriggerOpenAnimation()
    {
        animator.SetBool("isOpen", true);
        isOpen = true;
    }
}
