using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float rotateSpeed;


    private Transform coinVisual;
    // Start is called before the first frame update, we will do our communication with the game manager here
    void Start()
    {
        coinVisual = transform.GetChild(0);
        GameManager.instance.IncreaseRequiredCoins();
    }

    // Update is called once per frame, we will put our simple rotaiton animation here
    void Update()
    {
        coinVisual.Rotate(Vector3.up, rotateSpeed * Time.deltaTime * GameManager.instance.GetTimeScale());   
    }

    //Code we want to run when you pick up a coin
    public void Collect() 
    {
        GameManager.instance.CollectCoin();
        Destroy(this.gameObject);
    }
}
