using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.Networking;

public class buttonController : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public GameObject data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toMenu(){
        SceneManager.LoadScene("menu");
    }

    public void toHelp(){
        SceneManager.LoadScene("help");
    }

    public void toCustom(){
        SceneManager.LoadScene("custom");
    }

    public void toLvlSel(){
        SceneManager.LoadScene("lvlsel");
    }

    public void playCustom(){
        SceneManager.LoadScene("playCustom");
    }

    public void downloadCustom(){
        string url = txt.text;
        fetchLevel(url);
    }

    public void fetchLevel(string url){
        GameObject d = Instantiate(data, new Vector3(0f, 0f, 0f), Quaternion.Euler(0, 0, 0));
        d.GetComponent<persistentData>().setName(url);
        playCustom();
    }

    public void loadLevel(){
        string lvl = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        GameObject.FindWithTag("levelCounter").GetComponent<LvlCounter>().curLvl = int.Parse(lvl);
        SceneManager.LoadScene("lvl" + lvl);
    }

    public void nextLevel(){
        GameObject.FindWithTag("levelCounter").GetComponent<LvlCounter>().nextLevel();
        string nextLvl = GameObject.FindWithTag("levelCounter").GetComponent<LvlCounter>().curLvl.ToString();
        SceneManager.LoadScene("lvl" + nextLvl);
    }

    public void openURL(){
        Application.OpenURL("https://jjh47e.github.io/games/GravityShift/custom_levels/");
    }
}
