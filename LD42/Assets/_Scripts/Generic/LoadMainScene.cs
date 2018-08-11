using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour {

    public List<string> SceneList;

    private void Start()
    {
        foreach (var item in SceneList)
        {
            SceneManager.LoadScene(item,LoadSceneMode.Additive);
        }       
    }
}
