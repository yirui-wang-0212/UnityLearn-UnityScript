using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 倒计时
// 从 02:00 开始，最后 10s 字体为红色，时间为 00:00 后停止计时。
public class CountdownTimer : MonoBehaviour
{
    // 需求：1s 修改 1次 Text 文本内容
    // 1. 查找组件引用
    // 2. 定义变量：秒 second
    // 3. 120 --> 02:00  119 --> 01:59
    // 4. 修改文本
    // 5. 如何每秒修改一次 重点：在 Update 每帧执行的方法中，个别语句实现指定间隔执行一次

    private Text txtTimer;
    public int second = 120;

    private void Start(){

        txtTimer = this.GetComponent<Text>();

        // 重复调用
        // 参数 1：Timer3，需要重复调用的方法
        // 参数 2：1，开始调用的时间，即从第 1s 开始调用
        // 参数 3：1，调用的频率，即 1s 调用 1 次
        InvokeRepeating("Timer3", 1, 1);

        // 延迟调用
        // Invoke(“被执行方法”, 开始调用时间);

        // 是否有任何方法被 Invoke 调用？
        // IsInvoking()
    
        // 该方法是否正在被调用？
        // IsInvoking("被执行方法")
    }

    private void Update(){

       // Timer1();
       // Timer2();
    }

    // 方法 1：Time.time
    // 下次修改时间
    private float nextTime = 1;
    private void Timer1(){

        // 如果到了修改时间
        if(Time.time > nextTime){

            second--;
            // d2：2 位数，以 0 来填充
            txtTimer.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);

            // 设置下次修改时间
            nextTime = Time.time + 1;
        }
    }

    // 方法 2：Time.deltaTime
    // 累计时间
    private float totalTime;
    private void Timer2(){

        // 累加每帧间隔
        totalTime += Time.deltaTime;

        // 如果到了修改时间
        if(totalTime >= 1){

            second--;
            // d2：2 位数，以 0 来填充
            txtTimer.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);

            totalTime -= 1;
        }
    }

    // 方法 3：InvokeRepeating，每隔固定时间，重复执行
    // 查看 Start：InvokeRepeating("Timer3", 1, 1);
    private void Timer3(){

        second--;
        // d2：2 位数，以 0 来填充
        txtTimer.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);

        if(second == 0)
            // CancelInvoke()：取消这个 MonoBehaviour 里的所有 Invoke 调用
            // CancelInvoke("Timer3")：取消 Timer3 的 Invoke 的调用
            CancelInvoke("Timer3");
    }

    // 对比方法 3 和方法 1、2
    // 方法 3 适用于每隔固定时间，重复执行
    // 方法 1、2 可以根据需求动态修改间隔的时间

    // 对比方法 1 和方法 2，主要区别：先做还是先等
    // 试想场景：按下鼠标左键，每隔 1s 发射 1发子弹
    // 方法 1 比较适合：方法 1 将 nextTime 设为 0，鼠标按下就可以开始发射子弹
    // 方法 2 则要先等待累计到 1s，再发射子弹
    // 试想场景：一个人先走，走到某个点停留一段时间再走
    // 方法 2 比较适合
}