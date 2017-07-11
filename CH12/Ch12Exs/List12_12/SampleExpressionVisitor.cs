using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace List12_12
{
    /// <summary>
    /// Expression tree의 전 노드의 처리를 하는 클래스
    /// </summary>
    class SampleExpressionVisitor : ExpressionVisitor
    {
        /// <summary>
        /// [Where(s => s.Kind == "?")]의 "?"에 해당하는 문자열을 보존하는 멤버
        /// </summary>
        public string KindFilter { get; private set; }

        /// <summary>
        /// 멤버 호출하는 노드를 처리
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        protected override Expression VisitMethodCall(MethodCallExpression expression)
        {
            //실험적 구현으로
            // Where(s => s.Kind == "?")
            // 만을 해석한다

            switch (expression.Method.Name)
            {
                case "Where":
                    // Where 확장 메소드의 람다식
                    var lambda = (expression.Arguments[1] as UnaryExpression)?.Operand as LambdaExpression; // Operand 피연산함수, Unary 단항의
                    if (lambda.Parameters.Count > 0 && lambda.Parameters[0].Type == typeof(Sample))
                    // 람다식의 파라미터([=>]의 왼쪽)가 Sample오브젝트이고
                    {
                        var bodyExpression = lambda.Body as BinaryExpression;
                        if (bodyExpression?.NodeType == ExpressionType.Equal)
                        //람다식의 본체([=>]의 오른쪽)이 등가비교고
                        {
                            var left = bodyExpression.Left;
                            if (left.NodeType == ExpressionType.MemberAccess && (left as MemberExpression)?.Member.Name == "Kind")
                            // 등가비교의 왼쪽은 property로 그 이름은 "Kind"이고
                            {
                                var right = bodyExpression.Right;
                                if (right.NodeType == ExpressionType.Constant)
                                // 등가비교의 우변은 정수라면
                                {
                                    if (KindFilter != null)
                                        throw new InvalidOperationException("Where을 체인화 할 수 없습니다");

                                    // KindFilter에 그 정수를 셋팅한다
                                    KindFilter = (right as ConstantExpression).Value as string;
                                }
                            }
                        }
                    }
                    break;
                default:
                    throw new NotImplementedException($"{expression.Method.Name}은 지원하지 않습니다");
            }
            return base.VisitMethodCall(expression);
        }
    }
}
