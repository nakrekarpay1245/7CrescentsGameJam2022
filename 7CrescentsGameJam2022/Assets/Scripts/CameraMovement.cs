using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float followSpeed;

    [SerializeField]
    private float zOffset;

    [SerializeField]
    private float xOffset;

    [SerializeField]
    private GameObject target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(target.transform.position.x + xOffset,
            transform.position.y, target.transform.position.z + zOffset),
            followSpeed * Time.deltaTime);
    }
}
