using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronsControl : MonoBehaviour
{
    //Public Variables
    public List<GameObject> electrons;

    public bool isObjectPlayer;

    private void Start()
    {
        InvokeRepeating("ActiveElectron", 1, 1);
    }

    public void AddElectron(GameObject electron)
    {
        electrons.Add(electron);
        if (isObjectPlayer)
        {
            LevelManager.levelManager.IncreaseElectronCount();
        }
    }
    public void RemoveElectron(GameObject electron)
    {
        electrons.Remove(electron);
        if (isObjectPlayer)
        {
            LevelManager.levelManager.DecreaseElectronCount();
        }
    }

    private void ActiveElectron()
    {
        foreach (GameObject electron in electrons)
            electron.GetComponent<Collider>().enabled = true;
    }
}
