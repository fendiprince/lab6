﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WpfApp1
{
        [TestFixture]
        class tasteCase{

        [TestCase]
        public void isBroken() {
            CGenerator gen = new CGenerator();

            gen.field = new int[,] { 
                { -1, -1,  0,  0,  0 },
                { -1, -1, -1, -1,  0 },
                {  0, -1, -1, -1,  0 },
                {  0, -1, -1, -1,  0 } };

            Assert.AreEqual(true, gen.isBroken(0, 0));
            Assert.AreEqual(false, gen.isBroken(1, 0));
            Assert.AreEqual(true, gen.isBroken(2, 2));

            var ex = Assert.Throws<ArgumentException>(() => gen.isBroken(-1, 15));
            Assert.That(ex.Message, Is.EqualTo("ВЫХОД ЗА ГРАНИЦУ"));
           
        }

        [TestCase]
        public void plantMines()
        {
            CGenerator gen = new CGenerator();

            gen.field = new int[5,5] ;

            gen.plantMines(10);

            int mines = 0;

            for (int i = 0; i < gen.field.GetLength(0); i++)
                for (int j = 0; j < gen.field.GetLength(1); j++)
                    if (gen.field[i, j] == -1)
                        mines++;

            Assert.AreEqual(10, mines);

            bool isBroken = false;

            for (int i = 0; i < gen.field.GetLength(0); i++)
                for (int j = 0; j < gen.field.GetLength(1); j++)
                    if (gen.isBroken(i, j) == true)
                        isBroken = true;

            Assert.AreEqual(false, isBroken);


            //exception на количество мин больше максимума и меньше минимума

        }
    }
}