using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using System.Net;
#endif

public class PlayerMovement : MonoBehaviour
{
    //Serialize Variables
    [SerializeField]
    private float moveSpeed;

    //Private Variables
    private float _moveSpeed;
    private float moveBonus;

    //Public Variables

    //Component Variables
    [SerializeField]
    private Rigidbody rigidbodyComponent;

    [SerializeField]
    private ElectronsControl electronsControl;

    public static PlayerMovement playerMovement;
    private void Awake()
    {
        if (playerMovement == null)
            playerMovement = this;

        rigidbodyComponent = GetComponent<Rigidbody>();
        electronsControl = GetComponent<ElectronsControl>();
    }
   

    void Update()
    {
        _moveSpeed =moveBonus + moveSpeed + (moveSpeed * electronsControl.electrons.Count) / 10;

        //Debug.Log("Speed Player : " + _moveSpeed);

        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"),
            0, Input.GetAxis("Vertical")).normalized;

        rigidbodyComponent.velocity = moveVector * _moveSpeed;
    }

    public void IncreasePlayerSpeed()
    {
        moveBonus++;
    }
}
