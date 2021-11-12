using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuard : MonoBehaviour
{
    Transform _transform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("PlayerIN");
            other.transform.position = new Vector3(other.transform.position.x, 0, 0);

        }
    }
}
