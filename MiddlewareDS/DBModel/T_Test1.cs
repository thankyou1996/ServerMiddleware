using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace MiddlewareDS.DBModel
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("T_Test1")]
    public partial class T_Test1
    {
           public T_Test1(){


           }
           /// <summary>
           /// Desc:������ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ID {get;set;}

           /// <summary>
           /// Desc:ת������
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string NameT {get;set;}

    }
}

