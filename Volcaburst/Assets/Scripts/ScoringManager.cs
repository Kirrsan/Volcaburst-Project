using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringManager : MonoBehaviour
{

    static public int nbDeath = 0;
    public GameObject[] entitiesAlive;
    public GameObject[] entitiesKilled;
    public float timeElapsed = 0.0f;
    
    void Update()
    {
        LooseCheck();

        if (GameStateEnum.gameStateEnum == GameStateEnum.GAMESTATE.InGameFluid)
        {
            timeElapsed += Time.deltaTime;
        }
        else if (GameStateEnum.gameStateEnum == GameStateEnum.GAMESTATE.Win || GameStateEnum.gameStateEnum == GameStateEnum.GAMESTATE.Loose)
        {
            timeElapsed = 0.0f;
        }
    }

    private void LooseCheck()
    {
        if(nbDeath >= 3)
        {
            // UI fin de partie à ajouter
            GameStateEnum.gameStateEnum = GameStateEnum.GAMESTATE.Loose;
            nbDeath = 0;
        }   
    }

    private void EntitiesScoring()
    {
        // Calcul de la partie scoring vis-à-vis des entités présentent dans les deux tableaux
    } 
}
