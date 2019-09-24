using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MiddlewareDS.DBService
{
    public interface IRepository<T> where T : class, new()
    {


        #region 数据查询


        /********************
         * 1.排序方法
         ********************/
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        List<T> GetList();

        /// <summary>
        /// 获取数据_带参数
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        List<T> GetList(Expression<Func<T, bool>> whereExpression);

        /// <summary>
        /// 分页查询_带参数
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="page"></param>
        /// <returns></returns>

        List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel page);
        

        /// <summary>
        /// 返回序列的唯一元素；查询单条没有数据返回NULL。
        /// </summary>
        /// <param name="whereExpression">用于测试每个元素是否满足条件的函数</param>
        /// <returns>单个元素</returns>
        T Single(Expression<Func<T, bool>> whereExpression);

        /// <summary>
        /// 返回指定序列中满足条件的元素数量
        /// </summary>
        /// <param name="whereExpression">用于测试每个元素是否满足条件的函数</param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> whereExpression);


        /// <summary>
        /// 对象是否存在
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        bool IsAny(Expression<Func<T, bool>> whereExpression);

        #endregion

        #region 数据操作

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="insertObj"></param>
        /// <returns></returns>
        bool Insert(T insertObj);

        /// <summary>
        /// 插入_返回ID
        /// </summary>
        /// <param name="insertObj"></param>
        /// <returns></returns>
        int InsertReturnIdentity(T insertObj);

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="insertObjs"></param>
        /// <returns></returns>
        bool InsertRange(List<T>[] insertObjs);

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="insertObjs"></param>
        /// <returns></returns>
        bool InsertRange(T[] insertObjs);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="deleteObj"></param>
        /// <returns></returns>
        bool Delete(T deleteObj);


        /// <summary>
        /// 删除_带参数
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        bool Delete(Expression<Func<T, bool>> whereExpression);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="updateObj"></param>
        /// <returns></returns>
        bool Update(T updateObj);

        /// <summary>
        /// 更新_带参数
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        bool Update(Expression<Func<T, T>> columns, Expression<Func<T, bool>> whereExpression);



        #endregion

    }
}
