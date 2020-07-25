using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log("Triggered!");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("door");
        for(int i = 0; i < objs.Length; i++){
            objs[i].GetComponent<BoxCollider2D>().isTrigger = true;
            objs[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
}
