﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class customLevelBuilder : MonoBehaviour
{
    public string TxtFile;
    private string txt;
    public GameObject block, player, finish;

    // Start is called before the first frame update
    void Start()
    {
        txt = File.ReadAllText(Application.dataPath + TxtFile);
        buildLevel(txt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buildLevel(string file){
        List<List<string>> lst = buildList(file);
        for(int i = 0; i < lst.Count; i++){
            for(int k = 0; k < lst.Count; k++){
                if(lst[i][k] == "0"){

                }
                else if(lst[i][k] == "X"){
                    Instantiate(block, new Vector3((9f/lst.Count) * (k) - 4.5f + ((9f/lst.Count)/2), (9f/lst.Count) * (lst.Count-1-i) - 4.5f + ((9f/lst.Count)/2), 0f), Quaternion.Euler(0f, 0f, 0f));
                }
                else if(lst[i][k] == "P"){
                    Instantiate(player, new Vector3((9f/lst.Count) * (k) - 4.5f + ((9f/lst.Count)/2), (9f/lst.Count) * (lst.Count-1-i) - 4.5f + ((9f/lst.Count)/2), 0f), Quaternion.Euler(0f, 0f, 0f));
                }
                else if(lst[i][k] == "F"){
                    Instantiate(finish, new Vector3((9f/lst.Count) * (k) - 4.5f + ((9f/lst.Count)/2), (9f/lst.Count) * (lst.Count-1-i) - 4.5f + ((9f/lst.Count)/2), 0f), Quaternion.Euler(0f, 0f, 0f));
                }
            }
        }
        GameObject[] scale = GameObject.FindGameObjectsWithTag("block");
        for(int i = 0; i < scale.Length; i++){
            scale[i].GetComponent<Transform>().localScale = new Vector3((9f/(lst.Count)), (9f/(lst.Count)), 1f);
        }
    }

    List<List<string>> buildList(string file){
        List<List<string>> output = new List<List<string>>();
        for(int i = 0; i < file.Split('\n').Length; i++){
            List<string> subOut = new List<string>();
            for(int k = 0; k < file.Split('\n').Length; k++){
                subOut.Add(file.Split('\n')[i][k].ToString());
            }
            output.Add(subOut);
        }
        return output;
    }
}
