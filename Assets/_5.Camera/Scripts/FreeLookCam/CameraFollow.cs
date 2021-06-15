using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform m_Target;
    
    [SerializeField] private bool m_LockCursor = false;     //是否隐藏鼠标
    [SerializeField] private float m_MoveSpeed = 1f;     //左右旋转速度
    [SerializeField] private float m_TurnSpeed = 1.5f;     //上下旋转速度
    private float m_TiltMax = 75f;
    private float m_TiltMin = 45f;

    private float m_LookAngle;
    private float m_TiltAngle;
    private Vector3 m_Axis1;
    private Vector3 m_Axis2;
    private Transform m_Pivot;

    // Start is called before the first frame update
    public void Start() {
        Cursor.lockState = m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        m_Pivot = transform.GetChild(0);
    }


    private void FixedUpdate() {
        //获取鼠标位置1(这个方法如果隐藏鼠标后会有问题)
        //m_Axis1 = Input.mousePosition;
    }
    private void LateUpdate() {
        //跟随目标
        transform.position = Vector3.Lerp(transform.position, m_Target.position, Time.deltaTime * m_MoveSpeed);

        //获取鼠标位置2
        //m_Axis2 = Input.mousePosition;
        //鼠标位置x的差值就是左右的偏移量
        //var x = m_Axis1.x - m_Axis2.x;
        var x = Input.GetAxisRaw("Mouse X");
        m_LookAngle += -x * m_TurnSpeed;
        transform.localRotation = Quaternion.Euler(0, m_LookAngle, 0);
        //transform.eulerAngles = new Vector3(0, m_LookAngle, 0);

        //鼠标位置y的差值就是上下的偏移量
        //var y = m_Axis1.y - m_Axis2.y;
        var y = Input.GetAxisRaw("Mouse Y");
        m_TiltAngle += y * m_TurnSpeed;
        //这里取个最大值75,最少值-45,否则角度大于90或者小于-90坐标出现错乱
        m_TiltAngle = Mathf.Clamp(m_TiltAngle, -m_TiltMin, m_TiltMax);
        m_Pivot.transform.localRotation = Quaternion.Euler(m_TiltAngle, m_Pivot.transform.localEulerAngles.y, m_Pivot.transform.eulerAngles.z);
        //m_Pivot.transform.eulerAngles = new Vector3(m_TiltAngle, m_Pivot.transform.eulerAngles.y, m_Pivot.transform.eulerAngles.z);

    }
}
