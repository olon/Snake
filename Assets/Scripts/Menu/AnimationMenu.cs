using UnityEngine;
using System.Collections;

public class AnimationMenu : MonoBehaviour {

    public void Show(string show)
    {
        GetComponent<Animator>().SetTrigger(show);
    }

    public void Hide(string hide)
    {
        GetComponent<Animator>().SetTrigger(hide);
    }
}
