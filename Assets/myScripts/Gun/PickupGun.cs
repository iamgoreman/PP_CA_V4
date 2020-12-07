using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cammy;
    private float findRange = 3f;
    //public GameObject gun;
    Inventory inventory;
    ItemBank itemBank;
    GameObject gameController;
    public GameObject weaponSlot;
    public GameObject player;
    
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        inventory = player.GetComponent<Inventory>();
        itemBank = gameController.GetComponent<ItemBank>();

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cammy.ViewportPointToRay(new Vector3(.5f,.5f,0));
        RaycastHit hit; 
        
        
        if(Physics.Raycast(ray, out hit,findRange)){
            
               //Debug.Log(hit.collider);
                if ( hit.collider.tag == "Gun" && Input.GetKeyDown(KeyCode.E) )
                    {
                        int id = hit.transform.GetComponent<ItemID>().id;
                        int currentSlotID = inventory.currentSlot;
                        if(currentSlotID == 0){
                            if(inventory.inv[0] == null){  
                            inventory.inv[0] = Instantiate(itemBank.itemList[id].model,weaponSlot.transform.position,weaponSlot.transform.rotation);
                            inventory.inv[0].transform.SetParent(weaponSlot.transform);
                        }
                         if(hit.transform.GetComponent<ItemID>().id != inventory.inv[0].GetComponent<ItemID>().id ){

                             Destroy(inventory.inv[0]);
                             inventory.inv[0] = Instantiate(itemBank.itemList[id].model,weaponSlot.transform.position,weaponSlot.transform.rotation);
                             inventory.inv[0].transform.SetParent(weaponSlot.transform);
                         }

                         else{
                             Debug.Log("you already have a weapon");
                         }

                        }
                        
                        if(currentSlotID == 1){
                            if(inventory.inv[1] == null){  
                            inventory.inv[1] = Instantiate(itemBank.itemList[id].model,weaponSlot.transform.position,weaponSlot.transform.rotation);
                            inventory.inv[1].transform.SetParent(weaponSlot.transform);
                        }
                         if(hit.transform.GetComponent<ItemID>().id != inventory.inv[0].GetComponent<ItemID>().id ){

                             Destroy(inventory.inv[1]);
                             inventory.inv[1] = Instantiate(itemBank.itemList[id].model,weaponSlot.transform.position,weaponSlot.transform.rotation);
                             inventory.inv[1].transform.SetParent(weaponSlot.transform);
                         }

                         else{
                             Debug.Log("you already have a weapon");
                         }
                        }
                         
                     }



            }
    }
    // void checkInventory(int _currentSlotID){
    //     switch (_currentSlotID)
    //     {
            
    //         case 0:

    //     }
    // }
   
}
