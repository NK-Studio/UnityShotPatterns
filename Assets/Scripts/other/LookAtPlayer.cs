using UnityEngine;

namespace other
{
    public class LookAtPlayer : MonoBehaviour
    {
        [Tooltip("바라볼 물체이다. - > 주로 플레이어를 참조하면 된다.")]
        public Transform Target;

        private void Update()
        {
            //벡터 뻴셈을 통해 방향을 구함
            Vector3 direction = Target.position - transform.position;

            //방향을 각도로 변환
            float angle = DirectionToAngle(direction);

            //해당 타겟 방향으로 회전한다.
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
        /// <summary>
        /// 방향을 각도로 변경합니다.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private float DirectionToAngle(Vector3 direction)
        {
            //x,y의 값을 조합하여 Z방향 값으로 변형함. -> ~도 단위로 변형
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return angle;
        }
    }
}