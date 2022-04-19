using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GUI;

public class GameController : MonoBehaviour
{
    [Header("Map settings")]
    public int MapSizeX = 10;
    public int MapSizeY = 10;


    [Header("Prefabs")]
    public GameObject[] Prefabs_Enemies;
    public GameObject Prefab_bullet;
    public GameObject Prefab_laser;
    public GameObject Prefab_AsteroidParticle;


    private void Awake()
    {
        GameLogic.gc = this;
        GameLogic.PlayerObject = GameObject.Find("Player");
        GameLogic.controls = GameLogic.PlayerObject.GetComponent<PlayerControls>();
        GameLogic.gui = GameObject.Find("Canvas").GetComponent<GUIController>();

        EnemiesSpawner.InitializeEnemies(Prefabs_Enemies);
    }
    void Start()
    {
        
    }

    void Update()
    {
        EnemiesSpawning();
        InformationPanel.UpdateInformationalPanel(GameLogic.controls);
    }
    private void EnemiesSpawning()
    {
        for (int i = 0; i < EnemiesSpawner.EnemieTypes.Count; i++)
        {
            EnemiesSpawner.EnemieTypes[i].SpawningProcess();
        }
    }
    public void LoseGame()
    {
        GameLogic.gui.GameLostPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        GameLogic.gui.GameLostPanel.SetActive(false);
    }
}
