using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuivreCible : MonoBehaviour
{
    [SerializeField] Transform cible;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = cible.position;
    }
}
