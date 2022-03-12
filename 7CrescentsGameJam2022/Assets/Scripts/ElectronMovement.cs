using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronMovement : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float maxDistance;

    public GameObject pivotObject;

    //Private Variables
    private Vector3 movePoint;
    private void Start()
    {
        if (Random.Range(0, 2) > 0)
        {
            rotateSpeed = Random.Range(rotateSpeed / 3, rotateSpeed);
        }
        else
        {
            rotateSpeed = Random.Range(-rotateSpeed / 3, -rotateSpeed);
        }

        SearchMovePoint();
    }

    void Update()
    {
        if (pivotObject != null)
        {
            transform.RotateAround(pivotObject.transform.position,
                new Vector3(0, 1, 0), rotateSpeed);

            transform.RotateAround(pivotObject.transform.position,
                 new Vector3(1, 0, 0), rotateSpeed * Random.Range(0.25f, 1f));

            transform.RotateAround(pivotObject.transform.position,
                  new Vector3(0, 0, 1), rotateSpeed * Random.Range(-0.25f, -1f));
            //   Debug.Log("Rotate");
        }

        else
        {
            Patrol();
            // Debug.Log("Patrol Calling");
        }
    }

    private void Patrol()
    {
        // Debug.Log("Patrol");
        float distanceToMovePoint = Vector3.Distance(transform.position,
          movePoint);

        if (distanceToMovePoint < 0.25f)
        {
            //Debug.Log("Seacrh Patrol");

            SearchMovePoint();
        }
        else
        {
            // Debug.Log("Move Patrol");

            transform.position = Vector3.Lerp(transform.position,
                movePoint, Time.deltaTime * moveSpeed);
        }
    }

    private void SearchMovePoint()
    {
        float randomZpos = Random.Range(-maxDistance, maxDistance);
        float randomXpos = Random.Range(-maxDistance, maxDistance);
        randomZpos = Mathf.Clamp(randomZpos, 0, maxDistance);
        randomZpos = Mathf.Clamp(randomXpos, 0, maxDistance);

        movePoint = new Vector3(randomXpos, 0, randomZpos);
        //Debug.Log("Seacrh Move Point" + movePoint);
    }
}
