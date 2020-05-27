using Dtol.Attribute;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dto.Service.Extension
{
    public static  class ListExtensions
    {

        public static List<T> ValideListDayAndNight<T>(this List<T> st,List<Student_DayandNight_Info> sheet ) where T : new()
        {
            Type type = typeof(ExcelAttribute);
            Func<CustomAttributeData, bool> columnOnly = y => y.AttributeType == typeof(ExcelAttribute);
            var columns = typeof(T)//反射实体类
                                   //获取实体类的所有属性，他返回的一个属性数组，之后通过linq查询这个数组，因为这个数组继承自枚举类，所以支持linq
                .GetProperties()
                //根据条件来查询属性，（x => x.CustomAttributes.Any(columnOnly)）获取存在属性的特性
                .Where(x => x.CustomAttributes.Any(columnOnly))
                .Select(p => new
                {
                    Property = p,
                    Column = p.GetCustomAttributes<ExcelAttribute>().First().ColumnName
                }).ToList();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("您导入的数据存在如下错误:\n");
            sheet.Select(row =>  {

                columns.ForEach(col =>
                {

                    var item = col.Property.GetValue(col.Property.Name);
                    if (item == null)
                    {
                        stringBuilder.Append("数据错误:导入表格第 "+ row + " 行 ,"+ col.Column.ToString() + "列的值是'空值'请仔细核对;\n");
                        return;
                    }
                    if (col.Column.Equals("身份证号"))//这个需要验证身份证号
                    {

                        stringBuilder.Append("数据错误:导入表格第 " + row + " 行 ," + col.Column.ToString() + "列 '身份证号不存在于基础数据中' 请仔细核对;\n");
                    }
                    if (col.Column.Equals("年级（需与提供的年级完全一致）"))//这个需要验证身份证号
                    {

                        stringBuilder.Append("数据错误:导入表格第 " + row + " 行 ," + col.Column.ToString() + "列的值'年级名称不正确'请仔细核对;\n");
                    }
                    if (col.Column.Equals("班级（需与提供的班级完全一致）"))//这个需要验证身份证号
                    {

                        stringBuilder.Append("数据错误:导入表格第 " + row + " 行 ," + col.Column.ToString() + "列的值'班级名称不正确'是空值请仔细核对;\n");
                    }
                 
                    if (col.Column.Equals("体温"))//这个需要验证身份证号
                    {

                        stringBuilder.Append("数据错误:导入表格第 " + row + " 行 ," + col.Column.ToString() + "列的值是'体温格式不正确'空值请仔细核对;\n");
                    }
                    if (col.Column.Equals("应填报时间"))//这个需要验证身份证号
                    {

                        stringBuilder.Append("数据错误:导入表格第 " + row + " 行 ," + col.Column.ToString() + "列的值'导入的填报时间不能大于当前时间'空值请仔细核对;\n");
                    }
                });
                return "a";
            
            });



            return null;
       

          

        }
    }
}
