using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundHimself : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    void Update()
    {
        transform.Rotate(Time.deltaTime * Vector3.up * rotateSpeed);
    }
}
