﻿/*
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
			//megméri a doboz súlyát
			int suly=0;
			for (int i = 0; i < doboz.Count; i++) {
				suly+=doboz[i].suly;
			}
			return suly;
		}
		public static List<elem> DobozCsinal(int darabszam)
		{
			//létrehoz egy dobozt, benne x egyforma golyóval
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
			List<elem> elsodoboz=new List<elem>();
			List<elem> masodikdoboz=new List<elem>();
			List<elem> harmadikdoboz=new List<elem>();
			int index=0;
			int maradek=doboz.Count-doboz.Count/3-doboz.Count/3;
			Console.WriteLine("A nem vizsgált dobozba került ennyi golyó:{0}",maradek);
			//két dobozba belerakok ugyanannyit
			for (int i = 0; i < doboz.Count/3; i++) {
				elem peldany=new elem();
				peldany.suly=doboz[index].suly;
				peldany.index=doboz[index].index;
				elsodoboz.Add(peldany);
				index++;
			}
			for (int i = 0; i < doboz.Count/3; i++) {
				elem peldany=new elem();
				peldany.suly=doboz[index].suly;
				peldany.index=doboz[index].index;
				masodikdoboz.Add(peldany);
				index++;
			}
			//egy harmadik dobozba megy a maradék
			for (int i = 0; i < maradek; i++) {
				elem peldany=new elem();
				peldany.suly=doboz[index].suly;
				peldany.index=doboz[index].index;
				harmadikdoboz.Add(peldany);
				index++;
			}
			Console.WriteLine("\nEzt elvileg nem láthatom, csak mégis, hogy valami történjen futás közben:");
			Console.WriteLine("{0}\tennyi golyó van benne:{1}",Meres(elsodoboz),elsodoboz.Count);
			Console.WriteLine("{0}\tennyi golyó van benne:{1}",Meres(masodikdoboz),masodikdoboz.Count);
			Console.WriteLine("{0}\tennyi golyó van benne:{1}",Meres(harmadikdoboz),harmadikdoboz.Count);
			/*
			 * Kétkarú mérlegem van
			 * Ha az első két dobozom súlya megegyezik, biztos, hogy a harmadik dobozban van a nehezebb golyó
			 * Ha az első dobozban van a nehezebb golyó, arra billen a kétkarú mérlegem
			 * Ha a második dobozban, akkor abban
			 * Ráeresztem ezt a függvényt a kiválasztott dobozra
			 * 
			 * 
			 * Itt jönne a lényeg, az eszképszekvencia, meg a rekurzió, de ezt még tökéletesíteni kell, holnap... 
			 * Megvan a hiba, ha az első dobozban már csak két golyó van, és azok közül az egyik nehezebb, nem tudja a harmadát belerakni egy dobozba
			 * és így mindig a harmadik dobozba kerül nehezebb golyó->végtelen ciklus->stack overflow
			 * Megoldás: le kéne kezelni, hogy az első két dobozba kerüljön golyó, hogy a kétkarú mérlegemmel el tudjam dönteni, melyik a hunyó
			 * És akkor már szépen is meg lehetne oldani a feladatot
			 */
			if (doboz.Count<3) {
				foreach (var i in doboz) {
					Console.WriteLine("golyó indexe:"+i.index+" golyó súlya:"+i.suly);
				}
			} else {
				if (Meres(elsodoboz)==Meres(masodikdoboz)) {
					Keres(harmadikdoboz);
				}
				else if (Meres(elsodoboz)<Meres(masodikdoboz)) {
					Keres(masodikdoboz);
				}
				else {
					Keres(elsodoboz);
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
			doboz[vsz.Next(darabszam)].suly=2; //egy golyó-t kicserélek kétszer olyan nehézre
			/*
			 * Egy dobozban van x darab golyóm, abból az egyik nehezebb, mint a többi
			 * Van egy két karú mérlegem
			*/
			Console.WriteLine(Meres(doboz));
			Keres(doboz);
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			Console.ReadLine();
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
		}
	}
}