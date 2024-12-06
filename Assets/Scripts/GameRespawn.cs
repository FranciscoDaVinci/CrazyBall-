using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : SaveCheckPoints
{
    [SerializeField] GameObject player;
    public Transform smashPos1;
    public SphereCollider playerbox;
    public SphereCollider smashPosbox;
    public TextValuesIU text;
    [SerializeField] GameObject openAd;
    [SerializeField] Transform spawnPoint;
    public LifePlayer lifePlayer;
    public References reference;

    bool _loading;

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
        if (collision.gameObject.CompareTag("Depth"))
        {
            RespawnPoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Smash"))
        {
            transform.rotation = smashPos1.rotation;
            transform.localScale = smashPos1.localScale;
            playerbox.radius = smashPosbox.radius;
            Invoke(nameof(RespawnPoint), 0.5f);
        }
    }

    void RespawnPoint()
    {
        reference.LoadRef();

        lifePlayer.RestLife(1);
        Debug.Log(LifePlayer.Lifes);
        transform.position = spawnPoint.position;
        //Para evitar que la pelota quede aplastada al respawnear
        //player.transform.localScale = new Vector3(1, 1, 1);
        //playerbox.radius = 0.5f;
        text.SetLife();
        if (LifePlayer.Lifes <= 0)
        {
            openAd.SetActive(true);
        }
    }

    IEnumerator CorLoad()
    {
        _loading = true;

        while (_checkPoints.HaveReferences())
        {
            var data = _checkPoints.GoBack();
            player.transform.localScale = (Vector3)data.checkPointParameters[0];
            playerbox.radius = (float)data.checkPointParameters[1];
        }
        yield return new WaitForSeconds(0.01f);

        _loading = false;

    }

    public override void Load()
    {
        StartCoroutine(CorLoad());
    }

    public override void Save()
    {
        if (_loading)
        {
            return;
        }

        _checkPoints.SetPoints(player.transform.localScale, playerbox.radius);
    }
}
