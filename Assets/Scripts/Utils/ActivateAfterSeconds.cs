using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAfterSeconds : MonoBehaviour
{
    public List<GameObject> activateThese;

    public float delay;
    void Start()
    {
        Invoke("Delay", delay);
    }

    void Delay()
    {
        foreach (GameObject go in activateThese)
        {
            go.SetActive(true);
        }
    }
}
