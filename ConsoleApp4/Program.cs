class Program
{
    static void Main()
    {

        Console.WriteLine("Введите ваше имя: ");
        string name = Console.ReadLine();
        Console.WriteLine("Введите ваш возраст: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Viewer viewer = new(name: name, age: age, balance: 100, booking: []);

        while (true)
        { 
        Console.Clear();
        Console.WriteLine("Выберите действие: ");
        Console.WriteLine("1. Показать фильмы");
        Console.WriteLine("2. Показать сеансы");
        Console.WriteLine("3. Купить билет");
        Console.WriteLine("4. Мои бронирования");
        Console.WriteLine("5. Найти бронирование");
        Console.WriteLine("6. Статистика");
        Console.WriteLine("7. Проверить полиморфизм билетов");
        Console.WriteLine("8. Выйти");

        List<Movie> movies = new List<Movie>
            {
                new("Interstellar", "Sci-Fi", 169, 12),
                new("The Matrix", "Sci-Fi", 136, 16),
                new("The Lion King", "Animation", 88, 6),
                new("Home Alone", "Comedy", 103, 6)
            };

        string choice = Console.ReadLine();
        int action;

            if (int.TryParse(choice, out action))
            {
                switch (action)
                {
                    case 1:
                        foreach (var movie in movies)
                        {
                            movie.MovieInfo();
                            Console.WriteLine("-----------------");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Сеансы");
                        break;
                    case 3:
                        Console.WriteLine("Билеты");
                        break;
                    case 4:
                        Console.WriteLine("Бронирования");
                        break;
                    case 5:
                        Console.WriteLine("Найти бронирование");
                        break;
                    case 6:
                        Console.WriteLine("Статистика");
                        break;
                    case 7:
                        Console.WriteLine("Проверка билетов");
                        break;
                    case 8:
                        Console.WriteLine("Выйти");
                        return;
                }
                Console.ReadKey();
            }
        }
    }
}

class Movie(string title, string genre, int duration, int ageLimit)
{
    public string Title = title;
    public string genre = genre;
    public int duration = duration;
    public int ageLimit = ageLimit;

    public void MovieInfo()
    {
        Console.WriteLine($"Фильм: {this.Title}");
        Console.WriteLine($"Жанр: {this.genre}");
        Console.WriteLine($"Продолжительность: {this.duration} минут");
        Console.WriteLine($"Возрастное ограничение: от {this.ageLimit} лет");
    }
}

class Viewer(string name, int age, int balance, List<string> booking)
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public int Balance { get; private set; } = balance;
    public List<string> Booking { get; } = booking;

    public List<string> booking = [];
    public bool TryPay(int amount)
    {
        if (amount > Balance)
            return false;

        Balance -= amount;
        Console.WriteLine($"Оплата прошла успешно! Ваш новый баланс: {Balance}");
        return true;
    }
}
