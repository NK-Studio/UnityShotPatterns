using UnityEngine;

public class See_Player : MonoBehaviour {

    [Header("BulletToTarget를 활성화 해주세요.")]

    //회전될 오브젝트이다. -> 주로 보스나 몬스터를 참조하면 된다.
    public Transform center;

    //바라볼 물체이다. - > 주로 플레이어를 참조하면 된다.
    public Transform target;

	void Update () {
        //벡터 뻴셈을 통해 방향을 구함
        var rot = target.position - center.position;

        //x,y의 값을 조합하여 Z방향 값으로 변형함. -> ~도 단위로 변형
        var angle = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;

        //해당 타겟 방향으로 회전한다.
        center.rotation = Quaternion.Euler(0, 0, angle);
    }
}
