using System;
using Kata4.Core.Contract.UnitOfWork;
using NHibernate;

namespace Kata4.Repository.UnitOfWork
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        [ThreadStatic] private static NHibernateUnitOfWork _current;

        private readonly ISessionFactory _sessionFactory;

        private ITransaction _transaction;

        public NHibernateUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public static NHibernateUnitOfWork Current
        {
            get { return _current; }
            set { _current = value; }
        }

        public ISession Session { get; private set; }

        public void BeginTransaction()
        {
            Session = _sessionFactory.OpenSession();
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            finally
            {
                Session.Close();
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                Session.Close();
            }
        }
    }
}