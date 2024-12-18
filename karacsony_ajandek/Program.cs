namespace karacsony_ajandek
{
    internal class Program
    {
        private static List<string> ajandekNevList = new List<string>();
        private static List<int> ajandekArList = new List<int>();
        private static List<string> ajandekKategoriaList = new List<string>();
        private static int koltsegvetes;
        static void Main(string[] args)
        {

            bool fut = true;
            Console.Write("Add meg a költségvetés értékét: ");
            koltsegvetes=Convert.ToInt32(Console.ReadLine());
            while (fut)
            {
                Console.WriteLine("\t1. Ajándék hozzáadása\n\t2. Ajándék szerkesztése\n\t3. Ajándék eltávolítása\n\t5. Ajándéklista megtekintése\n\t6. Ajándékok kategorizálása\n\t7. Kosár statisztika\n\t8. Legdr. és legolcsóbb ajándék");
                Console.Write("Kérlek add meg az opciót: ");
                int beker=Convert.ToInt32(Console.ReadLine());
                switch (beker)
                {
                    case 1:
                        AddGift();
                        break;
                    case 2:
                        EditGift();
                        break;
                    case 3:
                        RemoveGift();
                        break;
                    case 4:

                }
            }
        }
        static void AddGift()
        {
            try
            {
                Console.Write("Add meg az ajándék nevét: ");
                string bekeres = Console.ReadLine();
                if (bekeres == "")
                {
                    throw new Exception("A bemenet nem lehet üres.");
                }
                if (!ajandekNevList.Contains(bekeres))
                {
                    ajandekNevList.Add(bekeres);
                    try
                    {
                        Console.Write("Add meg az ajándék árát: ");
                        int arBeker = Convert.ToInt32(Console.ReadLine());
                        if (arBeker < 0)
                        {
                            throw new Exception("Az ár nem lehet negatív.");
                        }
                        Console.Write("Add meg a kategóriát: ");
                        string kategBeker = Console.ReadLine();
                        ajandekNevList.Add(bekeres);
                        ajandekArList.Add(arBeker);
                        ajandekKategoriaList.Add(kategBeker);
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Túlment az eszmei határokon.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Rossz bemeneti formátum.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hiba: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Az ajándék már szerepel a listában.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }
        }
        static void EditGift()
        {
            try
            {
                Console.Write("Melyik ajándék módosítása: ");
                string AjandekNev = Console.ReadLine();
                if (AjandekNev=="")
                {
                    throw new Exception("A bemenet nem lehet üres.");
                }
                if (!ajandekNevList.Contains(AjandekNev))
                {
                    throw new Exception("Nincs ilyen elem a listában.");
                }
                int termekindex = ajandekNevList.IndexOf(AjandekNev);
                Console.Write("Új név: ");
                string bekerNev = Console.ReadLine();
                Console.Write("Új ár: ");
                int bekerAr=Convert.ToInt32(Console.ReadLine());
                if (bekerAr<0)
                {
                    throw new Exception("A szám nem lehet negatív.");
                }
                Console.Write("Új kategória: ");
                string kategBeker=Console.ReadLine();
                if (kategBeker == "")
                {
                    throw new Exception("A bemenet nem lehet üres.");
                }
                ajandekNevList[termekindex] = bekerNev;
                ajandekKategoriaList[termekindex] = kategBeker;
                ajandekArList[termekindex] = bekerAr;
            }
            catch (FormatException)
            {
                Console.WriteLine("Rossz bemeneti formátum.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Túlment a határon.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }
        }
        static void RemoveGift()
        {
            try
            {
                Console.Write("Ajándék neve: ");
                string AjiBeker = Console.ReadLine();
                if (AjiBeker == "")
                {
                    throw new Exception("A bemenet nem lehet üres.");
                }
                if (!ajandekNevList.Contains(AjiBeker))
                {
                    throw new Exception("Nincs ilyen elem a listában.");
                }
                int termekindex = ajandekNevList.IndexOf(AjiBeker);
                ajandekNevList.Remove(AjiBeker);
                ajandekKategoriaList.RemoveAt(termekindex);
                ajandekArList.RemoveAt(termekindex);
                Console.WriteLine("Termék sikeresen eltávolítva.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }
        }

    }
}
