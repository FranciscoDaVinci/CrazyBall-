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
    public MovPlayer movPlayer;

    bool _loading;

    private void Start()
    {
        text.SetLife();
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
            player.transform.position = (Vector3)data.checkPointParameters[2];
            Debug.Log("Carga los parametros");
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
        if (_loading || !movPlayer.CanJump())
        {
            return;
        }
        else
        {
            Debug.Log("Esta guardando");
            _checkPoints.SetPoints(player.transform.localScale, playerbox.radius, player.transform.position);
        }        
    }
}
