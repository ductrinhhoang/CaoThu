/*
 * Created by SharpDevelop.
 * User: Duc Laptop
 * Date: 4/7/2017
 * Time: 07:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TapHop
{
	class TapHop
	{
		// Đặc trưng cho mỗi tập X là mảng M[n] với M[i]=1 nếu i thuộc X và M[i]=0 nếu ngược lại.
		string str;
		TapHop(){}
		public void Nhap(){
			str= Console.ReadLine();
		}
		public static void StrToAr(string a, int []X){
			//Chuyển từ xâu sang mảng
			int i;
			for(i=0;i<6;i++) X[i]=0;
			string str= a;
			while(str.Length !=0){
				string s="";
				int n;
				for(i=0;i<str.Length;i++){
					//tìm vị trí i có dấu ","
					if(str[i]!=',') s+= str[i];
					else break;
				}
				if(s=="") {
					// str khác "" mà s="", tức là str[0]=","
					str= str.Substring(1);// bỏ dấu ",", cắt xâu từ vị trí 1 trở đi
				}
				else {
					str= str.Substring(i);//cắt xâu từ vị trí sau dấu , trở đi
					n= Convert.ToInt32(s);	// Số được lấy ra
					X[n]=1;
				}
			}
		}
		public static TapHop operator *(TapHop A, TapHop B){
			TapHop Giao= new TapHop();
			
			int []a= new int[100];
			StrToAr(A.str, a);
			
			int []b= new int[100];
			StrToAr(B.str, b);
			
			int i;
			for(i=0;i<100;i++){
				if(a[i]==1&&b[i]==1) Giao.str += i.ToString()+ ",";
			}
			Giao.str= (Giao.str).Substring(0, (Giao.str).Length-1);
			return Giao;
		}
		public static TapHop operator +(TapHop A, TapHop B){
			TapHop Hop= new TapHop();
			
			int []a= new int[100];
			StrToAr(A.str, a);
			
			int []b= new int[100];
			StrToAr(B.str, b);
			
			int i;
			for(i=0;i<100;i++){
				if(a[i]==1||b[i]==1) Hop.str += i.ToString()+ ",";
			}
			Hop.str= (Hop.str).Substring(0, (Hop.str).Length-1);
			return Hop;
		}
		public static TapHop operator -(TapHop A, TapHop B){
			TapHop Tru= new TapHop();
			
			int []a= new int[100];
			StrToAr(A.str, a);
			
			int []b= new int[100];
			StrToAr(B.str, b);
			
			int i;
			for(i=0;i<100;i++){
				if(a[i]==1&&b[i]!=1) Tru.str += i.ToString()+ ",";
			}
			Tru.str= (Tru.str).Substring(0, (Tru.str).Length-1);
			return Tru;
		}
		public static void Main(string[] args)
		{
			int N;
			Console.Write("Nhap N: ");
			N= Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Tap nen S= {0,1,...,"+N+"}");
			Console.WriteLine(" Lay 2 tap con A, B( ngan cach cac phan tu bang dau ',') tu S: ");
			
			//Ví dụ: nhập N=10; A= 1,2,5,2,3; B= 5,4,5,7,3.
			
			Console.Write("A= ");
			TapHop A= new TapHop();
			A.Nhap();
			
			Console.Write("B= ");
			TapHop B= new TapHop();
			B.Nhap();
			
			TapHop C= new TapHop();
			C.Nhap();
			
			TapHop D= new TapHop();
			D= A+B+C;
			
			TapHop E= new TapHop();
			E=A-D;
			
			Console.WriteLine("Tap giao cua A,B la: "+C.str);
			Console.WriteLine("Tap hop cua A+B+C la: "+D.str);
			Console.WriteLine("Tap tru cua A,B la: "+E.str);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			
		}
	}
}
