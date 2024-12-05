using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    [SerializeField] GameObject player;
    public GameObject youwinText;
    public Transform smashPos1;
    public SphereCollider playerbox;
    public SphereCollider smashPosbox;
    public TextValuesIU text;
    [SerializeField] GameObject openAd;
    [SerializeField] Transform spawnPoint;
    public LifePlayer lifePlayer;

    private void Start()
    {
        text.SetLife();

        if (LifePlayer.Lifes <= 0)
        {
            openAd.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Depth")
        {
            RespawnPoint();
        }
        
        if (collision.gameObject.tag == "Win")
        {
            youwinText.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Smash")
        {
            //transform.position = smashPos1.position;
            transform.rotation = smashPos1.rotation;
            transform.localScale = smashPos1.localScale;
            //RespawnPoint();
            playerbox.radius = smashPosbox.radius;
            Invoke("RespawnPoint", 0.5f);
        }
    }


    void RespawnPoint()
    {
        lifePlayer.RestLife(1);
        //LifePlayer.Lifes--;
        Debug.Log(LifePlayer.Lifes);
        transform.position = spawnPoint.position;
        //Para evitar que la pelota quede aplastada al respawnear
        player.transform.localScale = new Vector3(1, 1, 1);
        playerbox.radius = 0.5f;
        text.SetLife();
        //lifePlayer.Recharge();
        if (LifePlayer.Lifes <= 0)
        {
            openAd.SetActive(true);
        }
    }
}
