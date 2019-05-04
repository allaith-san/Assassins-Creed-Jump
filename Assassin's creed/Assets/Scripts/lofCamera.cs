using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lofCamera : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("playerClone");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,player.transform.position.y + 5,player.transform.position.z - 3);
    }
}
