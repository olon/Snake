using UnityEngine;
using System.Collections;

public class PathForTable : MonoBehaviour {


	void Start () {

#if UNITY_EDITOR
        SingletonGame.Instance.path = "ResultTable.xml";
#elif UNITY_ANDROID
        SingletonGame.Instance.path = Application.persistentDataPath + "ResultTable.xml";
#elif UNITY_STANDALONE_WIN
        SingletonGame.Instance.path = "ResultTable.xml";
#endif

    }


}
