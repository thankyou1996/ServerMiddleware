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
           /// Desc:������CK����д��ʱ��Ψһ��ţ�����ΪUUID/GUID��Ҳ����Ϊʱ�䣨������ʱ������룩+6λ��ŵķ�ʽ����֤Ψһ�ԣ�����2018 1207 150501 999 000001
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string BJBH {get;set;}

           /// <summary>
           /// Desc:CK����д�����ݿ�ʱ�䣬��ʽyyyy-mm-dd hh24:mi:ss �����ֶ��Ͻ�������
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime XRSJ {get;set;}

           /// <summary>
           /// Desc:����ʱ�䣬����������ʱ�䣬��ʽyyyy-mm-dd hh24:mi:ss�����ֶ��Ͻ�������
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime BJSJ {get;set;}

           /// <summary>
           /// Desc:�����������룬6λ���������������룬���ֶ��Ͻ�������
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string XZQH {get;set;}

           /// <summary>
           /// Desc:�û����ƣ�CK�����豸�����ƣ�����
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string YHMC {get;set;}

           /// <summary>
           /// Desc:�û���ַ����CK�豸�İ�װ��ַ������
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string YHDZ {get;set;}

           /// <summary>
           /// Desc:��ϵ�绰���豸����λ������˵���ϵ�绰
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LXDH {get;set;}

           /// <summary>
           /// Desc:�û��˺ţ���CK�豸���
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
           /// Desc:�������ݣ���CK�豸���¼�������Ϣ���Ϊ���֣���������ϸ
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BJNR {get;set;}

           /// <summary>
           /// Desc:CK�����ĸ���������
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DWFZRXM {get;set;}

           /// <summary>
           /// Desc:��������ϵ�ֻ�
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DWFZRSJ {get;set;}

           /// <summary>
           /// Desc:��Ͻ�ɳ����Ĺ����������룬�湫������������
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GXDW {get;set;}

           /// <summary>
           /// Desc:��Ͻ�ɳ���������
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GXDWMC {get;set;}

           /// <summary>
           /// Desc:��Ͻ�ɳ�������ϵ�绰
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GXDWDH {get;set;}

           /// <summary>
           /// Desc:������ϵ�绰
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string QTLXDH {get;set;}

           /// <summary>
           /// Desc:X����
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string XZB {get;set;}

           /// <summary>
           /// Desc:Y����
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string YZB {get;set;}

           /// <summary>
           /// Desc:���ر�־��1���У�2������3���ء���
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string QXBZ {get;set;}

           /// <summary>
           /// Desc:�������ͣ�1�������ࣻ2�������ࣻ3������ʶ��4������
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BJLX {get;set;}

           /// <summary>
           /// Desc:����ʶ�������ʱ�����֤��
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SFZH {get;set;}

           /// <summary>
           /// Desc:����
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string XM {get;set;}

           /// <summary>
           /// Desc:�Ա�
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string XB {get;set;}

           /// <summary>
           /// Desc:���������־ֵĹ�����������
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SSFJ {get;set;}

           /// <summary>
           /// Desc:���������־ֵ�����
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SSFJMC {get;set;}

           /// <summary>
           /// Desc:ͼƬuri
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PIC1 {get;set;}

           /// <summary>
           /// Desc:ͼƬuri
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PIC2 {get;set;}

           /// <summary>
           /// Desc:ͼƬuri
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PIC3 {get;set;}

           /// <summary>
           /// Desc:ͼƬuri
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PIC4 {get;set;}

           /// <summary>
           /// Desc:ͼƬuri
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PIC5 {get;set;}

           /// <summary>
           /// Desc:��ƵURL
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string VID1 {get;set;}

           /// <summary>
           /// Desc:��ƵURL
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string VID2 {get;set;}

           /// <summary>
           /// Desc:��ƵURL
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string VID3 {get;set;}

           /// <summary>
           /// Desc:��ƵURL
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string VID4 {get;set;}

           /// <summary>
           /// Desc:��ƵURL
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
           /// Desc:������������
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CKCJMC {get;set;}

           /// <summary>
           /// Desc:��������ֵ��绰
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CKCJZBDH {get;set;}

           /// <summary>
           /// Desc:�����ֶ�1
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REMARK1 {get;set;}

           /// <summary>
           /// Desc:�����ֶ�2
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REMARK2 {get;set;}

           /// <summary>
           /// Desc:�����ֶ�3
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REMARK3 {get;set;}

           /// <summary>
           /// Desc:�Ѷ���־��Ĭ��Ϊ�գ���DSϵͳ��ȡʱд�룬1��ʾ�Ѿ���ȡ�������ֶ��Ͻ�������
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? YDBZ {get;set;}

           /// <summary>
           /// Desc:��ȡʱ�䣬DSϵͳ��ȡ��д�뵱ǰʱ�䣬���ֶ��Ͻ�������
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? DQSJ {get;set;}

    }
}

