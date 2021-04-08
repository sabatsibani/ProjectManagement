using ProjectManagement.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectManagement.Api.Test
{
    public class FakeRepository<T>: IDbSet<T> where T : BaseEntity
    {
        private List<Project> _projects = new List<Project>();
        private Exception? _exceptionThrownOnNextCall = null;

        public ObservableCollection<T> Local => throw new NotImplementedException();

        public Type ElementType => throw new NotImplementedException();

        public Expression Expression => throw new NotImplementedException();

        public IQueryProvider Provider => throw new NotImplementedException();

        ObservableCollection<T> _repositoryCollection;
        IQueryable _repositoryQuery;
        public FakeRepository()
        {
            _repositoryCollection = new ObservableCollection<T>();
            _repositoryQuery = _repositoryCollection.AsQueryable();
            LoadProjects();
        }
        private void LoadProjects()
        {
            _exceptionThrownOnNextCall = null;
            _projects.Add(new Project
            {
                ID = 1,
                Name = "TestProject1",
                Detail = "This is a test project",
                CreatedOn = DateTime.Today
            });

            _projects.Add(new Project
            {
                ID = 2,
                Name = "TestProject2",
                Detail = "This is a test project",
                CreatedOn = DateTime.Today
            });
            _projects.Add(new Project
            {
                ID = 3,
                Name = "TestProject3",
                Detail = "This is a test project",
                CreatedOn = DateTime.Today
            });
            _projects.Add(new Project
            {
                ID = 4,
                Name = "TestProject4",
                Detail = "This is a test project",
                CreatedOn = DateTime.Today
            });
        }

        public void emptyProjects()
        {
            _projects.Clear();
            _projects = null;
            
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            _repositoryCollection.Add(entity);
            return entity;
        }

        public T Remove(T entity)
        {
            _repositoryCollection.Remove(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            throw new NotImplementedException();
        }

        public T Create()
        {
            throw new NotImplementedException();
        }

        TDerivedEntity IDbSet<T>.Create<TDerivedEntity>()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
