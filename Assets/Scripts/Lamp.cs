using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private Material material;

    public void OnEnable()
    {
        CycleJourNuit.QuandEtatDeJourChange += AllumeEnFonctionDeEtatDeJourner;
    }

    public void OnDisable()
    {
        CycleJourNuit.QuandEtatDeJourChange -= AllumeEnFonctionDeEtatDeJourner;
    }

    private void AllumeEnFonctionDeEtatDeJourner(bool estJour)
    {
        if (estJour)
        {
            Eteint();
        }
        else
        {
            Allume();
        }
    }

    private void Allume()
    {
        light.enabled = true;
        material.EnableKeyword("_EMISSION");
    }
    
    private void Eteint()
    {
        light.enabled = false;
        material.DisableKeyword("_EMISSION");
    }
}
