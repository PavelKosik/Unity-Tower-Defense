using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

//Component used to spawn all the necessary managers in to a level
[ExecuteInEditMode]
public class NecessaryObjectsImporterScript : MonoBehaviour
{

    public GameObject enemyStatsPanelManager;
    private List<GameObject> instEnemyStatsPanelManager = new List<GameObject>();

    public GameObject audioSource; 
    private List<GameObject> instAudioSource = new List<GameObject>();


    public GameObject mainCanvas;
    private List<GameObject> instMainCanvas = new List<GameObject>();

    public GameObject eventSystem;
    private List<GameObject> instEventSystem = new List<GameObject>();

    public GameObject goldManager;
    private List<GameObject> instGoldManager=new List<GameObject>();

    public GameObject turretsStatsPanelBuildManager;
    private List<GameObject> instTurretsStatsPanelBuildManager= new List<GameObject>();

    public GameObject blockedPositionManager;
    private List<GameObject> instBlockedPositionManager=new List<GameObject>();

    private bool cameraSet = false;
    // Start is called before the first frame update    

    public void OnClick()
    {
        instEnemyStatsPanelManager.Add(Instantiate(enemyStatsPanelManager));
        instAudioSource.Add(Instantiate(audioSource));
        instMainCanvas.Add(Instantiate(mainCanvas));
        instEventSystem.Add(Instantiate(eventSystem));
        instGoldManager.Add(Instantiate(goldManager));
        instTurretsStatsPanelBuildManager.Add(Instantiate(turretsStatsPanelBuildManager));
        instBlockedPositionManager.Add(Instantiate(blockedPositionManager));

        if (cameraSet==false)
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
            cameraSet = true;
        }
    }

    public void Remove()
    {
        if (instEnemyStatsPanelManager!=null) {

            for (int i=0;i<instEnemyStatsPanelManager.Count;i++) {

                DestroyImmediate(instEnemyStatsPanelManager[i]);
                DestroyImmediate(instAudioSource[i]);
                DestroyImmediate(instMainCanvas[i]);
                DestroyImmediate(instEventSystem[i]);
                DestroyImmediate(instGoldManager[i]);
                DestroyImmediate(instTurretsStatsPanelBuildManager[i]);
                DestroyImmediate(instBlockedPositionManager[i]);
                
            }
            instEnemyStatsPanelManager.Clear();
            instAudioSource.Clear();
            instMainCanvas.Clear();
            instEventSystem.Clear();
            instGoldManager.Clear();
            instTurretsStatsPanelBuildManager.Clear();
            instBlockedPositionManager.Clear();
        }

        else
        {
            Debug.Log("There is nothing to remove!");
        }
    }

   
    
}
