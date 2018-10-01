/*
 * Created by SharpDevelop.
 * User: zsolt
 * Date: 2018. 10. 01.
 * Time: 10:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace karszam
{
	class Program
	{
		public static void Main(string[] args)
		{
			String szoveg=Console.ReadLine();
			//szoveg="Ez itt a vizsgálandó szöveg, ez esetben adott";
			Random rand=new Random();
			int hossz=szoveg.Length/3;
			if (hossz>24) {
				hossz=24;
			}
			char[] keresendok=new char[hossz];
			for (int i = 0; i < keresendok.Length; i++) {
				keresendok[i]=Convert.ToChar(rand.Next(26)+97); //csak kisbetűk, lehetne 65-90 és 97-122, és nézhetné az ékezetes betűket is, de indulnom kell órára
			}
			int[] darabszam=new int[hossz];
			for (int i = 0; i < darabszam.Length; i++) {
				darabszam[i]=0;
			}
			for (int i = 0; i < szoveg.Length; i++) {
				for (int j = 0; j < keresendok.Length; j++) {
					if (szoveg[i]==keresendok[j]) {
						darabszam[j]++;
					}
				}
			}
			Console.WriteLine(szoveg);
			for (int i = 0; i < keresendok.Length; i++) {
				Console.WriteLine("{0}:{1}",keresendok[i],darabszam[i]);
			}
			for (int i = 0; i < szoveg.Length; i++) {
				for (int j = 0; j < keresendok.Length; j++) {
					if (szoveg[i]==keresendok[j]) {
						Console.ForegroundColor=ConsoleColor.Blue;
					}
				}
				Console.Write(szoveg[i]);
				Console.ForegroundColor=ConsoleColor.White;
			}
			Console.WriteLine();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}