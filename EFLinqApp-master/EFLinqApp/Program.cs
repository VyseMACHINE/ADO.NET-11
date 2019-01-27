using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLinqApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SportContext db = new SportContext())
            {
                db.Teams.Add(new Team { Name="ПСЖ"});
                db.Teams.Add(new Team { Name = "Барселона" });
                db.Teams.Add(new Team { Name = "Реал" });
                db.SaveChanges();

                db.Players.Add(new Player { FullName="Неймар", Position="Нападающий", Team = db.Teams.ToList().ElementAt(0)});
                db.Players.Add(new Player { FullName = "Гарет Бейл", Position = "Нападающий", Team = db.Teams.ToList().ElementAt(2) });
                db.Players.Add(new Player { FullName = "Лука Модрич", Position = "Полузащитник", Team = db.Teams.ToList().ElementAt(2) });
                db.Players.Add(new Player { FullName = "Лионель Месси", Position = "Нападающий", Team = db.Teams.ToList().ElementAt(1) });
                db.SaveChanges();

                while (true)
                {
                    Console.WriteLine("1-Список футболистов");
                    Console.WriteLine("2-Поиск футболиста");

                    int key;

                    if (int.TryParse(Console.ReadLine(),out key))
                    {
                        switch (key)
                        {
                            case 1:
                                foreach(Player player in db.Players.ToList())
                                {
                                    Console.WriteLine("Имя: {0} | Позиция: {1} | Команда: {2}",
                                          player.FullName, player.Position, player.Team.Name);
                                }
                                break;
                            case 2:
                                Console.WriteLine("Введите имя футболиста: ");
                                string name = Console.ReadLine();

                                var query = from player in db.Players
                                            where player.FullName == name
                                            select player;

                                Player findPlayer = query.FirstOrDefault();

                                if (findPlayer != null)
                                    Console.WriteLine("Имя: {0} | Позиция: {1} | Команда: {2}",
                                    findPlayer.FullName, findPlayer.Position, findPlayer.Team.Name);
                                else
                                {
                                    Console.WriteLine("Футболист не найден");
                                }
                                break;
                            default: break;
                        }
                    }

                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
