using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace List12_12
{
    public abstract class AbstractQueryProvider : IQueryProvider
    {
        protected AbstractQueryProvider()
        {
            // no codes
        }

        // IQueryProvider implementation : Start
        IQueryable<T> IQueryProvider.CreateQuery<T>(Expression expression) => new Query<T>(this, expression);

        IQueryable IQueryProvider.CreateQuery(Expression expression)
        {
            Type elementType = TypeSystem.GetElementType(expression.Type);

            try
            {
                return (IQueryable)Activator
                    .CreateInstance(typeof(Query<>).MakeGenericType(elementType), new object[] { this, expression });
            }
            catch(TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        T IQueryProvider.Execute<T>(Expression expression) => (T)this.Execute(expression);

        object IQueryProvider.Execute(Expression expression) => this.Execute(expression);

        //IQueryProvider implemetation : end

        //실제 사용하는 클래스에서 구현해야하는 메소드
        //LINQProvider의 구현에는 이 추상클래스를 상속하여
        //다음의 Execute/GetQueryText메소드를 구현한다
        public abstract string GetQueryText(Expression expression);
        public abstract object Execute(Expression expression);

    }
}
