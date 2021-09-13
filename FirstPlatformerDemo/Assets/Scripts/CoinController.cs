using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float rotateSpeed;


    private Transform coinVisual;
    // Start is called before the first frame update
    void Start()
    {
        coinVisual = transform.GetChild(0);
        GameManager.instance.IncreaseRequiredCoins();
    }

    // Update is called once per frame
    void Update()
    {
        coinVisual.Rotate(Vector3.up, rotateSpeed * Time.deltaTime * GameManager.instance.GetTimeScale());   
    }

    public void Collect() 
    {
        GameManager.instance.CollectCoin();
        Destroy(this.gameObject);
    }
}
