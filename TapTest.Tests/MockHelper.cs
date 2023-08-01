using System.Linq.Expressions;
using Moq;
using Moq.Language.Flow;

namespace TapTest.Tests
{
    internal static class MockHelper
    {
        public static ISetup<T> Setup<T>(this T obj, Expression<Action<T>> action) where T : class
        {
            var mock = Mock.Get(obj);
            return mock.Setup(action);
        }

        public static ISetup<T, TRes> Setup<T, TRes>(this T obj, Expression<Func<T,TRes>> action) where T : class
        {
            var mock = Mock.Get(obj);
            return mock.Setup(action);
        }

        public static Mock<T> MockObj<T>(this T obj) where T : class
        {
            return Mock.Get(obj);
        }
    }
}
