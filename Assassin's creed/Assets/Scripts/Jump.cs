using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Jump : MonoBehaviour
{

    public GameObject UIText1;
    public GameObject UIText2;
    public GameObject PlayerCamera;
    public GameObject CutsceneCamera;
    public GameObject lofCamera;
    public GameObject playerclone;
    bool init ;
    bool pressed;
    bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(init){

            if(!pressed && Input.GetKeyDown(KeyCode.E)){
                UIText1.SetActive(false);
                StartCutscene();
            }else if (!pressed){
                UIText1.SetActive(true);
            }

            if(canJump && pressed && Input.GetKeyDown(KeyCode.Space)){
                LOF();
            }else if (canJump && pressed){
                UIText2.SetActive(true);  
            }

        }else{
            UIText1.SetActive(false); 
            UIText2.SetActive(false);  
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Jump"){
            gameObject.GetComponent<ThirdPersonCharacter>().Crouch(true);
        }
        if(other.tag == "JumpingPoint"){
            init = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "JumpingPoint"){
            init = false;
        }
    }

    public void StartCutscene(){
        gameObject.GetComponent<Animator>().enabled = false;
        pressed = true;
        PlayerCamera.SetActive(false);
        CutsceneCamera.SetActive(true);
        gameObject.GetComponent<ThirdPersonCharacter>().cantMove = true;
    }

    public void ExitCutscene(){
        gameObject.GetComponent<Animator>().enabled = true;
        canJump = true;
        PlayerCamera.SetActive(true);
        CutsceneCamera.SetActive(false);
        gameObject.GetComponent<ThirdPersonCharacter>().cantMove = false;
    }

    public void LOF(){
        UIText2.SetActive(false);  
        PlayerCamera.SetActive(false);
        CutsceneCamera.SetActive(false);
        lofCamera.SetActive(true);
        playerclone.SetActive(true);
        gameObject.SetActive(false);
    }
}
