using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemy : MonoBehaviour
{

    private void OnGUI(){

        if(GUILayout.Button("查找血量最低的敌人")){
            // 查找场景中所有 Enemy 类型的引用
            Enemy[] allEnemy = Object.FindObjectsOfType<Enemy>();
            // 获取血量最低的对象引用
            Enemy min = FindEnemyByMinHP(allEnemy);
            // 根据 Enemy 类型引用获取其他组件类型引用
            min.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if(GUILayout.Button("查找距离最近的敌人")){
            // 查找场景中所有 Enemy 类型的引用
            Enemy[] allEnemy = Object.FindObjectsOfType<Enemy>();
            // 获取距离最近的对象引用
            Enemy min = FindEnemyByMinDistance(allEnemy);
            // 根据 Enemy 类型引用获取其他组件类型引用ß
            min.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }

    // 查找血量最低的敌人
    public Enemy FindEnemyByMinHP(Enemy[] allEnemy){
        // 假设第一个就是血量最低的敌人
        Enemy min = allEnemy[0];
        // 一次次与后面比较
        for (int i = 1; i < allEnemy.Length; ++i){
            if(min.HP > allEnemy[i].HP){
                min = allEnemy[i];
            }
        }
        return min;
    }

    // 查找距离最近的敌人
    public Enemy FindEnemyByMinDistance(Enemy[] allEnemy){
        // 假设第一个就是距离最近的敌人
        Enemy min = allEnemy[0];
        // minDistance 存储当前最近的距离
        float minDistance = Vector3.Distance(this.transform.position, min.transform.position);
        
        for (int i = 1; i < allEnemy.Length; ++i){

            float newDistance = Vector3.Distance(this.transform.position, allEnemy[i].transform.position);
            if(newDistance < minDistance){
                min = allEnemy[i];
                minDistance = newDistance;
            }
        }
        return min;
    }
}
