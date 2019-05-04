using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class cameraShaker : MonoBehaviour
{
    bool shake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shake){
            CameraShaker.Instance.ShakeOnce(1f,2f,.2f,2f);
        }
    }

    public void StopTheShaker(){
        shake = false;
    }
}
