using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlCounter : MonoBehaviour
{
    public int curLvl;
    public List<int> devScore, pbScore;
    public int lvls; // number of levels

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("levelCounter");
        if(objs.Length > 1){
            Destroy(gameObject, 0f);
        }
        for(int i = 0; i < lvls; i++){
            pbScore.Add(100);
            if(!(PlayerPrefs.HasKey("pb" + i.ToString()))){
                PlayerPrefs.SetInt("pb" + i.ToString(), 100);
            }
            else{
                pbScore[i] = PlayerPrefs.GetInt("pb" + i.ToString());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextLevel(){
        curLvl += 1;
    }

    public int minusLevel(){
        return curLvl - 1;
    }
}
