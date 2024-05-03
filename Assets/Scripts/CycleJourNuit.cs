using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CycleJourNuit : MonoBehaviour
{
    [SerializeField] private float vitesseEnDegreesParSeconde = 1f;
    [SerializeField] private Vector3 direction;

    private float heureActuel = 0;
    private bool estJour = true;
    private float heureDeMoitieEnSecondes;
    
    public static event Action<bool> QuandEtatDeJourChange;
    
    // Start is called before the first frame update
    void Start()
    {
        heureDeMoitieEnSecondes = 360 / vitesseEnDegreesParSeconde / 2;
    }

    // Update is called once per frame
    void Update()
    {
        float ajoutDeTemps = Time.deltaTime * vitesseEnDegreesParSeconde;
        transform.Rotate(direction * ajoutDeTemps);
        
        //Update heure actuel a chaque frame
        heureActuel += ajoutDeTemps;
        
        //Quand heure actuel est plus grand que la moitie de la journee, changer l'etat de jour
        if(heureActuel >= heureDeMoitieEnSecondes)
        {
            estJour = !estJour;
            heureActuel = 0;
            QuandEtatDeJourChange?.Invoke(estJour);
        }
        
       
    }
}
