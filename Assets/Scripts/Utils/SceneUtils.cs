using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneUtils {
    public static void Reset() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}