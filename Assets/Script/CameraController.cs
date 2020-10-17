using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject unitychan;
    private Vector3 pos;
    private Quaternion rotate;

    [SerializeField]
    [Range(1.0f, 7.0f)] private float rotateSpeed = 3.0f;

    private void Start()
    {
        pos = unitychan.transform.position;
        gameObject.transform.position = new Vector3(pos.x, pos.y + 1.0f, pos.z - 3.0f);
        rotate = unitychan.transform.localRotation;
        gameObject.transform.rotation = new Quaternion(rotate.x, rotate.y, rotate.z, rotate.w);
    }

    void Update()
    {
        // カメラの回転角度
        float rotate = Input.GetAxis("R_Horizontal") * rotateSpeed;

        // Unitychanの位置情報
        Vector3 unitychanPos = unitychan.transform.position;

        // カメラの回転
        transform.RotateAround(unitychanPos, Vector3.up, rotate);
    }
}
