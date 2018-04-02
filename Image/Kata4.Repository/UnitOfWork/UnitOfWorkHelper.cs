using System;
using System.Reflection;
using Kata4.Core.Contract.Repository;
using Kata4.Core.Model.Attribute;

namespace Kata4.Repository.UnitOfWork
{
    public static class UnitOfWorkHelper
    {
        public static bool IsRepositoryMethod(MethodInfo methodInfo)
        {
            return IsRepositoryClass(methodInfo.DeclaringType);
        }

        public static bool IsRepositoryClass(Type declaringType)
        {
            return typeof(IRepository<,>).IsAssignableFrom(declaringType);
        }

        public static bool HasUnitOfWorkAttribute(MethodInfo methodInfo)
        {
            return methodInfo.IsDefined(typeof(UnitOfWorkAttribute), true);
        }
    }
}