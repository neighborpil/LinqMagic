using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace List11_12
{
    /// <summary>
    /// Sample 데이터소스
    /// </summary>
    public class Sample
    {
        public string Kind { get; set; }
        public int Value { get; set; }
    }

    public class SampleDataSource : IEnumerable<Sample>
    {
        public IEnumerator<Sample> GetEnumerator()
        {
            return GetCsvEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // 외부로부터 인스턴스화 하지 않음(private 생성자)
        private SampleDataSource()
        {
            // 코드 없음
        }

        private string _csvFilePath;
        private string _kind;

        public static SampleDataSource ReadA(string csvFilePath)
        {
            return new SampleDataSource()
            {
                _csvFilePath = csvFilePath,
                _kind = "A"
            };
        }


        /// <summary>
        /// 파일을 읽어들여 샘플오브젝트를 열거하는 메소드
        /// 단지, 반환값에 주의
        /// </summary>
        /// <returns></returns>
        private IEnumerator<Sample> GetCsvEnumerator()
        {
            //검증용
            WriteLine("GetCsvEnumerator메서드 시작");

            //한행씩 읽어들여 루프돌린다
            foreach (var line in File.ReadLines(_csvFilePath))
            {
                //검증용
                WriteLine($"Read : {line}");

                //컴마로 분해
                string[] data = line.Split(',');

                //데이터의 Kind를 체크
                string kind = data[0].Trim();
                if (kind != _kind) //A가 아니라면 건너뛴다
                    continue;

                //데이터의 수치를 얻는다
                int value = 0;
                int.TryParse(data[1].Trim(), out value);

                //검증용
                WriteLine($"Create({kind}, {value})");

                //Sample오브젝트를 생성
                yield return new Sample() { Kind = kind, Value = value };
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var samples = SampleDataSource.ReadA(@".\sample.csv");

            WriteLine("1회차");
            foreach (var s in samples)
                WriteLine($"☆ Kind={s.Kind}, Value={s.Value}");
            /*
                1회차
                GetCsvEnumerator메서드 시작
                Read : A, 100
                Create(A, 100)
                ☆ Kind=A, Value=100
                Read : B, 200
                Read : A, 300
                Create(A, 300)
                ☆ Kind=A, Value=300
            */
            WriteLine();
            WriteLine("2회차");

            foreach (var s in samples)
                WriteLine($"☆ Kind={s.Kind}, Value={s.Value}");
            //출력
            /*
                2회차
                GetCsvEnumerator메서드 시작
                Read : A, 100
                Create(A, 100)
                ☆ Kind=A, Value=100
                Read : B, 200
                Read : A, 300
                Create(A, 300)
                ☆ Kind=A, Value=300
            */

            WriteLine();
            WriteLine("100보다 큰 데이터만 추출");

            var over100 = samples.Where(s =>
            {
                WriteLine($"Where:{s.Kind},{s.Value}");
                return s.Value > 100;
            });

            WriteLine("foreach시작");
            foreach (var s in over100)
                WriteLine($"☆ Kind={s.Kind}, Value={s.Value}");
            //출력
            /*
                100보다 큰 데이터만 추출
                foreach시작
                GetCsvEnumerator메서드 시작
                Read : A, 100
                Create(A, 100)
                Where:A,100
                Read : B, 200
                Read : A, 300
                Create(A, 300)
                Where:A,300
                ☆ Kind=A, Value=300
            */


#if DEBUG
            ReadKey();
#endif
        }
    }
}
