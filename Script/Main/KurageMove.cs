using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KurageMove : MonoBehaviour
{
    //目的地
    private Vector3 destination;
    //移動方向
    private Vector3 direction;
    //移動スピード
    private float speed = 0.01f;
    //インパクト時速度
    private float impactSpeed = 0.15f;
    //setPositionスクリプト
    private SetPosition setPosition;
    //待ち時間
    private float waitTime = 1f;
    //経過時間
    private float elapsedTime;
    //機能格納         
    private CharacterController controller;
    private ButtonControler buttonControler;
    public GameObject food;
    private GameObject[] foods=null;
    public GameObject touchEffectPrefab;
    public bool foodnullor = false;
    private bool impact = false;

    private void Start()
    {
        buttonControler = GameObject.Find("Foods").GetComponent<ButtonControler>();
        controller = GetComponent<CharacterController>();
        setPosition = GetComponent<SetPosition>();
        setPosition.CreateRandomPosition();
        elapsedTime = 0f;

    }

    private void Update()
    {
        //目的地に到着していない場合
        if (Vector3.Distance(transform.position, destination) >0.5f)
        {
            direction = (destination - transform.position).normalized;

            //通常移動
            if (impact == false)
            {
                controller.Move(direction * speed);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, direction), 0.01f);
            }
            //加速移動
            else if (impact == true)
            {
                direction = (destination - transform.position).normalized;

                controller.Move(direction * impactSpeed);
                if (impactSpeed >= 0.03)
                {
                    impactSpeed -= 0.001f;
                    Debug.Log(impactSpeed);
                }
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, direction), 0.1f);
            }
            //タッチ箇所への移動
            if (Input.GetMouseButtonDown(0))
            {
                Ray();
            }
        }

        //目的地に着いた場合
        else
        {
            impact = false;
            impactSpeed = 0.15f;
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= waitTime)
            {
                setPosition.CreateRandomPosition();
                destination = setPosition.GetDestenation();
                elapsedTime = 0f;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Ray();
            }
        }

        //エサがあるとき、エサを追いかける
        if (foodnullor)
        {
            
            foods = GameObject.FindGameObjectsWithTag("Food");
            if (foods.Length != 0)
            {
                destination=foods[0].transform.position;
            }
            else if (foods.Length==0)
            {
                foodnullor = false;
            }

        }

        //タッチ処理
        void Ray()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = (1 << LayerMask.NameToLayer("HitPlane"));

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Vector3 pos = new Vector3(hit.point.x, hit.point.y, transform.position.z);
                if (impact == true)
                {
                    impactSpeed = 0.15f;
                    impact = false;
                }
                if (buttonControler.foodButton)
                {
                    //エサの生成
                    Instantiate(food,pos,Quaternion.identity);
                    foodnullor = true;
                }
                else
                {
                    //波紋エフェクトの生成
                    Instantiate(touchEffectPrefab, pos, Quaternion.identity);
                    destination = pos;
                }
            }
        }

    }
    
    //エフェクト衝突時処理
    public void ImpactMove()
    {
        float randomX = UnityEngine.Random.Range(-8.1f, 8.5f);
        destination = new Vector3(randomX, 14.4f, 0f);
        impact = true;
    }
      
}



    
    
        
    
    

