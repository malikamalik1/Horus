﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Horus.Generator.ReferenceData
{
    public static class Products
    {
        private static Random r = new Random();
        private static Dictionary<int, Product> products = new Dictionary<int, Product>();
        private static char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static string[] elements = "Hydrogen (H) 1.007, Helium (He) 4.002, Lithium (Li) 6.941, Beryllium (Be) 9.012, Boron (B) 10.811, Carbon (C) 12.011, Nitrogen (N) 14.007, Oxygen (O) 15.999, Fluorine (F) 18.998, Neon (Ne) 20.18, Sodium (Na) 22.99, Magnesium (Mg) 24.305, Aluminum (Al) 26.982, Silicon (Si) 28.086, Phosphorus (P) 30.974, Sulfur (S) 32.065, Chlorine (Cl) 35.453, Argon (Ar) 39.948, Potassium (K) 39.098, Calcium (Ca) 40.078, Scandium (Sc) 44.956, Titanium (Ti) 47.867, Vanadium (V) 50.942, Chromium (Cr) 51.996, Manganese (Mn) 54.938, Iron (Fe) 55.845, Cobalt (Co) 58.933, Nickel (Ni) 58.693, Copper (Cu) 63.546, Zinc (Zn) 65.38, Gallium (Ga) 69.723, Germanium (Ge) 72.64, Arsenic (As) 74.922, Selenium (Se) 78.96, Bromine (Br) 79.904, Krypton (Kr) 83.798, Rubidium (Rb) 85.468, Strontium (Sr) 87.62, Yttrium (Y) 88.906, Zirconium (Zr) 91.224, Niobium (Nb) 92.906, Molybdenum (Mo) 95.96, Technetium (Tc) 98, Ruthenium (Ru) 101.07, Rhodium (Rh) 102.906, Palladium (Pd) 106.42, Silver (Ag) 107.868, Cadmium (Cd) 112.411, Indium (In) 114.818, Tin (Sn) 118.71, Antimony (Sb) 121.76, Tellurium (Te) 127.6, Iodine (I) 126.904, Xenon (Xe) 131.293, Cesium (Cs) 132.905, Barium (Ba) 137.327, Lanthanum (La) 138.905, Cerium (Ce) 140.116, Praseodymium (Pr) 140.908, Neodymium (Nd) 144.242, Promethium (Pm) 145, Samarium (Sm) 150.36, Europium (Eu) 151.964, Gadolinium (Gd) 157.25, Terbium (Tb) 158.925, Dysprosium (Dy) 162.5, Holmium (Ho) 164.93, Erbium (Er) 167.259, Thulium (Tm) 168.934, Ytterbium (Yb) 173.054, Lutetium (Lu) 174.967, Hafnium (Hf) 178.49, Tantalum (Ta) 180.948, Wolfram (W) 183.84, Rhenium (Re) 186.207, Osmium (Os) 190.23, Iridium (Ir) 192.217, Platinum (Pt) 195.084, Gold (Au) 196.967, Mercury (Hg) 200.59, Thallium (Tl) 204.383, Lead (Pb) 207.2, Bismuth (Bi) 208.98, Polonium (Po) 210, Astatine (At) 210, Radon (Rn) 222, Francium (Fr) 223, Radium (Ra) 226, Actinium (Ac) 227, Thorium (Th) 232.038, Protactinium (Pa) 231.036, Uranium (U) 238.029, Neptunium (Np) 237, Plutonium (Pu) 244, Americium (Am) 243, Curium (Cm) 247, Berkelium (Bk) 247, Californium (Cf) 251, Einsteinium (Es) 252, Fermium (Fm) 257, Mendelevium (Md) 258, Nobelium (No) 259, Lawrencium (Lr) 262, Rutherfordium (Rf) 261, Dubnium (Db) 262, Seaborgium (Sg) 266, Bohrium (Bh) 264, Hassium (Hs) 267, Meitnerium (Mt) 268, Darmstadtium  (Ds ) 271, Roentgenium  (Rg ) 272, Copernicium  (Cn ) 285, Nihonium (Nh) 284, Flerovium (Fl) 289, Moscovium (Mc) 288, Livermorium (Lv) 292, Tennessine (Ts) 295, Oganesson (Og) 294".Split(',');
        
        static Products()
        {
            int i = 0;
            foreach (var element in elements)
            {
                i++;
                Product p = new Product();
                p.Taxable = false;
                p.Price = r.NextDouble() * 100 * r.NextDouble();
                p.Discount = r.Next(0, 8);
                if (r.Next(1, 10) > 5) p.Taxable = true;
                string prefix = "";
                for (int j = 0; j < 4; j++)
                {
                    int index = r.Next(0, letters.Length - 1);
                    prefix += letters[index];
                }
                p.Isbn = $"{prefix}-{r.Next(10000, 99999)}";
                p.Title = element;
                products.Add(i, p);
            }
            
           
        }

       

        public static Product GetRandomProduct()
        {
            
            int i = r.Next(1, products.Count);
            return products[i];
        }
    }

    public class Product
    {
       
        public string Title { get; set; }
        public string Isbn { get; set; }

        public double Discount { get; set; }
        public double Price { get; set; }
        public bool Taxable { get; set; }

    }
}