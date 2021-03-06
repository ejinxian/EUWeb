﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EU.DAL
{
    /// <summary>
    /// 创建基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : InterfaceBaseRepository<T> where T : class
    {
        protected DALDbContext nContext = ContextFactory.GetCurrentContext();

        public IQueryable<T> Entities
        {
            get
            {
                return nContext.Set<T>();
            }
        }

        public T Add(T entity)
        {
            nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            nContext.SaveChanges();
            return entity;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return nContext.Set<T>().Count(predicate);
        }

        public bool Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return nContext.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return nContext.SaveChanges() > 0;
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return nContext.Set<T>().Any(anyLambda);
        }

        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T _entity = nContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }

        public IQueryable<T> FindList<S>(Expression<Func<T, bool>> whereLamdba, bool isAsc, Expression<Func<T, S>> orderLamdba)
        {
            var _list = nContext.Set<T>().Where<T>(whereLamdba);
            if (isAsc) _list = _list.OrderBy<T, S>(orderLamdba);
            else _list = _list.OrderByDescending<T, S>(orderLamdba);
            return _list;
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba, bool isAsc, string orderName)
        {
            var _list = nContext.Set<T>().Where(whereLamdba);
            _list = OrderBy(_list,orderName,isAsc);
            return _list;
        }

        public IQueryable<T> FindPageList<S>(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, bool isAsc, Expression<Func<T, S>> orderLamdba)
        {
            var _list = nContext.Set<T>().Where<T>(whereLamdba);
            totalRecord = _list.Count();
            if (isAsc) _list = _list.OrderBy<T, S>(orderLamdba).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            else _list = _list.OrderByDescending<T, S>(orderLamdba).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            return _list;
        }

        public IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, bool isAsc, string orderName)
        {
            var _list = nContext.Set<T>().Where<T>(whereLamdba);
            totalRecord = _list.Count();
            _list = OrderBy(_list,orderName,isAsc).Skip<T>((pageIndex-1)*pageSize).Take<T>(pageSize);
            return _list;
        }
        /// <summary>
        /// 排序
        /// </summary>
        ///<typeparam name="T">类型</typeparam>
        /// <param name="source">原IQueryable</param>
        /// <param name="propertyName">排序属性名</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns>排序后的IQueryable<T></returns>
        private IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc=true)
        {
            if (source == null) throw new ArgumentNullException("source", "不能为空");
            if (string.IsNullOrEmpty(propertyName)) return source;
            var _parameter = Expression.Parameter(source.ElementType);
            var _property = Expression.Property(_parameter, propertyName);
            if (_property == null) throw new ArgumentNullException("propertyName", "属性不存在");
            var _lambda = Expression.Lambda(_property, _parameter);
            var _methodName = isAsc ? "OrderBy" : "OrderByDescending";
            var _resultExpression = Expression.Call(typeof(Queryable), _methodName, new Type[] { source.ElementType, _property.Type }, source.Expression, Expression.Quote(_lambda));
            return source.Provider.CreateQuery<T>(_resultExpression);
        }
        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <typeparam name="S">排序字段类型</typeparam>
        /// <param name="curPage">当前页</param>
        /// <param name="pageSize">每页行数</param>
        /// <param name="total">总行数</param>
        /// <param name="whereLambda"></param>
        /// <param name="orderByLambda"></param>
        /// <param name="isAsc">是否升序(默认为升序)</param>
        /// <returns></returns>
        //public IList<T> LoadPageEntities<S>(int curPage, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc = true)
        //{
        //    using (oprsysEntities ctx = OprEntity.DBContext)
        //    {
        //        var temp = ctx.CreateObjectSet<T>().Where<T>(whereLambda);
        //        total = temp.Count();//得到数据总条数
        //        if (isAsc)
        //        {
        //            temp = temp.OrderBy(orderByLambda)
        //                   .Skip<T>(pageSize * (curPage - 1))  //越过条数
        //                   .Take<T>(pageSize); //取出条数
        //        }
        //        else
        //        {
        //            temp = temp.OrderByDescending(orderByLambda)
        //                  .Skip<T>(pageSize * (curPage - 1)) //越过条数
        //                  .Take<T>(pageSize); //取出条数
        //        }
        //        return temp.ToList();
        //    }
        //}
    }
}
