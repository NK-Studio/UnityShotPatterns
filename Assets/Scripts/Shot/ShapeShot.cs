using System.Collections.Generic;
using other;
using UnityEngine;

namespace Shot
{
    public class ShapeShot : MonoBehaviour
    {
        //초기 중심 : 회전 되는 방향
        [Range(0, 360), Tooltip("퍼지기 전 회전을 줄 수 있음")]
        public float Rotation;

        [Range(3, 7), Tooltip("퍼지는 모양이 몇각형으로 퍼질지 정하는 것")] //->삼~칠각형이 그나마 이쁨 그 이상으로 가면 원으로 보임..
        public int Vertex = 3;

        [Range(1, 5), Tooltip("이 값을 조정하여 둥근 느낌, 납작한 느낌으로 표현 됨")]
        public float Subdivision = 3;

        //스피드
        public float Speed = 3; //speed

        //기타 데이터들
        private int _m;
        private float _a;
        private float _phi;
        private readonly List<float> _v = new List<float>();
        private readonly List<float> _xx = new List<float>();

        public GameObject Bullet;

        private void Awake()
        {
            //모양 데이터를 초기화 한다.
            ShapeInit();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
                Shot();
        }
        
        [ContextMenu("모양 변경 초기화")]
        //해당 도형 패턴을 뽑기 위해선 init처리를 해야한다.
        private void ShapeInit()
        {
            //요소들이 들어 있을 수 있으니 초기화 하기전에 Clear한다.
            _v.Clear();
            _xx.Clear();

            //데이터 초기화
            _m = (int)Mathf.Floor(Subdivision / 2);
            _a = 2 * Mathf.Sin(Mathf.PI / Vertex);
            _phi = ((Mathf.PI / 2f) * (Vertex - 2f)) / Vertex;
            _v.Add(0);
            _xx.Add(0);

            for (int i = 1; i <= _m; i++)
            {
                //list.Insert(위치,요소) -> 해당 위치에 값을 집어넣습니다.
                _v.Add(Mathf.Sqrt(Subdivision * Subdivision - 2 * _a * Mathf.Cos(_phi) * i * Subdivision + _a * _a * i * i));
            }

            for (int i = 1; i <= _m; i++)
            {
                _xx.Add(Mathf.Rad2Deg * (Mathf.Asin(_a * Mathf.Sin(_phi) * i / _v[i])));
            }
        }

        private void Shot()
        {
            //rot값에 영향을 주지 않도록 별도로 dir값을 선언하였다.
            float direction = Rotation;

            //꼭짓점 수 만큼 실행
            for (int r = 0; r < Vertex; r++)
            {
                for (int i = 1; i <= _m; i++)
                {
                    #region //1차 생성

                    //총알 생성
                    GameObject idx1 = Instantiate(Bullet);

                    //2초후 삭제
                    Destroy(idx1, 2f);

                    //총알 생성 위치를 (0,0) 좌표로 한다.
                    idx1.transform.position = Vector2.zero;

                    //정밀한 회전 처리로 모양을 만들어 낸다.
                    idx1.transform.rotation = Quaternion.Euler(0, 0, direction + _xx[i]);

                    //정밀한 속도 처리로 모양을 만들어 낸다.
                    idx1.GetComponent<Bullet>().Speed = _v[i] * Speed / Subdivision;

                    #endregion

                    #region //2차 생성

                    //총알 생성
                    GameObject idx2 = Instantiate(Bullet);

                    //2초후 삭제
                    Destroy(idx2, 2f);

                    //총알 생성 위치를 (0,0) 좌표로 한다.
                    idx2.transform.position = Vector2.zero;

                    //정밀한 회전 처리로 모양을 만들어 낸다.
                    idx2.transform.rotation = Quaternion.Euler(0, 0, direction - _xx[i]);

                    //정밀한 속도 처리로 모양을 만들어 낸다.
                    idx2.GetComponent<Bullet>().Speed = _v[i] * Speed / Subdivision;

                    #endregion

                    #region //3차 생성

                    //총알 생성
                    GameObject idx3 = Instantiate(Bullet);

                    //2초후 삭제
                    Destroy(idx3, 2f);

                    //총알 생성 위치를 (0,0) 좌표로 한다.
                    idx3.transform.position = Vector2.zero;

                    //정밀한 회전 처리로 모양을 만들어 낸다.
                    idx3.transform.rotation = Quaternion.Euler(0, 0, direction);

                    //정밀한 속도 처리로 모양을 만들어 낸다.
                    idx3.GetComponent<Bullet>().Speed = Speed;

                    #endregion

                    //모양을 완성한다.
                    direction += 360 / Vertex;
                }
            }
        }
    }
}