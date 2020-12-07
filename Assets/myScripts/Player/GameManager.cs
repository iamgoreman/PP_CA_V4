using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawners
{
    public GameObject go;
    public bool active;
    public Spawners(GameObject newGo, bool newBool)
    {
        go = newGo;
        active = newBool;
    }
}

public class GameManager : MonoBehaviour
{
    // public GameObject panel;
    // public delegate void RestartRounds();
    // public static event RestartRounds RoundComplete;

    // private int health;
    // private int roundsSurvived;
    // private int currentRound;
    // private PlayerDamage playerDamage;
    // private Text panelText;

    public List<Spawners> spawner = new List<Spawners>();

    public List<GameObject> entityList = new List<GameObject>();

    void Awake() {
        
       List<GameObject> _playerList = GameObject.FindGameObjectsWithTag("Player").ToList();
       List<GameObject> _botList = GameObject.FindGameObjectsWithTag("Bot").ToList();
       Debug.Log(entityList);
        // GameObject[] _playerList = GameObject.FindGameObjectsWithTag("Player");
        if(_playerList.Count >0){
            foreach (GameObject player in _playerList)
            {
                entityList.Add(player);
            }
        }
        if(_botList.Count > 0){
            foreach (GameObject bot in _botList)
            {
                entityList.Add(bot);
            }
        }
        for (int i = 0; i < entityList.Count; i++)
        {   
            Debug.Log(entityList[i]);
        } 
    }
    void Start()
    {
        // Time.timeScale = 1;
        // //panel.SetActive(false);
        // playerDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamage>();
        // panelText = panel.GetComponentInChildren<Text>();
        // foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        // {
        //     if (go.name.Contains("Spawner"))
        //     {
        //         spawner.Add(new Spawners(go, true));
        //     }
        // }
        
        
        
        // GameObject[] _botList = GameObject.FindGameObjectsWithTag("Bot");
        // _botList.CopyTo(entityList,entityList.Length-1);
        // foreach (GameObject unit in entityList)
        // {
        //     Debug.Log(unit);
        // }
        
       
    }

    void Update()
    {
        

        // int total = 0;
        // health = playerDamage.health;
        // if (health > 0)
        // {
        //     for (int i = spawner.Count - 1; i >= 0; i--)
        //     {
        //         if (spawner[i].go.GetComponent<Spawner>().spawnsDead)
        //         {
        //             total++;
        //         }
        //     }

        //     if (total == spawner.Count && roundsSurvived == currentRound)
        //     {
        //         roundsSurvived++;
        //         panelText.text = string.Format("Round {0} Completed!", roundsSurvived);
        //         panel.SetActive(true);
        //     }

        //     if (roundsSurvived != currentRound && Input.GetButton("Fire2"))
        //     {
        //         currentRound = roundsSurvived;
        //         RoundComplete();
        //         panel.SetActive(false);
        //     }
        // }
        // else
        // {
        //     if (Input.GetButton("Fire2"))
        //     {
        //         Scene current = SceneManager.GetActiveScene();
        //         SceneManager.LoadScene(current.name);
        //     }
        //     else
        //     {
        //         panel.SetActive(true);
        //         panelText.text = string.Format("Survived {0} Rounds", roundsSurvived);
        //         Time.timeScale = 0;
        //     }
        // }
    }
}
