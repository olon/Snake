using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.IO;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;

    ResultTableContainer Result;

    int lastChangeCounter = -1;

	// Use this for initialization
	void Start () {

        if (!System.IO.File.Exists(SingletonGame.Instance.path))
        {
            return;
        }
        Result = new ResultTableContainer().LoadParamsInResultTable();
    }
	
	// Update is called once per frame
	void Update () {
        if (Result == null)
        {
            return;
        }

        if (Result.ResultTableList.Count == lastChangeCounter)
        {
            // No change since last update!
            return;
        }

        //Sort the list by points and displays the top 10 players
        var scores =
            (from score in Result.ResultTableList
            let n = score.userName
            let p = score.scores
            orderby p descending
            select new { name = n, score = p }).Take(10);

        int indexScores = 0;
        foreach (var resultList in scores)
        {
            GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
            go.transform.Find("TextNumber").GetComponent<Text>().text = "" + ++indexScores + "-->";
            go.transform.Find("TextUserName").GetComponent<Text>().text = resultList.name;
            go.transform.Find("TextScores").GetComponent<Text>().text = resultList.score.ToString();
        }
        lastChangeCounter = Result.ResultTableList.Count;
    }
}
