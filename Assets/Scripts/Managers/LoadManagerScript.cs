using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadManagerScript : MonoBehaviour
{
    public GameObject levelSelectMenu;
    public GameObject loadingMenu;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadLevelCoroutine(sceneIndex));
    }

    IEnumerator LoadLevelCoroutine(int sceneIndex)
    {
        //loads the level while showing the loading menu until the level is loaded
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        levelSelectMenu.SetActive(false);
        loadingMenu.SetActive(true);
        while (!operation.isDone)
        {
            float loadProgress = Mathf.Clamp01(operation.progress / 0.9f); // divided by 0.9f because of the way that operation.progress functions
            slider.value = loadProgress;
            Debug.Log(loadProgress);
            yield return null;
        }

       
    }
}
