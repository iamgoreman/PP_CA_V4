using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    int id;
    public float shotTimer,maxX,maxY;
    float minX,minY;
    ItemBank ib;
    GameObject GC;
    int currentAmmo;

    public GameObject bulletPrefab; 
    public Transform gunSlot;

    public Transform muzzle;
    void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameController");
        ib = GC.GetComponent<ItemBank>();
        id = GetComponent<ItemID>().id;
        minX = maxX *-1;
        minY = maxY *-1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(){
        Vector3 range = new Vector3(Random.Range(minX,maxX),Random.Range(minY,maxY),0);
        Instantiate(bulletPrefab,muzzle.transform.position + new Vector3(0f,0f,1f),muzzle.transform.rotation);
        bulletPrefab.transform.Rotate(range);
    }
}
