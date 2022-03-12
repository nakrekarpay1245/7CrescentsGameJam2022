using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomCollider : MonoBehaviour
{
    //Serialize Variables

    //Private Variables

    //Public Variables

    //Object Variables
    [SerializeField]
    private GameObject electrons;

    //Component Variables
    [SerializeField]
    private ElectronsControl electronsControl;
    private void Awake()
    {
        electronsControl = GetComponent<ElectronsControl>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Electron"))
        {
            //Debug.Log("Electron");
            other.gameObject.GetComponent<Collider>().enabled = false;
            if (other.gameObject.transform.parent != null)
            {
                //Debug.Log("Electron Parent Is Null");

                if (other.gameObject.transform.parent.transform.parent.
                    GetComponent<ElectronsControl>().electrons.Count >
                    electronsControl.electrons.Count)
                {
                    TakeTheElectron(other.gameObject,
                        other.gameObject.transform.parent.transform.parent.gameObject);
                   // Debug.Log("Daha Çok");
                }
                else if (other.gameObject.transform.parent.transform.parent.
                    GetComponent<ElectronsControl>().electrons.Count <
                    electronsControl.electrons.Count)
                {
                   // Debug.Log("Daha Az");
                }
            }
            else
            {
               // Debug.Log("Electron Parent");
                TakeTheElectron(other.gameObject);
            }
        }
    }

    private void TakeTheElectron(GameObject electron)
    {
        electron.transform.position = electrons.gameObject.transform.position + Vector3.right * 2;
        electron.transform.parent = electrons.gameObject.transform;
        electron.GetComponent<ElectronMovement>().pivotObject = this.gameObject;
        electronsControl.AddElectron(electron);
    }
    private void TakeTheElectron(GameObject electron, GameObject parentAtom)
    {
        parentAtom.GetComponent<ElectronsControl>().RemoveElectron(electron);
        electron.transform.parent = electrons.gameObject.transform;
        electron.GetComponent<ElectronMovement>().pivotObject = this.gameObject;
        electronsControl.AddElectron(electron);
    }
}
