using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : MonoBehaviour
{
    //Serialize Variables
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float maxDistance;

    //Object Variables

    //Component Variables
    [SerializeField]
    private ElectronsControl electronsControl;

    //Private Variables
    private Vector3 movePoint;

    private float _moveSpeed;

    private void Awake()
    {
        electronsControl = GetComponent<ElectronsControl>();
    }
    private void Start()
    {
        FollowPlayer();
    }

    void Update()
    {
        _moveSpeed = moveSpeed + (moveSpeed * electronsControl.electrons.Count) / 10;

        //Debug.Log("Speed " + _moveSpeed);

        if (electronsControl.electrons.Count
            < PlayerMovement.playerMovement.gameObject.GetComponent<ElectronsControl>().electrons.Count)
        {
            FollowPlayer();
        }
        else
        {
            Patrol();
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
                movePoint, Time.deltaTime * _moveSpeed);
        }
    }

    public void SearchMovePoint()
    {
        float randomZpos = Random.Range(-maxDistance, maxDistance);
        float randomXpos = Random.Range(-maxDistance, maxDistance);
        randomZpos = Mathf.Clamp(randomZpos, 0, maxDistance);
        randomZpos = Mathf.Clamp(randomXpos, 0, maxDistance);

        movePoint = new Vector3(randomXpos, 0, randomZpos);
        //Debug.Log("Seacrh Move Point" + movePoint);
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.Lerp(transform.position,
                PlayerMovement.playerMovement.gameObject.transform.position,
                Time.deltaTime * _moveSpeed * 0.25f);
    }
}
