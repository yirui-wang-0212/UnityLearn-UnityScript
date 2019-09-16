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
    
    // ---------------------------------------脚本生命周期------------------------------------------
    // -----------------------------------------初始阶段--------------------------------------------
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

    // -----------------------------------------物理阶段--------------------------------------------
    // 执行时机：脚本启用后，每隔固定时间被调用
    // 更新频率：默认为 0.02s，设置更新频率：Edit -> Project Setting -> Time -> Fixed Timestep
    // 作用：适用于对游戏对象做物理操作，例如移动、旋转、施加力等
    // 不会受到渲染影响，渲染时间不固定（每帧渲染量不同、机器性能不同）
    private void FixedUpdate(){

         Debug.Log("FixedUpdate--" + Time.time + "--" + this.name);
    }

    // -----------------------------------------游戏逻辑--------------------------------------------
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

    // -----------------------------------------输入事件：物体必须有 Collider--------------------------------------------
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
    
    // -----------------------------------------场景渲染：物体必须有 Mesh Renderer--------------------------------------------
    // 执行时机：当 Mesh Renderer 在任何相机上可见时调用（变成看见那帧执行 1 次）
    private void OnBecameVisible(){

        Debug.Log("OnBecameVisible--" + Time.time + "--" + this.name);
    }

    // 执行时机：当 Mesh Renderer 在任何相机上都不可见时调用（变成看不见那帧执行 1 次）
    private void OnBecameInvisible(){

        Debug.Log("OnBecameInvisible--" + Time.time + "--" + this.name);
    }

    // -----------------------------------------结束阶段--------------------------------------------
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
