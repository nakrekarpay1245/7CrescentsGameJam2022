using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronsControl : MonoBehaviour
{
    //Public Variables
    public List<GameObject> electrons;

    private void Start()
    {
        InvokeRepeating("ActiveElectron", 1, 1);
    }

    public void AddElectron(GameObject electron)
    {
        electrons.Add(electron);
    }
    public void RemoveElectron(GameObject electron)
    {
        electrons.Remove(electron);
    }

    private void ActiveElectron()
    {
        foreach (GameObject electron in electrons)
            electron.GetComponent<Collider>().enabled = true;
    }
}
