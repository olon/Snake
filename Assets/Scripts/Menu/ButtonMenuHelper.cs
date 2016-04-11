using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMenuHelper : MonoBehaviour {

    public Text _textCamera;
    public GameObject[] AllPanel; 

    void Awake()
    {
        HelpChangeCamera(0, 1, "Classic Camera", "Third Person");
        SingletonGame.Instance.points = 0;
        SingletonGame.Instance.lifeSnake = 3;
    }
    
    public void OnStartGameClick()
    {
        if(SingletonGame.Instance._cameraSwitch == 1)
            GameController.LoadLevelSnakeThirdPerson();
        else
            GameController.LoadLevelSnake();
    }

    private void HelpChangeCamera(int firstCamera, int secondCamera, string firstNameCamera, string secondNameCamera)
    {
        switch (SingletonGame.Instance._cameraSwitch)
        {
            case 0:
                {
                    _textCamera.text = "Camera:" + Environment.NewLine + firstNameCamera; 
                    SingletonGame.Instance._cameraSwitch = firstCamera; 
                }
                break;
            case 1:
                {
                    _textCamera.text = "Camera:" + Environment.NewLine + secondNameCamera; 
                    SingletonGame.Instance._cameraSwitch = secondCamera; 
                }
                break;
        }
    }

    public void OnChangeCameraClick()
    {
        HelpChangeCamera(1, 0, "Third Person", "Classic Camera");
    }

    public void OnScoreScreenClick()
    {
        AllPanel[0].SetActive(false);
        AllPanel[1].SetActive(true);
    }

    public void OnExitGameClick()
    {
        GameController.ExitGame();
    }
}
