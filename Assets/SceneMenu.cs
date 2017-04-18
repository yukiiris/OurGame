using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour {
    private void Awake()
    {
        SceneManager.LoadScene("片头",LoadSceneMode.Additive);
    }
}
