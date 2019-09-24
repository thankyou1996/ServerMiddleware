using MiddlewareDS.DBModel;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MiddlewareDS.DBService
{/// <summary>
 /// 新写法
 /// </summary>
 /// <typeparam name="T"></typeparam>
    public class DbContext<T> where T : class, new()
    {

        /// <summary>
        /// 数据库对象
        /// </summary>
        public SqlSugar.SqlSugarClient Db;
        /// <summary>
        /// 构造函数
        /// </summary>
        public DbContext()
        {
            Db = new SqlSugar.SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = Para.DBConnectStr,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            });
            //Db.Aop.OnLogExecuted = (sql, pars) => //SQL执行完事件
            //{
            //    string x = sql;
            //};
            //Db.Aop.OnLogExecuting = (sql, pars) => //SQL执行前事件
            //{
            //    string x = sql;
            //};
        }

        //public SimpleClient<Student> StudentDb { get { return new SimpleClient<Student>(Db); } }//用来处理Student表的常用操作
        /// <summary>
        /// 指定表
        /// </summary>
        public SimpleClient<T> ThisDb
        {
            
            get
            {
                return new SimpleClient<T>(Db);
            }
        }

        /// <summary>
        /// 统计
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public virtual int Count(Expression<Func<T, bool>> whereExpression)
        {
            return ThisDb.Count(whereExpression);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="deleteObj"></param>
        /// <returns></returns>
        public virtual bool Delete(T deleteObj)
        {
            return ThisDb.Delete(deleteObj);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="whereExpression">条件</param>
        /// <returns></returns>
        public virtual bool Delete(Expression<Func<T, bool>> whereExpression)
        {
            return ThisDb.Delete(whereExpression);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetList()
        {
            return ThisDb.GetList();
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public virtual List<T> GetList(Expression<Func<T, bool>> whereExpression)
        {
            return ThisDb.GetList(whereExpression);
        }
        /// <summary>
        /// 获取分页
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel page)
        {
            return ThisDb.GetPageList(whereExpression, page);
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="insertObj"></param>
        /// <returns></returns>
        public virtual bool Insert(T insertObj)
        {
            return ThisDb.Insert(insertObj);
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="insertObjs"></param>
        /// <returns></returns>
        public virtual bool InsertRange(List<T>[] insertObjs)
        {
            //return ThisDb.InsertRange(insertObjs);
            return false;
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="insertObjs"></param>
        /// <returns></returns>
        public virtual bool InsertRange(T[] insertObjs)
        {
            return ThisDb.InsertRange(insertObjs);
        }
        /// <summary>
        /// 插入并返回自增长ID
        /// </summary>
        /// <param name="insertObj"></param>
        /// <returns></returns>
        public virtual int InsertReturnIdentity(T insertObj)
        {
            return ThisDb.InsertReturnIdentity(insertObj);
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public virtual bool IsAny(Expression<Func<T, bool>> whereExpression)
        {
            return ThisDb.IsAny(whereExpression);
        }
        /// <summary>
        /// 获取唯一的数据
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public virtual T Single(Expression<Func<T, bool>> whereExpression)
        {
            return ThisDb.GetSingle(whereExpression);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="updateObj"></param>
        /// <returns></returns>
        public virtual bool Update(T updateObj)
        {
            return ThisDb.Update(updateObj);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public virtual bool Update(Expression<Func<T, T>> columns, Expression<Func<T, bool>> whereExpression)
        {
            return ThisDb.Update(columns, whereExpression);
        }
    }
}
