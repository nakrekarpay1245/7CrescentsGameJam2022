using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonus : MonoBehaviour
{
    //Component Variables
    [SerializeField]
    private SphereCollider collider;

    [SerializeField]
    private ElectronsControl electronsControl;

    public static PlayerBonus playerBonus;

    //Serialize Variables
    [SerializeField]
    private GameObject electronPrefab;

    [SerializeField]
    private GameObject electrons;
    private void Awake()
    {
        if (playerBonus == null)
            playerBonus = this;

        electronsControl = GetComponent<ElectronsControl>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //AddElectronBonus();
            //IncreasePlayerSpeed();
            Magnet();
        }
    }
    public void AddElectronBonus()
    {
        GameObject electron = Instantiate(electronPrefab,
            electrons.gameObject.transform.position + Vector3.right * 2, Quaternion.identity);
        electron.transform.position =
            electrons.gameObject.transform.position + Vector3.right * 2;

        electron.transform.parent = electrons.gameObject.transform;

        electron.GetComponent<ElectronMovement>().pivotObject = this.gameObject;

        electronsControl.AddElectron(electron);
    }

    public void IncreasePlayerSpeed()
    {
        PlayerMovement.playerMovement.IncreasePlayerSpeed();
    }

    public void Magnet()
    {
        collider.radius++;
    }
}
