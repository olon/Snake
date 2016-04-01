using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonChangeYourName : MonoBehaviour {

    public InputField newName;
    public static bool nameFlag = false;

    public void ChangeYourName()
    {
        SingletonGame.Instance.name = newName.text;
        nameFlag = true;
    }

}
