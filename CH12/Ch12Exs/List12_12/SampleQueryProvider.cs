using System;
using System.Collections.Generic;
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
    class SampleQueryProvider
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
            return ReadSampleCsvFile(KindFilter).AsQuerable();
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

    }
}
