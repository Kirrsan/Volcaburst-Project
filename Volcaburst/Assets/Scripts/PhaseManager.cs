using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{

    public float firstPhaseTimer;
    private float firstPhaseTimerMax;

    public GameObject lavaSpawnObject;
    public GameStateEnum.GAMESTATE startGameState;
    // Start is called before the first frame update
    void Start()
    {
        firstPhaseTimerMax = firstPhaseTimer;
        GameStateEnum.gameStateEnum = startGameState;
    }

    // Update is called once per frame
    void Update()
    {
        PhaseBehaviour();
    }

    private void PhaseBehaviour()
    {
        if(GameStateEnum.gameStateEnum == GameStateEnum.GAMESTATE.InGameTerraforming)
        {
            FirstPhase();
        }
        else if (GameStateEnum.gameStateEnum == GameStateEnum.GAMESTATE.InGameFluid)
        {
            SecondPhase();
        }
        else if (GameStateEnum.gameStateEnum == GameStateEnum.GAMESTATE.Loose)
        {
            LooseState();
        }
    }

    private void FirstPhase()
    {
        firstPhaseTimer -= Time.deltaTime;
        if (firstPhaseTimer <= 0)
        {
            GameStateEnum.gameStateEnum = GameStateEnum.GAMESTATE.InGameFluid;
            firstPhaseTimer = firstPhaseTimerMax; 
        }
    }

    private void SecondPhase()
    {
        lavaSpawnObject.SetActive(true);
    }

    private void LooseState()
    {
        //lavaSpawnObject.SetActive(false);
        //display defeat screen
    }

    //called on event OnParticleCollisions
    public void SwitchToDefeatPhase(GameObject LooseObject)
    {
        GameStateEnum.gameStateEnum = GameStateEnum.GAMESTATE.Loose;
        LooseObject.SetActive(false);
    }
}
