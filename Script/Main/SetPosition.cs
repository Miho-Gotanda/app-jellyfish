using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    //初期位置
    private Vector3 startPosition;
    //目的地
    private Vector3 destination;
    
    void Start()
    {
        //初期位置の設定
        startPosition = transform.position;
        SetDestination(transform.position);
    }

    //ランダムな位置にの作成
    public void CreateRandomPosition()
    {
        //ランダムな位置を得る
        var randDestinationX = Random.Range(-9.9f, 9.9f);
        var randDestinationY = Random.Range(-12.9f, 13.5f);
        //現在地にランダムな位置を足して目的地とする
        SetDestination(startPosition+new Vector3(randDestinationX, randDestinationY, transform.position.z));

    }

    //目的地を設定する
    public void SetDestination(Vector3 position)
    {
        destination = position;
    }

    //目的地を取得する
    public Vector3 GetDestenation()
    {
        return destination;
    }

   
}
