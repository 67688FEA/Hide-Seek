﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionController : MonoBehaviour {
    
    private Transform target;
    private List<GameObject> lastColliderObject;
    private List<GameObject> colliderObject;
    Vector3 aim;
    Vector3 ve;
    float an;
    RaycastHit[] hit;

    // Use this for initialization
    void Start(){
        target = GameObject.FindGameObjectWithTag("Player").transform;
        colliderObject = new List<GameObject>();
        lastColliderObject = new List<GameObject>();
    }

	// Update is called once per frame
	void Update () {
        aim = target.position;

        ve = (target.position - transform.position).normalized;
        an = transform.eulerAngles.y;
        aim -= an * ve;

        //在场景视图中可以看到这条射线
        //Debug.DrawLine(target.position, aim, Color.red);

        hit = Physics.RaycastAll(target.position, aim, 100f);

        //将 colliderObject 中所有的值添加进 lastColliderObject
        for (int i = 0; i < colliderObject.Count; i++)
            lastColliderObject.Add(colliderObject[i]);
        colliderObject.Clear();//清空上次碰撞到的所有物体

        for (int i = 0; i < hit.Length; i++)//获取本次碰撞到的所有物体
        {
            if (hit[i].collider.gameObject.tag != "Player" && hit[i].collider.gameObject.layer != 12)//角色和边界
            {
                //Debug.Log(hit[i].collider.gameObject.name);
                colliderObject.Add(hit[i].collider.gameObject);
                SetMaterialsColor(hit[i].collider.gameObject.GetComponent<Renderer>(), 0f);//置当前物体材质透明度
            }
        }


        //上次与本次对比，本次还存在的物体则赋值为null
        for (int i = 0; i < lastColliderObject.Count; i++)
        {
            for (int ii = 0; ii < colliderObject.Count; ii++)
            {
                if (colliderObject[ii] != null)
                {
                    if (lastColliderObject[i] == colliderObject[ii])
                    {
                        lastColliderObject[i] = null;
                        break;
                    }
                }
            }
        }
        //当值为null时则可判断当前物体还处于遮挡状态
        //值不为null时则可恢复默认状态(不透明)
        for (int i = 0; i < lastColliderObject.Count; i++)
        {
            if (lastColliderObject[i] != null)
                SetMaterialsColor(lastColliderObject[i].GetComponent<Renderer>(), 1f);//恢复上次物体材质透明度
        }
    }
    
    /// 置物体所有材质球颜色 <summary>
     /// 置物体所有材质球颜色
     /// </summary>
     /// <param name="_renderer">材质</param>
     /// <param name="Transpa">透明度</param>
    private void SetMaterialsColor(Renderer _renderer, float Transpa)
    {
        //获取当前物体材质球数量
        int materialsNumber = _renderer.sharedMaterials.Length;
        for (int i = 0; i < materialsNumber; i++)
        {
            //获取当前材质球颜色
            Color color = _renderer.materials[i].color;

            //设置透明度  取值范围：0~1;  0 = 完全透明
            color.a = Transpa;

            //置当前材质球颜色
            _renderer.materials[i].SetColor("_Color", color);
        }
    }

}