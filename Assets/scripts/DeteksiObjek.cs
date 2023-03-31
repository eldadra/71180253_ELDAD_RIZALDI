using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeteksiObjek : MonoBehaviour
{
    public string nameTag;
    public AudioClip audioBenar;
    public AudioClip audioSalah;
    private AudioSource MediaPlayerBenar;
    private AudioSource MediaPlayerSalah;
    public Text textScore;
    public Text textNyawa;
    void Start()
    {
        MediaPlayerBenar = gameObject.AddComponent<AudioSource>(); ;
        MediaPlayerBenar.clip = audioBenar;

        MediaPlayerSalah = gameObject.AddComponent<AudioSource>(); ;
        MediaPlayerSalah.clip = audioSalah;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals(nameTag))
        {
            Data.score += 10;
            textScore.text = Data.score.ToString();
            Destroy(collision.gameObject);
            MediaPlayerBenar.Play();    
        }
        else
        {
            if(Data.nyawa <2)
            {
                Destroy(collision.gameObject);
                Data.nyawa = Data.nyawa - 1;
                textNyawa.text = Data.nyawa.ToString();
                SceneManager.LoadScene("Gameover");
            }
            else
            {
                Data.score -= 5;
                Data.nyawa = Data.nyawa - 1;
                textScore.text = Data.score.ToString();
                textNyawa.text = Data.nyawa.ToString();
                Destroy(collision.gameObject);
                MediaPlayerSalah.Play();
            }
            
        }
    }
}
