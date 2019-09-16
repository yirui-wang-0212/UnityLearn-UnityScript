# UnityLearn-UnityScript



### 语法结构

- 命名空间与类名必须一致
- 写好的脚本必须附加到物体上才能执行
- 附加到游戏物体的脚本类必须从 MonoBehaviour 类继承



### 编译过程

**源代码** --（CLS）-- > **中间语言** --（Mono Runtime）--> **机器码**



### 脚本编译工具

Unity 编辑器中，Edit ->Preferences，在弹出的对话框中单击左侧 Extenal Tool 命令，然后在 External Script Editor 下拉列表中选择 VS Code 作为 Unity 默认的编辑器



### 类？对象？

- Scripts（一个类） 挂到 GameObject 上时会创建一个对象。
- GameObject 上的一个 Component 是一个对像：如 Transform、Camera、Audio Listener 都是对应类（Transform 类、Camera 类、Audio Listener 类）的对象
- GameObject 是 GameObject 类的一个对象
- 每个 GameObject 中都有一个数组管理 Components 对象的**引用**



### 代码

- 默认不写就是 private
- Update 如果不删除，即使里面不写内容，也会每帧被调用（内存中会给它开辟一个栈帧）
- 在 Unity/Editor/Data/Resources/    /81-C# Script-NewBehaviourScripts.cs.txt 中可以修改创建 Scripts 后默认生成的代码

-  若 Script 中设置  ```public int a = 100``` ，在 Inspector 中将 a 的值修改为 200，那么运行时 a 的值为 200，因为  Script 中是类的初始化，Inspector 中则是为类的对象重新赋值。

```c#
// Lifecycle.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifecycle : MonoBehaviour{

// C# 类
// - 字段
// - 属性（get、set）
// - 构造函数
// - 方法

// 脚本
// - 字段
// - 方法

    // 序列化字段 作用：在编辑器中显示私有变量
    [SerializeField]
    private int a = 100;

    // 作用：在编译器中隐藏字段
    [HideInInspector]
    public float b;

    // 作用：在编译器中在一个范围内调整数值
    [Range(0, 100)]
    public int c;
    
    // 属性：在编译器中不能显示，通常脚本中不写
    // public int A{
    //     get
    //     {return this.a;}
    //     set
    //     {this.a = value;}
    // }

    // 通常不要再脚本中写构造函数
    // public Lifecycle(){

    //     // 不能在子线程中访问主线程成员
    //     // 创建脚本对象是在子线程里做的
    //     // Unity 提供的功能是主线程里做的
    //     // 不能跨线程访问
    //     // 不要在构造函数中使用 Unity 提供的功能
    //     b = Time.time; // 这行代码会报错

    //     // 游戏创建时会调用两次构造函数，执行时机不是我们想要的
    //     Debug.log("构造函数"); // 编译器中创建一次这个对象，运行时创建两次这个对象
    // }
    
}
```



### 脚本生命周期（必然事件、消息Message）

文档：MonoBehaviour 下的消息

