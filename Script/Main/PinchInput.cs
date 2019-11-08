using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PinchInput: MonoBehaviour
{
    //画面幅（or 高さ）で正規化した値でコールバックする（false=ピクセル単位で返す）
    public bool isNormalized = true;

    //isNormalized=true のとき、
    //画面幅（Screen.width）を基準にする（false=高さ（Screen.height）を基準）[単位が px/Screen.width のようになる]
    public bool widthRederence = true;

    //認識する画面上の領域（0.0～1.0）[(0,0):画面左下, (1,1):画面右上]
    public Rect validArea = new Rect(0, 0, 1, 1);

    //ピンチ検出プロパティ
    public bool IsPinching { get;private set; }

    //ピンチ幅（距離）プロパティ
    public float Width { get;private set; }

    //ピンチ幅（距離）の直前との差分　プロパティ
    public float Delta { get;private set; }

    //ピンチ幅（距離）の変化比プロパティ
    public float Ratio { get;private set; }

    //ピンチ開始コールバック
    [Serializable]
    public class PinchStartHandler : UnityEvent<float, Vector2> { } //Width,center（2指間の中心座標が返る）
    public PinchStartHandler OnPinchStart;

    [Serializable]
    public class PinchHandler : UnityEvent<float, float, float> { }//Width,Delta,Ratioが返る
    public PinchHandler OnPinch;

    //ピンチ開始時の指の距離
    private float startDinstance;
    //直前の伸縮距離
    private float oldDistance;

    private void OnEnable()
    {
        IsPinching = false;
    }

    private void Update()
    {
        //プロパティはフレーム毎に初期化
        Width = 0; Delta = 0; Ratio = 1;

        if (Input.touchCount == 2)
        {
            //※fingerIdとtouch[]のインデックスは必ずしも一致しないのでfingerId=1となっている方を取得
            //(指1本から2本になったときに可能とするため）
            Touch touch = (Input.touches[1].fingerId == 1) ? Input.touches[1] : Input.touches[0];

            //新しく認識したときのみ
            if (!IsPinching && touch.phase == TouchPhase.Began)
            {
                //認識する画面上の領域内か？（２本の指の中心の座標を標準にする）
                Vector2 center = (Input.touches[0].position + Input.touches[1].position) / 2;

                if (validArea.xMin * Screen.width <= center.x && center.x <= validArea.xMax * Screen.width &&
                    validArea.yMin * Screen.height <= center.y && center.y <= validArea.yMax * Screen.height)
                {
                    IsPinching = true; //ピンチ開始

                    //fingerId=0～1のみ（必ず最初の２本目の指）。指3本→2本（0-2など）は不可
                    Width = startDinstance = oldDistance = 
                        Vector2.Distance(Input.touches[0].position, Input.touches[1].position);

                    if (isNormalized)
                    {
                        //画面幅で正規化して解像度に依存させない
                        float unit = widthRederence ? Screen.width : Screen.height;
                        Width /= unit;
                        center /= unit;
                    }

                    if (OnPinchStart != null)
                        OnPinchStart.Invoke(Width, center); //開始時は必ずDelta=0,Ratio=1となる
                }
            }
            else if (IsPinching)
            {
                //既に認識されているときのみ　3本から2本になった場合無効
                float endDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                Width = endDistance;
                Delta = endDistance - oldDistance; //直前との差分
                Ratio = endDistance / startDinstance; //開始時のピンチ幅(px距離)を基準にした倍率になる

                oldDistance = endDistance;

                if (isNormalized)
                {
                    float unit = widthRederence ? Screen.width : Screen.height;
                    Width /= unit; //画面幅で正規化すれば解像度に依存しなくなる
                    Delta /= unit;
                }

                if (OnPinch != null)
                    OnPinch.Invoke(Width, Delta, Ratio);
            }
        }
        else
        {
            IsPinching = false;
        }
    }








}
