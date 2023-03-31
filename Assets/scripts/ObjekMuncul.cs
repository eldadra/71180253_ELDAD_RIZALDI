using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjekMuncul : MonoBehaviour
{
    public float jeda = 1.3f;
    float timer;
    public GameObject[] objek;
    void Start()
    {
        
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > jeda )
        {
            int random = Random.Range( 0, objek.Length );
            Instantiate(objek[random], transform.position, transform.rotation );
            timer = 0;
        }
    }
}
