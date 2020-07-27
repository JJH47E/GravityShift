using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonInfo : MonoBehaviour
{
    private string name, path;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public string getPath(){
        return path;
    }

    public void setName(string n){
        this.name = n;
        //Debug.Log("name set to " + n);
        gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = name;// = what it gets given by findLevels.cs script
        path = Application.dataPath + "\\StreamingAssets\\CustomLevels\\" + name + ".txt";
    }
}
