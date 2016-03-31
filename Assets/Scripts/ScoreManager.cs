using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScoreManager : MonoBehaviour {

	// The map we're building is going to look like:
	//
	//	LIST OF USERS -> A User -> LIST OF SCORES for that user
	//

	Dictionary< string, Dictionary<string, int> > playerScores;

	int changeCounter = 0;

	void Start() {
	}

	void Init() {
		if(playerScores != null)
			return;

		playerScores = new Dictionary<string, Dictionary<string, int>>();
	}

	public void Reset() {
		changeCounter++;
		playerScores = null;
	}

	public int GetScore(string username, string scoreType) {
		Init ();

		if(playerScores.ContainsKey(username) == false) {
			// We have no score record at all for this username
			return 0;
		}

		if(playerScores[username].ContainsKey(scoreType) == false) {
			return 0;
		}

		return playerScores[username][scoreType];
	}

	public void SetScore(string username, string scoreType, int value) {
		Init ();

		changeCounter++;

		if(playerScores.ContainsKey(username) == false) {
			playerScores[username] = new Dictionary<string, int>();
		}

		playerScores[username][scoreType] = value;
	}
	
	public string[] GetPlayerNames(string sortingScoreType) {
		Init ();

		return playerScores.Keys.OrderByDescending( n => GetScore(n, sortingScoreType) ).ToArray();
	}

	public int GetChangeCounter() {
		return changeCounter;
	}

	public void DEBUG_INITIAL_SETUP() {
		SetScore("quill18", "score", 0);
		SetScore("quill18", "length", 345);
		
		SetScore("bob", "score", 1000);
		SetScore("bob", "length", 14345);
		
		SetScore("AAAAAA", "score", 3);
		SetScore("BBBBBB", "score", 2);
		SetScore("CCCCCC", "score", 1);
		
	}

}
