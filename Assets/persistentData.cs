using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class persistentData : MonoBehaviour
{
    private string file;
    private bool build = true;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("CustomLevelBuilder") && build == true){
            build = false;
            Debug.Log("its broken...");
            GameObject.Find("CustomLevelBuilder").GetComponent<customLevelBuilderPrivate>().buildLevel(File.ReadAllText(Application.dataPath + @"\" + "StreamingAssets" + @"\" + "Levels" + @"\" + file + ".txt"));
            Destroy(gameObject, 0f);
        }
    }

    public void setName(string n){
        gameObject.GetComponent<persistentData>().file = n;
    }

    public string getName(){
        return file;
    }
}
