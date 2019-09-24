using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace MiddlewareDS.DBModel
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("CK_ALARM")]
    public partial class CK_ALARM
    {
           public CK_ALARM(){


           }
           /// <summary>
           /// Desc:主键，CK厂商写入时的唯一编号，可以为UUID/GUID，也可以为时间（年月日时分秒毫秒）+6位序号的方式，保证唯一性，例：2018 1207 150501 999 000001
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string BJBH {get;set;}

           /// <summary>
           /// Desc:CK厂商写入数据库时间，格式yyyy-mm-dd hh24:mi:ss ，此字段上建立索引
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime XRSJ {get;set;}

           /// <summary>
           /// Desc:报警时间，报警发生的时间，格式yyyy-mm-dd hh24:mi:ss，此字段上建立索引
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime BJSJ {get;set;}

           /// <summary>
           /// Desc:行政区划代码，6位国家行政区划代码，此字段上建立索引
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string XZQH {get;set;}

           /// <summary>
           /// Desc:用户名称，CK报警设备的名称，汉字
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string YHMC {get;set;}

           /// <summary>
           /// Desc:用户地址，即CK设备的安装地址，汉字
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string YHDZ {get;set;}

           /// <summary>
           /// Desc:联系电话，设备管理单位或管理人的联系电话
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LXDH {get;set;}

           /// <summary>
           /// Desc:用户账号，即CK设备编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string YHZH {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string AFDD {get;set;}

           /// <summary>
           /// Desc:报警内容，由CK设备将事件属性信息组合为汉字，尽可能详细
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BJNR {get;set;}

           /// <summary>
           /// Desc:CK报警的负责人姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DWFZRXM {get;set;}

           /// <summary>
           /// Desc:负责人联系手机
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DWFZRSJ {get;set;}

           /// <summary>
           /// Desc:管辖派出所的公安机构代码，存公安部机构代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GXDW {get;set;}

           /// <summary>
           /// Desc:管辖派出所的名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GXDWMC {get;set;}

           /// <summary>
           /// Desc:管辖派出所的联系电话
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GXDWDH {get;set;}

           /// <summary>
           /// Desc:其他联系电话
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string QTLXDH {get;set;}

           /// <summary>
           /// Desc:X坐标
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string XZB {get;set;}

           /// <summary>
           /// Desc:Y坐标
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string YZB {get;set;}

           /// <summary>
           /// Desc:区县标志，1：市，2：区，3：县……
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string QXBZ {get;set;}

           /// <summary>
           /// Desc:报警类型，1：金融类；2：民用类；3：人脸识别；4：其他
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BJLX {get;set;}

           /// <summary>
           /// Desc:人脸识别等类型时的身份证号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SFZH {get;set;}

           /// <summary>
           /// Desc:姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string XM {get;set;}

           /// <summary>
           /// Desc:性别
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string XB {get;set;}

           /// <summary>
           /// Desc:所属公安分局的公安机构代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SSFJ {get;set;}

           /// <summary>
           /// Desc:所属公安分局的名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SSFJMC {get;set;}

           /// <summary>
           /// Desc:图片uri
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PIC1 {get;set;}

           /// <summary>
           /// Desc:图片uri
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PIC2 {get;set;}

           /// <summary>
           /// Desc:图片uri
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PIC3 {get;set;}

           /// <summary>
           /// Desc:图片uri
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PIC4 {get;set;}

           /// <summary>
           /// Desc:图片uri
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PIC5 {get;set;}

           /// <summary>
           /// Desc:视频URL
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string VID1 {get;set;}

           /// <summary>
           /// Desc:视频URL
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string VID2 {get;set;}

           /// <summary>
           /// Desc:视频URL
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string VID3 {get;set;}

           /// <summary>
           /// Desc:视频URL
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string VID4 {get;set;}

           /// <summary>
           /// Desc:视频URL
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string VID5 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CKCJBH {get;set;}

           /// <summary>
           /// Desc:技防厂家名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CKCJMC {get;set;}

           /// <summary>
           /// Desc:技防厂家值班电话
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CKCJZBDH {get;set;}

           /// <summary>
           /// Desc:保留字段1
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REMARK1 {get;set;}

           /// <summary>
           /// Desc:保留字段2
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REMARK2 {get;set;}

           /// <summary>
           /// Desc:保留字段3
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REMARK3 {get;set;}

           /// <summary>
           /// Desc:已读标志，默认为空，由DS系统读取时写入，1表示已经读取…，此字段上建立索引
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? YDBZ {get;set;}

           /// <summary>
           /// Desc:读取时间，DS系统读取后写入当前时间，此字段上建立索引
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? DQSJ {get;set;}

    }
}

