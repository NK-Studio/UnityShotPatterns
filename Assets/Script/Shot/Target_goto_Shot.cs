using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_goto_Shot : MonoBehaviour
{
    [Header("BulletToTarget를 활성화 해주세요.")]

    //총알이 발사될 위치
    public Transform pos;

    //방향 -> Center가 Target을 바라보고 있으므로, Rotation은 방향으로 처리함
    public Transform Center;

    //총알 오브젝트
    public GameObject bullet;

    void Update()
    {
        //스페이스바를 누를시
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //총알 생성
            var temp = Instantiate(bullet);

            //총알 생성 위치를 머즐 입구로 한다.
            temp.transform.position = pos.position;

            //총알의 방향을 Center의 방향으로 한다.
            //->참조된 Center오브젝트가 Target을 바라보고 있으므로, Rotation이 방향이 됨.
            temp.transform.rotation = Center.rotation;
        }
    }
}
