using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPooling : MonoBehaviour
{
    private Vector2 originPos = new Vector2(-100, -100);

    public static LevelPooling Instance { get; private set; }

    [SerializeField]
    private ScoreManager scoreManager;

    //Variaveis da explosão
    public Explosao explosaoPrefab;

    public Queue<Explosao> explosoes = new Queue<Explosao>();

    private int explosoesCriadas = 0;

    //Variaveis do tiro
    public TiroPlayer tiroDoPlayerPrefab;

    public Queue<TiroPlayer> tirosPlayer = new Queue<TiroPlayer>();


    void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    public Explosao GetExplosion()
    {
        if(explosoes.Count <= 0)
        {
            CreateExplosion();
        }

        return explosoes.Dequeue();
    }

    public TiroPlayer GetTiroPlayer()
    {
        if (tirosPlayer.Count <= 0)
        {
            CreateTiroPlayer();
        }

        return tirosPlayer.Dequeue();
    }


    private void CreateExplosion()
    {
        Explosao explosion = Instantiate(explosaoPrefab, originPos, Quaternion.identity);
        explosoes.Enqueue(explosion);
        explosoesCriadas++;
        explosion.gameObject.SetActive(false);
        explosion.gameObject.name = "Explosão" + explosoesCriadas;
    }

    private void CreateTiroPlayer()
    {
        TiroPlayer tiro = Instantiate(tiroDoPlayerPrefab, originPos, Quaternion.identity);
        tirosPlayer.Enqueue(tiro);
        tiro.gameObject.SetActive(false);
        tiro.gameObject.name = "Tiro" + explosoesCriadas;
    }

    public void PutExplosionBackInPool(Explosao explosion)
    {
        if (explosion.gameObject.activeSelf == true)
            explosion.gameObject.SetActive(false);
            explosoes.Enqueue(explosion);
    }

    public void PutPlayerShootBackInPool(TiroPlayer tiro)
    {
        if (tiro.gameObject.activeSelf == true)
            tiro.gameObject.SetActive(false);
            tirosPlayer.Enqueue(tiro);
    }


    /*public T[] GetObject<T>()
    {
        T newObject = 
        return ;
    }*/
}
