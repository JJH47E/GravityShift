using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour
{
    void Start(){
        DontDestroyOnLoad(gameObject);
        Debug.Log("not destroying");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("sound");
        if(objs.Length > 1){
            Destroy(gameObject, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
