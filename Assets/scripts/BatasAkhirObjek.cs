using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BatasAkhirObjek : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textNyawa;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(Data.nyawa < 2)
        {
            Destroy(collision.gameObject);
            Data.nyawa -= 1;
            textNyawa.text = Data.nyawa.ToString();
            SceneManager.LoadScene("Gameover");
        }
        else
        {
            Data.nyawa -= 1;
            textNyawa.text = Data.nyawa.ToString();
            Destroy(collision.gameObject);
        }
    }
}
