using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelMenu : AnimationMenu
{

    void Awake()
    {
        transform.Find("TextNamePlayer").GetComponent<Text>().text = SingletonGame.Instance.name;
    }

    void Update()
    {
        if (!ButtonChangeYourName.nameFlag)
            return;

        transform.Find("TextNamePlayer").GetComponent<Text>().text = SingletonGame.Instance.name;
        ButtonChangeYourName.nameFlag = false;
    }

}
