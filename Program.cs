/*
 * Created by SharpDevelop.
 * User: zsolt
 * Date: 2018. 10. 25.
 * Time: 21:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace golyonehezebb
{
	class Program
	{
		public static int Meres(List<elem> doboz)
		{
			int suly=0;
			for (int i = 0; i < doboz.Count; i++) {
				suly+=doboz[i].suly;
			}
			return suly;
		}
		public static List<elem> DobozCsinal(int darabszam)
		{
			List<elem> doboz=new List<elem>();
			
			
			for (int i = 0; i < darabszam; i++) {
				elem peldany=new elem();
				peldany.suly=1;
				peldany.index=i;
				doboz.Add(peldany);
			}
			
			return doboz;
		}
		
		public static void Keres(List<elem> doboz)
		{
			List<elem> dobozelsoharmada=new List<elem>();
			List<elem> dobozmasodikharmada=new List<elem>();
			List<elem> dobozharmadikharmada=new List<elem>();
			int index=0;
			int maradek=doboz.Count-doboz.Count/3-doboz.Count/3;
			Console.WriteLine("maradek:{0}",maradek);
			for (int i = 0; i < doboz.Count/3; i++) {
				elem peldany=new elem();
				peldany.suly=doboz[index].suly;
				peldany.index=doboz[index].index;
				dobozelsoharmada.Add(peldany);
				index++;
			}
			for (int i = 0; i < doboz.Count/3; i++) {
				elem peldany=new elem();
				peldany.suly=doboz[index].suly;
				peldany.index=doboz[index].index;
				dobozmasodikharmada.Add(peldany);
				index++;
			}
			for (int i = 0; i < maradek; i++) {
				elem peldany=new elem();
				peldany.suly=doboz[index].suly;
				peldany.index=doboz[index].index;
				dobozharmadikharmada.Add(peldany);
				index++;
			}
			Console.WriteLine();
			Console.WriteLine(Meres(dobozelsoharmada));
			Console.WriteLine(Meres(dobozmasodikharmada));
			Console.WriteLine(Meres(dobozharmadikharmada));
			if (Meres(doboz)<6) {
				foreach (var i in doboz) {
					Console.WriteLine("golyó indexe:"+i.index+" golyó súlya:"+i.suly);
				}
			} else {
				if (Meres(dobozelsoharmada)>Meres(dobozmasodikharmada)) {
					Keres(dobozelsoharmada);
				}
				if (Meres(dobozelsoharmada)<Meres(dobozmasodikharmada)) {
					Keres(dobozmasodikharmada);
				}
				if (Meres(dobozelsoharmada)==Meres(dobozmasodikharmada)) {
					Keres(dobozharmadikharmada);
				}
			}
			
			
		}
		
		public class elem
		{
			public int suly { get; set; }
			public int index { get; set; }
		}
		
		public static void Main(string[] args)
		{
			int darabszam=50000;
			List<elem> doboz;
			doboz=DobozCsinal(darabszam);
			Random vsz=new Random();
			doboz[vsz.Next(darabszam)].suly=2;
			/*
			foreach (var i in doboz) {
				Console.WriteLine(i.index+","+i.suly);
			}
			*/
			Console.WriteLine(Meres(doboz));
			Keres(doboz);
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			Console.ReadLine();
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
		}
	}
}