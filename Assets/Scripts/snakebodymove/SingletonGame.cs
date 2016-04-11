using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingletonGame {

    private static SingletonGame instance;

    public int _cameraSwitch = 1;
    public int lifeSnake = 3;
    public int points = 0;
    public float distanceSnake = 0;
    public string name = "Player";

    public List<AllDataListSnake> AllPointsList;

    private SingletonGame() { }

    public static SingletonGame Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingletonGame();
            }
            return instance;
        }
    }
}
