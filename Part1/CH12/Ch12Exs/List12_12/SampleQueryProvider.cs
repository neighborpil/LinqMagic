using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace List12_12
{
    /// <summary>
    /// 샘플 데이터
    /// </summary>
    public class Sample
    {
        public string Kind { get; set; }
        public int Value { get; set; }
    }

    /// <summary>
    /// LINQ Provider
    /// IQueryProvider의 구현
    /// </summary>
    class SampleQueryProvider : AbstractQueryProvider
    {
        /// <summary>
        /// 추상메소드 구현
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public override object Execute(Expression exp)
        {
            // SampleExpressionVisitor을 사용하여, 후속 확장메소드를 분석한다
            var visitor = new SampleExpressionVisitor();
            visitor.Visit(exp);

            // 순석한 Kind의 指定を取り出す
            string KindFilter = visitor.KindFilter;

            // CSV파일을 읽어들이면서, Sample객체를 생성하여 반환한다
            return ReadSampleCsvFile(KindFilter).AsQueryable();
        }

        public override string GetQueryText(Expression exp)
        {
            return string.Empty;
        }

        /// <summary>
        /// 외부로부터 인스턴스화하지 않는다
        /// </summary>
        private SampleQueryProvider()
        {
            // No Codes
        }

        public static IQueryable<Sample> CreateQuery(string csvFilePath)
        {
            var p = new SampleQueryProvider()
            {
                _csvFilePath = csvFilePath,
            };
            return new Query<Sample>(p);
        }

        private string _csvFilePath;

        // 파일을 읽어들여, Sample 객체를 열거하는 메소드
        private IEnumerable<Sample> ReadSampleCsvFile(string kindFilter)
        {
            // 검증용
            Console.WriteLine("ReadSampleCsvFile 메소드 시작");

            bool checkKind = (kindFilter != null);

            // 한행씩 읽어들여 루프를 돌린다
            foreach (var line in File.ReadLines(_csvFilePath))
            {
                //검증용
                Console.WriteLine($"Read : {line}");

                //콤마로 분해한다
                string[] data = line.Split(',');

                //데이터의 Kind를 체크한다
                string kind = data[0].Trim(); //체크하기 직전에 트림
                if (checkKind && kind != kindFilter)
                    continue;

                //데이터의 수치를 획득
                int value = 0;
                int.TryParse(data[1].Trim(), out value);

                //검증용
                Console.WriteLine($"Create({kind}, {value}");

                //Sample 객체를 생성하여 반환
                yield return new Sample() { Kind = kind, Value = value };
            }
        }
    }
}