```c#
// Lifecycle.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifecycle : MonoBehaviour{
    // ---------------------------------------脚本生命周期------------------------------------
    // -----------------------------------------初始阶段-------------------------------------
    // 初始阶段
    // 执行时机：创建游戏对象 --> 立即执行1次（脚本不启用也执行）
    // 早于 OnEnable 和 Start
    // 作用：初始化
    private void Awake(){

        Debug.Log("Awake--" + Time.time + "--" + this.name);
    }

    // 初始阶段
    // 执行时机：每当脚本对象启用时调用
    // 同一个物体晚于 Awake，早于 Start，执行完第一个物体的 Awake 后执行该物体的 OnEnable，再执行下一个物体的 Awake 和 Enable
    // 作用：常用于在游戏开始前进行初始化，可以判断当满足某种条件执行此脚本 this.enable = true
    private void OnEnable(){

        Debug.Log("OnEnable--" + Time.time + "--" + this.name);
    }

    // 初始阶段
    // 执行时机：创建游戏对象 --> 脚本启用 --> 才执行1次
    // 晚于 Awake 和 Enable，且所有物体的 Awake 和 Enable 执行完后，再执行所有 Start
    // 作用：常用于数据或游戏逻辑初始化
    private void Start(){

        Debug.Log("Start--" + Time.time + "--" + this.name);
    }

    // -----------------------------------------物理阶段-------------------------------------
    // 执行时机：脚本启用后，每隔固定时间被调用
    // 更新频率：默认为 0.02s，设置更新频率：Edit -> Project Setting -> Time -> Fixed Timestep
    // 作用：适用于对游戏对象做物理操作，例如移动、旋转、施加力等
    // 不会受到渲染影响，渲染时间不固定（每帧渲染量不同、机器性能不同）
    private void FixedUpdate(){

         Debug.Log("FixedUpdate--" + Time.time + "--" + this.name);
    }

    // -----------------------------------------游戏逻辑-------------------------------------
    // 执行时机：渲染帧执行，执行间隔不固定（每帧渲染量不同、机器性能不同）
    // 作用：处理游戏逻辑
    private void Update(){

        Debug.Log("Update--" + Time.time + "--" + this.name);
    }

    // // 执行时机：在 Update 函数被调用后执行，和 Update 在同一帧执行
    // // 作用：适用于跟随逻辑
    private void LateUpdate(){

        Debug.Log("LateUpdate--" + Time.time + "--" + this.name);
    }

    // -----------------------------------------输入事件：物体必须有 Collider------------------
    // 执行时机：鼠标移入到当前 Collider 时调用
    private void OnMouseEnter(){

        Debug.Log("OnMouseEnter--" + Time.time + "--" + this.name);
    }

    // 执行时机：鼠标经过当前 Collider 时调用
    private void OnMouseOver(){

        Debug.Log("OnMouseOver--" + Time.time + "--" + this.name);
    }

    // 执行时机：鼠标离开当前 Collider 时调用
    private void OnMouseExit(){

        Debug.Log("OnMouseExit--" + Time.time + "--" + this.name);
    }

    // 执行时机：鼠标按下当前 Collider 时调用
    private void OnMouseDown(){

        Debug.Log("OnMouseDowns--" + Time.time + "--" + this.name);
    }

    // 执行时机：鼠标在当前 Collider 上抬起时调用
    private void OnMouseUp(){

        Debug.Log("OnMouseDowns--" + Time.time + "--" + this.name);
    }
    
    // -----------------------------------------场景渲染：物体必须有 Mesh Renderer-------------
    // 执行时机：当 Mesh Renderer 在任何相机上可见时调用（变成看见那帧执行 1 次）
    private void OnBecameVisible(){

        Debug.Log("OnBecameVisible--" + Time.time + "--" + this.name);
    }

    // 执行时机：当 Mesh Renderer 在任何相机上都不可见时调用（变成看不见那帧执行 1 次）
    private void OnBecameInvisible(){

        Debug.Log("OnBecameInvisible--" + Time.time + "--" + this.name);
    }

    // -----------------------------------------结束阶段-------------------------------------
    // 执行时机：对象变为不可用或附属游戏对象非激活状态时被调用
    private void OnDisable(){

        Debug.Log("OnDisable--" + Time.time + "--" + this.name);
    }

    // 执行时机：当脚本销毁或附属的游戏对象被销毁时被调用
    private void OnDestroy(){

        Debug.Log("OnDestroy--" + Time.time + "--" + this.name);
    }

    // 执行时机：应用程序推出时被调用
    private void OnApplicationQuit(){

        Debug.Log("OnApplicationQuit--" + Time.time + "--" + this.name);
    }
}
```

![1](Pictures/1.png)



### Debug

1. 控制台调试

   消耗性能，忘记删掉游戏会很卡。

   - Debug.Log
   - print 也是调用的 Debug.Log

2. 定义公有变量，程序运行后在检测面板查看数据（可以看变化的数值）

3. 编译器调试

   1. 加断点
   2. 编译器点击运行（启动调试）
   3. Unity Editor 点击 Play，运行场景

4. 单帧调试（适合 Update）

   1. 编译器点击运行（启动调试）
   2. Unity Editor 点击 Play，运行场景
   3. 暂停游戏
   4. 加断点
   5. 单帧执行
   6. 结束调试

   （可以使用 Windows - Analysis - Frame Debugger 查看每一帧的渲染情况）



###  

### 常用 API

![2](Pictures/2.png)



#### Component

Component 类提供了查找（在当前 GameObject、后代、先辈）组件的功能。

- 判断标签与传入字符串是否相等：```other.CompareTag("Player")```
- 其他见代码

```c#
// ComponentDemo.cs
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
```



#### Transform

继承自 Component。

用于存储并操控物体的位置、旋转和缩放。每一个 Transform 可以有一个父级，允许你分层次应用位置、旋转和缩放。

1. Position

   - Position：世界坐标系
   - LocalPosition：相对于父级变换的位置

   Inspector 中 Transform 的 Position 实际上是 LocalPosition



