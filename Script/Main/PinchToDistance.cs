using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchToDistance : MonoBehaviour
{
    public Transform target;           //視点となるオブジェクト
    public float speed = 2f;           //変化速度
    public float minDistance = 1.0f;   //近づける最小距離
    public Vector3 maxDistance;          //遠のける最大距離
    public bool lookAt = true;         //オブジェクトの方を向く

    private float initDistance;        //起動初期距離（リセット用）
    public bool PinchingNow = false;  //ピンチ中か判定


    // Start is called before the first frame update
    void Start()
    {
        maxDistance = transform.position;
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            initDistance = dir.magnitude;
            if (lookAt)
                transform.LookAt(target.position);
        }     
    }

    //width: ピンチ幅, delta: 直前のピンチ幅の差, 
    //ratio: ピンチ幅の開始時からの伸縮比(1:ピンチ開始時, 1以上拡大, 1より下(1/2,1/3,...)縮小)
    public void OnPinch(float width,float delta,float ratio)
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        float distance = Math.Max(minDistance, dir.magnitude - delta * speed);
        Vector3 pos = target.position - dir.normalized * distance;
        if (pos.z >= maxDistance.z)
        {
            transform.position = pos;
            PinchingNow = true;
        }
        else
            PinchingNow = false;

    }

    //初期の距離に戻す
    public void ResetDistance()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Vector3 pos = target.position - dir.normalized * initDistance;
        transform.position = pos;

    }

}
