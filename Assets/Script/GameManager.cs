using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerMovement thePlayer;
    public PlayerHealth thePlayerHealth;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;
    private EnemyDestroyer[] enemyList;
    private HealthDestroyer[] healthList;

    private ScoreManager theScoreManager;
    public AudioSource playerDeathSound;
    public DeathMenu theDeathMenu;
    public PauseMenu thePauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            thePauseMenu.PauseGame();
        }
    }

    public void RestartGame()
    {
        // StartCoroutine ("RestartGameCo");
        playerDeathSound.Play();

        thePlayer.moveSpeed = thePlayer.moveSpeedStore;
        thePlayer.speedMilestoneCount = thePlayer.speedMilestoneCountStore;
        thePlayer.speedIncreaseMilestone = thePlayer.speedIncreaseMilestoneStore;

        theScoreManager.scoreIncreasing = false;

        thePlayer.gameObject.SetActive(false);

        theDeathMenu.gameObject.SetActive(true);
    }

    public void Reset()
    {
        theDeathMenu.gameObject.SetActive(false);

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        enemyList = FindObjectsOfType<EnemyDestroyer>();
        for(int i = 0; i < enemyList.Length; i++)
        {
            Destroy(enemyList[i].gameObject);
        }

        healthList = FindObjectsOfType<HealthDestroyer>();
        for(int i = 0; i < healthList.Length; i++)
        {
            Destroy(healthList[i].gameObject);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        thePlayerHealth.AddHealth(3);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

    /*public IEnumerator RestartGameCo()
    {
        // playerDeathSound.Play();

        // thePlayer.moveSpeed = thePlayer.moveSpeedStore;
        // thePlayer.speedMilestoneCount = thePlayer.speedMilestoneCountStore;
        // thePlayer.speedIncreaseMilestone = thePlayer.speedIncreaseMilestoneStore;

        // theScoreManager.scoreIncreasing = false;

        // thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);

        // platformList = FindObjectsOfType<PlatformDestroyer>();
        // for(int i = 0; i < platformList.Length; i++)
        // {
        //     platformList[i].gameObject.SetActive(false);
        // }

        // enemyList = FindObjectsOfType<EnemyDestroyer>();
        // for(int i = 0; i < enemyList.Length; i++)
        // {
        //     Destroy(enemyList[i].gameObject);
        // }

        // healthList = FindObjectsOfType<HealthDestroyer>();
        // for(int i = 0; i < healthList.Length; i++)
        // {
        //     Destroy(healthList[i].gameObject);
        // }

        // thePlayer.transform.position = playerStartPoint;
        // platformGenerator.position = platformStartPoint;
        // thePlayer.gameObject.SetActive(true);

        // thePlayerHealth.AddHealth(3);

        // theScoreManager.scoreCount = 0;
        // theScoreManager.scoreIncreasing = true;
    }*/
}
