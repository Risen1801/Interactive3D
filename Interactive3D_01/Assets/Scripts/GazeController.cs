using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GazeController : MonoBehaviour
{
    public float maxDistance = 5;
    public TextMeshProUGUI contextLabel;
    public GameObject contextLabelContainer;

    private InteractableObject _currentGazeObject;
    private RectTransform _contextLabelTransform;

    // Start is called before the first frame update
    void Start()
    {
        _contextLabelTransform = contextLabel.GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 origin = Camera.main.transform.position;
        RaycastHit hit;

        if(Physics.Raycast(origin, forward, out hit, maxDistance) && hit.collider.gameObject.GetComponent<InteractableObject>() != null)
        {
            Debug.DrawRay(origin, forward * hit.distance, Color.green);

            contextLabelContainer.SetActive(true);
            _currentGazeObject = hit.collider.gameObject.GetComponent<InteractableObject>();
            contextLabel.text = _currentGazeObject.commandText;

            LayoutRebuilder.ForceRebuildLayoutImmediate(_contextLabelTransform);
        }

        else
        {
            Debug.DrawRay(origin, forward * maxDistance, Color.red);

            contextLabelContainer.SetActive(false);
            contextLabel.text = "";
            _currentGazeObject = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _currentGazeObject !=null)
        {
            _currentGazeObject.TriggerInteraction();
        }
    }
}
