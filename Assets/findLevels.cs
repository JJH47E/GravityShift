using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class findLevels : MonoBehaviour
{
    public GameObject button, noLevelText;
    public int btns = 0;
    // Start is called before the first frame update
    void Start()
    {
        DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "\\StreamingAssets\\CustomLevels\\");
        FileInfo[] info = dir.GetFiles("*.txt");
        if(info.Length > 0){
            //remove  line below
            //Destroy(noLevelText, 0f);
            List<FileInfo> infoList = new List<FileInfo>();
            for(int i = 0; i < info.Length; i++){
                infoList.Add(info[i]);
            }
            for(int i = 0; i < infoList.Count; i++){
                //Debug.Log("TEST BEGUN  " + infoList[i].Name + " : " + i + " : " + infoList.Count);
                string txt = File.ReadAllText(infoList[i].DirectoryName + "\\" + infoList[i].Name);
                if(!(legalCustomLevel(txt))){
                    infoList.RemoveAt(i);
                    i -= 1;
                    Debug.Log("Failed");
                }
                else{
                    Destroy(noLevelText, 0f);
                    GameObject btn = Instantiate(button, new Vector3(0f, 0, 0f), Quaternion.Euler(0f, 0f, 0f));
                    btn.transform.parent = GameObject.Find("Panel").transform;
                    btn.GetComponent<buttonInfo>().setName(infoList[i].Name.Substring(0, infoList[i].Name.Length - 4));
                    btn.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
                    btns += 1;
                    //Debug.Log("added button");
                }
            }
            GameObject.Find("scrollPanelHandler").GetComponent<scrollpanel>().arrangeButtons(btns);
            //Debug.Log("End of testing");
        }
        else{
            Debug.Log("no levels found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool legalCustomLevel(string text){
        List<List<string>> tempVar = buildList(text);
        for(int i = 0; i < tempVar.Count - 1; i++){
            tempVar[i].RemoveAt(tempVar.Count - 1);
        }
        for(int k = 0; k < tempVar.Count; k++){
            if(tempVar[k].Count != tempVar.Count){
                return false;
            }
        }
        return true;
    }

    List<List<string>> buildList(string file){
        List<List<string>> output = new List<List<string>>();
        for(int i = 0; i < file.Split('\n').Length; i++){
            List<string> subOut = new List<string>();
            for(int k = 0; k < file.Split('\n')[i].Length; k++){
                if(file.Split('\n')[i][k].ToString() != '\n'.ToString()){
                    subOut.Add(file.Split('\n')[i][k].ToString());
                }
            }
            output.Add(subOut);
        }
        return output;
    }
}
