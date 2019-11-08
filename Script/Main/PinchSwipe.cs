using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchSwipe : MonoBehaviour
{
    //フリック時のスピード
    private float x_speed = 0;
    private float y_speed = 0;

    //初期位置
    private Vector2 startPos;
    //最初のタップからの経過時間
    private float duration = 0;
    //オブジェクトの移動比率を操作する変数
    [SerializeField]
    private float moveRatio = 0.5f;
    private Vector3 screenLeftStartPos;
    private Vector3 screenRightStartPos;
    private PinchToDistance pinchToDistance;
  
    //認識する画面上の領域（0.0～1.0）[(0,0):画面左下, (1,1):画面右上]
    public Rect validArea = new Rect(0, 0, 1, 1);


    // Start is called before the first frame update
    void Start()
    {
        pinchToDistance = Camera.main.GetComponent<PinchToDistance>();
        screenLeftStartPos = GetScreenLeft();
        screenRightStartPos = GetScreenBottomRight();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("最初の右下"+screenRightStartPos);
        Debug.Log("最初の左上"+screenLeftStartPos);
        //一本指での操作
        if (Input.touchCount == 1 && pinchToDistance.PinchingNow)
        {
            Touch touch = Input.GetTouch(0);
            TouchBegan(touch);
        }
    }

    //スワイプ中にスワイプ
    private void TouchBegan(Touch touch)
    {
        switch (touch.phase)
        {
            //タップ開始
            case TouchPhase.Began:
                startPos = Input.mousePosition;
                break;

            //タップ中（指が動いている状態）
            case TouchPhase.Moved:
                Vector3 nowPos = transform.localPosition;
                nowPos.x = nowPos.x - touch.deltaPosition.x * moveRatio;
                nowPos.y = nowPos.y - touch.deltaPosition.y * moveRatio;

                Debug.Log("今の左上" + GetScreenLeft());
                Debug.Log("今の右下" + GetScreenBottomRight());
                if (screenLeftStartPos.x >= GetScreenLeft().x && GetScreenBottomRight().x >= screenRightStartPos.x &&
                    screenRightStartPos.y <= GetScreenBottomRight().y && GetScreenLeft().y <= screenLeftStartPos.y)
                {
                    transform.localPosition = nowPos;
                    Debug.Log("よばれた");
                }
                break;

            case TouchPhase.Ended:
                break;
        }
    }

    //画面の左上を取得
    private Vector3 GetScreenLeft()
    {
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0,0,transform.position.z));
        return min;
    }

    //画面の右下を取得
    private Vector3 GetScreenBottomRight()
    {
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1,1,transform.position.z));
        return max;
    }
}
