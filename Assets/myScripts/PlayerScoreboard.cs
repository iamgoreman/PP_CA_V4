using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreboard : MonoBehaviour
{
    Transform container;
    Transform template;
    public List<GameObject> entityList = new List<GameObject>();
    // Start is called before the first frame update

   void Awake() {
       container = transform.Find("Score Panel");
       //Debug.Log(container);
       template = container.Find("tableEntry");

       template.gameObject.SetActive(false);
       entityList = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>().entityList; 
       Debug.Log(GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>().entityList);
       float height = 20f;

       for (int i = 0; i < entityList.Count; i++)
       {
           Transform playerEntry = Instantiate(template,container);
           RectTransform entryRect = playerEntry.GetComponent<RectTransform>();
           entryRect.anchoredPosition = new Vector2(0,i*-height);
           playerEntry.gameObject.SetActive(true);

            playerEntry.Find("playername").GetComponent<Text>().text = string.Concat(entityList[i].GetComponent<Entity>().name);

            int kill = Random.Range(0,5);
            int death = Random.Range(0,10);

            playerEntry.Find("killcount").GetComponent<Text>().text = kill.ToString();
            playerEntry.Find("deathcount").GetComponent<Text>().text = death.ToString();

       }
   }
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Tab)){
            container.gameObject.SetActive(true);
        }
        else{
            container.gameObject.SetActive(false);
        }
    }
}
