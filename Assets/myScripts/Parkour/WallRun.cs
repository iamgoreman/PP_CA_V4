using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    public CharacterController playerCC;
    public LayerMask runnable;
    public float speed = 10;
    public float wallDist;
    bool isWallRunning, OnWall,foundWall;
    RaycastHit hit;
    Vector3[] directions;
    RaycastHit [] hits;
    Ray wallPath;
    // Start is called before the first frame update
    void Start()
    {
        isWallRunning = false;
        OnWall = false;
        directions = new Vector3[]{
            Vector3.right,
            Vector3.left,
            Vector3.forward

        } ;
    }

    // Update is called once per frame
    void Update()
    {   
        hits = new RaycastHit[directions.Length];
        for (int i = 0; i< directions.Length; i++)
        {
            Vector3 dir = transform.TransformDirection(directions[i]);
            Physics.Raycast(transform.position,dir,out hits[i],wallDist);
            Debug.DrawRay(transform.position,dir,Color.red);
            foundWall = Physics.Raycast(transform.position,dir,out hit,3f);
        }
        
        
        if(foundWall && hit.collider.gameObject.layer == 11){
            wallPath = new Ray(hit.point,Vector3.Cross(hit.normal,Vector3.up).normalized);         
            Debug.DrawRay(hit.point,Vector3.Cross(hit.normal,Vector3.up).normalized,Color.red);
            //Debug.Log(hit.collider.gameObject.layer);
        }
            
        if(Input.GetKeyDown(KeyCode.R) && !playerCC.isGrounded){
            isWallRunning = true;
            Debug.Log(wallPath);
        }   

        if(isWallRunning){
            isOnWall();
            wallRun(wallPath);
        } 
            
        if(playerCC.isGrounded || !OnWall){
            isWallRunning = false;
        }
        
        
    }
    void isOnWall(){
        if(foundWall && !playerCC.isGrounded){
            OnWall = true;
            isWallRunning = true;
            playerCC.GetComponent<PlayerMovement>().gravity = 0f;           
        }
        else{
            OnWall = false;
            isWallRunning = false;
            playerCC.GetComponent<PlayerMovement>().gravity = -10f;
        }
    }

    void wallRun(Ray _dir){
        
             //playerCC.GetComponent<PlayerMovement>().gravity = 0f;
            Debug.Log(_dir);
            playerCC.Move(_dir.direction * speed * Time.deltaTime);
        
    }
}
