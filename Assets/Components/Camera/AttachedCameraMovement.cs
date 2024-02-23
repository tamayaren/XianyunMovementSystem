using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedCameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject attachedObject;

    private void Update()
    {
        if (ReferenceEquals(attachedObject, null)) return;

        Camera.main.transform.position = attachedObject.transform.position + new Vector3(0, 3, -15f);
    }
}
