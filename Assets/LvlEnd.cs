using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlEnd : MonoBehaviour
{
    private bool colliding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("ending");
        colliding = true;
        StartCoroutine(EndLvl());
    }

    void OnCollisionExit2D(Collision2D col){
        Debug.Log("left finish tile");
        colliding = false;
    }

    IEnumerator EndLvl(){
        yield return new WaitForSeconds(1f);
        if(colliding == true){
            if(GameObject.Find("rotateHandler").GetComponent<rotationController>().moves < PlayerPrefs.GetInt("pb" + GameObject.FindWithTag("levelCounter").GetComponent<LvlCounter>().minusLevel().ToString())){
                PlayerPrefs.SetInt("pb" + GameObject.FindWithTag("levelCounter").GetComponent<LvlCounter>().minusLevel().ToString(), GameObject.Find("rotateHandler").GetComponent<rotationController>().moves);
            }
            Debug.Log(GameObject.Find("rotateHandler").GetComponent<rotationController>().moves);
            Debug.Log("pb" + GameObject.FindWithTag("levelCounter").GetComponent<LvlCounter>().minusLevel().ToString());
            SceneManager.LoadScene("PostLvl");
        }
    }
}
