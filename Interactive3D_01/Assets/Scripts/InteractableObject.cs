using UnityEngine;

/// <summary>
///  Base class for all "gaze"-able objects
/// </summary>
public abstract class InteractableObject : MonoBehaviour
{
    // Text to display when object is gazed
    public string commandText;

    // Bool to check for animation
    //public bool _isOpen;

    // Instruction to Trigger
    public abstract void TriggerInteraction();

    public abstract void TriggerClosingAnimation();

    public abstract void TriggerOpenAnimation();
}
