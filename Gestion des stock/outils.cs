using Bunifu.UI.WinForms;
using System;

namespace Gestion_des_stock
{
    class outils
    {
        public static void autodate(BunifuDatePicker bunifuDatePicker1, BunifuDatePicker bunifuDatePicker2)
        {
            int mounth = bunifuDatePicker1.Value.Month;
            try
            {
                switch (mounth)
                {
                    case 1:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);
                        break;
                    case 2:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 28);

                        break;
                    case 3:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);
                        break;
                    case 4:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 30);
                        break;
                    case 5:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);
                        break;
                    case 6:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 30);
                        break;
                    case 7:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);
                        break;
                    case 8:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);

                        break;
                    case 9:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 30);
                        break;
                    case 10:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);
                        break;
                    case 11:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 30);
                        break;
                    case 12:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);
                        break;
                }


            }
#pragma warning disable CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            catch (Exception x)
#pragma warning restore CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            {
                bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 28);
            }
        }

        public static void autodate2(BunifuDatePicker bunifuDatePicker1, BunifuDatePicker bunifuDatePicker2)
        {
            int mounth = DateTime.Now.Month;

            bunifuDatePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            try
            {
                switch (mounth)
                {
                    case 1:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);
                        break;
                    case 2:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 28);

                        break;
                    case 3:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);
                        break;
                    case 4:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 30);
                        break;
                    case 5:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);
                        break;
                    case 6:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 30);
                        break;
                    case 7:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);
                        break;
                    case 8:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);

                        break;
                    case 9:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 30);
                        break;
                    case 10:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);
                        break;
                    case 11:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 30);
                        break;
                    case 12:
                        bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 31);
                        break;
                }


            }
#pragma warning disable CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            catch (Exception x)
#pragma warning restore CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            {
                bunifuDatePicker2.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, 28);
            }
        }
    }
}
