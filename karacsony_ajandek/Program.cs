namespace karacsony_ajandek
{
    internal class Program
    {
        private static List<string> ajandekNevList = new List<string>();
        private static List<int> ajandekArList = new List<int>();
        private static List<string> ajandekKategoriaList = new List<string>();
        private static int koltsegvetes;
        private static int elkoltott;
        static void Main(string[] args)
        {
            try
            {
                bool fut = true;
                Console.Write("Add meg a költségvetés értékét: ");
                koltsegvetes = Convert.ToInt32(Console.ReadLine());
                if (koltsegvetes<0)
                {
                    throw new Exception("A szám nem lehet negatív.");
                }
                while (fut)
                {
                    try
                    {
                        Console.WriteLine("\t1. Ajándék hozzáadása\n\t2. Ajándék szerkesztése\n\t3. Ajándék eltávolítása\n\t5. Ajándéklista megtekintése\n\t5. Ajándékok kategorizálása\n\t6. Kosár statisztika\n\t7. Legdr. és legolcsóbb ajándék");
                        Console.Write("Kérlek add meg az opciót: ");
                        int beker = Convert.ToInt32(Console.ReadLine());
                        if (beker < 0)
                        {
                            throw new Exception("A szám nem lehet negatív.");
                        }
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
                                ViewGifts();
                                break;
                            case 5:
                                CategorizeGifts();
                                break;
                            case 6:
                                ViewStatistics();
                                break;
                            case 7:
                                MostExpMostCheap();
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("A bemenet formátuma hibás.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Túlment az eszmei határokon.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hiba: {ex.Message}");
                    }

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("A bemenet formátuma hibás.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Túlment az eszmei határokon.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }

        }
        static void AddGift()
        {
            try
            {
                if (ajandekArList.Sum() >= koltsegvetes)
                {
                    throw new Exception("Nem adható hozzá több ajándék, mivel átlépte a költségvetést.");
                }
                Console.Write("Add meg az ajándék nevét: ");
                string bekeres = Console.ReadLine();
                if (bekeres == "")
                {
                    throw new Exception("A bemenet nem lehet üres.");
                }
                if (!ajandekNevList.Contains(bekeres))
                {
                    try
                    {
                        Console.Write("Add meg az ajándék árát: ");
                        int arBeker = Convert.ToInt32(Console.ReadLine());
                        if (ajandekArList.Sum() >= 0.9m * koltsegvetes)
                        {
                            Console.WriteLine("Figyelem: Az elköltött összeg elérte a költségvetés 90%-át!");
                        }
                        if (ajandekArList.Sum()>koltsegvetes)
                        {
                            throw new Exception("Nem adható hozzá több ajándék, mivel átlépte a költségvetést.");
                        }
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
                if (ajandekArList.Sum() >= 0.9m * koltsegvetes)
                {
                    Console.WriteLine("Figyelem: Az elköltött összeg elérte a költségvetés 90%-át!");
                }
                if (ajandekArList.Sum() >= koltsegvetes)
                {
                    throw new Exception("Nem adható hozzá több ajándék, mivel átlépte a költségvetést.");
                }
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
        static void ViewGifts()
        {
            if (ajandekNevList.Count == 0)
            {
                Console.WriteLine("Nincsenek ajándékok a listában.");
                return;
            }

            Console.WriteLine("Ajándékok:");
            for (int i = 0; i < ajandekNevList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ajandekNevList[i]}");
            }
        }
        static void ViewStatistics()
        {
            if (ajandekNevList.Count == 0)
            {
                Console.WriteLine("Nincsenek ajándékok a listában.");
                return;
            }
            Console.WriteLine($"Ajándékok száma: {ajandekNevList.Count}");
            Console.WriteLine($"Összes elköltött pénz: {ajandekArList.Sum()} Ft");
        }
        static void MostExpMostCheap()
        {
            int legdragabb = 0;
            int legolcsobb = ajandekArList[0];
            int termekindex_legdragabb = 0;
            int termekindex_legolcsobb = 0;
            for (int i = 0; i < ajandekArList.Count; i++)
            {
                if (ajandekArList[i]>legdragabb)
                {
                    legdragabb=ajandekArList[i];
                    termekindex_legdragabb=ajandekArList.IndexOf(legdragabb);
                }
            }
            for (int i = 0; i < ajandekArList.Count; i++)
            {
                if (ajandekArList[i]<legolcsobb)
                {
                    legolcsobb=ajandekArList[i];
                    termekindex_legolcsobb = ajandekArList.IndexOf(legolcsobb);
                }
            }
            Console.WriteLine($"Legdrágább ajándék: {ajandekNevList[termekindex_legdragabb]}, {legdragabb} Ft");
            Console.WriteLine($"Legolcsóbb ajándék: {ajandekNevList[termekindex_legolcsobb]}, {legolcsobb} Ft");
        }
        static void CategorizeGifts()
        {
            if (ajandekNevList.Count == 0)
            {
                Console.WriteLine("Nincsenek ajándékok a listában.");
                return;
            }

            var KategorizaltAjandekok = new Dictionary<string, List<string>>();

            for (int i = 0; i < ajandekNevList.Count; i++)
            {
                string kategoria = ajandekKategoriaList[i];
                string ajandek = ajandekNevList[i];

                if (!KategorizaltAjandekok.ContainsKey(kategoria))
                {
                    KategorizaltAjandekok[kategoria] = new List<string>();
                }

                KategorizaltAjandekok[kategoria].Add(ajandek);
            }

            Console.WriteLine("Kategóriák szerint:");
            foreach (var kategoria in KategorizaltAjandekok)
            {
                Console.WriteLine($"{kategoria.Key}: {string.Join(", ", kategoria.Value)}");
            }
        }
    }
}
