using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FonMover : MonoBehaviour
{
    public Animator Player;
    public GameObject[] Platform;
    public GameObject[] Bird;
    public float Paus;
    private int BirdNumber1;
    private int BirdNumber2;
    private int PlatformNumber;
    public float FonSpeed;
    private float FonSpeedUse;
    public float tileSise;
    private float X;
    private Transform tr;
    public Text ScoreText;
    private int Score;
    void Start()
    {
        
        StartCoroutine("PlatformSpawn");
        tr = GetComponent<Transform>();
        StartCoroutine(StopA());
        Score = 0;
 
    }

    IEnumerator PlatformSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            PlatformNumber = Random.Range(0, 3);
            BirdNumber1 = Random.Range(0, 5);
            BirdNumber2 = Random.Range(0, 5);
            Instantiate(Platform[PlatformNumber], new Vector2(18, 0), Quaternion.identity);
            Instantiate(Bird[BirdNumber1]);
            Instantiate(Bird[BirdNumber2]);

        }
    }
    IEnumerator StopA()
    {
        FonSpeedUse = 0;
        yield return new WaitForSeconds(Paus);
        Player.SetTrigger("Stay");
        Player.ResetTrigger("Lending");
        FonSpeedUse = FonSpeed;
    }
 
    void Update()
    {
       
           X = Mathf.Repeat((Time.time - Paus) * FonSpeedUse, tileSise);
           tr.position = new Vector3(X, tr.position.y, tr.position.z);          

        UpdateScore();


    }
    void UpdateScore()
    {
        ScoreText.text = "Пройдено:" + Score;
    }
}
