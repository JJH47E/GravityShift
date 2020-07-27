using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class persistentData : MonoBehaviour
{
    private string file;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(GameObject.FindGameObjectsWithTag("GameController").Length > 1){
            Destroy(gameObject, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPath(string n){
        file = n;
    }

    public string getPath(){
        return file;
    }
}
