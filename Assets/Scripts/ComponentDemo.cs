using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component 类提供了查找（在当前 GameObject、后代、先辈）组件的功能
public class ComponentDemo : MonoBehaviour{

    private void OnGUI(){

        if (GUILayout.Button("transform")){

            // 挂载在 GameObject 上的 Script 可以直接访 问GameObject 的 Tranform，
            // 原因是 Script 中的类继承自 MonoBehaviour，MonoBehaviour 继承自 Behaviour，Behaviour 继承自 Component，
            // Component 中有对当前 GameObject 的 Tranform 的引用这个属性，可以直接使用。
            this.transform.position = new Vector3(1, 1, 1);
        }

        if (GUILayout.Button("GetComponent")){

            // GetComponent 方法在 Component 类中
            // GetComponent<MeshRenderer>() 返回 GameObject MeshRenderer 组件的引用
            this.GetComponent<MeshRenderer>().material.color =  Color.red;
        }

        if (GUILayout.Button("GetComponents")){

            // 获取当前 GameObject 所有组件
            var allComponent = this.GetComponents<Component>();
            foreach (var item in allComponent){
                print(item.GetType());
            }
        }

        if (GUILayout.Button("GetComponentsInChildren")){

            // 获取当前 GameObject 和 后代 GameObject 的所有指定类型组件（从自身开始）
            // 如果使用 GetComponentInChildren，则只寻找到一个指定类型组件就停止
            var allComponent = this.GetComponentsInChildren<MeshRenderer>();
            foreach (var item in allComponent){
                item.material.color = Color.red;
            }
        }

        if (GUILayout.Button("GetComponentsInParent")){

            // 获取当前 GameObject 和 先辈 GameObject 的所有指定类型组件（从自身开始）
            // 如果使用 GetComponentInParent，则只寻找到一个指定类型组件就停止
            var allComponent = this.GetComponentsInParent<MeshRenderer>();
            foreach (var item in allComponent){
                item.material.color = Color.red;
            }
        }
    }
}