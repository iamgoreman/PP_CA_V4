using UnityEngine;
using System.Collections.Generic;
public class WeaponSwapping : MonoBehaviour {
	public int selectedWeapon = 0;
	// Use this for initialization

	private  List<GameObject> guns; 
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		int previousSelectedWeapon = selectedWeapon;
		if(Input.GetAxis("Mouse ScrollWheel") > 0f){
			if (selectedWeapon >= transform.childCount - 1) {
				selectedWeapon = 0;
			} else {
				selectedWeapon++;
			}

		}

		if(Input.GetAxis("Mouse ScrollWheel") < 0f){
			if (selectedWeapon <= 0) {
				selectedWeapon = transform.childCount - 1;
			} else {
				selectedWeapon--;
			}

		}

	

	void selectWeapon(){

		int i = 0;
		foreach (Transform weapon in transform) {
			if (i == selectedWeapon) {
				weapon.gameObject.SetActive (true);
			} else {
				weapon.gameObject.SetActive (false);
			}
			i++;
		}
	}


	void pickUpWeapon(GameObject gun){
		foreach(GameObject weapon in guns){
			if(gun.name != weapon.name){

				guns.Add(weapon);
			}
		}
		

	}
	}
}
