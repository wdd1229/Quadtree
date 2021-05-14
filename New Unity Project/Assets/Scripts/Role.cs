using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[ExecuteAlways] 
public class Role : MonoBehaviour
{
    public bool bMove = false;
    public Vector3 lastPos = Vector3.zero;
    public float moveSpeed = 5;
    public float rotSpeed = 3;

    public Camera mCamera;

    private void Awake()
    {
        mCamera = transform.Find("Camera").GetComponent<Camera>();
    }

    
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            transform.localEulerAngles -= new Vector3(0, rotSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            transform.localEulerAngles += new Vector3(0, rotSpeed, 0);
        }

        if (lastPos != transform.position)
        {
            bMove = true;
            lastPos = transform.position;
        }
        else
        {
            bMove = false;
        }
        
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Matrix4x4 temp = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        if (mCamera.orthographic)
        {
            //相机照射的可视范围
            float spread = mCamera.farClipPlane - mCamera.nearClipPlane;
            //照射中心
            float center = (mCamera.farClipPlane + mCamera.nearClipPlane) * 0.5f;
            Gizmos.DrawWireCube(new Vector3(0, 0, center), new Vector3(mCamera.orthographicSize * 2 * mCamera.aspect, mCamera.orthographicSize * 2, spread));
        }
        else
        {
            //使用当前设置的小玩意绘制相机截锥。矩阵的位置和旋转。
  // 参数含义 :
            // 截形金字塔的顶端。
            //垂直视野(即顶点的角度)。
            //截锥体远平面的距离。
            //截锥体近平面的距离。
            //宽 / 高比率。
            Gizmos.DrawFrustum(Vector3.zero, mCamera.fieldOfView, mCamera.farClipPlane, mCamera.nearClipPlane, mCamera.aspect);
        }
        //绘制4*4的矩阵
        Gizmos.matrix = temp;
    }
}
