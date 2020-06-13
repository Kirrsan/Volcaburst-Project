using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateEnum : MonoBehaviour
{
    public enum GAMESTATE
    {
        Menu,
        InGameTerraforming,
        InGameFluid,
        Win,
        Loose
    }

    public static GAMESTATE gameStateEnum;

}
