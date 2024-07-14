using UnityEngine;
using TMPro;

public class DecalsToggle : MonoBehaviour
{
    // Root cotainig alls decals in scene
    public GameObject decalsRoot;

    // Textfield showing mode
    public TextMeshProUGUI infoLabel; 
    
    // Update is called once per frame
    void Update()
    {
        if (decalsRoot == null || infoLabel == null)
            return;


        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            decalsRoot.SetActive(!decalsRoot.activeSelf);
            infoLabel.text = decalsRoot.activeSelf ? "Decals: on" : "Decals: off";
        }
    }
}
