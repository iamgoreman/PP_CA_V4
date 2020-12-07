using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inv;
    public int currentSlot = 0;
    GameObject gc;
    ItemBank ib;
    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        inv = new GameObject[2];
        gc = GameObject.FindGameObjectWithTag("GameController");
        ib = gc.GetComponent<ItemBank>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f){
			if (currentSlot >= 1) {
                currentSlot = 0;
                
            }
            else{
                currentSlot++;
            }
		}

		if(Input.GetAxis("Mouse ScrollWheel") < 0f){
			if (currentSlot <= 0) {
                currentSlot = 1;
            }
            else{
                currentSlot--;
            }
            

		}
        RenderGun();
        if(Input.GetButtonDown("Fire1")){
            CallFire(currentSlot);
        }
    }

    void CallFire(int _currentSlot ){
        
           //ib.playerList[_ID].GetComponent<Inventory>().inv[_currentSlot].GetComponent<Gun>().Fire();
            inv[_currentSlot].GetComponent<Gun>().Fire();
            
        
    }

    int findPlayerID( GameObject character){
        
        return character.GetComponent<Unit>().ID;

    }

    void RenderGun(){
        int i = 0;
		foreach (GameObject weapon in inv) {
            if(weapon != null){
                if (i == currentSlot) {
				weapon.gameObject.SetActive (true);
			} else {
				weapon.gameObject.SetActive (false);
			}
			i++;
            }
			
		}
    }

    
}
