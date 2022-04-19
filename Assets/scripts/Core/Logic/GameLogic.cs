using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameLogic 
{
    public static GameController gc;
    public static GUI.GUIController gui;
    public static  GameObject PlayerObject;
    public static PlayerControls controls;
    
   
    
    public static Vector3 GetRandomBorderPosition()
    {
        int Modifier = 1;
        if (RandomValue())
        {
            Modifier *= -1;
        }
        if (RandomValue())
        {
            return new Vector3(gc.MapSizeX * Modifier, Random.Range(-gc.MapSizeY, gc.MapSizeY));
        }
        else
        {
            return new Vector3(Random.Range(-gc.MapSizeX, gc.MapSizeX), gc.MapSizeY * Modifier);
        }
    }
    public static bool RandomValue()
    {
        if (Random.Range(0, 2) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static void MapLeaving(Transform LeavingTransform)
    {
        if (LeavingTransform.position.x > GameLogic.gc.MapSizeX)
        {
            LeavingTransform.position = new Vector3(LeavingTransform.position.x - (GameLogic.gc.MapSizeX * 2), LeavingTransform.position.y);
        }

        if (LeavingTransform.position.y > GameLogic.gc.MapSizeY)
        {
            LeavingTransform.position = new Vector3(LeavingTransform.position.x, LeavingTransform.position.y - (GameLogic.gc.MapSizeY * 2));
        }

        if (LeavingTransform.position.x < -GameLogic.gc.MapSizeX)
        {
            LeavingTransform.position = new Vector3(LeavingTransform.position.x + (GameLogic.gc.MapSizeX * 2), LeavingTransform.position.y);
        }

        if (LeavingTransform.position.y < -GameLogic.gc.MapSizeY)
        {
            LeavingTransform.position = new Vector3(LeavingTransform.position.x, LeavingTransform.position.y + (GameLogic.gc.MapSizeY * 2));
        }
    }
    
}
