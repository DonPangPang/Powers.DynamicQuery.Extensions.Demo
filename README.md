# Powers.DynamicQuery.Extensions.Demo
 DynamicQuery

## Examples
```csharp
public class User
{
	public string Name{get; set;}
	public int Age{get; set;}
	public DateTime Brith{get; set;}
	public string Address{get; set;}
}
```

HTTP Get(查找所有用户,按照名字正序以及年龄倒序排序, 不包含Jack的名字, 出生日期小于2000/01/01, 并且居住地址以china开头):
https://0.0.0.0:8080/getUser?orderby=name,-age&name=Jack&birth_lessthan=2000-01-01&address=china&age=99