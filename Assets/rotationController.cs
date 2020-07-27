using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rotationController : MonoBehaviour
{
    public Transform camera;
    private bool clockwise = false, anticlockwise = false, canRotate = true;
    public float rotateVel;
    public bool menuScreen = false;
    private bool menuCanRotate = false;
    public int moves = 0;
    //private sliderScript slider;

    // Start is called before the first frame update
    void Start()
    {
        //slider = GameObject.FindWithTag("progress").GetComponent<sliderScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && menuScreen == false){
            clockwise = true;
            //Debug.Log("click registered");
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1) && menuScreen == false){
            anticlockwise = true;
        }
        else if(Input.GetKeyDown(KeyCode.A)){
            //PlayerPrefs.DeleteAll();
        }
        else if(menuScreen == false && Input.GetKeyDown(KeyCode.R)){
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    void FixedUpdate(){
        if(clockwise == true){
            clockwise = false;
            if(canRotate == true){
                canRotate = false;
                //Debug.Log("starting function");
                StartCoroutine(clockwiseRotate());
            }
        }
        else if(anticlockwise == true){
            anticlockwise = false;
            if(canRotate == true){
                canRotate = false;
                StartCoroutine(anticlockwiseRotate());
            }
        }
        if(menuScreen == true){
            if(canRotate == true){
                canRotate = false;
                StartCoroutine(clockwiseRotate());
            }
        }
    }

    IEnumerator clockwiseRotate(){
        //Debug.Log("ROTATING");
        float counter = 0;
        if(menuScreen == false){
            //slider.appear();
        }
        while(1 > 0){
            camera.Rotate(0f, 0f, rotateVel);
            counter += rotateVel;
            if(menuScreen == false){
                //slider.addProgress(rotateVel/90f);
            }
            yield return new WaitForSeconds(0.02f);
            if(counter == 90f){
                break;
            }
        }
        if(menuScreen == true){
            yield return new WaitForSeconds(1f);
        }
        else{
            //slider.resetAndHide();
        }
        moves += 1;
        //Debug.Log(camera.rotation.eulerAngles.z);
        canRotate = true;
    }

    IEnumerator anticlockwiseRotate(){
        float counter = 0;
        if(menuScreen == false){
            //slider.appear();
        }
        while(1 > 0){
            camera.Rotate(0f, 0f, -1f * rotateVel);
            counter += rotateVel;
            if(menuScreen == false){
                //slider.addProgress(rotateVel/90f);
            }
            yield return new WaitForSeconds(0.02f);
            if(counter == 90f){
                break;
            }
        }
        if(menuScreen == true){
            yield return new WaitForSeconds(1f);
        }
        else{
            //slider.resetAndHide();
        }
        moves += 1;
        canRotate = true;
    }
}
