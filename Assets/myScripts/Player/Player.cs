using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    // Start is called before the first frame update
    public int ID;
    public int health; 
    public GameObject SpawnFolder;
    List<SpawnPoint> SpawnPoints;
    Inventory inventory;
    public LayerMask Enemies;
    bool dead;
    public Camera deathCam, mainCam;
    float deathTimer = 3f;

    void Start() {
        inventory = GetComponent<Inventory>();
        PopulateSpawnPoints();
        SpawnPlayer();
        name = "Mavaris";
    }

    void Update() {
          if(Input.GetMouseButtonDown(1)){
              health = 0;
          }

          if(health <= 0 && !dead){
              KillPlayer();
          }
          
          //deathCam.transform = Vector3.RotateTowards(deathCam.transform.position,transform.position,1f*Time.deltaTime,0.0f);
    }

    void SpawnPlayer() {
        
        if(SpawnPoints.Count != 0){
            int range = Random.Range(0,SpawnPoints.Count - 1);
            //Debug.Log(SpawnPoints[range].transform.position);
            if(!Physics.CheckSphere(SpawnPoints[range].transform.position,SpawnPoints[range].spawnRange,Enemies)){
                transform.position = SpawnPoints[range].transform.position;
            }

            else{
                SpawnPlayer();
            }
        }

    }

    void KillPlayer(){
        dead = true;
        mainCam.gameObject.GetComponent<CameraController>().SwitchActivation();
        deathCam.gameObject.GetComponent<DeathCameraController>().SwitchActivation();
        gameObject.GetComponent<CharacterController>().enabled = false;
        Invoke(nameof(RespawnPlayer),deathTimer);
    }

    void RespawnPlayer(){
        health = 100;
        mainCam.gameObject.GetComponent<CameraController>().SwitchActivation();
        deathCam.gameObject.GetComponent<DeathCameraController>().SwitchActivation();
        gameObject.GetComponent<CharacterController>().enabled = true;
        SpawnPlayer();
        dead = false;
    }

    void PopulateSpawnPoints(){
        
        List<SpawnPoint> _tempList = new List<SpawnPoint>();
        
        foreach (Transform child in SpawnFolder.transform)
        {
           // Debug.Log(SpawnFolder.GetComponentInChildren<Transform>());
            if(child!= null && child.gameObject != null){
                _tempList.Add(child.GetComponent<SpawnPoint>());
            }
        }
        
        SpawnPoints = _tempList;
    }
}