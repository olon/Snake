using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;

	ScoreManager scoreManager;

	int lastChangeCounter;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.FindObjectOfType<ScoreManager>();

		lastChangeCounter = scoreManager.GetChangeCounter();

        ResultTableContainer Result = new ResultTableContainer().LoadParamsInResultTable();
        int i = 0;
        foreach (var resultList in Result.ResultTableList)
        {
            GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform);
            go.transform.Find("TextNumber").GetComponent<Text>().text = "" + ++i + "-->";
            go.transform.Find("TextUserName").GetComponent<Text>().text = resultList.userName;
            go.transform.Find("TextScores").GetComponent<Text>().text = resultList.scores.ToString();
        }
    }
	
	// Update is called once per frame
	void Update () {
        //if(scoreManager == null) {
        //	Debug.LogError("You forgot to add the score manager component to a game object!");
        //	return;
        //}

        //if(scoreManager.GetChangeCounter() == lastChangeCounter) {
        //	// No change since last update!
        //	return;
        //}

        //lastChangeCounter = scoreManager.GetChangeCounter();

        //while(this.transform.childCount > 0) {
        //	Transform c = this.transform.GetChild(0);
        //	c.SetParent(null);  // Become Batman
        //	Destroy (c.gameObject);
        //}

        //string[] names = scoreManager.GetPlayerNames("kills");

        //foreach(string name in names) {
        //	GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
        //	go.transform.SetParent(this.transform);
        //	go.transform.Find ("TextUserName").GetComponent<Text>().text = name;
        //	go.transform.Find ("TextScores").GetComponent<Text>().text = scoreManager.GetScore(name, "score").ToString();
        //}

	}
}
