using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Define where to Teleport
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        // Wenn berühung stattfindet
        if (other.gameObject.CompareTag("Player"))
        {
            // Finde den Character Controller des Player Objects
            CharacterController ccScript = other.gameObject.GetComponent<CharacterController>();

            // Deaktiviere das Script auf dem Object
            ccScript.enabled = false;

            // Setze die Position des Players auf die Position der Destination
            other.transform.position = destination.position;
            other.transform.rotation = destination.rotation;

            // Aktiviere das Script auf dem Player Object wieder
            ccScript.enabled = true;
        }
    }
}
