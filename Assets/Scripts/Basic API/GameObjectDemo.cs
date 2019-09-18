using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDemo : MonoBehaviour
{
    private void OnGUI(){

        // 场景中的游戏对象是否激活？即实际的激活状态。试想这种场景：爸爸的勾取消了，自己的勾还在，但是在场景中被禁用了
        // this.gameObject.activeInHierarchy
        // 局部激活状态（只读），即自身激活状态。就是物体 Inspector 里面的勾是不是还在
        // this.gameObject.activeSelf

        // 设置物体启用还是禁用
        // this.gameObject.SetActive();

        if (GUILayout.Button("添加光源")){

            // 不可以直接 new 一个 Component：light = new Light();
            // 1. 创建物体
            GameObject lightGO = new GameObject();
            // 2. 在物体上添加组件
            Light light = lightGO.AddComponent<Light>();
            // 3. 修改组件的属性
            light.color = Color.red;
            light.type = LightType.Point;
        }

        // 在场景中根据名称查找物体（慎用），而this.transform.Find("游戏对象名称") 只查找子物体，可以使用
        // GameObject.Find("游戏对象名称")

        // 获取所有使用该标签的物体
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        // 获取使用该标签的物体（单个）
        GameObject playerGO1 = GameObject.FindGameObjectWithTag("Player");
        GameObject playerGO2 = GameObject.FindWithTag("Player");
        
        // ----------------------------------------Object-------------------------------------------
        // 根据类型查找对象（component）
        MeshRenderer mr = Object.FindObjectOfType<MeshRenderer>();
        MeshRenderer[] mrs = Object.FindObjectsOfType<MeshRenderer>();
        // Object.Destroy()
    }
    // 练习：查找血量最低的敌人
    // 提示：查找 Enemy 脚本
}
