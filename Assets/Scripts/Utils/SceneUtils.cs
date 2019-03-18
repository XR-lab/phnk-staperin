using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneUtils {
    public static void Reset() {

		string _SceneName = SceneManager.GetActiveScene().name;

		if(SceneManager.UnloadSceneAsync(_SceneName).isDone){
			SceneManager.LoadScene(_SceneName,LoadSceneMode.Single);
		}
    }
}