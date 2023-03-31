using other;
using UnityEngine;

namespace Shot
{
    public class HeartShot : MonoBehaviour {

        //발사될 총알
        public GameObject Bullet;

        //초기 중심 : 회전 되는 방향
        [Range(0, 360), Tooltip("퍼지기 전 회전을 줄 수 있음")]
        public float Rotation;

        private readonly float[] _speeds = new float[34];
        private readonly float[] _direction = new float[34];

        private void Awake()
        {
            //하트 모양으로 데이터 초기화
            HeartDataInit();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
                Shot();
        }

        private void Shot()
        {
            //34개의 게임오브젝트 생성
            for (int i = 0; i < 34; i += 1)
            {
                //오브젝트 생성
                GameObject temp = Instantiate(Bullet);

                //2초후 삭제
                Destroy(temp, 2f);

                //총알 생성 위치를 (0,0) 좌표로 한다.
                temp.transform.position = Vector2.zero;

                //정밀한 회전 처리로 모양을 만들어 낸다.
                temp.transform.rotation = Quaternion.Euler(0, 0, _direction[i] + Rotation);

                //정밀한 속도 처리로 모양을 만들어 낸다.
                temp.GetComponent<Bullet>().Speed = _speeds[i] / 50;
            }
        }

        private void HeartDataInit()
        {
            _speeds[0] = 111.00f;
            _direction[0] = 90.00f;
            _speeds[1] = 133.10f;
            _direction[1] = 98.70f;
            _speeds[2] = 152.04f;
            _direction[2] = 107.37f;
            _speeds[3] = 166.88f;
            _direction[3] = 116.18f;
            _speeds[4] = 176.00f;
            _direction[4] = 125.28f;
            _speeds[5] = 181.88f;
            _direction[5] = 134.29f;
            _speeds[6] = 181.50f;
            _direction[6] = 143.31f;
            _speeds[7] = 175.54f;
            _direction[7] = 152.33f; 
            _speeds[8] = 165.63f;
            _direction[8] = 161.38f;
            _speeds[9] = 151.50f;
            _direction[9] = 170.43f;
            _speeds[10] = 136.35f;
            _direction[10] = 180.18f;
            _speeds[11] = 120.40f;
            _direction[11] = 190.90f;
            _speeds[12] = 106.45f;
            _direction[12] = 203.68f;
            _speeds[13] = 98.56f;
            _direction[13] = 219.22f;
            _speeds[14] = 99.10f;
            _direction[14] = 235.97f;
            _speeds[15] = 107.97f;
            _direction[15] = 251.19f;
            _speeds[16] = 124.58f;
            _direction[16] = 262.83f;
            _speeds[17] = 133.10f;
            _direction[17] = 81.30f;
            _speeds[18] = 152.04f;
            _direction[18] = 72.63f;
            _speeds[19] = 166.88f;
            _direction[19] = 63.82f;
            _speeds[20] = 176.00f;
            _direction[20] = 54.72f;
            _speeds[21] = 181.88f;
            _direction[21] = 45.71f;
            _speeds[22] = 181.50f;
            _direction[22] = 36.69f;
            _speeds[23] = 175.54f;
            _direction[23] = 27.67f;
            _speeds[24] = 165.63f;
            _direction[24] = 18.62f;
            _speeds[25] = 151.50f;
            _direction[25] = 9.57f;
            _speeds[26] = 136.35f;
            _direction[26] = 359.82f;
            _speeds[27] = 120.40f;
            _direction[27] = 349.10f;
            _speeds[28] = 106.45f;
            _direction[28] = 336.32f;
            _speeds[29] = 98.56f;
            _direction[29] = 320.78f;
            _speeds[30] = 99.10f;
            _direction[30] = 304.03f;
            _speeds[31] = 107.97f;
            _direction[31] = 288.81f;
            _speeds[32] = 124.58f;
            _direction[32] = 277.17f;
            _speeds[33] = 147.85f;
            _direction[33] = 270.05f;
        }

    }
}

